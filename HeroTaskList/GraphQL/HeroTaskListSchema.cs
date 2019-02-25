using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.GraphQL
{
    public class HeroTaskListSchema: Schema
    {
        public HeroTaskListSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<HeroTaskListQuery>();
        }
    }
}
