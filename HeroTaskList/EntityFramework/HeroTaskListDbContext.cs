using HeroTaskList.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeroTaskList.EntityFramework
{
    public class HeroTaskListDbContext: DbContext, IHeroTaskListDbContext
    {

        public HeroTaskListDbContext(DbContextOptions<HeroTaskListDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<SubTask> SubTasks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<AssignmentStatus> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Category)
                .WithMany(b => b.Tasks);
            modelBuilder.Entity<SubTask>()
                .HasOne(a => a.Task)
                .WithMany(b => b.SubTasks);
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Status)
                .WithMany(b => b.Tasks);
        }
        

        public void Migrate()
        {
            Database.Migrate();
        }
        
    }
}
