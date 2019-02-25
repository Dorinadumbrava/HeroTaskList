using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using HeroTaskList.Repository_Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HeroTaskList.Repositories
{
    public class AssignmentStatusRepository: IAssignmentStatusRepository
    {
        private IHeroTaskListDbContext _dbContext;
        public AssignmentStatusRepository(IHeroTaskListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AssignmentStatus> GetAll()
        {
            return _dbContext.Statuses;
        }
    }
}
