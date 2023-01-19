using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Methods
{
    internal class Menues
    {
        enum MainMenu
        {
            Admin_Page = 1,
            Book_Room,
            Exit = 0
        }
        enum AdminMenu
        {
            Create_Room = 1,
            See_Name_Of_All_Rooms,
            See_Room_Specific_Week_And_Day,
            Queries,
            Insert_Hard_Coded_Values,
            Return = 0
        }

        enum Queries_Menu
        {
            See_Amount_Of_Bookings=1,
            See_Amount_Of_Empty_Room,
            Amount_Free_That_Week,
            Amount_Booked_One_Week,
            Return=0
        }
        public static void RunProgram()
        {
            bool run = true;

            while (run)
            {
                foreach (int i in Enum.GetValues(typeof(MainMenu)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(MainMenu), i).Replace('_', ' ')}");
                }
                int nr;
                MainMenu menu = (MainMenu)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (MainMenu)nr;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }
                switch (menu)
                {
                    case MainMenu.Admin_Page:
                        AdminPage();
                        break;
                    case MainMenu.Book_Room:
                        Customers.BookRoom();
                        break;
                    case
                        MainMenu.Exit:
                        run = false;
                        break;
                }
            }
        }
        public static void AdminPage()
        {
            bool run = true;
            while (run)
            {
                foreach (int i in Enum.GetValues(typeof(AdminMenu)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(AdminMenu), i).Replace('_', ' ')}");
                }

                int nr;
                AdminMenu menu = (AdminMenu)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (AdminMenu)nr;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }

                switch (menu)
                {
                    case AdminMenu.Create_Room:
                        Admin.CreateRoom();
                        break;
                    case AdminMenu.See_Name_Of_All_Rooms:
                        Views.ShowRooms();
                        break;
                    case AdminMenu.See_Room_Specific_Week_And_Day:
                        Views.ShowRoomWithBookedRooms();
                        break;
                    case AdminMenu.Queries:
                        QueriesPage();
                        break;
                    case AdminMenu.Insert_Hard_Coded_Values:
                        Methods.HardCoded.InsertHardCodedValues();
                        break;
                    case AdminMenu.Return:
                        run = false;
                        break;
                }
            }
        }
        public static void QueriesPage()
        {
            bool run = true;
            while (run)
            {
                foreach (int i in Enum.GetValues(typeof(Queries_Menu)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(Queries_Menu), i).Replace('_', ' ')}");
                }

                int nr;
                Queries_Menu menu = (Queries_Menu)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (Queries_Menu)nr;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }

                switch (menu)
                {
                    case Queries_Menu.See_Amount_Of_Bookings:
                        Admin.LinqAmountBooked();
                        break;
                    case Queries_Menu.See_Amount_Of_Empty_Room:
                        Admin.LinqFreeAmount();
                        break;
                    case Queries_Menu.Amount_Free_That_Week:
                        Admin.FreeRoomsOneWeek();
                        break;
                    case Queries_Menu.Amount_Booked_One_Week:
                        Admin.BookedOneWeek();
                        break;
                    case Queries_Menu.Return:
                        run= false; 
                        break;
                    
                   
                }
            }
        }
    }
}
