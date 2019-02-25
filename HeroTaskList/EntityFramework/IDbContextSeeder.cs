using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.EntityFramework
{
    public interface IDbContextSeeder
    {
        void Seed(IHeroTaskListDbContext context);
    }
}
