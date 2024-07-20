using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Cargo;
using URAL.Extensions;

namespace URAL.Controllers;

[ApiController]
public class CargoController(ICargoService service) : ControllerBase
{
    [HttpGet]
    public CargoToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }

    [HttpGet]
    public async Task<PaginatedList<CargoToGet>> GetByName([FromQuery] string name, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByNameAsync(name, pageNumber);
        return cargos;
    }

    [HttpGet]
    public async Task<PaginatedList<CargoToGet>> GetByUserId([FromQuery] ulong id, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByUserIdAsync(id, pageNumber);
        return cargos;
    }

    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] CargoToAdd cargoToAdd) 
    {
        var userId = ulong.Parse(User.GetClaimByType("Id"));
        var entityId = await service.AddAsync(cargoToAdd, userId);
        return entityId;
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] CargoToUpdate cargoToUpdate)
    {
        await service.UpdateAsync(cargoToUpdate);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] CargoToDelete cargoToDelete)
    {
        await service.DeleteAsync(cargoToDelete);
        return Ok();
    }
}
