using URAL.Application.RequestModels.LoadingType;

namespace URAL.Application.IServices;

public interface ILoadingTypeService
{
    public IEnumerable<LoadingTypeToGet> GetAll();
    public LoadingTypeToGet GetById(ulong id);
}
