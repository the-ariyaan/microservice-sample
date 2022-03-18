using System.Linq.Expressions;
using Domain.Entities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Infrastructure.Repositories.Base;

    public abstract class RepositoryBase<TEntity, TKey, TDbContext> : RepositoryBase<TDbContext>,
        IRepositoryBase<TEntity, TKey>, IDisposable
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
        protected virtual IQueryable<TEntity> Query => _ignoreQueryFilters ? DbSet.IgnoreQueryFilters() : DbSet;
        private bool _ignoreQueryFilters;

        public RepositoryBase(TDbContext dbContext) : base(dbContext)
        {
        }

        public virtual TValue GetValue<TValue>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TValue>> selector)
        {
            return QueryNoTracking(predicate).Select(selector).FirstOrDefault();
        }

        public virtual Task<TValue> GetValueAsync<TValue>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TValue>> selector)
        {
            return QueryNoTracking(predicate).Select(selector).FirstOrDefaultAsync();
        }

        public virtual TKey GetId(Expression<Func<TEntity, bool>> predicate)
        {
            return GetValue(predicate, nameof(IEntity.Id).ToSelectExpression<TEntity, TKey>());
        }

        public virtual Task<TKey> GetIdAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetValueAsync(predicate, nameof(IEntity.Id).ToSelectExpression<TEntity, TKey>());
        }

        public virtual IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return Query.AddPredicate(predicate)
                .Include(includes)
                .AsNoTracking();
        }
        //
        // public virtual async Task<EntityQueryable<TEntity>> QueryWithCountNoTracking(
        //     Expression<Func<TEntity, bool>> predicate = null)
        // {
        //     var query = DbSet.AddPredicate(predicate).AsNoTracking();
        //     var totalCount = await query.CountAsync();
        //
        //     return new EntityQueryable<TEntity>(query, totalCount);
        // }

        public IDisposable BeginIgnoreQueryFilters()
        {
            _ignoreQueryFilters = true;

            return this;
        }

        public void Dispose()
        {
            _ignoreQueryFilters = false;
        }
    }

    public class RepositoryBase<TDbContext> : IRepository, IScopedDependency where TDbContext : DbContext
    {
        protected TDbContext DbContext { get; }

        public RepositoryBase(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }