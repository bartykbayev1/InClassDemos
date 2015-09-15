<Query Kind="Expression">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//oderby

//default ascending
from food in Items 
orderby food.Description
select food

//default ascending
from food in Items 
orderby food.CurrentPrice descending
select food

//default ascending
from food in Items 
where food.MenuCategory.Description.Equals("Entree")
orderby food.CurrentPrice descending, food.Calories ascending
select food