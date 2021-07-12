using CraftsPlanner.Models.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.ProjectGroup
{
    public class PGroupDetail
    {
        public int PGroupId { get; set; }
        public string PGroupName { get; set; }

        public int ProjectId { get; set; }
        public IEnumerable<ElementListItem> Elements { get; set; }
    }
}
