using Microsoft.AspNetCore.Mvc;
using URAL.Application.IServices;
using URAL.Application.RequestModels.LoadingType;

namespace URAL.Controllers;

[ApiController]
public class LoadingTypeController(ILoadingTypeService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<LoadingTypeToGet> Get()
    {
        return service.GetAll();
    }

    [HttpGet]
    public LoadingTypeToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }
}
