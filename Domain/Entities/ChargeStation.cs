namespace Domain.Entities;

public class ChargeStation : BaseEntity
{
    public string Name { get; set; }
    public long GroupId { get; set; }

    public virtual Group Group { get; set; }
    public virtual ICollection<Connector> Connectors { get; set; }
}