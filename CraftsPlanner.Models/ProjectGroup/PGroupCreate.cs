using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.ProjectGroup
{
    public class PGroupCreate
    {
        [Required]
        [Display(Name = "List")]
        public string PGroupName { get; set; }
        public int ProjectId { get; set; }
    }
}
