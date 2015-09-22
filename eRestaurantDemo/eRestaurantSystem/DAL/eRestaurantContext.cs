using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using System.Data.Entity;
#endregion

namespace eRestaurantSystem.DAL
{   
    //this class should be restricted to a access by only the BLL methods
    //this class should not be accessible outside of the component library

    internal class eRestaurantContext : DbContext
    {
        public eRestaurantContext() : base("name=EatIn") 
        {
            //constructor is used to pass web config name
        }
        //setup the DbSet Mapping

        //one DbSet for each entity
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        //when overriding OnModeCreating(), it is important to remember to call
        //the base method's implementation before you exit the method

        //the ManyToManyNavigationPropertyConfiguratoin.Map method lets you 
        //configure the tables and columns used for many to many relationship
        //it takes a ManyToManyNavigationPropertyConfiguratoin insatance in which
        //you specify the column names b calling the MapLeftKEy, MapRightKEy
        // and To Table MEthods


        //left key is the one specified in the hasMany Method
        //left key is the one specified in the WithMany Method

        //we have many to many relationship between  reservation and tables
        // a reservation may need many tables
        //a table can have over time many reservations

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("ReservationID");
                    mapping.MapRightKey("TableID");
                });
            base.OnModelCreating(modelBuilder);
        }




    }
}
