using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    //split into two??
    public class CategoryGroup
    {
        [Key]
        public int CGroupId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string CGroupName { get; set; }


        public virtual List<Category> Categories { get; set; }
    }
}
