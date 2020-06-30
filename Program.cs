using System;

namespace psuedoGAME
{
    class Program
    {
        static string username;
        static string tempIGN;
        static string password;
        static int pin;
        static Game newAccount = new Game();
        static Account account;
        static Character character;

        static void Main(string[] args)
        {
            bool shouldTerminate = false;
            while (!shouldTerminate)
            {
                Console.Clear();
                Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n\n");
                switch (ShowMenu("[Register]", "[Login]", "[Forgot Password]", "[Exit]"))
                {
                    case '1':
                        RegisterAccnt();
                        break;
                    case '2':
                        Login();
                        break;
                    case '3':
                        ForgotPassword();
                        break;
                    case '4':
                        shouldTerminate = true;
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

        static void RegisterAccnt()
        {
            Console.Clear();
            Console.WriteLine("REGISTER - psuedoRAGNAROK.offline\n");
            Console.Write("Enter Username: ");
            username = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            Console.Write("Enter Secure PIN: ");
            int.TryParse(Console.ReadLine(), out pin);
            newAccount.Registration(username, password, pin);
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("LOGIN - psuedoRAGNAROK.offline\n");
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            account = newAccount.Login(username, password);
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
                            CreateCharacter();
                            break;
                        case '2':
                            SelectCharacter();
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

        static void ForgotPassword()
        {
            Console.Clear();
            Console.WriteLine("FORGOT PASSWORD - psuedoRAGNAROK.offline\n");
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Secure PIN: ");
            int.TryParse(Console.ReadLine(), out pin);
            account = newAccount.ForgotPassword(username, pin);
            Console.WriteLine($"\nAccount Username: {account.username}\nAccount Password: {account.password}");
            Console.ReadLine();
        }

        static void CreateCharacter()
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

        static void SelectCharacter()
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
                character = account.GetCharacter(tempIGN);
                DisplayCharacter();
            }
            else
            {
                Console.WriteLine("No Characters to Show...");
                Console.WriteLine("----------------------------------------");
                Console.ReadLine();
            }
        }

        static void DisplayCharacter()
        {
            bool shouldChangeChar = false;
            while (!shouldChangeChar)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n");
                Console.WriteLine($"IGN: {character.name}\tJob: {character.job}\tBase LVL: {character.baselevel}\tJob LVL: {character.joblevel}");
                Console.WriteLine($"\t\tSTR: {character.str}\t\tAGI: {character.agi}\t\tVIT: {character.vit}");
                Console.WriteLine($"\t\tINT: {character.intel}\t\tDEX: {character.dex}\t\tLUK: {character.luk}\n\n");
                switch (ShowMenu("[Add Stats]", "[Access Inventory]", "[Kafra]", "[Change Character]"))
                {
                    case '1':
                        AddStats();
                        break;
                    case '2':
                        DisplayCharacterInventory();
                        break;
                    case '3':
                        KafraCorp();
                        break;
                    case '4':
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

        static void DisplayCharacterInventory()
        {
            Console.Clear();
            Console.WriteLine("psuedoRAGNAROK.offline\n");
            Console.WriteLine($"IGN: {character.name}");
            Console.WriteLine("Quantity\tItem Name");
            if (character.ShowInventory().Count > 0)
            {
                foreach (Inventory item in character.ShowInventory())
                {
                    Console.WriteLine($"{item.quantity}\t\t{item.name}[{item.slot}]");
                }
                Console.ReadLine();
            }
        }

        static void KafraCorp()
        {
            bool shouldTerminate = false;
            while (!shouldTerminate)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n\n");
                Console.WriteLine($"Welcome to Kafra Corp [{character.name}]!\nHow can I be of service?..\n\n");
                switch (ShowMenu("[Mail Item]", "[Access Storage]", "[Good Bye...]"))
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        shouldTerminate = true;
                        break;
                }
            }
        }

    }
}
