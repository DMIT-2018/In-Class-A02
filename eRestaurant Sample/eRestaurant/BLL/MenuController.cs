using eRestaurant.DAL;
using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // needed for the Lambda version of .Include() method

namespace eRestaurant.BLL
{
    [DataObject]
    public class MenuController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Item> ListMenuItems()
        {
            using (var context = new RestaurantContext())
            {
                // Get the Item data and include the Category data for each item
                return context.Items.Include(x => x.Category).ToList();






                // The .Include() method on the DbSet<T> class performs "eager loading" of data.
            }
        }
    }
}
