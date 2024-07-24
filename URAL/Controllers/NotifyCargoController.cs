using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.NotifyCargo;
using URAL.Extensions;

namespace URAL.Controllers;

[Route("api/[controller]")]
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
        var isSuccess = await service.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }

    [HttpGet("{id}")]
    public ActionResult<NotifyCargoToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("getUserMatch")]
    public async Task<PaginatedList<NotifyCargoToGet>> GetUserMatch([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserMatchAsync(userId, pageNumber);
        return result;
    }

    [HttpGet("getUserNotifications")]
    public async Task<PaginatedList<NotifyCargoToGet>> GetUserNotifications([FromQuery] int pageNumber)
    {
        var userId = User.GetUserIdFromClaim();
        var result = await service.GetUserNotificationsAsync(userId, pageNumber);
        return result;
    }

    [HttpGet("getUserResponses")]
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

        var isSuccess = await service.UpdateAsync(notifyCargoToUpdate);

        return isSuccess ? Ok() : NotFound();
    }
}
