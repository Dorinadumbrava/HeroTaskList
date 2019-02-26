using GraphQL.DataLoader;
using GraphQL.Types;
using HeroTaskList.Entities;
using HeroTaskList.Repository_Interfaces;

namespace HeroTaskList.GraphQL.Types
{
    public class AssignmentType: ObjectGraphType<Assignment>
    {
        public AssignmentType(IAssignmentRepository assignmentRepository, IDataLoaderContextAccessor dataLoader, 
            IAssignmentStatusRepository statusRepository, ICategoryRepository categoryRepository)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.DueDate);
            Field(t => t.Important);
            Field<StatusType, AssignmentStatus>()
                .Name("TaskStatus")
                .ResolveAsync(ctx =>
                {
                    var loader = dataLoader.Context.GetOrAddBatchLoader<int, AssignmentStatus>(
                        "GetStatus", statusRepository.GetStatusForAssignments);
                    return loader.LoadAsync(ctx.Source.Id);
                });
            Field<CategoryType, Category>()
                .Name("TaskCategory")
                .ResolveAsync( context =>
                {
                    var loader = dataLoader.Context.GetOrAddBatchLoader<int, Category>(
                        "GetCategory", categoryRepository.GetCategoryForAssignments);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
