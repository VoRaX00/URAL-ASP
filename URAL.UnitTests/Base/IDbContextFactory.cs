using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URAL.UnitTests.Base
{
    public interface IDbContextFactory<T, SetType> where T : DbContext
    {
        public T Create(IQueryable<SetType> values);
    }
}
