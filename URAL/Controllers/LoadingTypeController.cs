﻿using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.LoadingType;

namespace URAL.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class LoadingTypeController(ILoadingTypeService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<LoadingTypeToGet> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<LoadingTypeToGet> Get([FromRoute] long id)
    {
        var result = service.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
