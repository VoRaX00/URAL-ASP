using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.Filters;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Cargo;
using URAL.Extensions;
using URAL.Filters.ActionFilters;

namespace URAL.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class CargoController(ICargoService service) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult<CargoToGet> Get([FromRoute] long id)
    {
        var result = service.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [PageNumberFilter]
    [AllowAnonymous]
    [HttpGet]
    public async Task<PaginatedList<CargoToGet>> Get([FromQuery] int pageNumber)
    {
        return await service.GetAllAsync(pageNumber);
    }

    [PageNumberFilter]
    [AllowAnonymous]
    [HttpGet]
    public async Task<PaginatedList<CargoToGet>> GetByUserId([FromQuery] string id, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByUserIdAsync(id, pageNumber);
        return cargos;
    }
    
    [PageNumberFilter]
    [AllowAnonymous]
    [HttpGet]
    public async Task<PaginatedList<CargoToGet>> GetByFilters([FromQuery] CargoFilter filters, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByFiltersAsync(filters, pageNumber);
        return cargos;
    }

    [HttpPost]
    public async Task<ActionResult<long>> Add([FromBody] CargoToAdd cargoToAdd) 
    {
        var userId = User.GetUserIdFromClaim();
        var entityId = await service.AddAsync(cargoToAdd, userId);
        return entityId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] long id, [FromBody] CargoToUpdate cargoToUpdate)
    {
        if (id != cargoToUpdate.Id)
            return BadRequest();

        var isSuccess = await service.UpdateAsync(cargoToUpdate);

        return isSuccess ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] long id)
    {
        var isSuccess = await service.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }
}
