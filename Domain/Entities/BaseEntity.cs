namespace Domain.Entities;

public abstract class BaseEntity : BaseEntity<long>, IEntity
{
}

public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
    public TrackingState EntityState { get; set; } = TrackingState.Unchanged;
}

public enum TrackingState
{
    Added,
    Deleted,
    Modified,
    Unchanged,
    Detached
}