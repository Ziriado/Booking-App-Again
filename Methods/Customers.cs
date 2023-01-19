using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Booking.Methods
{
    internal class Customers
    {
        public static void BookRoom()
        {
            var inputWeek = 0;
            var inputDay = 0;
            var inputBookingID= 0;
            using (var db = new RoomContext())
            {
                var roomCount = db.Rooms.ToList();
                var weekCount = db.Weeks.ToList();
                var dayCount = db.Days.ToList();
                var roomIDCount =db.DayWeeks.ToList();
                Views.ShowIdWeek();
                Console.Write("Enter the week you want to book: ");
                inputWeek = Helpers.TryNumber(inputWeek, weekCount.Count(), 1);
                Console.Clear();
                Views.ShowIdDay();
                Console.Write("Enter the id of the day you want to book: ");
                inputDay = Helpers.TryNumber(inputDay, dayCount.Count(), 1);
                Console.Clear();
                Views.ShowFreeDays(inputWeek,inputDay);
                Console.Write("Enter the id of the room you wish to book it only works on free rooms: ");
                inputBookingID = Helpers.TryNumber(inputBookingID);
                var data = db.DayWeeks.ToList();
                var orderUpdated = db.DayWeeks.Where(x => x.Id == inputBookingID).OrderBy(x => x.Id).LastOrDefault();
                var number = orderUpdated;

                
                if (data[inputBookingID-1].Isbooked == false)
                {
                    Console.Write("Enter your name: ");
                    string name = Helpers.CheckStringInput();
                    Console.Write("Enter the company name: ");
                    string companyName=Helpers.CheckStringInput();
                    var newBooker = new Booker()
                    {
                        Name= name,
                        CompanyName= companyName,
                        DayWeek = data[inputBookingID-1]
                    };
                    db.Add(newBooker);
                    db.SaveChanges();
                  
                    var dataBooker = db.Bookers.ToList();
                   
                    int count=db.Bookers.Max(x => x.Id);
                    

                    
                    data[inputBookingID-1].Isbooked= true;
                    data[inputBookingID - 1].BookerDayID = count;

                    db.SaveChanges();
                   

                }
                else
                {
                    Console.WriteLine("That room is already booked.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menues.RunProgram();
                }
                
            }
        }
    }
}
