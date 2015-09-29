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
    public class ReservationByDate
    {
        public string Description { get; set; }
        //the rest of the data will be collection of POCO rows
        // the actual POCO will be defined in the link query
        public IEnumerable Reservation { get; set; }
    }
}
