using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class ToDoGroup
    {
        public int TGroupId { get; set; }
        public int ProjectId { get; set; }

        public int ToDoId { get; set; }
        public List<ToDo> ToDos { get; set; }

        public bool IsCompleted { get; set; }
    }
}
