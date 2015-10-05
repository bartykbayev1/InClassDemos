using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
#endregion


namespace eRestaurantSystem.Entities.POCO
{
    public class MenuItem
    {
        //public string MenuItem { get; set; }
        public decimal Price { get; set; }
        public int? Calories {get;set;}
        public string Comment { get; set; }

        public string Description { get; set; }
    }
}
