using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class LoadingType : BaseEntity
{
    public string Name { get; set; }
    public List<Car> Cars { get; set; } = [];
}
