using Booking.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Methods
{
    internal class Views
    {

        public static void ShowRooms()
        {
            using (var database = new RoomContext())
            {
                var room = database.Rooms;
                Console.WriteLine("Id \t\t Name\n-----------------------------");
                foreach (var c in room)
                {
                    Console.WriteLine(c.Id + "\t\t" + c.RoomName);
                }
            }
        }
        public static void ShowIdDay()
        {
            using (var database = new RoomContext())
            {
                var day = database.Days;
                Console.WriteLine("Id \t\t Day\n-----------------------------");
                foreach (var c in day)
                {
                    Console.WriteLine(c.Id + "\t\t" + c.Name);
                }
            }
        }
        public static void ShowIdWeek()
        {
            using (var database = new RoomContext())
            {
                var week = database.Weeks;
                Console.WriteLine("Id \t\t Week\n-----------------------------");
                foreach (var c in week)
                {
                    Console.WriteLine(c.Id + "\t\t" + c.WeekNr);
                }
            }
        }
        public static void ShowFreeDays(int input, int dayinput)
        {
            using (var connection = new RoomContext())
            {
                var result = (
                    from dayWeek in connection.DayWeeks
                    join days in connection.Days on dayWeek.DayId equals days.Id
                    join room in connection.Rooms on dayWeek.RoomID equals room.Id

                    where dayWeek.WeekId == input && dayWeek.DayId == dayinput
                    select new { DayOfWeeks = dayWeek, Days = days, Rooms = room }
                    );
                int pad = 20;
                int pad3 = 19;
               
                Console.WriteLine("Booking ID".PadRight(pad)+"Room Name".PadRight(pad)+"Week".PadRight(pad)+"Day".PadRight(pad)+
                    "Size".PadRight(pad)+"Booked");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------\n");
                foreach (var c in result)
                {
                    Console.WriteLine(c.DayOfWeeks.Id + "".PadRight(pad3) + c.Rooms.RoomName.ToString().PadRight(pad) + 
                        c.DayOfWeeks.WeekId.ToString().PadRight(pad)
                        + c.Days.Name +"".PadRight(13) + 
                        c.Rooms.Size.ToString().PadRight(pad) +
                        (c.DayOfWeeks.Isbooked == false ? "Free" : "Booked"));
                }
                Console.WriteLine();
            }
        }

        public static void ShowInfoWithBookers(int weekInput, int dayinput)
        {
            using (var connection = new RoomContext())
            {

                var result = (
                    from dayWeek in connection.DayWeeks
                    join days in connection.Days on dayWeek.DayId equals days.Id
                    join room in connection.Rooms on dayWeek.RoomID equals room.Id
                    join booker in connection.Bookers on dayWeek.BookerDayID equals booker.Id
                    where dayWeek.WeekId == weekInput && dayWeek.DayId == dayinput
                    select new { DayOfWeeks = dayWeek, Days = days, Rooms = room, Bookers = booker }
                    );
                int pad = 20;
                int pad2 = 19;
                int pad3 = 10;
                int pad4 = 15;
                Console.WriteLine("Booking ID".PadRight(pad)+"Room Name".PadRight(pad)+"Week".PadRight(pad)+"Day".PadRight(pad)+"Booked".PadRight(pad)+
                    "Booker Name".PadRight(pad)+"Company Name");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
                foreach (var c in result)
                {
                    Console.WriteLine(c.DayOfWeeks.Id + "".PadRight(pad2) + c.Rooms.RoomName + "".PadRight(pad3) + c.DayOfWeeks.WeekId + "".PadRight(pad) +
                        c.Days.Name + "".PadRight(pad4) +
                        (c.DayOfWeeks.Isbooked == false ? "Free" : "Booked").PadRight(pad) + c.Bookers.Name + "".PadRight(pad4) + c.Bookers.CompanyName);
                }
            }
        }
        public static void ShowRoomWithBookedRooms()
        {
            var week = 0;
            var day = 0;
            using (var db = new RoomContext())
            {
                var weeklist = db.Weeks.ToList();
                var daylist = db.Days.ToList();
                ShowIdWeek();
                Console.Write("Enter the id of the week you want to browse: ");
                week=Helpers.TryNumber(week,weeklist.Count,1);
                Console.Clear();
                ShowIdDay();
                Console.Write("Enter the id of the day you want to brose: ");
                day = Helpers.TryNumber(day, daylist.Count, 1);
                Console.Clear();
                ShowInfoWithBookers(week,day);

            }
        }
    }
}
