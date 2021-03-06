using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.CategoryGroup
{
    public class CGroupCreate
    {
        [Key]
        public int CGroupId { get; set; }
        
        [Required]
        [Display(Name = "Group")]
        public string CGroupName { get; set; }
    }
}
