using HeroTaskList.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeroTaskList.Repository_Interfaces
{
    public interface ICategoryRepository
    {
        Task<IDictionary<int, Category>> GetCategoryForAssignments(IEnumerable<int> taskIds, CancellationToken cancellationToken);
    }
}
