using AutoMapper;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Application.UseCases.Professors.Delete;

public sealed class DeleteProfessorMapper : Profile
{
    public DeleteProfessorMapper()
    {
        CreateMap<DeleteProfessorRequest, Professor>();
        CreateMap<Professor, DeleteProfessorResponse>();
    }
}
