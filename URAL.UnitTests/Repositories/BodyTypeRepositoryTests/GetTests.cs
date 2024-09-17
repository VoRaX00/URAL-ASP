using URAL.Domain.Entities;
using URAL.Infrastructure.Repositories;
using URAL.UnitTests.Base;

namespace URAL.UnitTests.Repositories.BodyTypeRepositoryTests;

public class GetTests
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

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(6)]
    public void Get_WithCorrectId_ReturnEntity(int id)
    {
        var dbContext = dbFactory.Create(bodyTypes);
        var bodyTypeRepository = new BodyTypeRepository(dbContext);

        var actual = bodyTypeRepository.GetById(id);
        var expected = bodyTypes.FirstOrDefault(x => x.Id == id);

        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(7)]
    [InlineData(8)]
    public void Get_WithWrongId_ReturnNull(int id)
    {
        var dbContext = dbFactory.Create(bodyTypes);
        var bodyTypeRepository = new BodyTypeRepository(dbContext);

        var actual = bodyTypeRepository.GetById(id);

        Assert.Null(actual);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(0)]
    public void Get_WithEmptySet_ReturnNull(int id)
    {
        var emptyCollection = new List<BodyType>().AsQueryable();
        var dbContext = dbFactory.Create(emptyCollection);
        var bodyTypeRepository = new BodyTypeRepository(dbContext);

        var actual = bodyTypeRepository.GetById(id);

        Assert.Null(actual);
    }
}
