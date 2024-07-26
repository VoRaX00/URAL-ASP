using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.BodyType;

namespace URAL.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BodyTypeController(IBodyTypeService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<BodyTypeToGet> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<BodyTypeToGet> Get([FromRoute] ulong id)
    {
        var result = service.GetById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}
