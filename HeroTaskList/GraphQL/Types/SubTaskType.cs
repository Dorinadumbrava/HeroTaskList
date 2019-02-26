using GraphQL.Types;
using HeroTaskList.Entities;

namespace HeroTaskList.GraphQL.Types
{
    public class SubTaskType: ObjectGraphType<SubTask>
    {
        public SubTaskType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.DueDate);
            Field(t => t.Description);
        }
    }
}
