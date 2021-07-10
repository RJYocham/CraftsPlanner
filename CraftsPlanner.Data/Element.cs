using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class Element
    {
        public int ElementId { get; set; }
        public string ElementName { get; set; }
        public string ElementDescription { get; set; }
        public bool IsCompleted { get; set; }
    }
}
