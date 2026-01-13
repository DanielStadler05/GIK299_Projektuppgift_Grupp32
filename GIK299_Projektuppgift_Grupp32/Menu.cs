using GIK299_Projektuppgift_Grupp32;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_Projektuppgift_Grupp32
{
    internal class Start
    {
        internal static List<Booking> Booking = new List<Booking>();
        internal static void Main()
        {
            //Logga in på adminpanelen
            while (true)
            {
                Console.WriteLine("---Adminpanel---");
                Console.Write("Lösenord: ");
                string AdminPassword = Console.ReadLine();

                //Om lösenordet är rätt starta programmet
                if (AdminPassword == "admin123")
                {
                    while (true)
                    {
                        Console.Clear();
                        //Startar menyn
                        Menu.StartMenu();
                    }
                }
                else
                {
                    Console.WriteLine("FEL lösenord");
                }
            }
        }
    }
}
internal class Menu
{
    internal static void StartMenu()
    {
        while (true)
        {
            Console.WriteLine("---Adminpanel---");
            Console.WriteLine("1. Visa dagens bokningar");
            Console.WriteLine("2. Lägg till en ny bokning");
            Console.WriteLine("3. Sök ledinga bokningar");
            Console.WriteLine("4. Ta bort bokning vid tid");
            Console.WriteLine("5. Visa alla bokningar");
            Console.WriteLine("0. Avsluta Programmet");

            if (int.TryParse(Console.ReadLine(), out int Choice))
            {
                switch (Choice)
                {
                    case 1:
                        BookingMenu.TodaysBookings();
                        break;

                    case 2:
                        BookingMenu.AddBooking();
                        break;

                    case 3:
                        BookingMenu.SearchBookings();
                        break;

                    case 4:
                        BookingMenu.RemoveBooking();
                        break;

                    case 5:
                        BookingMenu.AllBookings();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Fel inmatning endast number mellan 0-5"); //Check if int 6 as a input does run this code
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Fel inmatning endast number mellan 0-5");
            }
        }
    }
}