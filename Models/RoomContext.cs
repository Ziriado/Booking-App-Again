using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Booking.Models
{
    public  class RoomContext : DbContext
    {
        public DbSet <Day> Days{ get; set; }
        public DbSet <Week> Weeks { get; set; }
        public DbSet <Room> Rooms { get; set; }
        public DbSet <Booker> Bookers { get; set; }
        public DbSet< RoomWeek> RoomWeeks { get; set; }
        public DbSet< DayWeek> DayWeeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:mybooking9993.database.windows.net,1433;Initial Catalog=myBooking9993;Persist Security Info=False;User ID=christoffergustafssonadmin;Password=Hejsanmicke123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
