using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }

        [Required]
        public string ToDoName { get; set; }
        public string ToDoDescription { get; set; }

        public bool IsCompleted { get; set; }
    }
}
