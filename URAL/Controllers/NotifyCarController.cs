using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.NotifyCar;
using URAL.Extensions;
using URAL.Filters.ActionFilters;

namespace URAL.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class NotifyCarController(INotifyCarService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] NotifyCarToAdd notifyCarToAdd)
    {
        var entityId = await service.AddAsync(notifyCarToAdd);
        return entityId;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        var isSuccess = await service.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }

    [HttpGet("{id}")]
    public ActionResult<NotifyCarToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [PageNumberFilter]
    [HttpGet]
    public async Task<PaginatedList<NotifyCarToGet>> GetUserMatch([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserMatchAsync(userId, pageNumber);
        return result;
    }

    [PageNumberFilter]
    [HttpGet]
    public async Task<PaginatedList<NotifyCarToGet>> GetUserNotifications([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserNotificationsAsync(userId, pageNumber);
        return result;
    }

    [PageNumberFilter]
    [HttpGet]
    public async Task<PaginatedList<NotifyCarToGet>> GetUserResponses([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserResponsesAsync(userId, pageNumber);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] ulong id, [FromBody] NotifyCarToUpdate notifyCarToUpdate)
    {
        if (id != notifyCarToUpdate.Id)
            return BadRequest();

        var isSuccess = await service.UpdateAsync(notifyCarToUpdate);

        return isSuccess ? Ok() : NotFound();
    }
}
