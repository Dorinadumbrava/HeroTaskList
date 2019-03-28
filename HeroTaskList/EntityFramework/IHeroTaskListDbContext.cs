using HeroTaskList.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HeroTaskList.EntityFramework
{
    public interface IHeroTaskListDbContext
    {
        DbSet<Assignment> Assignments { get; set; }
        DbSet<SubTask> SubTasks { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<AssignmentStatus> Statuses { get; set; }

        void Migrate();
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
