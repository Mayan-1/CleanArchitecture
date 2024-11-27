namespace CleanArchitecture.Application.UseCases.Auth.ResetPassword;

public sealed record ResetPasswordResponse
{
    public string Message { get; set; } = string.Empty;
}