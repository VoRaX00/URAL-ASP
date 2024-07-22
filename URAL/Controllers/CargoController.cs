using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Cargo;
using URAL.Extensions;

namespace URAL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoController(ICargoService service) : ControllerBase
{
    [HttpGet("{id}")]
    public CargoToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }

    [HttpGet("getByName")]
    public async Task<PaginatedList<CargoToGet>> GetByName([FromQuery] string name, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByNameAsync(name, pageNumber);
        return cargos;
    }

    [HttpGet("getByUserId")]
    public async Task<PaginatedList<CargoToGet>> GetByUserId([FromQuery] ulong id, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByUserIdAsync(id, pageNumber);
        return cargos;
    }

    [HttpPost]
    public async Task<ActionResult<ulong>> Add([FromBody] CargoToAdd cargoToAdd) 
    {
        var userId = User.GetUserIdFromClaim();
        var entityId = await service.AddAsync(cargoToAdd, userId);
        return entityId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] ulong id, [FromBody] CargoToUpdate cargoToUpdate)
    {
        if (id != cargoToUpdate.Id)
            return BadRequest();

        await service.UpdateAsync(cargoToUpdate);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        await service.DeleteAsync(new(id));
        return Ok();
    }
}
