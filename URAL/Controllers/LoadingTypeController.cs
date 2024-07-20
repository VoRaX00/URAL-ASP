using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.LoadingType;
using URAL.Domain.Entities;

namespace URAL.Controllers;

[ApiController]
public class LoadingTypeController(ILoadingTypeService service) : ControllerBase
{
    public IEnumerable<LoadingTypeToGet> Get()
    {
        return service.GetAll();
    }

    public LoadingTypeToGet Get([FromRoute] ulong id)
    {
        return service.GetById(id);
    }
}
