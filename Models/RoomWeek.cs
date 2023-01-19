using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class RoomWeek
    {
        public int ID { get; set; }
        public int WeekId { get; set; }
        public int RoomId { get; set; }
        public virtual Week Weeks { get; set; }

        public virtual Room Room { get; set; }
    }
}
