using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public bool IsCompleted { get; set; }
    }
}
