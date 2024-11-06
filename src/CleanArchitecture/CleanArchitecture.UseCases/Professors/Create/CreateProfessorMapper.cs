using CleanArchitecture.Core.Entities;
using AutoMapper;

namespace CleanArchitecture.UseCases.Professors.Create;

public sealed class CreateProfessorMapper : Profile
{
    public CreateProfessorMapper()
    {
        CreateMap<CreateProfessorRequest, Professor>();
        CreateMap<Professor, CreateProfessorResponse>();
    }
}
