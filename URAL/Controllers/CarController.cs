﻿using Microsoft.AspNetCore.Mvc;
using URAL.Application.Base;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Extensions;

namespace URAL.Controllers;

[ApiController]
public class CarController(ICarService service) : ControllerBase
{
    [HttpGet("{id}")]
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
        var userId = User.GetUserIdFromClaim();
        var entityId = await service.AddAsync(carToAdd, userId);
        return entityId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] ulong id, [FromBody] CarToUpdate carToUpdate)
    {
        if (id != carToUpdate.Id)
            return BadRequest();

        await service.UpdateAsync(carToUpdate);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] ulong id)
    {
        await service.DeleteAsync(new(id));
        return Ok();
    }
}