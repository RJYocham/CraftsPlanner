using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Source { get; set; }

        public List<Category> Categories { get; set; }

        public List<ProjectGroup> Groups { get; set; }

        public DateTimeOffset Created { get; set; }

        //public List<Progress> ProgressList { get; set; }
        //public int Difficulty { get; set; }
        //public List<Material> Materials { get; set; }
        //public int Budget { get; set; }
        //public int Cost { get; set; }
    }
}
                                                                       