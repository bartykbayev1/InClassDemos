﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
#endregion

namespace eRestaurantSystem.Entities
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }
        [Required(ErrorMessage = "A Description is required (5-35 characters)")]
        [StringLength(35, MinimumLength = 5, ErrorMessage = "Descriptions must be from 5 to 35 characters in length")]
        public string Description { get; set; }

        public virtual ICollection<Item> MenuItems { get; set; }
    }
}
