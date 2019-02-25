using System;
using System.ComponentModel.DataAnnotations;

namespace HeroTaskList.Entities
{
    public class SubTask
    {
        [Key]
        public int Id { get; set; }

        public int? TaskId { get; set; }
        public Assignment Task { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
    }
}