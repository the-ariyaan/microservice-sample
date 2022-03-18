using System.Linq.Expressions;
using Domain.Contracts.Repository;
using Domain.Entities;
using Domain.Utils;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class GroupRepository : EntityRepositoryBase<Group, MicroSampDbContext>, IGroupRepository
{
    public GroupRepository(MicroSampDbContext dbContext) : base(dbContext)
    {
    }

    public Task<EntityQueryable<Group>> QueryWithCountNoTracking(Expression<Func<Group, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }
}