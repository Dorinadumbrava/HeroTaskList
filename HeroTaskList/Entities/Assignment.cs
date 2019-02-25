using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeroTaskList.Entities
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Important { get; set; }

        public int? StatusId { get; set; }
        public AssignmentStatus Status { get; set; }

        public List<SubTask> SubTasks { get; set; }
    }
}
