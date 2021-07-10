using CraftsPlanner.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.CategoryGroup
{
    public class CGroupListItem
    {
        public int CGroupId { get; set; }

        [Display(Name = "Group")]
        public string CGroupName { get; set; }

        public List<CategoryListItem> Categories { get; set; }        
    }
}
