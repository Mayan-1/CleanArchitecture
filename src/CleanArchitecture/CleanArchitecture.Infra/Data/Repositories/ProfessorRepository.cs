using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infra.Data.Config;

namespace CleanArchitecture.Infra.Data.Repositories;

public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
{
    public ProfessorRepository(AppDbContext context) : base(context)
    {
    }
    public Task<Professor> GetByEmail(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
