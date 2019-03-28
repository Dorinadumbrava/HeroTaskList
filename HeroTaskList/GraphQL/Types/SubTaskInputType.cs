using GraphQL.Types;

namespace HeroTaskList.GraphQL.Types
{
    public class SubTaskInputType: InputObjectGraphType
    {
        public SubTaskInputType()
        {
            Name = "SubTaskInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<StringGraphType>("Description");
            Field<NonNullGraphType<IntGraphType>>("TaskId");
            Field<DateGraphType>("DueDate");
        }
    }
}
