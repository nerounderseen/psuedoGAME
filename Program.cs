using System;
using System.Collections.Generic;

namespace psuedoGAME
{
    class Program
    {
        static string tempUsername = string.Empty;
        static string tempPassword = string.Empty;
        static bool shouldExit = false;
        static bool shouldLogout = false;
        static void Main(string[] args)
        {
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to psuedoRAGNAROK\n\n");
                Console.WriteLine("Select Option");
                switch (ShowMenu("[Register]", "[Login]", "[Exit]"))
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("[REGISTRATION]\n");
                        Console.Write("Username: ");
                        tempUsername = Console.ReadLine().ToLower().Trim();
                        Console.Write("Password: ");
                        tempPassword = Console.ReadLine().ToLower().Trim();
                        Console.Clear();
                        Console.WriteLine("[REGISTRATION]\n");
                        Console.Write("Successfully Registered\n\nReturning to Main Screen");
                        Console.ReadKey();
                        break;
                    case '2':
                        while (!shouldLogout)
                        {
                            Console.Clear();
                            Console.WriteLine("[LOGIN]\n");
                            Console.Write("Username: ");
                            tempUsername = Console.ReadLine().ToLower().Trim();
                            Console.Write("Password: ");
                            tempPassword = Console.ReadLine().ToLower().Trim();
                            Console.Clear();
                            Console.WriteLine("[LOGIN]\n");
                            Console.WriteLine("Entering World\n");
                            Console.WriteLine("Select Option");
                            switch (ShowMenu("[Create Character]", "[Select Character]", "[Exit]"))
                            {
                                case '1':
                                    break;
                                case '2':
                                    break;
                                case '3':
                                    shouldLogout = true;
                                    break;
                            }
                        }
                        break;
                    case '3':
                        shouldExit = true;
                        break;
                }
            }
        }

        static char ShowMenu(params string[] items)
        {
            string menuString = "";
            for (int i = 0; i < items.Length; i++)
            {
                string postFix = i == items.Length - 1 ? string.Empty : ", ";
                menuString += $"{i + 1} to {items[i]}{postFix}";
            }
            Console.Write($"{menuString}: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            return key.KeyChar;
        }
    }
}
