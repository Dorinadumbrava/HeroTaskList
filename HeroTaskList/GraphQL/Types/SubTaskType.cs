using GraphQL.DataLoader;
using GraphQL.Types;
using HeroTaskList.Entities;

namespace HeroTaskList.GraphQL.Types
{
    public class SubTaskType: ObjectGraphType<SubTask>
    {
        public SubTaskType(IDataLoaderContextAccessor dataLoader)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.DueDate);
            Field(t => t.Description);
            Field(t => t.TaskId);
            //Field<AssignmentType, Assignment>()
            //    .Name("Assignment")
            //    .ResolveAsync(ctx =>
            //    {
            //        var loader = dataLoader.Context.GetOrAddBatchLoader<int, AssignmentStatus>(
            //            "GetStatus", statusRepository.GetStatusForAssignments);
            //        return loader.LoadAsync(ctx.Source.Id);
            //    });
        }
    }
}
