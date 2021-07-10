using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Element
{
    public class ElementDetail
    {
        public int ElementId { get; set; }
        public string ElementName { get; set; }
        public string ElementDescription { get; set; }
        public int PGroupId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
