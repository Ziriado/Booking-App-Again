using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DayWeek> DaysWeeks { get; set; }
        
    }
}
