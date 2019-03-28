using GraphQL;
using GraphQL.Types;

namespace HeroTaskList.GraphQL
{
    public class HeroTaskListSchema: Schema
    {
        public HeroTaskListSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<HeroTaskListQuery>();
            Mutation = resolver.Resolve<HeroTaskListMutation>();
        }
    }
}
