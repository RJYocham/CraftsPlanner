using CraftsPlanner.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.CategoryGroup
{
    public class CGroupDetail
    {
        public int CGroupId { get; set; }
        public string CGroupName { get; set; }
        public List<CategoryListItem> Categories { get; set; }
    }
}
