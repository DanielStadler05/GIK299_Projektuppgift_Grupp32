using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_Projektuppgift_Grupp32
{
    internal class Data
    {
        internal static List<Booking> BookedList = new List<Booking>();

        // Lägg till exempel bokningar
        static Data()
        {
            BookedList.AddRange(new List<Booking>
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

            // Lägg till exempel bokningar idag
            var today = DateTime.Now.Date;

            BookedList.AddRange(new List<Booking>
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
        }
    }
}
