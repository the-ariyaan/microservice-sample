using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Infrastructure.Repositories.Base;

public interface IRepositoryBase<TEntity, TKey> : IRepository
    where TEntity : class, IEntity<TKey>
{
    TValue GetValue<TValue>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TValue>> selector);

    Task<TValue> GetValueAsync<TValue>(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TValue>> selector);

    TKey GetId(Expression<Func<TEntity, bool>> predicate);
    Task<TKey> GetIdAsync(Expression<Func<TEntity, bool>> predicate);

    IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>> predicate = null,
        params Expression<Func<TEntity, object>>[] includes);

    //Task<EntityQueryable<TEntity>> QueryWithCountNoTracking(Expression<Func<TEntity, bool>> predicate = null);
    IDisposable BeginIgnoreQueryFilters();
}

public interface IRepository
{
}