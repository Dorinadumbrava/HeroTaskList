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

        
    }
}
