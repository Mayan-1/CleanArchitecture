using AutoMapper;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Application.UseCases.Professors.GetAll;

public sealed class GetAllProfessorMapper : Profile
{
    public GetAllProfessorMapper()
    {
        CreateMap<Professor, GetAllProfessorResponse>();
    }
}
