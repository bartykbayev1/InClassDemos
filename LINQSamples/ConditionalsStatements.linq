<Query Kind="Expression">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

//simple where clause

//list all tables that hold more than 3 people
from row in Tables 
where row.Capacity > 3 
select row

//list all items that are with more 500 calories
from foodies in Items
where foodies.Calories > 500
select foodies

//list all items that are with more 500 calories and selling for more than 10 dollars
from foodies in Items
where foodies.Calories > 500 && foodies.Calories >10.00m
select foodies


//list all items that are with more 500 calories and selling for more than 10 dollars
// are Entrees on the menu 
//hint: navigational properties  of the database  and Linqpad knowledge 
from foodies in Items
where foodies.Calories > 500 &&
		foodies.MenuCategory.Description.Equals("Entree")
select foodies