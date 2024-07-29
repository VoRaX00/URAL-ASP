using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using URAL.Application.IServices;
using URAL.Application.RequestModels.User;
using URAL.Authentication;
using URAL.Extensions;
using URAL.Filters.ExceptionFilters;

namespace URAL.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(
    AuthOptions authOptions, 
    IUserService userService, 
    IMessageService messageService, 
    IJwtTokenWriter jwtTokenWriter) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserToGet>> Get([FromRoute] string id)
    {
        var result = await userService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [AllowAnonymous]
    [UserExceptionFilter]
    [HttpPost]
    public async Task<ActionResult<string>> Register([FromBody] UserToAdd userToAdd, [FromHeader] string clientUri)
    {
        var entityId = await userService.AddAsync(userToAdd);
        var code = await userService.GenerateEmailConfirmationTokenAsync(entityId);
        var param = new Dictionary<string, string?>() 
        {
            { "userId", "entityId" },
            { "code", code },
        };
        var callbackUrl = QueryHelpers.AddQueryString(clientUri, param);

        await messageService.SendAsync(new(userToAdd.Email, "Confirm your account", $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>"));

        return entityId;
    }

    [AllowAnonymous]
    [UserExceptionFilter]
    [HttpPost]
    public async Task<ActionResult<string>> Login([FromBody] UserLogin userLogin)
    {
        var isCorrect = await userService.CheckLoginAsync(userLogin);

        if (!isCorrect)
            return BadRequest("неправильный пароль");

        var user = await userService.GetByEmailFullInfo(userLogin.Email);

        if (!user.EmailConfirmed)
            return BadRequest("подтвердите почту");

        return Ok(jwtTokenWriter.WriteToken(user));
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string code)
    {
        if (userId == null || code == null)
            return BadRequest();

        var isSuccess = await userService.ConfirmEmailAsync(userId, code);

        if (!isSuccess)
            return BadRequest();

        return Ok();
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] string id)
    {
        var isSuccess = await userService.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete()
    {
        var userId = User.GetUserIdFromClaim();

        return await Delete(userId);
    }

    [Authorize(Policy = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] string id, [FromBody] UserToUpdate userToUpdate)
    {
        if (id != userToUpdate.Id)
            return BadRequest();

        var isSuccess = await userService.UpdateAsync(userToUpdate);

        return isSuccess ? Ok() : NotFound();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UserToUpdate userToUpdate)
    {
        var userId = User.GetUserIdFromClaim();

        return await Update(userId, userToUpdate);
    }
}
