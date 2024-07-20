using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Application.RequestModels.Cargo;
using URAL.Extensions;

namespace URAL.Controllers;

[ApiController]
public class CarController(ICarService service) : ControllerBase
{
    [HttpGet]
    public CarToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }

    [HttpGet]
    public async Task<PaginatedList<CarToGet>> GetByName([FromQuery] string name, [FromQuery] int pageNumber)
    {
        var cars = await service.GetByNameAsync(name, pageNumber);
        return cars;
    }

    [HttpGet]
    public async Task<PaginatedList<CarToGet>> GetByUserId([FromQuery] ulong id, [FromQuery] int pageNumber)
    {
        var cars = await service.GetByUserIdAsync(id, pageNumber);
        return cars;
    }

    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] CarToAdd carToAdd)
    {
        var userId = ulong.Parse(User.GetClaimByType("Id"));
        var entityId = await service.AddAsync(carToAdd, userId);
        return entityId;
    }

    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] CarToUpdate carToUpdate)
    {
        await service.UpdateAsync(carToUpdate);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] CarToDelete carToDelete)
    {
        await service.DeleteAsync(carToDelete);
        return Ok();
    }
}
