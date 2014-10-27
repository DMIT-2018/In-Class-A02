<Query Kind="Statements">
  <Connection>
    <ID>9ce9a7d8-b99a-41be-8f51-0fbda42bc83b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Find out information on the tables in the restaurant at a specific date/time

// Create a date and time object to use for sample input data
var date = Bills.Max(b => b.BillDate).Date;
var time = Bills.Max(b => b.BillDate).TimeOfDay.Add(new TimeSpan(0, 30, 0));
date.Add(time).Dump("The test date/time I am using");

// Step 1 - Get the table info along with any walk-in bills and reservation bills for the specific time slot
var step1 = from data in Tables
             select new
             {
                Table = data.TableNumber,
                Seating = data.Capacity,
                // This sub-query gets the bills for walk-in customers
                Bills = from billing in data.Bills
                        where 
                               billing.BillDate.Year == date.Year
                            && billing.BillDate.Month == date.Month
                            && billing.BillDate.Day == date.Day
                            && billing.BillDate.TimeOfDay <= time
                            && (!billing.OrderPaid.HasValue || billing.OrderPaid.Value >= time)
//                          && (!billing.PaidStatus || billing.OrderPaid >= time)
                        select billing,
                 // This sub-query gets the bills for reservations
                 Reservations = from booking in data.ReservationTables
                        from billing in booking.Reservation.Bills
                        where 
                               billing.BillDate.Year == date.Year
                            && billing.BillDate.Month == date.Month
                            && billing.BillDate.Day == date.Day
                            && billing.BillDate.TimeOfDay <= time
                            && (!billing.OrderPaid.HasValue || billing.OrderPaid.Value >= time)
//                          && (!billing.PaidStatus || billing.OrderPaid >= time)
                        select billing
             };
step1.Dump();

// Step 2 - Union the walk-in bills and the reservation bills while extracting the relevant bill info
// .ToList() helps resolve the "Types in Union or Concat are constructed incompatibly" error
var step2 = from data in step1.ToList() // .ToList() forces the first result set to be in memory
            select new
            {
                Table = data.Table,
                Seating = data.Seating,
                CommonBilling = from info in data.Bills.Union(data.Reservations)
                                select info
            };
step2.Dump();

































