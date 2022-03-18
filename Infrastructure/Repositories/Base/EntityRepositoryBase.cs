using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base;

public class EntityRepositoryBase<TEntity, TDbContext> : EntityRepositoryBase<TEntity, long, TDbContext>,
    IEntityRepository<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    public EntityRepositoryBase(TDbContext dbContext) : base(dbContext)
    {
    }
}

public class EntityRepositoryBase<TEntity, TKey, TDbContext> : RepositoryBase<TEntity, TKey, TDbContext>,
    IEntityRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TDbContext : DbContext
{
    public EntityRepositoryBase(TDbContext dbContext)
        : base(dbContext)
    {
    }

    public virtual async Task<TEntity> GetAsync(TKey id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveAsync();
        return entity;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        await SaveAsync();
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveAsync();
        return entity;
    }

    public int Save()
    {
        return DbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
}