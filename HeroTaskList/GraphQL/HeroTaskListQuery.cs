using GraphQL.Types;
using HeroTaskList.GraphQL.Types;
using HeroTaskList.Repository_Interfaces;

namespace HeroTaskList.GraphQL
{
    internal class HeroTaskListQuery: ObjectGraphType
    {

        public HeroTaskListQuery(IAssignmentRepository assignmentRepository)
        {
            Field<ListGraphType<AssignmentType>>(
                "Tasks",
                resolve: context => assignmentRepository.GetAll());
        }
    }
}