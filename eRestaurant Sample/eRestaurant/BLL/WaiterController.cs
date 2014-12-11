using eRestaurant.DAL;
using eRestaurant.Entities;
using eRestaurant.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class WaiterController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ListDataItem> ListActiveBills()
        {
            using (var context = new RestaurantContext())
            {
                var result = from data in context.Bills
                             where !data.PaidStatus
                                && data.Items.Count() > 0
                             select new ListDataItem()
                             {
                                 DisplayText = data.BillID.ToString() + " (Table " + data.Table.TableNumber.ToString() + ")",
                                 KeyValue = data.BillID
                             };
                return result.ToList();
            }
        }

        public Order GetBill(int billId)
        {
            using (var context = new RestaurantContext())
            {
                var result = from data in context.Bills
                             where data.BillID == billId
                             select new Order()
                             {
                                 BillID = data.BillID,
                                 Items = (from info in data.Items
                                         select new OrderItem()
                                         {
                                             ItemName = info.Item.Description,
                                             Price = info.SalePrice,
                                             Quantity = info.Quantity
                                         }).ToList()
                             };
                return result.FirstOrDefault();
            }
        }

        public void SplitBill(int billId, List<OrderItem> updatesToOriginalBillItems, List<OrderItem> newBillItems)
        {
            // TODO: Actually go through and split that bill into two
            using (var context = new RestaurantContext())
            {
                // TODO: 0) Validation :)
                // 1) Get the bill
                var bill = context.Bills.Find(billId);
                if (bill == null) throw new ArgumentException("Invalid Bill ID - does not exist");

                // 2) Loop through bill items, if item not in original, remove
                List<BillItem> toMove = new List<BillItem>();
                foreach(var item in bill.Items) // the items already in the DB
                {
                    bool inOriginal = updatesToOriginalBillItems.Any(x => x.ItemName == item.Item.Description);
                    bool inNewItems = newBillItems.Any(x => x.ItemName == item.Item.Description);
                    if(!inOriginal)
                    {
                        // TODO: clean
                        if (!inNewItems)
                            throw new Exception("Hey - someone's got to pay for that!");
                        toMove.Add(item);
                    }
                }
                foreach (var item in toMove)
                    context.BillItems.Remove(item);

                // 3) Make a new bill
                var newBill = new Bill()
                {
                    BillDate = bill.BillDate,
                    Comment = "Split from bill# " + bill.BillID,
                    NumberInParty = bill.NumberInParty, // meh 
                    OrderPlaced = bill.OrderPlaced,
                    OrderReady = bill.OrderReady,
                    OrderServed = bill.OrderServed,
                    WaiterID = bill.WaiterID
                    // TODO: thorny question about rules around splitting bill for a single table vs. reservation
                };

                // 4) Add the new missing items to the new bill
                foreach(var item in toMove)
                {
                    newBill.Items.Add(new BillItem()
                        {
                            ItemID = item.ItemID,
                            Notes = item.Notes,
                            Quantity = item.Quantity,
                            SalePrice = item.SalePrice,
                            UnitCost = item.UnitCost                            
                        });
                }

                // 5) Add the new bill to the context
                context.Bills.Add(newBill);

                // 6) hope for the best.
                context.SaveChanges();
            }
        }
    }
}
