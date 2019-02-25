using HeroTaskList.Entities;
using System.Collections.Generic;

namespace HeroTaskList.Repository_Interfaces
{
    public interface IAssignmentStatusRepository
    {
        IEnumerable<AssignmentStatus> GetAll();
    }
}
