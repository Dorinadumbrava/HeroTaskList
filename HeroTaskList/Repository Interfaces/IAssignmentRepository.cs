using HeroTaskList.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.Repository_Interfaces
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment> GetAll();
        AssignmentStatus GetAssignmentStatus(int taskId);
        Task<ILookup<int, AssignmentStatus>> GetStatusForAssignments(IEnumerable<int> taskIds);
    }
}
