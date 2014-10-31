using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.DTOs
{
    public class ReservationCollection
    {
        public int Hour { get; set; }
        public TimeSpan Time { get { return new TimeSpan(Hour, 0, 0); } }
        public List<ReservationSummary> Reservations { get; set; }
    }
}
