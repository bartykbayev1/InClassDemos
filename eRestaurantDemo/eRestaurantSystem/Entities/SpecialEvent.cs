using System;
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
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="An event code is required(Only one character)")]
        [StringLength(1, ErrorMessage="Event Codes can only use a single-character code")]
        public string EventCode { get; set; }
        [Required(ErrorMessage="A description is required (5-30 characters)")]
        [StringLength(30, MinimumLength=5, ErrorMessage="Descrition must be 5 to 30 characters in length")]
        public string Description { get; set; }
        public bool Active { get; set; }
        
        
        //NAvigation virtual porperties

        public virtual ICollection<Reservation> Reservations { get; set; }

        //all class can have their own 
        //constructors can contain initialization values

        public SpecialEvent() {
            Active = true;
        }
    }
}
