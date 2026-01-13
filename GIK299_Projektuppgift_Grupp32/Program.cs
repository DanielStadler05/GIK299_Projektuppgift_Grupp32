using System.Globalization;

namespace GIK299_Projektuppgift_Grupp32
{
    public class Start
    {
        internal static List<Booking> BookedList = new List<Booking>();

        internal static void Main()
        {
            // Bokningar i november 2025
            Start.BookedList.AddRange(new List<Booking>
            {
                new Booking(
                    new DateTime(2025, 11, 26, 10, 0, 0),
                    Services.Däckbyte,
                    new Costumers("Anna Svensson", "GIK299", "070-1234567")
                ),
                new Booking(
                    new DateTime(2025, 11, 26, 14, 0, 0),
                    Services.Balansering,
                    new Costumers("Erik Johansson", "XYZ123", "073-9876543")
                ),
                new Booking(
                    new DateTime(2025, 11, 28, 9, 0, 0),
                    Services.Däckhotell,
                    new Costumers("Lisa Karlsson", "ABC456", "072-5556667")
                ),
                new Booking(
                    new DateTime(2025, 11, 29, 12, 0, 0),
                    Services.Hjulintställning,
                    new Costumers("Jonas Lind", "DEF789", "076-8889990")
                )
            });

                // Bokningar för "idag"
                var today = DateTime.Now.Date;

                Start.BookedList.AddRange(new List<Booking>
            {
                new Booking(
                    new DateTime(today.Year, today.Month, today.Day, 10, 0, 0),
                    Services.Däckbyte,
                    new Costumers("Mikael Andersson", "MKA001", "070-1112233")
                ),
                new Booking(
                    new DateTime(today.Year, today.Month, today.Day, 14, 0, 0),
                    Services.Balansering,
                    new Costumers("Sofia Berg", "SOB002", "073-4445566")
                ),
                // Bokning för imorgon (ska inte visas idag)
                new Booking(
                    today.AddDays(1).AddHours(9),
                    Services.Däckhotell,
                    new Costumers("Peter Nilsson", "PEN003", "072-7778899")
                )
            });


            //Logga in på adminpanelen
            while (true)
            {
                Console.WriteLine("---Adminpanel---");
                Console.Write("Lösenord: ");
                string AdminPassword = Console.ReadLine();

                //Om lösenordet är rätt starta programmet
                if (AdminPassword == "admin123")
                {
                    Console.Clear();
                    //Startar menyn
                    Menu.StartMenu();
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
                Console.WriteLine("4. Ta bort bokning via namn");
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
            
            var today = DateTime.Now.Date;
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
            Console.WriteLine("Lägg till en ny bokning");

            // --- Datum och tid ---
            DateTime planedTime;
            while (true)
            {
                Console.Write("Ange datum och tid (ÅÅÅÅ-MM-DD HH:mm): ");
                if (DateTime.TryParse(Console.ReadLine(), out planedTime))
                {
                    break;
                }
                Console.WriteLine("Fel format, försök igen!");
            }

            // --- Välj tjänst ---
            Console.WriteLine("Välj tjänst:");
            var services = Enum.GetValues(typeof(Services));
            for (int i = 0; i < services.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {services.GetValue(i)}");
            }

            Services service;
            while (true)
            {
                Console.Write("Ange nummer för tjänst: ");
                if (int.TryParse(Console.ReadLine(), out int serviceChoice) &&
                    serviceChoice >= 1 && serviceChoice <= services.Length)
                {
                    service = (Services)services.GetValue(serviceChoice - 1);
                    break;
                }
                Console.WriteLine("Fel val, försök igen!");
            }

            //Skriv in kundens namn, registreringsnummer och telefonnummer
            Console.Write("Ange kundens namn: ");
            string name = Console.ReadLine();

            Console.Write("Ange registreringsnummer: ");
            string registration = Console.ReadLine();

            Console.Write("Ange telefonnummer: ");
            string phone = Console.ReadLine();

            //Skapa Costumer så den passar konstruktorn
            var costumer = new Costumers(name, registration, phone);

            // Skapa Booking så den passar konstruktorn och lägg till listan
            var booking = new Booking(planedTime, service, costumer);
            Start.BookedList.Add(booking);

            Console.WriteLine("\nBokningen är tillagd!");
            Console.WriteLine(booking);

            Console.WriteLine("\nTryck på enter för att återgå till menyn...");
            Console.ReadLine();
            Console.Clear();
        }


        internal static void SearchBookings()
        {
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

                //Visa bokningar inom dom angivna datumintervallen
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
            if (Start.BookedList.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns just nu.");
                return;
            }

            Console.WriteLine("Alla bokningar: ");
            foreach (Booking booking in Start.BookedList)
            {
                Console.WriteLine($"{booking}");
            }

            Console.WriteLine("Vilken kunds bokning ska tas bort? (För och efternamn måste matcha)");
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

            Console.WriteLine("Tryck på enter för att återgå till menyn...");
            Console.ReadLine();
            Console.Clear();
        }
        


        internal static void AllBookings()
        {
            if (Start.BookedList.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns just nu.");
                return;
            }

            Console.WriteLine("Alla bokningar: ");
            foreach (Booking booking in Start.BookedList)
            {
                Console.WriteLine($"{booking}");
            }
            Console.WriteLine("Tryck på enter för att återgå till menyn...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}