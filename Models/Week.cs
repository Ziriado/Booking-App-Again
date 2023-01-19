using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class Week
    {
        public int Id { get; set; }
        public int WeekNr { get; set; }

        public virtual ICollection<DayWeek> DayWeeks { get; set; }
        public virtual ICollection<RoomWeek>RoomWeeks{ get; set; }
        
    }
}
