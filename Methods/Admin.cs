using Booking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Booking.Methods
{
    internal class Admin
    {
        static string connString = "Server=tcp:mybooking9993.database.windows.net,1433;Initial Catalog=myBooking9993;Persist Security Info=False;User ID=christoffergustafssonadmin;Password=Hejsanmicke123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static void CreateRoom()
        {
            int size = 0;
            Console.Write("Enter the room name: ");
            string roomName = Helpers.CheckStringInput();
            Console.Write("Enter the size of the room: ");
            size = Helpers.TryNumber(size, 30000, 1);

            using (var myDb = new RoomContext())
            {
                var newRoom = new Room()
                {
                    RoomName = roomName,
                    Size = size

                };
                myDb.Add(newRoom);
                myDb.SaveChanges();
                InsertAllWeeks();
                HardCoded.HardCodedInsertDaysAndWeeks();
                Console.Clear();
            }
        }
        private static void InsertAllWeeks()
        {
            using (var myDb = new RoomContext())
            {
                var weekList = myDb.Weeks.ToList();
                var room = myDb.Rooms;
                var lasIdRoom = room.ToList().Count();
                for (int i = 0; i < weekList.Count; i++)
                {
                    var weekId = weekList[i].WeekNr;

                    var sql = $"INSERT INTO RoomWeeks Values({weekId},{lasIdRoom})";
                    using (var connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        connection.Execute(sql);
                        connection.Close();
                    }

                }
            }
        }
        public static void LinqAmountBooked()
        {
            using (var db = new RoomContext())
            {
                var result = db.DayWeeks.Where(x=>x.Isbooked==true).ToList();

                var count=result.Count;

                Console.WriteLine("Rooms booked "+count);
            }         
        }

        public static void LinqFreeAmount()
        {
            using (var db = new RoomContext())
            {
                var result = db.DayWeeks.Where(x => x.Isbooked == false).ToList();

                var count = result.Count;

                Console.WriteLine("Rooms not booked " + count);
            }
        }

        public static void FreeRoomsOneWeek()
        {
            using (var db = new RoomContext())
            {
                var weeklist = db.Weeks.ToList();
                var input = 0;
                Views.ShowIdWeek();
                Console.Write("Enter the id of the week you want to browse: ");
                input = Helpers.TryNumber(input, weeklist.Count, 1);
                var result = db.DayWeeks.Where(x => x.Isbooked == false && x.WeekId==input).ToList();

                var count = result.Count;

                Console.WriteLine("Rooms free " + count);
            }
        }

        public static void BookedOneWeek()
        {
            using (var db = new RoomContext())
            {
                var weeklist = db.Weeks.ToList();
                var input = 0;
                Views.ShowIdWeek();
                Console.Write("Enter the id of the week you want to browse: ");
                input = Helpers.TryNumber(input, weeklist.Count, 1);
                var result = db.DayWeeks.Where(x => x.Isbooked == true && x.WeekId == input).ToList();

                var count = result.Count;

                Console.WriteLine("Rooms booked " + count);
            }
        }
    }
}
