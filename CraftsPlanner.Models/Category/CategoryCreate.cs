using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Models.Category
{
    public class CategoryCreate
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public string CategoryName { get; set; }

    }
}
