using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PerformanceAnalysis.Application.Auth.DTOs;
using PerformanceAnalysis.Domain.Auth;
using PerformanceAnalysis.Infrastructure.Auth;

namespace PerformanceAnalysis.Application.Auth;

public class AuthService : IAuthService
{
    private readonly AuthDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(AuthDbContext dbContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken ct = default)
    {
        // Проверка существования пользователя
        var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Login == request.Login || u.Email == request.Email, ct);

        if (existingUser != null)
        {
            throw new InvalidOperationException("Пользователь с таким логином или email уже существует");
        }

        // Проверка существования группы
        var group = await _dbContext.Groups.FindAsync(new object[] { request.GroupId }, ct);
        if (group == null)
        {
            throw new InvalidOperationException("Группа не найдена");
        }

        // Создание пользователя
        var user = new User
        {
            Login = request.Login,
            Email = request.Email,
            Passwordhash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Firstname = request.FirstName,
            Middlename = request.MiddleName,
            Lastname = request.LastName,
            Role = "Student",
            Createdat = DateTime.UtcNow
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(ct);

        // Создание студента
        var student = new Student
        {
            Userid = user.Id,
            Phone = request.Phone ?? string.Empty,
            Vkprofilelink = request.VkProfileLink ?? string.Empty
        };

        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync(ct);

        // Привязка к группе через many-to-many
        student.Groups.Add(group);
        await _dbContext.SaveChangesAsync(ct);

        // Генерация токена
        var accessToken = GenerateAccessToken(user);
        var accessTokenExpiresAt = DateTime.UtcNow.AddMinutes(
            _configuration.GetValue<int>("JwtSettings:AccessTokenExpirationMinutes"));

        return new AuthResponse
        {
            UserId = user.Id,
            Login = user.Login,
            Email = user.Email,
            FirstName = user.Firstname,
            LastName = user.Lastname,
            Role = user.Role,
            AccessToken = accessToken,
            AccessTokenExpiresAt = accessTokenExpiresAt
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var user = await _dbContext.Users
            .Include(u => u.Student)
            .FirstOrDefaultAsync(u => 
                (u.Login == request.LoginOrEmail || u.Email == request.LoginOrEmail), ct);

        if (user == null)
        {
            throw new InvalidOperationException("Неверный лин или пароль");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Passwordhash))
        {
            throw new InvalidOperationException("Неверный логин или пароль");
        }

        var accessToken = GenerateAccessToken(user);
        var accessTokenExpiresAt = DateTime.UtcNow.AddMinutes(
            _configuration.GetValue<int>("JwtSettings:AccessTokenExpirationMinutes"));

        return new AuthResponse
        {
            UserId = user.Id,
            Login = user.Login,
            Email = user.Email,
            FirstName = user.Firstname,
            LastName = user.Lastname,
            Role = user.Role,
            AccessToken = accessToken,
            AccessTokenExpiresAt = accessTokenExpiresAt
        };
    }

    private string GenerateAccessToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

        if (user.Role == "Student" && user.Student != null)
        {
            claims.Add(new Claim("StudentId", user.Student.Id.ToString()));
        }



        var expirationMinutes = jwtSettings.GetValue<int>("AccessTokenExpirationMinutes");

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<AuthResponse> LoginWithCookieAsync(LoginWithCookieRequest request, CancellationToken ct = default)
    {
        var user = await _dbContext.Users
            .Include(u => u.Student)
            .FirstOrDefaultAsync(u =>
                (u.Login == request.LoginOrEmail || u.Email == request.LoginOrEmail), ct);

        if (user == null)
        {
            throw new InvalidOperationException("Неверный лин или пароль");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Passwordhash))
        {
            throw new InvalidOperationException("Неверный логин или пароль");
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

        if (user.Role == "Student" && user.Student != null)
        {
            claims.Add(new Claim("StudentId", user.Student.Id.ToString()));
        }

        var claimsIdentity = new ClaimsIdentity(
            claims,
            "Cookies");

        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext == null)
            throw new InvalidOperationException("HttpContext недоступен.");

        var expiresAt = DateTimeOffset.UtcNow.AddDays(request.RememberMe ? 30 : 8);
        
        var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
        {
            ExpiresUtc = expiresAt,
            IsPersistent = request.RememberMe
        };

        await httpContext.SignInAsync(
            "Cookies",
            new ClaimsPrincipal(claimsIdentity),
            authProperties
            );

        return new AuthResponse
        {
            UserId = user.Id,
            Login = user.Login,
            Email = user.Email,
            FirstName = user.Firstname,
            LastName = user.Lastname,
            Role = user.Role,
            UseCookies = true
        };
    }

    public async Task LogoutAsync(CancellationToken ct = default)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext != null)
        {
            await httpContext.SignOutAsync("Cookies");
        }            
    }
}
