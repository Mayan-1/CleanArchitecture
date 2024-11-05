using CleanArchitecture.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> Get(int id, CancellationToken cancellationToken);
        Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken);
    }
}
