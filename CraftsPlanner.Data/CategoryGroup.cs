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
        public int CatGroupId { get; set; }

        [Required]
        public string CGroupName { get; set; }


        public List<Category> Categories { get; set; }
    }
}
