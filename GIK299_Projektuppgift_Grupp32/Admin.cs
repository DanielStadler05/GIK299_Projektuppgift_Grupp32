using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_Projektuppgift_Grupp32
{
    internal class AdminClass
    {
    internal static void Admin()
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
}
