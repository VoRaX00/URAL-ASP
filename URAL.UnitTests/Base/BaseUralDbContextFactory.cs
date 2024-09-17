using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.UnitTests.Base
{
    public class BaseUralDbContextFactory<SetType> : IDbContextFactory<UralDbContext, SetType> where SetType : class
    {
        public UralDbContext Create(IQueryable<SetType> values)
        {
            var valuesDbsetMock = new Mock<DbSet<SetType>>();

            valuesDbsetMock.As<IQueryable<SetType>>().Setup(m => m.Expression).Returns(values.Expression);
            valuesDbsetMock.As<IQueryable<SetType>>().Setup(m => m.ElementType).Returns(values.ElementType);
            valuesDbsetMock.As<IQueryable<SetType>>().Setup(m => m.Provider).Returns(values.Provider);
            valuesDbsetMock.As<IQueryable<SetType>>().Setup(m => m.GetEnumerator()).Returns(values.GetEnumerator());
            var a = valuesDbsetMock.Object;


            var dbcontextMock = new Mock<UralDbContext>();
            dbcontextMock.Setup(dbContext => dbContext.Set<SetType>())
                .Returns(valuesDbsetMock.Object);

            return dbcontextMock.Object;
        }
    }
}
