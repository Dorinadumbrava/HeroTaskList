﻿using GraphQL.DataLoader;
using GraphQL.Types;
using HeroTaskList.Entities;

namespace HeroTaskList.GraphQL.Types
{
    public class StatusType: ObjectGraphType<AssignmentStatus>
    {
        public StatusType()
        {
            Field(t => t.Id);
            Field(t => t.Status);
        }
    }
}
