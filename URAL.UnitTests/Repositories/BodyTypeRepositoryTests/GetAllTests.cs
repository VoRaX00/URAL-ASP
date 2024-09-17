using URAL.Domain.Entities;
using URAL.Infrastructure.Repositories;
using URAL.UnitTests.Base;

namespace URAL.UnitTests.Repositories.BodyTypeRepositoryTests;

public class GetAllTests
{
    private IQueryable<BodyType> bodyTypes = new List<BodyType>()
        {
            new BodyType {Id = 0, Name = "a" },
            new BodyType {Id = 1, Name = "h" },
            new BodyType {Id = 2, Name = "c" },
            new BodyType {Id = 3, Name = "d" },
            new BodyType {Id = 4, Name = "a" },
            new BodyType {Id = 5, Name = "e" },
            new BodyType {Id = 6, Name = "h" },
        }.AsQueryable();
    
    private BaseUralDbContextFactory<BodyType> dbFactory = new BaseUralDbContextFactory<BodyType>();

    [Fact]
    public void GetAll_IfCollectionNotEmpty_ReturnCollection()
    {
        var dbContext = dbFactory.Create(bodyTypes);
        var bodyTypeRepository = new BodyTypeRepository(dbContext);

        var actual = bodyTypeRepository.GetAll().ToList();
        var expected = bodyTypes.ToList();

        Assert.Equal(actual.Count, expected.Count);
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void GetAll_IfCollectionEmpty_ReturnEmpty()
    {
        var emptyCollection = new List<BodyType>().AsQueryable();
        var dbContext = dbFactory.Create(emptyCollection);
        var bodyTypeRepository = new BodyTypeRepository(dbContext);

        var actual = bodyTypeRepository.GetAll().ToList();

        Assert.Empty(actual);
    }
}
