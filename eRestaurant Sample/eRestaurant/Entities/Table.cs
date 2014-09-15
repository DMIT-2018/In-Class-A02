using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities
{
    public class Table
    {
        public Table()
        {
            Available = true;
        }

        // In EF, by convention, if there is a property with the same name as the class but with the suffix ID, then EF will assume that this property is mapping to a Primary Key column on the database tables
        public int TableID { get; set; }
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        #region Navigation Properties
        public virtual ICollection<Reservation> Reservations { get; set; }
        #endregion
    }
}
