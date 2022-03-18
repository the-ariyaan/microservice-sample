using System.Linq.Expressions;
using Domain.Contracts.Repository;
using Domain.Entities;
using Domain.Utils;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class ChargeStationRepository : EntityRepositoryBase<ChargeStation, MicroSampDbContext>,
    IChargeStationRepository
{
    public ChargeStationRepository(MicroSampDbContext dbContext) : base(dbContext)
    {
    }

    public Task<EntityQueryable<ChargeStation>> QueryWithCountNoTracking(Expression<Func<ChargeStation, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }
}