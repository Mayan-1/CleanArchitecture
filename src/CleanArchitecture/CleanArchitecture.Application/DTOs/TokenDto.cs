namespace CleanArchitecture.Application.DTOs;

public sealed record TokenDto
{
    public string AcessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
