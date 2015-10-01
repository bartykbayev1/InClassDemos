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
    public class Reservation
    {
        [Key]
        
        public int ReservationID { get; set; }
        [Required]
        [StringLength(40)]
        
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Range(1,16,ErrorMessage = "Party size is limited to 1- 16")]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }

        [Required, StringLength(1,MinimumLength = 1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }

        //NAvigation porperties
        public virtual SpecialEvent Event { get; set; }

        //the reservationtables is a many to many relationship to tables table
        // the sql reservationstable resolves this problem
        //however reservationstable  holds only a compound PK
        //We will not create a reservationtable entity in our project
        //but handele it via navigation mapping
        // therefore we will place a Icollection properties in
        //this entity refering to the tables table

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Bill> Bills{ get; set; }
    }
}
