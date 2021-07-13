using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.ProjectGroup
{
    public class PGroupEdit
    {
        public int PGroupId { get; set; }

        [Required]
        [Display(Name = "List")]
        public string PGroupName { get; set; }

        public int ProjectId { get; set; }
    }
}
