<Query Kind="Statements">
  <Connection>
    <ID>50e535df-8b6d-4a21-b5d3-dfde364563ec</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var data = from cat in MenuCategories
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
			};
data.Dump("Menu Items by Category");
// .Dump() is an extension method that is available in LinqPad - don't expect to see it in
// your Visual Studio solution...
			