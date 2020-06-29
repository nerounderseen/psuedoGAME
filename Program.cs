using System;
using System.Collections.Generic;

namespace psuedoGAME
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static string tempUserN = string.Empty;
        static string tempPassW = string.Empty;
        static string tempIGN = string.Empty;
        static Account account;
        static Character character;
        static bool shouldExit = false;
        static void Main(string[] args)
        {
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n\n");
                switch (ShowMenu("[Register]", "[Login]", "[Forgot Password]", "[Exit]"))
                {
                    case '1':
                        AccountRegister();
                        break;
                    case '2':
                        Login();
                        break;
                    case '3':
                        Console.Clear();
                        break;
                    case '4':
                        shouldExit = true;
                        break;
                }
            }
        }
        static void AccountRegister()
        {
            Console.Clear();
            Console.WriteLine("REGISTRATION - psuedoRAGANAROK.offline\n");
            Console.Write("Enter Username: ");
            tempUserN = Console.ReadLine().Trim();
            Console.Write("Enter Password: ");
            tempPassW = Console.ReadLine().Trim();
            accountList.Add(new Account { username = tempUserN, password = tempPassW });
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("LOGIN - psuedoRAGANAROK.offline\n");
            Console.Write("Username: ");
            tempUserN = Console.ReadLine().Trim();
            Console.Write("Password: ");
            tempPassW = Console.ReadLine().Trim();
            account = GetAccount(tempUserN, tempPassW);
            if (account != null)
            {
                bool shouldLogout = false;
                while (!shouldLogout)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n\n");
                    Console.WriteLine("Select Option");
                    switch (ShowMenu("[Create Character]", "[Select Character]", "[Delete Character]", "[Exit]"))
                    {
                        case '1':
                            CreateChar();
                            break;
                        case '2':
                            SelectChar();
                            break;
                        case '3':
                            break;
                        case '4':
                            shouldLogout = true;
                            break;
                    }
                }
            }
        }

        static void CreateChar()
        {
            Console.Clear();
            Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n\n");
            Console.Write("Character Name: ");
            tempIGN = Console.ReadLine().Trim();
            Console.Write("Select Gender [M] [F]: ");
            ConsoleKeyInfo genderSelect = Console.ReadKey();
            Console.Write("");
            account.CharacterCreate(tempIGN, genderSelect.KeyChar);
        }

        static void SelectChar()
        {
            Console.Clear();
            Console.WriteLine("psuedoRAGNAROK.offline\n\n");
            Console.WriteLine("Character Select");
            Console.WriteLine("----------------------------------------");
            if (account.ShowChar().Length != 0)
            {
                foreach (Character identity in account.ShowChar())
                {
                    Console.WriteLine($"IGN: {identity.name}\tJob: {identity.job}\nBase Level: {identity.baselevel}\tJob Level: {identity.baselevel}");
                    Console.WriteLine($"STR: {identity.str}\t\tAGI: {identity.agi}\t\tVIT: {identity.vit}");
                    Console.WriteLine($"INT: {identity.intel}\t\tDEX: {identity.dex}\t\tLUK: {identity.luk}");
                    Console.WriteLine("----------------------------------------");
                }
                Console.Write("Select Character Name: ");
                tempIGN = Console.ReadLine();
                character = GetCharacter(tempIGN);
                CharDisplay();
            }
            else
            {
                Console.WriteLine("No Characters to Show...");
                Console.WriteLine("----------------------------------------");
                Console.ReadLine();
            }
        }

        static void CharDisplay()
        {
            bool shouldChangeChar = false;
            while (!shouldChangeChar)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n");
                Console.WriteLine($"IGN: {character.name}\tJob: {character.job}\tBase LVL: {character.baselevel}\tJob LVL: {character.joblevel}");
                Console.WriteLine($"\t\tSTR: {character.str}\t\tAGI: {character.agi}\t\tVIT: {character.vit}");
                Console.WriteLine($"\t\tINT: {character.intel}\t\tDEX: {character.dex}\t\tLUK: {character.luk}\n\n");
                switch (ShowMenu("[Add Stats]", "[Access Inventory]", "[Mail Item]", "[Kafra Storage]", "[Change Character]"))
                {
                    case '1':
                        AddStats();
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        shouldChangeChar = true;
                        break;
                }
            }
        }

        static void AddStats()
        {
            bool shouldReturn = false;
            while (!shouldReturn)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n");
                Console.WriteLine($"IGN: {character.name}\t\tStat Points: {character.freePoints}");
                Console.WriteLine($"\tSTR: {character.str}\t\tAGI: {character.agi}\t\tVIT: {character.vit}");
                Console.WriteLine($"\tINT: {character.intel}\t\tDEX: {character.dex}\t\tLUK: {character.luk}\n");
                switch (ShowMenu("[+STR]", "[+AGI]", "[+VIT]", "[+INT]", "[+DEX]", "[+LUK]", "[Character Page]"))
                {
                    case '1':
                        character.AddSTR();
                        break;
                    case '2':
                        character.AddAGI();
                        break;
                    case '3':
                        character.AddVIT();
                        break;
                    case '4':
                        character.AddINT();
                        break;
                    case '5':
                        character.AddDEX();
                        break;
                    case '6':
                        character.AddLUK();
                        break;
                    case '7':
                        shouldReturn = true;
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

        static Character GetCharacter(string ign)
        {
            foreach (Character character in account.ShowChar())
            {
                if (character.name == ign)
                    return character;
            }
            return null;
        }
    }
}