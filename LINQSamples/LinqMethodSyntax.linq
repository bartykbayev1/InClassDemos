<Query Kind="Expression">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters



//query syntax 
from item in Waiters 
select item


//method syntax to view 
Waiters
   .Select (item => item)
//Waiters.Select (item => item.datafield==5)

//alter the query syntax into a C# statement 
var results = from item in Waiters select item;
results.Dump();


//once query is created, tested u will be able to transfer th e query with minor modifications into your bll methods
public List<pocoObject> SomeBllMethodName()
{
//connect to your DAL object: var contexvariable
//do your query 

var results = from item in contexvariable.Waiters select item;
return results.ToList();
}