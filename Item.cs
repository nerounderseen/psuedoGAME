using System.Collections.Generic;

namespace psuedoGAME
{
    public class Item
    {
        public int id;
        public string name;
        public int slot;

        public static List<Item> itemList = new List<Item>()
        {
            new Item {id = 501, name = "Red Potion", slot=0},
            new Item {id = 504, name = "White Potion", slot=0},
            new Item {id = 505, name = "Blue Potion", slot=0},
            new Item {id = 5015, name = "Egg Shell", slot=0}
        };

        public Item GetItem(int x)
        {
            foreach (Item item in itemList)
            {
                if (item.id == x)
                {
                    return item;
                }
            }
            return null;
        }
    }
}