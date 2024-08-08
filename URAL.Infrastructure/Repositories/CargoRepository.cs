using Microsoft.EntityFrameworkCore;
using URAL.Application.Filter;
using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
{
    public CargoRepository(UralDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Cargo> GetByName(string name)
    {
        return _context.Cargo.Where(cargo => cargo.Name == name);
    }

    public IQueryable<Cargo> GetByUserId(string id)
    {
        return _context.Cargo.Where(cargo => cargo.UserId == id);
    }

    public IQueryable<Cargo> GetByFilters(CargoFilter filters)
    {
        return _context.Cargo.Where(cargo =>
            (filters.Name == null || cargo.Name == filters.Name) && (filters.Volume == null || filters.Volume == cargo.Volume) 
            && (filters.RequestPrice == null || cargo.RequestPrice == filters.RequestPrice) && (filters.Length == null
                || cargo.Length == filters.Length) && (filters.Weight == null || cargo.Weight == filters.Weight) && (filters.Weight == null || 
            cargo.Weight == filters.Weight) && (filters.Width == null || cargo.Width == filters.Width) && (filters.CountPlace == null || cargo.CountPlace == filters.CountPlace) 
            && (filters.LoadingDate == null || cargo.LoadingDate == filters.LoadingDate) && (filters.UnloadingDate == null ||
                cargo.UnloadingDate == filters.UnloadingDate) && (filters.LoadingPlace == null || cargo.LoadingPlace == filters.LoadingPlace) &&
            (filters.UnloadingPlace == null || cargo.UnloadingPlace == filters.UnloadingPlace) && (filters.PriceCash == null ||
                cargo.PriceCash == filters.PriceCash) && (filters.PriceCashNds == null || cargo.PriceCashNds == filters.PriceCashNds)
                && (filters.PriceCashWithoutNds == null || cargo.PriceCashWithoutNds == filters.PriceCashWithoutNds)
        );
    }
}