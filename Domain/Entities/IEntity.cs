namespace Domain.Entities;

public interface IEntity : IEntity<long>
{
}

public interface IEntity<TKey> : ITrackableEntity
{
    TKey Id { get; set; }
}

public interface ITrackableEntity
{
    TrackingState EntityState { get; set; }
}