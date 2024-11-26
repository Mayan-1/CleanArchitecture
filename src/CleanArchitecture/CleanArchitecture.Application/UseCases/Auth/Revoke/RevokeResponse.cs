namespace CleanArchitecture.Application.UseCases.Auth.Revoke;

public sealed record RevokeResponse
{
    public string Message { get; set; } = string.Empty;
}
