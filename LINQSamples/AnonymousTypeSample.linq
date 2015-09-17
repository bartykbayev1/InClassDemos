<Query Kind="Program">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

 //anonymous type

void Main(){
//
Waiters.Dump();
//
//from food in Items 
//where food.MenuCategory.Description.Equals("Entree")
//	&& food.Active
//orderby food.CurrentPrice descending
//select new 
//	{
//	Description = food.Description,
//	Price = food.CurrentPrice,
//	Cost = food.CurrentCost,
//	Profit = food.CurrentPrice - food.CurrentCost
//	}
//	
////another sample
//
//from food in Items 
//where food.MenuCategory.Description.Equals("Entree")
//	&& food.Active
//orderby food.CurrentPrice descending
//select new 
//	{
//	 food.Description,
//	food.CurrentPrice,
//	food.CurrentCost,
//	//food.CurrentPrice - food.CurrentCost
//	}
	
	//type query set
	var results = from food in Items 
		where food.MenuCategory.Description.Equals("Entree")
			&& food.Active
		orderby food.CurrentPrice descending
		select new FoodMargin()
			{
			Description = food.Description,
			Price = food.CurrentPrice,
			Cost = food.CurrentCost,
			Profit = food.CurrentPrice - food.CurrentCost
			};
	
	
	var results2 = from orders in Bills
					where orders.PaidStatus && 
						(orders.BillDate.Month ==9 && orders.BillDate.Year ==2014)
					orderby orders.Waiter.LastName, orders.Waiter.FirstName
					select new BillOrders() {
						BillID = orders.BillID,
						Waiter = orders.Waiter.LastName + " , " + orders.Waiter.FirstName,
						Orders = orders.BillItems						
					};
		
	results2.Dump();
}

//define other methids 
//sample of a POCO type class: flat data set no structures
public class FoodMargin {

	public string Description{get;set;}
	public decimal Price{get;set;}
	public decimal Cost{get;set;}
	public decimal Profit{get;set;}
}


//sample of a DTOs type class: flat data set with possible structures
public class BillOrders {

	public int BillID{get;set;}
	public string Waiter{get;set;}
	public IEnumerable Orders{get;set;}
}