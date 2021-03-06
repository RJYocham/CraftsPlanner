using CraftsPlanner.Models.ProjectGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Project
{
    public class ProjectDetail
    {
        public int ProjectId { get; set; }
        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        public string Source { get; set; }

        public List<PGroupListItem> ProjectGroup { get; set; }


        //public List<Category> Categories { get; set; }
        //public int Difficulty { get; set; }
        //public List<Material> Materials { get; set; }
        //public int Budget { get; set; }
        //public int Cost { get; set; }
        //public int Plan { get; set; }
    }

}
