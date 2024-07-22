using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class LoadingTypeRepository : ReadRepository<LoadingType>
{
    public LoadingTypeRepository(UralDbContext context)
    {
        _context = context;
    }
}