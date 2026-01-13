using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_Projektuppgift_Grupp32
{
    internal class Get
    {
        internal static void BookedTime()
        {
            bool GotTimeFalse = false;
            while (!GotTimeFalse)
            {
                Console.WriteLine("Skriv datum på kundens bokning (åååå-MM-dd HH)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime TimeWhenBooked))
                {
                    foreach (var t in Program.BookedList)
                    {
                        if (t.PlanedTime == TimeWhenBooked)
                        {
                            //forsätt här
                        }
                    }
                    Console.Clear();
                    GotTimeFalse = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel format (åååå-MM-dd HH)");
                }
            }
        }

        internal static void Customer()
        {
            bool NameFalse = false;
            while (!NameFalse)
            {
                Console.WriteLine("Skriv namnet på bokningen:");
                string Name = Console.ReadLine();

                if (Name.Any(Char.IsDigit))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. No numbers.");
                }
                else
                {
                    Console.Clear();
                    NameFalse = true;
                }
            }
            bool Phone = false;
            while (!Phone)
            {
                Console.WriteLine("Skriv Telefonnumert på kunden");
                if (int.TryParse(Console.ReadLine(), out int PhoneNumber))
                {
                    Console.Clear();
                    Phone = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Numbers only.");
                }
            }

            bool RegFalse = false;
            while (!RegFalse)
            {
                Console.WriteLine("Skriv in kundes registreringsnumber");
                string Registration = Console.ReadLine();

                if (Registration.Length == 6)
                {
                    Console.Clear();
                    RegFalse = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel antal måste vara 6 tecken");
                }
            }
        }
    }
}