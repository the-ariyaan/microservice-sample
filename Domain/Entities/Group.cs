using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than {1}")]
    public int Capacity { get; set; }

    [JsonIgnore] public virtual ICollection<ChargeStation> ChargeStations { get; set; }
}