using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Project
{
    public class ProjectCreate
    {
        [Required]
        public string ProjectName { get; set; }
        public string Reference { get; set; }
        //public List<Category> Categories { get; set; }
    }
}
