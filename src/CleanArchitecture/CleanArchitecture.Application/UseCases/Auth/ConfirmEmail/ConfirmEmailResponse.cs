namespace CleanArchitecture.Application.UseCases.Auth.ConfirmEmail;

public sealed record ConfirmEmailResponse
{
    public string Message { get; set; } = string.Empty;
}