using HeroTaskList.Entities;
using HeroTaskList.EntityFramework;
using HeroTaskList.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeroTaskList.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private IHeroTaskListDbContext _dbContext;
        public CategoryRepository(IHeroTaskListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDictionary<int, Category>> GetCategoryForAssignments(IEnumerable<int> taskIds, CancellationToken cancellationToken)
        {
            return await _dbContext.Assignments.Where(p => taskIds.Contains(p.Id)).Select(p => p.Category).ToDictionaryAsync(a => a.Id);
        }
    }
}
