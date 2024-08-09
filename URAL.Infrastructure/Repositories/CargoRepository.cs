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
            (filters.name == null || cargo.Name == filters.name) && (filters.volume == null || filters.volume == cargo.Volume) 
            && (filters.requestPrice == null || cargo.RequestPrice == filters.requestPrice) && (filters.length == null
                || cargo.Length <= filters.length) && (filters.weight == null || cargo.Weight == filters.weight) && (filters.weight == null || 
            cargo.Weight == filters.weight) && (filters.width == null || cargo.Width == filters.width) && (filters.countPlace == null || cargo.CountPlace == filters.countPlace) 
            && (filters.loadingDate == null || cargo.LoadingDate == filters.loadingDate) && (filters.unloadingDate == null ||
                cargo.UnloadingDate == filters.unloadingDate) && (filters.loadingPlace == null || cargo.LoadingPlace == filters.loadingPlace) &&
            (filters.unloadingPlace == null || cargo.UnloadingPlace == filters.unloadingPlace) && (filters.priceCash == null ||
                cargo.PriceCash == filters.priceCash) && (filters.priceCashNds == null || cargo.PriceCashNds == filters.priceCashNds)
                && (filters.priceCashWithoutNds == null || cargo.PriceCashWithoutNds == filters.priceCashWithoutNds)
        );
    }
}