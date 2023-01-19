using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class DayWeek
    {
        //Var Icollection på allt
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int DayId { get; set; }
        public bool Isbooked { get; set; } = false;
        public int? BookerDayID { get; set; }
        public int RoomID { get; set; }

        public virtual Week Week { get; set; }
        public virtual  Day Day { get; set; }
        public virtual ICollection<Booker> Bookers { get; set; }

    }
}
