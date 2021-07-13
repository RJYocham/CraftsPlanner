using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Element
{
    public class ElementCreate
    {
        [Required]
        [Display(Name ="Task")]
        public string ElementName { get; set; }
        public int ProjectId { get; set; }
        public int PGroupId { get; set; }
        [Display(Name = "Completed?")]
        public bool IsCompleted { get; set; }
    }
}
