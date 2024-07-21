using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.User;

namespace URAL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService service) : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<UserToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);
        return result;
    }

    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] UserToAdd userToAdd)
    {
        var entityId = await service.AddAsync(userToAdd);
        return entityId;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        await service.DeleteAsync(new(id));
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] ulong id, [FromBody] UserToUpdate userToUpdate)
    {
        if (id != userToUpdate.Id)
            return BadRequest();

        await service.UpdateAsync(userToUpdate);
        return Ok();
    }
}
