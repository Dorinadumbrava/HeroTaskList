using HeroTaskList.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.Repository_Interfaces
{
    public interface ICategoryRepository
    {
        Task<ILookup<int, Category>> GetCategoryForAssignments(IEnumerable<int> taskIds);
    }
}
