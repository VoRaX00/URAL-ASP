using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.NotifyCargo;
using URAL.Extensions;

namespace URAL.Controllers;

[ApiController]
public class NotifyCargoController(INotifyCargoService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] NotifyCargoToAdd notifyCargoToAdd)
    {
        var entityId = await service.AddAsync(notifyCargoToAdd);
        return entityId;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        await service.DeleteAsync(new(id));
        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult<NotifyCargoToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);
        return result;
    }

    [HttpGet]
    public async Task<PaginatedList<NotifyCargoToGet>> GetUserMatch([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserMatchAsync(userId, pageNumber);
        return result;
    }

    [HttpGet]
    public async Task<PaginatedList<NotifyCargoToGet>> GetUserNotifications([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserNotificationsAsync(userId, pageNumber);
        return result;
    }

    [HttpGet]
    public async Task<PaginatedList<NotifyCargoToGet>> GetUserResponses([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserResponsesAsync(userId, pageNumber);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] ulong id, [FromBody] NotifyCargoToUpdate notifyCargoToUpdate)
    {
        if (id != notifyCargoToUpdate.Id)
            return BadRequest();

        await service.UpdateAsync(notifyCargoToUpdate);
        return Ok();
    }
}
