namespace PerformanceAnalysis.Application.Auth.DTOs;

public class RegisterRequest
{
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? VkProfileLink { get; set; }
    public int GroupId { get; set; }
}
