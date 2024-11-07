using AutoMapper;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Application.UseCases.Professors.Update;

public sealed class UpdateProfessorMapper : Profile
{
    public UpdateProfessorMapper()
    {
        CreateMap<UpdateProfessorRequest, Professor>();
        CreateMap<Professor, UpdateProfessorResponse>();
    }

}
