using GraphQL.Types;
using HeroTaskList.Entities;
using HeroTaskList.GraphQL.Types;
using HeroTaskList.Repository_Interfaces;

namespace HeroTaskList.GraphQL
{
    public class HeroTaskListMutation: ObjectGraphType
    {
        public HeroTaskListMutation(ISubTaskRepository subTaskRepository)
        {
            FieldAsync<SubTaskType>(
                "CreateSubTask",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SubTaskInputType>> { Name = "subTask" }),
                resolve: async context =>
                {
                    var subTask = context.GetArgument<SubTask>("subTask");
                    return await subTaskRepository.AddSubtask(subTask);
                });
        }
    }
}
