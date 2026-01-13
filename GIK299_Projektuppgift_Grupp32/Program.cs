using System.Globalization;

namespace GIK299_Projektuppgift_Grupp32
{
    public class Start
    {
        internal static List<Booking> BookedList = new List<Booking>();
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
                    Console.Clear();
                    Console.WriteLine("FEL lösenord");
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
                Console.WriteLine("3. Sök lediga bokningar");
                Console.WriteLine("4. Ta bort bokning vid tid");
                Console.WriteLine("5. Visa alla bokningar");
                Console.WriteLine("0. Avsluta Programmet");
                Console.Write("Type the number: ");

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
    internal class BookingMenu
    {
        internal static void TodaysBookings()
        {
            DateTime today = DateTime.Now.Date;
            bool found = false;

            foreach (var booking in Start.BookedList)
            {
                if (booking.PlanedTime.Date == today)
                {
                    Console.WriteLine(booking);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Inga bokningar idag");
            }

            Console.WriteLine("\nTryck på enter för att återgå till menyn...");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void AddBooking()
        {

        }

        internal static void SearchBookings()
        {
            Start.BookedList.AddRange(new List<Booking>
{
    new Booking
    {
        Service = Services.Däckbyte,
        PlanedTime = new DateTime(2025, 11, 26, 10, 0, 0),
        Costumer = new Costumers
        {
            Name = "Anna Svensson",
            Registration = "GIK299",
            PhoneNumber = "070-1234567"
        }
    },
    new Booking
    {
        Service = Services.Balansering,
        PlanedTime = new DateTime(2025, 11, 26, 14, 0, 0),
        Costumer = new Costumers
        {
            Name = "Erik Johansson",
            Registration = "XYZ123",
            PhoneNumber = "073-9876543"
        }
    },
    new Booking
    {
        Service = Services.Däckhotell,
        PlanedTime = new DateTime(2025, 11, 28, 9, 0, 0),
        Costumer = new Costumers
        {
            Name = "Lisa Karlsson",
            Registration = "ABC456",
            PhoneNumber = "072-5556667"
        }
    },
    new Booking
    {
        Service = Services.Hjulintställning,
        PlanedTime = new DateTime(2025, 11, 29, 12, 0, 0),
        Costumer = new Costumers
        {
            Name = "Jonas Lind",
            Registration = "DEF789",
            PhoneNumber = "076-8889990"
        }
    }
});

            {
                Console.WriteLine("Sök tider");
                DateTime startDate;
                DateTime endDate;

                // Startdatum
                while (true)
                {
                    Console.Clear();
                    Console.Write("Ange startdatum för sökning (ÅÅÅÅ-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out startDate))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Fel format. Ange datum i formatet ÅÅÅÅ-MM-DD");
                }

                // Slutdatum         
                while (true)
                {                    
                    Console.Write("Ange slutdatum för sökning (ÅÅÅÅ-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out endDate))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Fel format. Ange datum i formatet ÅÅÅÅ-MM-DD");
                }

                if (startDate > endDate)
                {
                    Console.Clear();
                    Console.WriteLine("Startdatum kan inte vara efter slutdatum. Tryck på enter för att återgå till menyn...");
                    Console.ReadLine();
                    return;
                }

                for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
                {
                    Console.WriteLine($"{date:yyyy-MM-dd} ");

                    bool found = false;

                    //Sök bokningar för just den dagen
                    foreach (var booking in Start.BookedList)
                    {
                        if (booking.PlanedTime.Date == date)
                        {
                            Console.WriteLine($"{booking}");
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Inga bokningar");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Tryck på enter för att återgå till menyn...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        internal static void RemoveBooking()
        {
            Console.WriteLine("Vilken kunds bokning ska tas bort?");
            string namn = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < Start.BookedList.Count; i++)
            {
                if (Start.BookedList[i].Costumer.Name == namn)
                {
                    Start.BookedList.RemoveAt(i);
                    Console.WriteLine("Bokning togs bort!");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Ingen bokning med detta namn hittades.");
            }
        }
        


        internal static void AllBookings()
        {
            if (Start.BookedList.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns just nu.");
                return;
            }

            Console.WriteLine("--- Alla bokningar ---");
            foreach (Booking booking in Start.BookedList)
            {
                Console.WriteLine(
                    $"Tid: {booking.PlanedTime:yyyy/MM/dd HH:mm}, " +
                    $"Tjänst: {booking.Service}, " +
                    $"Kund: {booking.Costumer}");
            }

        }
    }
}