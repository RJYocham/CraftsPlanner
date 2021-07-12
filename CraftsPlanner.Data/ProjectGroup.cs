using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    public class ProjectGroup
    {
        [Key]
        public int PGroupId { get; set; }
        [Required]
        public string PGroupName { get; set; }

        public int ProjectId { get; set; }
        public List<Element> Elements { get; set; }
    }
}
