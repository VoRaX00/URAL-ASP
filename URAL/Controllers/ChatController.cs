using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Chat;
using URAL.Extensions;

namespace URAL.Controllers;

[Route("api/[controller]/[action]")]
[Authorize()]
[ApiController]
public class ChatController(IChatService service) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<ChatToGet>>> Get([FromQuery] string userId)
    {
        var chats = await service.GetByUserIdAsync(userId);
        return chats;
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult<ChatToGet> GetById([FromQuery] long id)
    {
        var chat = service.GetById(id);

        if (chat is null)
            return NotFound();
        
        return Ok(chat);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<ChatToGet>>> GetByFirstUserId([FromQuery] string userId)
    {
        var chats = await service.GetByFirstUserIdAsync(userId);
        return chats;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<ChatToGet>>> GetBySecondUserId([FromQuery] string userId)
    {
        var chats = await service.GetBySecondUserIdAsync(userId);
        return chats;
    }

    [HttpPost]
    public async Task<ActionResult<long>> Add([FromBody] ChatToAdd chatToAdd)
    {
        var userId = User.GetUserIdFromClaim();
        var entityId = await service.AddAsync(chatToAdd, userId);
        return entityId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Update([FromRoute] long id, [FromBody] ChatToUpdate chatToUpdate)
    {
        if (id != chatToUpdate.Id)
            return BadRequest();

        var isSuccess = await service.UpdateAsync(chatToUpdate);
        return isSuccess ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {

        var isSuccess = await service.DeleteAsync(new(id));
        return isSuccess ? Ok() : NotFound();
    }
}