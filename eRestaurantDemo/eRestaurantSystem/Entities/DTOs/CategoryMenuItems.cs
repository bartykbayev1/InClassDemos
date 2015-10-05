using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections; //reqierred by IEnumarable
using System.ComponentModel.DataAnnotations.Schema;
#endregion


namespace eRestaurantSystem.Entities.DTOs
{
    public class CategoryMenuItems
    {
        public string Description { get; set; }
        public IEnumerable MenuItems { get; set; }
    }
}
