using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using HeroTaskList.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.Repositories
{
    public class SubTaskRepository: ISubTaskRepository
    {
        private IHeroTaskListDbContext _dbContext;
        public SubTaskRepository(IHeroTaskListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SubTask> AddSubtask(SubTask subTask)
        {
            _dbContext.SubTasks.Add(subTask);
            await _dbContext.SaveChangesAsync();
            return subTask;
        }

        public async Task<ILookup<int, SubTask>> GetSubTasksForAssignments(IEnumerable<int> taskIds)
        {
            var subtasks = await _dbContext.SubTasks.Where(p => taskIds.Contains(p.Task.Id)).ToListAsync();
            return subtasks.ToLookup(r=> r.Task.Id);
        }
    }
}
