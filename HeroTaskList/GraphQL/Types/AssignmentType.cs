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
            Field<ListGraphType<StatusType>>(
                "TaskStatus",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, AssignmentStatus>(
                        "GetStatus", statusRepository.GetStatusForAssignments);
                    return loader.LoadAsync(context.Source.Id);
                });
            Field<ListGraphType<CategoryType>>(
                "TaskCategory",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, Category>(
                        "GetCategory", categoryRepository.GetCategoryForAssignments);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
