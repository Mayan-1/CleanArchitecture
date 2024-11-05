using CleanArchitecture.Core.Common;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infra.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Create(TEntity entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        Context.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.DateDeleted = DateTimeOffset.UtcNow;
        Context.Remove(entity);
    }

    public async Task<TEntity> Get(int id, CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public void Update(TEntity entity)
    {
        entity.DateModified = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }
}
