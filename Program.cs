using System;
using System.Collections.Generic;

namespace psuedoGAME
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static string charName = string.Empty;
        static string charJob = string.Empty;
        static string tempUsername = string.Empty;
        static string tempPassword = string.Empty;
        static bool shouldExit = false;
        static Account account;
        static Character character;
        static Job job;
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
                        AccountRegister();
                        break;
                    case '2':
                        {
                            Console.Clear();
                            Console.WriteLine("[LOGIN]\n");
                            Console.Write("Username: ");
                            tempUsername = Console.ReadLine().ToLower().Trim();
                            Console.Write("Password: ");
                            tempPassword = Console.ReadLine().ToLower().Trim();
                            account = GetAccount(tempUsername, tempPassword);
                            if (account != null)
                            {
                                bool shouldLogout = false;
                                while (!shouldLogout)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Welcome to psuedoRAGNAROK\n\n");
                                    Console.WriteLine("Select Option");
                                    switch (ShowMenu("[Create Character]", "[Select Character]", "[Exit]"))
                                    {
                                        case '1':
                                            Console.Clear();
                                            Console.WriteLine("Welcome to psuedoRAGNAROK\n\n");
                                            Console.Write("Character Name: ");
                                            charName = Console.ReadLine().Trim();
                                            Console.Clear();
                                            Console.WriteLine("Welcome to psuedoRAGNAROK\n\n");
                                            Console.Write("Select a Job");
                                            foreach (var job in job.jobList)
                                            {
                                                Console.Write($"{job}");
                                            }
                                            break;
                                        case '2':
                                            break;
                                        case '3':
                                            shouldLogout = true;
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("[LOGIN]\n");
                                Console.WriteLine("Incorrect Username/Passowrd...");
                                Console.ReadKey();
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
        static Account GetAccount(string uName, string pWord)
        {
            foreach (Account account in accountList)
            {
                if (account.username == uName && account.password == pWord)
                    return account;
            }
            return null;
        }
        static void AccountRegister()
        {
            Console.Clear();
            Console.WriteLine("[REGISTRATION]\n");
            Console.Write("Username: ");
            tempUsername = Console.ReadLine().ToLower().Trim();
            Console.Write("Password: ");
            tempPassword = Console.ReadLine().ToLower().Trim();
            if (accountList.Exists(x => x.username != null) && accountList.Exists(x => x.username == tempUsername))
            {
                Console.Clear();
                Console.WriteLine("[REGISTRATION]\n");
                Console.Write("Username is already taken...\nReturning to Main Screen...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                accountList.Add(new Account { username = tempUsername, password = tempPassword });
                Console.WriteLine("[REGISTRATION]\n");
                Console.Write("Successfully Registered\n\nReturning to Main Screen...");
                Console.ReadKey();
            }
        }
    }
}
