using URAL.Application.RequestModels.BodyType;

namespace URAL.Application.IServices;

public interface IBodyTypeService
{
    public IEnumerable<BodyTypeToGet> GetAll();
    public BodyTypeToGet? GetById(ulong id);
}
