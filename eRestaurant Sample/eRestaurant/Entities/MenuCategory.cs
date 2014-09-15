using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> MenuItems { get; set; }
    }
}
