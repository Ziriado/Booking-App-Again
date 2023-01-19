using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models
{
    [Index(nameof(RoomName), IsUnique = true)]
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int Size { get; set; }
        public virtual ICollection<RoomWeek> RoomWeeks { get; set; }
        

    }
}
