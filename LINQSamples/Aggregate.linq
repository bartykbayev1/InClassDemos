<Query Kind="Expression">
  <Connection>
    <ID>e78c719d-3025-46c9-bbbf-9e89144d4d5c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from category in MenuCategories
select new
{
    Category = category.Description,
    Items = category.Items.Count()
}

//query syntax
from category in MenuCategories
select new
{
    Category = category.Description,
    Items = (from x in category.Items select x).Count()
}

(from theBill in BillItems
where theBill.BillID == 104
select theBill.SalePrice * theBill.Quantity).Sum()


BillItems
    .Where (theBill => theBill.BillID == 104)
    .Select(theBill => theBill.SalePrice * theBill.Quantity)
    .Sum()	
	
from customer in Bills
where customer.BillID == 104
select customer.BillItems.Sum (theBill => theBill.SalePrice * theBill.Quantity)


//1
from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum (theBill => theBill.SalePrice * theBill.Quantity)

//2continie

(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum (theBill => theBill.SalePrice * theBill.Quantity)).Max()

	
(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Count()).Average()


//conversions
