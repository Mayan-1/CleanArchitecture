using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
