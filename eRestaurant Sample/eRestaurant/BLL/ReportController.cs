using eRestaurant.DAL;
using eRestaurant.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class ReportController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CategoryMenuItem> GetReportCategoryMenuItems()
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Category.Description, cat.Description
                              select new CategoryMenuItem()
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CategorizedItemSale> TotalCategorizedItemSales()
        {
            using( var context = new RestaurantContext())
            {
                var result = from info in context.BillItems
                             orderby info.Item.Category.Description, info.Item.Description
                             select new CategorizedItemSale()
                             {
                                 CategoryDescription = info.Item.Category.Description,
                                 ItemDescription = info.Item.Description,
                                 Quantity = info.Quantity,
                                 // Do the calculation in the LINQ Query
                                 Price = info.SalePrice * info.Quantity,
                                 Cost = info.UnitCost * info.Quantity
                             };
                return result.ToList();
            }
        }
    }
}
