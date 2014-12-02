<Query Kind="Statements">
  <Connection>
    <ID>9ce9a7d8-b99a-41be-8f51-0fbda42bc83b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Update the database to make the last few paid bills to be un-paid...
var result = from data in  Bills
//where data.BillDate >= new DateTime(2014, 10, 24, 21, 30, 0)
where data.BillDate >= Bills.Max(x=>x.BillDate).AddMinutes(-30)
&& data.TableID != null
select data;
foreach(var info in result)
{
    info.PaidStatus = false;
    info.OrderPaid = null;
    SubmitChanges();
}
result.Dump();