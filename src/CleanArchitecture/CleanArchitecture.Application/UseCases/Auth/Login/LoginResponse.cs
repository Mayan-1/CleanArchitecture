namespace CleanArchitecture.Application.UseCases.Auth.Login;

public sealed record LoginResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}
