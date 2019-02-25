using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroTaskList.Entities
{
    public class AssignmentStatus
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public List<Assignment> Tasks { get; set; }
    }
}
