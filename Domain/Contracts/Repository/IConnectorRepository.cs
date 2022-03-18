using Domain.Entities;
using Domain.Utils.Repository;

namespace Domain.Contracts.Repository;

public interface IConnectorRepository : IEntityRepository<Connector>
{
}