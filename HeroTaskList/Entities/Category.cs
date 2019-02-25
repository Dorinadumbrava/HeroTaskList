using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeroTaskList.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public List<Assignment> Tasks { get; set; }
    }
}