using Microsoft.EntityFrameworkCore;
using Moq;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.UnitTests.Repositories.BodyTypeRepositoryTests;

internal static class UralDbContextWithBodyTypeSetFactory
{
    public static UralDbContext Create(IQueryable<BodyType> bodyTypes)
    {
        var bodyTypesDbsetMock = new Mock<DbSet<BodyType>>();

        bodyTypesDbsetMock.As<IQueryable<BodyType>>().Setup(m => m.Expression).Returns(bodyTypes.Expression);
        bodyTypesDbsetMock.As<IQueryable<BodyType>>().Setup(m => m.ElementType).Returns(bodyTypes.ElementType);
        bodyTypesDbsetMock.As<IQueryable<BodyType>>().Setup(m => m.Provider).Returns(bodyTypes.Provider);
        bodyTypesDbsetMock.As<IQueryable<BodyType>>().Setup(m => m.GetEnumerator()).Returns(bodyTypes.GetEnumerator());
        var a = bodyTypesDbsetMock.Object;


        var dbcontextMock = new Mock<UralDbContext>();
        dbcontextMock.Setup(dbContext => dbContext.Set<BodyType>())
            .Returns(bodyTypesDbsetMock.Object);
        dbcontextMock.Setup(dbContext => dbContext.BodyTypes)
            .Returns(bodyTypesDbsetMock.Object);

        return dbcontextMock.Object;
    }
}
