using eRestaurant.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class AdHocController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DateTime GetLastBillDateTime()
        {
            using (var context = new RestaurantContext())
            {
                var result = context.Bills.Max(x => x.BillDate);
                return result;
            }
        }
    }
}
