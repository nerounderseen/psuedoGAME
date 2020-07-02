using System.Collections.Generic;

namespace psuedoGAME
{
    public class Item
    {
        public int id;
        public string name;
        public int slot;
        public int quantity;
        private static List<Item> _itemList = new List<Item>()
        {
            new Item {id = 501, name = "Red Potion", slot=0,},
            new Item {id = 505, name = "Blue Potion", slot=0},
            new Item {id = 1203, name = "Knife", slot=0},
            new Item {id = 2305, name = "Adventurer's Suit", slot=0},
            new Item {id = 5015, name = "Egg Shell", slot=0}
        };

        public Item InputItem(int id)
        {
            foreach (Item item in _itemList)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Item GenerateItem(int itemID, int quantity)
        {
            if (_itemList.Exists(x => x.id == itemID))
            {
                int index = _itemList.FindIndex(x => x.id == itemID);
                if (index != -1)
                {
                    _itemList[index].quantity = quantity;
                    return _itemList[index];
                }
            }
            return null;
        }

        public List<Item> ShowItemList()
        {
            List<Item> itemListCopy = new List<Item>();
            itemListCopy = _itemList;
            return itemListCopy;
        }
    }
}