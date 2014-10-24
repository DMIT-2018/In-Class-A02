using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.DTOs
{
    public class Order
    {
        public int TableNumber { get; set; }
        public string Waiter { get; set; }
        public int WaiterID { get; set; }
        public int? BillID { get; set; }
        public bool Served { get; set; }
        public string OrderComments { get; set; }
        // YOUDO: Create a property called TotalAmount which will
        //        sum up the item totals in the Items collection.
        //        Remember to check if Items is null.
        //        Use a LINQ method .Sum() with a lambda to get the total.
        public decimal TotalAmount
        {
            get
            {
                decimal value = 0; // default value
                if (Items != null)
                    value = Items.Sum(x => x.ItemTotal); // See footnote #1

                return value;
            }
        }

        public IList<OrderItem> Items { get; set; }
    }
}
/* Footnotes:
 *  #1: A labmda expression is just an inline anonymous function call.
 *      The following lambda expression:
            Items.Sum(x => x.ItemTotal)
        
 *      is the same as this inline delegate:
            Items.Sum(  delegate(OrderItem x)
                        {
                            return x.ItemTotal;
                        }
                     )
         
 *      and the same as:
            // GetItemTotal is the name of a method; it must be cast because it cannot be automatically inferred
            Items.Sum((Func<OrderItem, decimal>)GetItemTotal)
            ...
            private static decimal GetItemTotal(OrderItem x)
            {
                return x.ItemTotal;
            }
  
 * 
 */