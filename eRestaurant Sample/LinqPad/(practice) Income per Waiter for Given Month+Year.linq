<Query Kind="Statements">
  <Connection>
    <ID>9ce9a7d8-b99a-41be-8f51-0fbda42bc83b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Income brought in per Waiter for a given month/year
var month = 9;
var monthName = "September";
var year = 2014;

var data = from info in Bills
           where info.BillDate.Month == month
              && info.BillDate.Year == year
           select new
           {
               Name = info.Waiter.LastName + " " + info.Waiter.FirstName,
               BillTotal = info.BillItems.Sum(bi => bi.Quantity * bi.SalePrice)
           };
//data.Dump();
var report = from info in data
			 group info by info.Name into infoGroup
			 select new
		{
			Person = infoGroup.Key,
			Total = infoGroup.Sum(grp => grp.BillTotal)
		};
report.Dump("Income collected for " + monthName + " " + year);		