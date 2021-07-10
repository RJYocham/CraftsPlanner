using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    //combine with tasks?

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
           
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public int CGroupId { get; set; }

        [ForeignKey("CGroupId")]
        public virtual CategoryGroup CategoryGroup { get; set; }

        //public List<Project> Projects { get; set; }
    }
}
