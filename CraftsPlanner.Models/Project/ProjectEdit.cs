using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Project
{
    public class ProjectEdit
    {
        public int ProjectId { get; set; }

        [Required]
        [Display(Name ="Project")]
        public string ProjectName { get; set; }

        [Required]
        public string Source { get; set; }

        //public List<Category> Categories { get; set; }
        //public int Difficulty { get; set; }
        //public List<Material> Materials { get; set; }
        //public int Budget { get; set; }
        //public int Cost { get; set; }
        //public int Plan { get; set; }
    }
}
