using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftsPlanner.Data
{
    //split into two??
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }
                
        //Grouping for categories
        public List<Category> Categories { get; set; }

        //Grouping for pieces of a project
        public int ProjectId { get; set; }
        public List<Task> Tasks { get; set; }
        public bool IsCompleted { get; set; }
    }
}
