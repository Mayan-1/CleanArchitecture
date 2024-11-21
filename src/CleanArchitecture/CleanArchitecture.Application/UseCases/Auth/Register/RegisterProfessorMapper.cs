using AutoMapper;
using CleanArchitecture.Application.Professors.Create;
using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Auth.Register;

public sealed class RegisterProfessorMapper : Profile
{
    public RegisterProfessorMapper()
    {
        CreateMap<RegisterRequest, Professor>();
        CreateMap<Professor, RegisterResponse>();
    }
}
