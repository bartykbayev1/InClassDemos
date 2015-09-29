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
    public class ReservationDetail
    {   
        //no validation in the poco class 
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
    }
}
