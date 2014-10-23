<Query Kind="Statements">
  <Connection>
    <ID>50e535df-8b6d-4a21-b5d3-dfde364563ec</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var result = from info in BillItems
             orderby info.Item.MenuCategory.Description, info.Item.Description
			 select new
			 {
			 	CategoryDescription = info.Item.MenuCategory.Description,
				ItemDescription = info.Item.Description,
				Quantity = info.Quantity,
				Price = info.SalePrice * info.Quantity,
				Cost = info.UnitCost * info.Quantity
			 };
result.Count().Dump();
result.Dump();