using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.BodyType;
using URAL.Domain.Entities;

namespace URAL.Controllers;

[ApiController]
public class BodyTypeController(IBodyTypeService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<BodyTypeToGet> Get()
    {
        return service.GetAll();
    }

    [HttpGet]
    public BodyTypeToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }
}
