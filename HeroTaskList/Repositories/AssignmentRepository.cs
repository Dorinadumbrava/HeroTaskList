using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using HeroTaskList.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.Repositories
{
    public class AssignmentRepository: IAssignmentRepository
    {
        private IHeroTaskListDbContext _dbContext;
        public AssignmentRepository(IHeroTaskListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Assignment> GetAll()
        {
            return _dbContext.Assignments;
        }

        public AssignmentStatus GetAssignmentStatus(int taskId)
        {
            return _dbContext.Assignments.Where(i => i.Id == taskId).Select(s => s.Status).SingleOrDefault();
        }

        public async Task<ILookup<int, AssignmentStatus>> GetStatusForAssignments(IEnumerable<int> taskIds)
        {
            var statuses = await _dbContext.Assignments.Where(p => taskIds.Contains(p.Id)).Select(p => p.Status).ToListAsync();
            var final  = statuses.ToLookup(r => r.Id);
            return final;
        }
    }
}
