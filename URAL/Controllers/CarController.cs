using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Extensions;

namespace URAL.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CarController(ICarService service) : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<CarToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<PaginatedList<CarToGet>> GetByName([FromQuery] string name, [FromQuery] int pageNumber)
    {
        var cars = await service.GetByNameAsync(name, pageNumber);
        return cars;
    }

    [HttpGet]
    public async Task<PaginatedList<CarToGet>> GetByUserId([FromQuery] string id, [FromQuery] int pageNumber)
    {
        var cars = await service.GetByUserIdAsync(id, pageNumber);
        return cars;
    }

    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] CarToAdd carToAdd)
    {
        var userId = User.GetUserIdFromClaim();
        var entityId = await service.AddAsync(carToAdd, userId);
        return entityId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] ulong id, [FromBody] CarToUpdate carToUpdate)
    {
        if (id != carToUpdate.Id)
            return BadRequest();

        var isSuccess = await service.UpdateAsync(carToUpdate);

        return isSuccess ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        var isSuccess = await service.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }
}
