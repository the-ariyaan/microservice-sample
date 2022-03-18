namespace Domain.Utils;

public class EntityQueryable<TEntity>
{
    public EntityQueryable(IQueryable<TEntity> query, int totalCount)
    {
        Query = query;
        TotalCount = totalCount;
    }

    public IQueryable<TEntity> Query { get; set; }
    public int TotalCount { get; set; }
}