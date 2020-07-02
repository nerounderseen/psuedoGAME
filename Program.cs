using System;

namespace psuedoGAME
{
    class Program
    {
        static string username;
        static string tempIGN;
        static string transferIGN;
        static string password;
        static string nPassword;
        static int pin;
        static int itemID;
        static int quantity;
        static Game newAccount = new Game();
        static Kafra kStoredItem;
        static Account xAccount = new Account();
        static Account account;
        static Character character;
        static Character transferChar = new Character();
        static Inventory inventoryItem;
        static Item item = new Item();
        static Item rItem;
        static Job job = new Job();

        static void Main(string[] args)
        {
            bool shouldTerminate = false;
            while (!shouldTerminate)
            {
                Console.Clear();
                Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n");
                switch (ShowMenu("[Register]", "[Login]", "[Change Password]", "[Forgot Password]", "[Exit]"))
                {
                    case '1':
                        RegisterAccnt();
                        break;
                    case '2':
                        Login();
                        break;
                    case '3':
                        ChangePassword();
                        break;
                    case '4':
                        ForgotPassword();
                        break;
                    case '5':
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
            account = newAccount.IsAccountExists(username);
            if (account == null)
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                Console.Write("Enter Secure PIN: ");
                if (int.TryParse(Console.ReadLine(), out pin))
                {
                    if ((!string.IsNullOrEmpty(username) || !string.IsNullOrWhiteSpace(username)) && (!string.IsNullOrEmpty(password) || !string.IsNullOrWhiteSpace(password)))
                    {
                        newAccount.Registration(username, password, pin);
                        Console.Clear();
                        Console.WriteLine("REGISTER - psuedoRAGNAROK.offline\n");
                        Console.Write("Account Successfully Registered...\nProceed to Login...\t");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("\nUsername/Password can't be Empty...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("\nSecured Pin is Invalid...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("REGISTER - psuedoRAGNAROK.offline\n");
                Console.Write("Username Already Exists");
                Console.ReadKey();
            }
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
                    Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n");
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
                            DeleteCharacter();
                            break;
                        case '4':
                            shouldLogout = true;
                            break;
                    }
                }
            }
            else
            {
                Console.Write("\nIncorrect Username/Password...");
                Console.ReadKey();
            }
        }

        static void ChangePassword()
        {
            Console.Clear();
            Console.WriteLine("CHANGE PASSWORD - psuedoRAGNAROK.offline\n");
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Old Password: ");
            password = Console.ReadLine();
            newAccount.PasswordCheck(password);
            if (newAccount != null)
            {
                Console.Write("New Password: ");
                nPassword = Console.ReadLine();
                newAccount.ChangePassword(username, password, nPassword);
                Console.Write("\n\nPassword Changed Successfully...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("\nEntered Password is Incorrect...\nReturning to Main Screen...");
                Console.ReadKey();
            }
        }

        static void ForgotPassword()
        {
            Console.Clear();
            Console.WriteLine("FORGOT PASSWORD - psuedoRAGNAROK.offline\n");
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Secured PIN: ");
            if (int.TryParse(Console.ReadLine(), out pin))
            {
                account = newAccount.SecuredPINCheck(pin);
                if (account != null)
                {
                    account = newAccount.ForgotPassword(username, pin);
                    Console.Write($"\nAccount Username: {account.username}\nAccount Password: {account.password}\t");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("\nAccount/Secured Pin is Invalid...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("\nSecured PIN is Invalid...");
                Console.ReadLine();
            }
        }

        static void CreateCharacter()
        {
            if (account.ShowChar().Length < 3)
            {
                Console.Clear();
                Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n");
                Console.Write("Character Name: ");
                tempIGN = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(tempIGN) || !string.IsNullOrWhiteSpace(tempIGN))
                {
                    character = newAccount.IsIGNExists(tempIGN);
                    if (character == null)
                    {
                        Console.Write("Select Gender [M] [F]: ");
                        ConsoleKeyInfo genderSelect = Console.ReadKey();
                        if (genderSelect.KeyChar == 'M' || genderSelect.KeyChar == 'm' || genderSelect.KeyChar == 'F' || genderSelect.KeyChar == 'f')
                        {
                            account.CharacterCreate(tempIGN, genderSelect.KeyChar);
                            Console.Clear();
                            Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n");
                            Console.Write("Character Successfully Created...\nProceed to Selection...\t");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\n\nYou can't possibly set your gender to Apache Attack Helicopter...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("psuedoRAGNAROK.offline\n");
                        Console.Write("IGN Already Exists");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("\nCharacter Name can't be Empty...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Welcome to psuedoRAGNAROK.offline\n");
                Console.Write("Maximum # of Characters Reached...\nReturning to Main Window...");
                Console.ReadKey();
            }
        }

        static void SelectCharacter()
        {
            Console.Clear();
            Console.WriteLine("psuedoRAGNAROK.offline\n");
            Console.WriteLine("Select Character");
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
                Console.Write("Enter Character Name: ");
                tempIGN = Console.ReadLine();
                character = newAccount.IsIGNExists(tempIGN);
                if (character != null)
                {
                    DisplayCharacter();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("psuedoRAGNAROK.offline\n");
                    Console.Write("IGN Doesn't Exists...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No Characters to Show...");
                Console.WriteLine("----------------------------------------");
                Console.ReadLine();
            }
        }

        static void DeleteCharacter()
        {
            Console.Clear();
            Console.WriteLine("psuedoRAGNAROK.offline\n");
            Console.WriteLine("Select Character to Delete");
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
                Console.Write("Enter Character Name: ");
                tempIGN = Console.ReadLine();
                character = newAccount.IsIGNExists(tempIGN);
                if (character != null)
                {
                    account.DeleteCharacter(tempIGN);
                    Console.Clear();
                    Console.WriteLine("psuedoRAGNAROK.offline\n");
                    Console.WriteLine("Character Deleted...\nReturning to Character Menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("psuedoRAGNAROK.offline\n");
                    Console.Write("IGN Doesn't Exists...");
                    Console.ReadKey();
                }
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
                switch (ShowMenu("[+Base LVL]", "[+Job LVL]", "[Add Stats]", "[Access Inventory]", "[Kafra]", "[Change Job]", "[Change Character]"))
                {
                    case '1':
                        character.IncBaseLVL();
                        break;
                    case '2':
                        character.IncJobLVL();
                        break;
                    case '3':
                        AddStats();
                        break;
                    case '4':
                        DisplayCharacterInventory();
                        break;
                    case '5':
                        KafraCorp();
                        break;
                    case '6':
                        ChangeJob();
                        break;
                    case '7':
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
                Console.WriteLine($"IGN: {character.name}");
                Console.WriteLine($"Base Level: {character.baselevel}\tJob Level: {character.joblevel}\t\tStat Points: {character.freePoints}");
                Console.WriteLine($"\t\tSTR: {character.str}\t\tAGI: {character.agi}\t\tVIT: {character.vit}");
                Console.WriteLine($"\t\tINT: {character.intel}\t\tDEX: {character.dex}\t\tLUK: {character.luk}\n");
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
            bool shouldExitBag = false;
            while (!shouldExitBag)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n");
                Console.WriteLine($"IGN: {character.name}");
                Console.WriteLine("Quantity\tItem Name");
                foreach (Inventory item in character.ShowInventory())
                {
                    Console.WriteLine($"{item.quantity}\t\t{item.name}[{item.slot}]");
                }
                Console.WriteLine();
                switch (ShowMenu("[Add Item]", "[Return to Character Screen]"))
                {
                    case '1':
                        AddItem();
                        break;
                    case '2':
                        shouldExitBag = true;
                        break;
                }
            }
        }

        static void AddItem()
        {
            Console.Clear();
            Console.WriteLine("psuedoRAGNAROK.offline\n");
            Console.WriteLine($"IGN: {character.name}");
            Console.WriteLine("Item ID\t\tItem Name");
            foreach (Item item in item.ShowItemList())
            {
                Console.WriteLine($"{item.id}\t\t{item.name}");
            }
            Console.Write("\nEnter Item ID: ");
            if (int.TryParse(Console.ReadLine(), out itemID))
            {
                Console.Write("Enter Quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity))
                {
                    rItem = item.GenerateItem(itemID, quantity);
                    if (rItem != null)
                    {
                        character.AddInventory(rItem);
                        Console.Write($"Added {quantity} {rItem.name} to Inventory");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("Item Doesn't Exist...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("\nEnter a Valid Item Quantity");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("\nEnter a Valid Item ID");
                Console.ReadLine();
            }
        }

        static void KafraCorp()
        {
            bool shouldTerminate = false;
            while (!shouldTerminate)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to Kafra Corp [{character.name}]!\nHow can I be of service?..\n\n");
                switch (ShowMenu("[Mail Item]", "[Access Storage]", "[Store Item]", "[Retrive Item]", "[Good Bye...]"))
                {
                    case '1':
                        ItemTransfer();
                        break;
                    case '2':
                        DisplayKafraStorage();
                        break;
                    case '3':
                        StoreItemKafra();
                        break;
                    case '4':
                        RetrieveItemKafra();
                        break;
                    case '5':
                        shouldTerminate = true;
                        break;
                }
            }
        }

        static void ChangeJob()
        {
            if (character.job == "Novice" && character.joblevel == 10)
            {
                Console.Clear();
                Console.WriteLine($"Select a First Job for {character.name}\n");
                Console.WriteLine($"Job Name\t\tJob Description");
                foreach (Job job in job.ShowFirstJobList())
                {
                    Console.WriteLine($"{job.name}\t\t{job.descript}");
                }
                Console.Write("\n\nSelect New Job: ");
                if (!int.TryParse(Console.ReadLine().ToLower(), out var x))
                {
                    string JobChange = x.ToString();
                    job = character.ChangeJob(character, JobChange);
                    if (job != null)
                    {
                        Console.Write($"UPDATE:[{character.name}] Job is now [{job.name}]...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("\nInvalid Job...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("\nInvalid Job...");
                    Console.ReadLine();
                }
            }
            else if (character.job != "Novice" && character.joblevel <= 50)
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n");
                Console.Write("Job Level 51 is needed to Change First Job...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("psuedoRAGNAROK.offline\n");
                Console.Write("Job Level 10 is needed to Change First Job...");
                Console.ReadKey();
            }
        }

        static void ItemTransfer()
        {
            Console.Clear();
            Console.WriteLine("Kafra Corp - Mailing Service\n");
            Console.WriteLine($"Which items you wish to be sent via MAIL [{character.name}]");
            Console.WriteLine("ItemID\t\tQuantity\t\tItem Name");
            foreach (Inventory item in character.ShowInventory())
            {
                Console.WriteLine($"{item.id}\t\t{item.quantity}\t\t{item.name}[{item.slot}]");
            }
            Console.Write("\nEnter Item ID: ");
            if (int.TryParse(Console.ReadLine(), out itemID))
            {
                inventoryItem = character.CheckItem(itemID);
                if (inventoryItem != null)
                {
                    Console.Write("Enter Quantity: ");
                    if (int.TryParse(Console.ReadLine(), out quantity))
                    {
                        if (inventoryItem.quantity >= quantity)
                        {
                            Console.Write("Mail to [Character Name]: ");
                            transferIGN = Console.ReadLine();
                            transferChar = newAccount.IsIGNExists(transferIGN);
                            if (transferChar != null)
                            {
                                character.DeductItem(itemID, quantity);
                                xAccount.ItemTransfer(transferChar, inventoryItem, quantity);
                                Console.Write($"\n[{transferChar.name}] has been sent [{quantity}] [{inventoryItem.name}]...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("Receiving Character doesn't Exists");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Write("\nItem quantity exceeds number of items in Inventory");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Write("\nEnter a Valid Item Quantity");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("\nItem not found in Inventory");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("\nEnter a Valid Item ID");
                Console.ReadKey();
            }
        }

        static void DisplayKafraStorage()
        {
            Console.Clear();
            Console.WriteLine("Kafra Corp - Storage Service\n");
            Console.WriteLine($"Storage of [{character.name}]");
            Console.WriteLine("ItemID\t\tQuantity\tItem Name");
            if (account.ShowStorage().Count != 0)
            {
                foreach (var item in account.ShowStorage())
                {
                    Console.WriteLine($"{item.id}\t\t{item.quantity}\t\t{item.name}[{item.slot}]");
                }
            }
            else
            {
                Console.Write("\n\nKafra Storage Empty");
            }
            Console.ReadKey();
        }

        static void StoreItemKafra()
        {
            Console.Clear();
            Console.WriteLine("Kafra Corp - Storage Service\n");
            Console.WriteLine("ItemID\tQuantity\t\tItem Name");
            foreach (var itemInv in character.ShowInventory())
            {
                Console.WriteLine($"{itemInv.id}\t{itemInv.quantity}\t\t{itemInv.name}[{itemInv.slot}]");
            }
            Console.Write("\nEnter Item ID: ");
            if (int.TryParse(Console.ReadLine(), out itemID))
            {
                inventoryItem = character.CheckItem(itemID);
                if (inventoryItem != null)
                {
                    Console.Write("Enter Quantity: ");
                    if (int.TryParse(Console.ReadLine(), out quantity))
                    {
                        if (quantity <= inventoryItem.quantity)
                        {
                            if (inventoryItem != null)
                            {
                                character.DeductItem(itemID, quantity);
                                account.KafraStoreItem(inventoryItem, itemID, quantity);
                                Console.Write($"Stored {quantity} {inventoryItem.name}");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("\nEnter a Valid Item ID");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Write("\nItem Quantity exceeds number of items in Inventory");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Write("\nEnter a Valid Item Quantity");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("\nItem not found in Inventory");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("\nEnter a Valid Item ID");
                Console.ReadKey();
            }
        }

        static void RetrieveItemKafra()
        {
            Console.Clear();
            Console.WriteLine("Kafra Corp - Storage Service\n");
            Console.WriteLine($"Storage of [{character.name}]");
            Console.WriteLine("ItemID\t\tQuantity\tItem Name");
            if (account.ShowStorage().Count != 0)
            {
                foreach (var item in account.ShowStorage())
                {
                    Console.WriteLine($"{item.id}\t\t{item.quantity}\t\t{item.name}[{item.slot}]");
                }
                Console.Write("\nEnter Item ID: ");
                if (int.TryParse(Console.ReadLine(), out itemID))
                {
                    kStoredItem = account.StorageCheck(itemID);
                    if (kStoredItem != null)
                    {
                        Console.Write("Enter Quantity: ");
                        int.TryParse(Console.ReadLine(), out quantity);
                        if (item.quantity <= quantity)
                        {
                            account.StorageDeductItem(itemID, quantity);
                            account.KafraRetrieveItem(character, inventoryItem, quantity);
                            Console.Write($"Retrieved {quantity} {inventoryItem.name}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\nEnter a Valid Item Quantity");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Write("\nItem not found in Kafra Storage");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("\nEnter a Valid Item ID");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("\n\nKafra Storage Empty");
                Console.ReadKey();
            }
        }
    }
}