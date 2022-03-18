using Domain.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GroupController : BaseApiController
{
    private readonly ILogger<GroupController> _logger;
    private readonly IGroupRepository _groupRepository;

    public GroupController(ILogger<GroupController> logger, IGroupRepository groupRepository)
    {
        _logger = logger;
        _groupRepository = groupRepository;
    }

    [HttpGet(Name = "")]
    public async Task<IEnumerable<bool>> Get()
    {
        var test = await _groupRepository.GetAsync(10);
        throw new NotImplementedException();
    }
}