using MapsterMapper;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.BodyType;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class BodyTypeService(IMapper mapper, IBodyTypeRepository repository) : IBodyTypeService
{
    public IEnumerable<BodyTypeToGet> GetAll()
    {
        return repository.GetAll().Select(x => mapper.Map<BodyType, BodyTypeToGet>(x));
    }

    public BodyTypeToGet? GetById(ulong id)
    {
        var entity = repository.GetById(id);

        if (entity is null)
            return null;

        return mapper.Map<BodyType, BodyTypeToGet>(entity);
    }
}
