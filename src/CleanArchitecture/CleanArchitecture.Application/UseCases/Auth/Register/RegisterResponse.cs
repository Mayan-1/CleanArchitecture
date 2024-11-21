namespace CleanArchitecture.Application.UseCases.Auth.Register;

public sealed record RegisterResponse
{
    public string? Status { get; set; }
    public string? Message { get; set; }
}