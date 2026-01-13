using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_Projektuppgift_Grupp32
{
    internal class BookingMenu
    {
        internal static void TodaysBookings()
        {

            var today = DateTime.Now.Date;
            bool found = false;

            foreach (var booking in Data.BookedList)
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

            //Visa datum och tid
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

            //Loopa igenom och visa tjänsterna
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
            Data.BookedList.Add(booking);

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
                    foreach (var booking in Data.BookedList)
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
            if (Data.BookedList.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns just nu.");
                return;
            }
            //Visa alla bokningar
            Console.WriteLine("Alla bokningar: ");
            foreach (Booking booking in Data.BookedList)
            {
                Console.WriteLine($"{booking}");
            }

            Console.WriteLine("Vilken kunds bokning ska tas bort? (För och efternamn måste matcha)");
            string namn = Console.ReadLine();

            bool found = false;

            //Loopar igenom bokningarna och tar bort den som matchar namnet
            for (int i = 0; i < Data.BookedList.Count; i++)
            {
                if (Data.BookedList[i].Costumer.Name == namn)
                {
                    Data.BookedList.RemoveAt(i);
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
            if (Data.BookedList.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns just nu.");
                return;
            }

            Console.WriteLine("Alla bokningar: ");
            foreach (Booking booking in Data.BookedList)
            {
                Console.WriteLine($"{booking}");
            }
            Console.WriteLine("Tryck på enter för att återgå till menyn...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
