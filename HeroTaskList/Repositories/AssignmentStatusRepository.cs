using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using HeroTaskList.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<IDictionary<int, AssignmentStatus>> GetStatusForAssignments(IEnumerable<int> taskIds, CancellationToken cancellationToken)
        {
            return await _dbContext.Assignments.Where(p => taskIds.Contains(p.Id)).Select(p => p.Status).ToDictionaryAsync(x => x.Id);
        }
    }
}
