using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.POCOs
{
    public class CategoryMenuItem
    {
        public string Comment { get; set; }
        public int? Calories { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }
        public string CategoryDescription { get; set; }
    }
}
