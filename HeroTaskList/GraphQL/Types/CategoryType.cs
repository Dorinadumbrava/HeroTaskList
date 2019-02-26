using GraphQL.Types;
using HeroTaskList.Entities;

namespace HeroTaskList.GraphQL.Types
{
    public class CategoryType: ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(t => t.Id);
            Field(t => t.Description);
        }
    }
}
