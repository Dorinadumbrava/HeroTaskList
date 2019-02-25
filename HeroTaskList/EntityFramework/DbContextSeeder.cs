using HeroTaskList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentStatus = HeroTaskList.Entities.AssignmentStatus;

namespace HeroTaskList.EntityFramework
{
    public class DbContextSeeder: IDbContextSeeder
    {
        public void Seed(IHeroTaskListDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(
                    new Category
                    {
                        Description = "ToRead"
                    });
                context.Categories.Add(
                    new Category
                    {
                        Description = "MoviesToWatch"
                    });
                context.Categories.Add(
                    new Category
                    {
                        Description = "Projects To Do"
                    });
                context.Categories.Add(
                    new Category
                    {
                        Description = "To Learn"
                    });
                context.SaveChanges();
            };
            if (!context.Assignments.Any())
            {
                context.Assignments.Add(
                    new Assignment
                    {
                        Name = "Read ProC#",
                        Description = "Finish reading remaining chapters",
                        DueDate = new DateTime(2019, 03, 15),
                        CategoryId = 1,
                        Important = true,
                        Status = new AssignmentStatus
                        {
                            Status = StatusEnum.Started.ToString()
                        }

                    });
                context.Assignments.Add(
                    new Assignment
                    {
                        Name = "Watch Star Wars",
                        Description = "Watch all parts",
                        DueDate = new DateTime(2019, 05, 31),
                        CategoryId = 2,
                        Important = false,
                        Status = new AssignmentStatus
                        {
                            Status = StatusEnum.Done.ToString()
                        }

                    });
                context.Assignments.Add(
                    new Assignment
                    {
                        Name = "Finish GraphQL project",
                        Description = "Finish project",
                        DueDate = new DateTime(2019, 02, 28),
                        CategoryId = 3,
                        Important = true,
                        Status = new AssignmentStatus
                        {
                            Status = StatusEnum.NotDone.ToString()
                        }

                    });
                context.Assignments.Add(
                    new Assignment
                    {
                        Name = "Learn Angular",
                        Description = "Should be able to make front for a new app",
                        DueDate = new DateTime(2019, 02, 15),
                        CategoryId = 4,
                        Important = true,
                        Status = new AssignmentStatus
                        {
                            Status = StatusEnum.Outdated.ToString()
                        }

                    });
                context.SaveChanges();
            };
            if (!context.SubTasks.Any())
            {
                context.SubTasks.Add(
                    new SubTask
                    {
                        Name = "A Phantom Menace",
                        Description = "Watch First Episode",
                        TaskId = 2
                    });
                context.SaveChanges();
            };

            
        }
    }
}
