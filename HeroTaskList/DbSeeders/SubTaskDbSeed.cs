using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using System.Linq;

namespace HeroTaskList.DbSeeders
{
    public class SubTaskDbSeed: SubTask
    {
        public SubTask ToEntity(IHeroTaskListDbContext context)
        {
            Task = context.Assignments.FirstOrDefault(x => x.Id == TaskId);
            return this;
        }
    }
}
