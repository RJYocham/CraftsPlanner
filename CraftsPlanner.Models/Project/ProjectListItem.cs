using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Project
{
    public class ProjectListItem
    {
        public int ProjectId { get; set; }

        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        public string Source { get; set; }
    }
}
