﻿namespace CleanArchitecture.UseCases.Professors.Create;

public sealed record CreateProfessorResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
