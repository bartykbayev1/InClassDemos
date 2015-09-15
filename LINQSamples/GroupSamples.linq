<Query Kind="Expression">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//group

from food in Items
group food by food.MenuCategory.Description

// required the creation fo anonymous type
from food in Items
group food by new {food.MenuCategory.Description, food.CurrentPrice}