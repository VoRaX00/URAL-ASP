﻿using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<CargoToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("getByName")]
    public async Task<PaginatedList<CargoToGet>> GetByName([FromQuery] string name, [FromQuery] int pageNumber)
    {
        var cargos = await service.GetByNameAsync(name, pageNumber);
        return cargos;
    }

    [HttpGet("getByUserId")]
    public async Task<PaginatedList<CargoToGet>> GetByUserId([FromQuery] string id, [FromQuery] int pageNumber)
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

        var isSuccess = await service.UpdateAsync(cargoToUpdate);

        return isSuccess ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        var isSuccess = await service.DeleteAsync(new(id));

        return isSuccess ? Ok() : NotFound();
    }
}
