<Query Kind="Program">
  <Connection>
    <ID>9ce9a7d8-b99a-41be-8f51-0fbda42bc83b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// List tables and unpaid bill #s for walk-ins only
void Main()
{
    var result = from data in Tables
    select new Stuff()
    {
        Table = "Table " + data.TableNumber.ToString(),
        NotPaid = data.Bills.Any(x=>x.PaidStatus == false),
        Bill = data.Bills.FirstOrDefault(x=>x.PaidStatus == false),
        BillID = data.Bills.Any(x=>x.PaidStatus==false) ?
                 data.Bills.SingleOrDefault(x=>x.PaidStatus == false).BillID
                 : 0
                 
    };
    result.Dump();
}

// Define other methods and classes here
// My DTO
public class Stuff
{
    public string Table {get;set;}
    public bool NotPaid {get;set;}
    public Bills Bill {get;set;}
    public int BillID {get;set;}
    public string Name
    {
        get
        {
            if(BillID == 0) return "nada";
            else return Table + " (" + BillID + ")";
        }
    }
}
