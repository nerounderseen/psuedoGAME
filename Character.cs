using System.Collections.Generic;

namespace psuedoGAME
{
    class Character
    {
        public int charCount { get; set; }
        public string name { get; set; }
        public int baselevel { get; set; }
        public int joblevel { get; set; }
        public string job = "Novice";
        public char gender { get; set; }
        public int freePoints = 48;
        public int str = 1;
        public int agi = 1;
        public int vit = 1;
        public int intel = 1;
        public int dex = 1;
        public int luk = 1;
        private List<Inventory> charInventory { get; set; }

        public void AddSTR()
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                str += 1;
            }
            else
            {
                str += 0;
            }
        }

        public void AddAGI()
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                agi += 1;
            }
            else
            {
                agi += 0;
            }
        }

        public void AddVIT()
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                vit += 1;
            }
            else
            {
                vit += 0;
            }
        }

        public void AddINT()
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                intel += 1;
            }
            else
            {
                intel += 0;
            }
        }

        public void AddDEX()
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                dex += 1;
            }
            else
            {
                dex += 0;
            }
        }

        public void AddLUK()
        {
            if (freePoints > 0)
            {
                freePoints -= 1;
                luk += 1;
            }
            else
            {
                luk += 0;
            }
        }

        public Character()
        {
            charInventory = new List<Inventory>();
        }
        public List<Inventory> ShowInventory()
        {
            List<Inventory> inventoryListCopy = new List<Inventory>();
            inventoryListCopy = charInventory;
            return inventoryListCopy;
        }
    }
}