<Query Kind="Expression" />

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
	Profit = food.CurrentPrice - foof.CurrentCost
	}