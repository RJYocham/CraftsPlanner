using CraftsPlanner.Models.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.ProjectGroup
{
    public class PGroupListItem
    {
        public int PGroupId { get; set; }

        [Display(Name = "List")]
        public string PGroupName { get; set; }

        public int ProjectId { get; set; }
        public List<ElementListItem> Elements { get; set; }
    }
}
