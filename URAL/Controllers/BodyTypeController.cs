﻿using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.BodyType;

namespace URAL.Controllers;

[ApiController]
public class BodyTypeController(IBodyTypeService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<BodyTypeToGet> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public BodyTypeToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }
}