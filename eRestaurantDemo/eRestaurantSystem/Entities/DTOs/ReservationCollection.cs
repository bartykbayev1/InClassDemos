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
using eRestaurantSystem.Entities.POCO;
#endregion

namespace eRestaurantSystem.Entities.DTOs
{
    public class ReservationCollection
    {
        
        //data properties
        public int Hour { get; set; }        
        public virtual ICollection<ReservationSummary> Reservations { get; set; }

        //read only property
        public TimeSpan SeatingTime { get { return new TimeSpan(Hour, 0, 0); } }
    }
}
