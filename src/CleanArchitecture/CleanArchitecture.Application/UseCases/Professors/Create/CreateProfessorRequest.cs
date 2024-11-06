using MediatR;

namespace CleanArchitecture.Application.Professors.Create 
{ 

    public sealed record CreateProfessorRequest(
        string Name, string Email, string Password) : IRequest<CreateProfessorResponse>;

  



}
