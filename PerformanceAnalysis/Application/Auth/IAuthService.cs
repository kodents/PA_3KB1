using PerformanceAnalysis.Application.Auth.DTOs;

namespace PerformanceAnalysis.Application.Auth;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken ct = default);
    Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct = default);
    Task<AuthResponse> LoginWithCookieAsync(LoginWithCookieRequest request, CancellationToken ct = default);
    Task LogoutAsync(CancellationToken ct = default);
}
