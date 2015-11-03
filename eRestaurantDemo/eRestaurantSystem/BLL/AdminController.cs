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
                              orderby item.FirstName
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
        //wa problem with class with the same name
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<eRestaurantSystem.Entities.POCO.CategoryMenuItem> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Category.Description, cat.Description
                              select new CategoryMenuItem
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

        #endregion

        //another sample of report

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<WaiterBilling> GetWaiterBillingReport()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from abillrow in context.Bills
                              where abillrow.BillDate.Month == 5
                              orderby abillrow.BillDate, abillrow.Waiter.LastName, abillrow.Waiter.FirstName
                              select new WaiterBilling
                              {
                                  BillDate = abillrow.BillDate.Year + "/" +
                                                          abillrow.BillDate.Month + "/" +
                                                          abillrow.BillDate.Day,
                                  Name = abillrow.Waiter.LastName + ", " + abillrow.Waiter.FirstName,
                                  BillID = abillrow.BillID,
                                  BillTotal = abillrow.Items.Sum(bitem => bitem.Quantity * bitem.SalePrice),
                                  PartySize = abillrow.NumberInParty,
                                  Contact = abillrow.Reservation.CustomerName
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

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
        public int Waiter_Add(Waiter item)
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
                //added contains the data of newly added waiter
                //including pkey value
                return added.WaiterID;
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

        //ux
        #region FrontDesc

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DateTime GetLastBillDateTime()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var result = context.Bills.Max(x => x.BillDate);
                return result;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ReservationCollection> ReservationsByTime(DateTime date)
        {
            using (var context = new eRestaurantContext())
            {
                var result = (from data in context.Reservations
                              where data.ReservationDate.Year == date.Year
                              && data.ReservationDate.Month == date.Month
                              && data.ReservationDate.Day == date.Day
                                  // && data.ReservationDate.Hour == timeSlot.Hours
                              && data.ReservationStatus == Reservation.Booked
                              select new ReservationSummary()
                              {
                                  ID = data.ReservationID,
                                  Name = data.CustomerName,
                                  Date = data.ReservationDate,
                                  NumberInParty = data.NumberInParty,
                                  Status = data.ReservationStatus,
                                  Event = data.Event.Description,
                                  Contact = data.ContactPhone
                              }).ToList();
                //second part of these method using the result of the first link query.
                //link to entity will only execute the query when it deems necessery for having the result
                //in memory

                //to get youor query to execute and have resulting data inside memory for further use
                //u can attach the .ToList() to the previous query
 
                //the second query is NOT using entity. Its using the results a previous query

                //itemGroup is a temporary in memory data collection
                //this collection can be used in selecting your final 
                //data collection
                var finalResult = from item in result
                                  orderby item.NumberInParty
                                  group item by item.Date.Hour into itemGroup
                                  select new ReservationCollection()
                                  {
                                      Hour = itemGroup.Key,
                                      Reservations = itemGroup.ToList()
                                  };
                return finalResult.OrderBy(x => x.Hour).ToList();
            }
        }


        #endregion
    }
}
