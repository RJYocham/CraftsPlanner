using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class Element
    {
        [Key]
        public int ElementId { get; set; }

        [Required]
        public string ElementName { get; set; }

        public string ElementDescription { get; set; }
        public int ProjectId { get; set; }
        public int PGroupId { get; set; }        
        public bool IsCompleted { get; set; }
    }
}
