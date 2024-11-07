namespace CleanArchitecture.Application.UseCases.Professors.Update;

public sealed record UpdateProfessorResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
