using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.User;
using URAL.Authentication;

namespace URAL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(AuthOptions authOptions, IUserService userService, IMessageService messageService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserToGet>> Get([FromRoute] string id)
    {
        var result = await userService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register([FromBody] UserToAdd userToAdd)
    {
        var entityId = await userService.AddAsync(userToAdd);
        var code = await userService.GenerateEmailConfirmationTokenAsync(entityId);
        var callbackUrl = Url.Action(
            "ConfirmEmail",
            "User",
            new { userId = entityId, code },
            protocol: HttpContext.Request.Scheme);

        await messageService.SendAsync(new(userToAdd.Email, "Confirm your account", $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>"));

        return entityId;
    }

    [HttpPost("confirmEmail")]
    public async Task<ActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string code)
    {
        if (userId == null || code == null)
            return BadRequest();

        var isSuccess = await userService.ConfirmEmailAsync(userId, code);

        if (!isSuccess)
            return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] string id)
    {
        var isSuccess = await userService.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] string id, [FromBody] UserToUpdate userToUpdate)
    {
        if (id != userToUpdate.Id)
            return BadRequest();

        var isSuccess = await userService.UpdateAsync(userToUpdate);

        return isSuccess ? Ok() : NotFound();
    }
}
