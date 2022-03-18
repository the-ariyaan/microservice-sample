using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Utils;

public static partial class Extensions
{
    public static Expression<Func<TEntity, bool>> IdentityEquality<TEntity, TKey>(this TKey id)
    {
        var type = typeof(TEntity);
        var parameter = Expression.Parameter(type, "p");
        var propertyExp = Expression.Property(parameter, "Id");
        var equalExp = Expression.Equal(propertyExp, Expression.Constant(id));

        return Expression.Lambda<Func<TEntity, bool>>(equalExp, parameter);
    }

    public static Expression<Func<TEntity, TValue>> ToSelectExpression<TEntity, TValue>(this string name)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "p");
        var body = Expression.PropertyOrField(parameter, name);
        return Expression.Lambda<Func<TEntity, TValue>>(body, parameter);
    }

    public static IQueryable<TEntity> AddPredicate<TEntity>(this IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate != null)
            return query.Where(predicate);

        return query;
    }

    public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> query,
        IEnumerable<Expression<Func<TEntity, object>>> includes = null)
        where TEntity : class
    {
        includes?.ToList().ForEach(p => query = query.Include(p));
        return query;
    }
}