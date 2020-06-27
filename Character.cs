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

        public Character()
        {
            charInventory = new List<Inventory>();
        }
    }
}