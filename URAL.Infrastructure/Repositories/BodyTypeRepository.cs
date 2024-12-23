using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class BodyTypeRepository : ReadRepository<BodyType>, IBodyTypeRepository
{
    public BodyTypeRepository(UralDbContext context)
    {
        _context = context;
    }
}