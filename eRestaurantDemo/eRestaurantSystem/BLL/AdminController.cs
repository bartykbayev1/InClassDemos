using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;//use for ODS Access
using System.Data.Entity;
using eRestaurantSystem.Entities.DTOs;
using eRestaurantSystem.Entities.POCO;
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        #region Query Samples


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the special events table
                //to do so we will use DbSet eRestaurantContext
                //call SpecialEvent (done by mapping)

                //method syntax 
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;

                return results.ToList();
               
            }
        }
        /// <summary>
        // Method 
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiter_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the special events table
                //to do so we will use DbSet eRestaurantContext
                //call SpecialEvent (done by mapping)

                //method syntax 
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax
                var results = from item in context.Waiters
                              select item;

                return results.ToList();

            }
        }
        //Method for waier to getByID
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiterByID(int waiterid)
        {
            using (var context = new eRestaurantContext())
            {

                var results = from item in context.Waiters
                              where item.WaiterID.Equals(waiterid)
                              
                              select item;

                return results.FirstOrDefault();

            }
        }



        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
                
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;

                return results.ToList();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationByDate> GetReservationByDate(string reservationdate)
        {
            using (var context = new eRestaurantContext())
            {
                //remmeber LINQ does not like using dateTime casting
                int theYear = (DateTime.Parse(reservationdate)).Year;
                int theMonth= (DateTime.Parse(reservationdate)).Month;
                int theDay = (DateTime.Parse(reservationdate)).Day;

                //query status
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate() //DTO
                              {
                                  Description = item.Description,
                                  Reservation = from row in item.Reservations //collection of navigated rows of ICollection
                                                //in Special Event entity
                                                where row.ReservationDate.Year == theYear 
                                                        && row.ReservationDate.Month == theMonth
                                                        && row.ReservationDate.Day == theDay
                                                        select new ReservationDetail () //POCO class
                                                        {
                                                            CustomerName = row.CustomerName,
                                                            ReservationDate = row.ReservationDate,
                                                            NumberInParty = row.NumberInParty,
                                                            ReservationStatus = row.ReservationStatus,
                                                            ContactPhone = row.ContactPhone

                                                        }
                              };
                return results.ToList();
            }
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> CategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
               
                //query status
                var results = from category in context.MenuCategories
                              orderby category.Description
                              select new CategoryMenuItems() //DTO
                              {
                                  Description = category.Description,
                                  MenuItems = from row in category.MenuItems //collection of navigated rows of ICollection
                                                //in Special Event entity
                                                
                                                select new MenuItem() //POCO class
                                                {
                                                    Description = row.Description,
                                                    Price =row.CurrentPrice,
                                                    Calories =row.Calories,
                                                    Comment = row.Comment
                                                    

                                                }
                              };
                return results.ToList();
            }
        }

        #endregion

        #region CRUD Insert, Update, Delete

        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set pointer to null
                SpecialEvent added = null;

                //set up the add request for DBContext
                added = context.SpecialEvents.Add(item);

                //saving the changes will cause .Add to execute
                //commits the add to the database
                //evaluates the annotations (validation) on your entity

                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
               //look th eitem instance on th edatabase to detemine if the insatnce exist
                //on the delete make sure u have PK name
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);


                //set up the data command request 
                existing = context.SpecialEvents.Remove(existing);

                //commit the action to happen
                context.SaveChanges();

            }
        }


        //waiter CRUD

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Waiter_Add(Waiter item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set pointer to null
                Waiter added = null;

                //set up the add request for DBContext
                added = context.Waiters.Add(item);

                //saving the changes will cause .Add to execute
                //commits the add to the database
                //evaluates the annotations (validation) on your entity

                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiter_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<Waiter>(context.Waiters.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiter_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //look th eitem instance on th edatabase to detemine if the insatnce exist
                //on the delete make sure u have PK name
                Waiter existing = context.Waiters.Find(item.WaiterID);


                //set up the data command request 
                existing = context.Waiters.Remove(existing);

                //commit the action to happen
                context.SaveChanges();

            }
        }
        #endregion
    }
}
