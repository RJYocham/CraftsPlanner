﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Guid OwnerId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public int CGroupId { get; set; }

        //public List<Project> Projects { get; set; }
    }
}
