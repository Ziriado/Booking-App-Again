using Booking.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Security.Cryptography.X509Certificates;

namespace Booking.Methods
{
    internal class HardCoded
    {
        static string connString = "Server=tcp:mybooking9993.database.windows.net,1433;Initial Catalog=myBooking9993;Persist Security Info=False;User ID=christoffergustafssonadmin;Password=Hejsanmicke123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static void InsertHardCodedValues()
        {
            HardCodedDays();
            HardCodedWeek();
            //HardCodedInsertDaysAndWeeks();
        }
        private static void HardCodedDays()
        {
            using (var myDb = new RoomContext())
            {
                myDb.AddRange(
                    new Day() { Name = "Måndag" },
                    new Day() { Name = "Tisdag" },
                    new Day() { Name = "Onsdag" },
                    new Day() { Name = "Torsdag" },
                    new Day() { Name = "Fredag" }
                    
                    );
                myDb.SaveChanges();
            }
        }
        private static void HardCodedWeek()
        {
            using (var myDb = new RoomContext())
            {
                myDb.AddRange(
                    new Week() { WeekNr = 1 },
                    new Week() { WeekNr = 2 },
                    new Week() { WeekNr = 3 },
                    new Week() { WeekNr = 4 },
                    new Week() { WeekNr = 5 },
                    new Week() { WeekNr = 6 }
                
                    );
                myDb.SaveChanges();
            }
        }
        //fixa
        public static void HardCodedInsertDaysAndWeeks()
        {
            using (var database = new RoomContext())
            {
                int id = 0;
                int weekNr = 0;
                var dayList = database.Days.ToList();
                var weekList = database.Weeks.ToList();
                int boolFalse = 0;
                var room=database.Rooms.ToList();
                var lasIdRoom = room.ToList().Count();

               

                for (int j = 0; j < weekList.Count; j++)
                {
                    for (int i = 0; i < dayList.Count; i++)
                    {
                        weekNr = weekList[j].WeekNr;
                        id = dayList[i].Id;
                        var sql = $"INSERT INTO DayWeeks (WeekId,DayId,IsBooked,RoomId) Values({weekNr},{id},{boolFalse},{lasIdRoom})";
                        using (var connection = new SqlConnection(connString))
                        {
                            connection.Open();
                            connection.Execute(sql);
                            connection.Close();
                        }

                    }
                }
            }
        }
    }
}
