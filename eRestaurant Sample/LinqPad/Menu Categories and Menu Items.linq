<Query Kind="Expression">
  <Connection>
    <ID>50e535df-8b6d-4a21-b5d3-dfde364563ec</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from cat in MenuCategories
orderby cat.Description
select new
{
    Description = cat.Description,
	MenuItems = from food in cat.Items
	            where food.Active
	            select new
				{
					Description = food.Description,
					Price = food.CurrentPrice
				}
}