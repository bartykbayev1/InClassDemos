<Query Kind="Expression">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//anonymous type

from food in Items 
where food.MenuCategory.Description.Equals("Entree")
	&& food.Active
orderby food.CurrentPrice descending
select new 
	{
	Description = food.Description,
	Price = food.CurrentPrice,
	Cost = food.CurrentCost,
	Profit = food.CurrentPrice - food.CurrentCost
	}
	
//another sample

from food in Items 
where food.MenuCategory.Description.Equals("Entree")
	&& food.Active
orderby food.CurrentPrice descending
select new 
	{
	 food.Description,
	food.CurrentPrice,
	food.CurrentCost,
	//food.CurrentPrice - food.CurrentCost
	}