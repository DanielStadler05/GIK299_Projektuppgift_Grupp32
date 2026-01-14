using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GIK299_Projektuppgift_Grupp32
{
    internal class AdminClass
    {
        internal static void Admin()
        {
            // Pre-generated hash of "admin123"
            string storedHash = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9";

            while (true)
            {
                Console.WriteLine("---Adminpanel---");
                Console.Write("Lösenord: ");
                string input = Console.ReadLine();

                string inputHash = ComputeHash(input);

                if (inputHash == storedHash)
                {
                    Console.Clear();
                    Menu.StartMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("FEL lösenord");
                }
            }
        }

        static string ComputeHash(string text)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
