using AutoMapper;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Application.UseCases.Professors.Get;

public sealed class GetProfessorMapper : Profile
{
    public GetProfessorMapper()
    {
        CreateMap<GetProfessorRequest, Professor>();
        CreateMap<Professor, GetProfessorResponse>();
    }
}
