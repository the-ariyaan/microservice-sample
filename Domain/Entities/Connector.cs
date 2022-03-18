using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Connector : BaseEntity
{
    [Range(1, int.MaxValue, ErrorMessage = "MaxCurrent must be greater than {1}")]
    public int MaxCurrent { get; set; }

    public long ChargeStationId { get; set; }

    public virtual ChargeStation ChargeStation { get; set; }
}