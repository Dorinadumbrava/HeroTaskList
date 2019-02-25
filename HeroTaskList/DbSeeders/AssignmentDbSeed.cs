using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using TaskStatus = HeroTaskList.Entities.TaskStatus;

namespace HeroTaskList.DbSeeders
{
    public class AssignmentDbSeed: Assignment
    {
        public Assignment ToEntity(IHeroTaskListDbContext dbContext)
        {
            Category = dbContext.Categories.SingleOrDefault(x => x.Id == CategoryId);
            Status = dbContext.Statuses.SingleOrDefault(x => x.Id == StatusId);
            return this;
        }
    }
}
