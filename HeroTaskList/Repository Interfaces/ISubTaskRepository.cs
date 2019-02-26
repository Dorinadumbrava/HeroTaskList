using HeroTaskList.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.Repository_Interfaces
{
    public interface ISubTaskRepository
    {
        Task<ILookup<int, SubTask>> GetSubTasksForAssignments(IEnumerable<int> taskIds);
    }
}
