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
        private Item _item;
        private List<Inventory> _charInventory = new List<Inventory>();
        public Character()
        {
            _charInventory = new List<Inventory>();
            BeginnerLoadout(501, 10);
            BeginnerLoadout(1203, 1);
            BeginnerLoadout(2305, 1);
        }

        public void BeginnerLoadout(int id, int quantity)
        {
            _item = new Item();
            Item item = _item.InputItem(id);

            _charInventory.Add(new Inventory
            {
                id = item.id,
                name = item.name,
                slot = item.slot,
                quantity = quantity
            });
        }

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

        public void AddInventory(Item item)
        {
            if (_charInventory.Exists(x => x.id == item.id))
            {
                int index = _charInventory.FindIndex(x => x.id == item.id);
                if (index != -1)
                {
                    _charInventory[index].quantity = _charInventory[index].quantity + item.quantity;
                }
            }
            else
            {
                _charInventory.Add(new Inventory
                {
                    id = item.id,
                    name = item.name,
                    slot = item.slot,
                    quantity = item.quantity
                });
            }
        }

        public void AppendItem(Inventory rItem, int quantity)
        {
            if (_charInventory.Exists(x => x.id == rItem.id))
            {
                int index = _charInventory.FindIndex(x => x.id == rItem.id);
                if (index != -1)
                {
                    _charInventory[index].quantity = _charInventory[index].quantity + quantity;
                }
            }
            else
            {
                _charInventory.Add(new Inventory
                {
                    id = rItem.id,
                    name = rItem.name,
                    slot = rItem.slot,
                    quantity = quantity
                });
            }
        }

         public void DeductItem(int itemID, int quantity)
        {
            if (_charInventory.Exists(x => x.id == itemID))
            {
                int index = _charInventory.FindIndex(x => x.id == itemID);
                if (index != -1)
                {
                    _charInventory[index].quantity -= quantity;
                }
            }
        }

        public Inventory CheckItem(int itemID)
        {
            if (_charInventory.Exists(x => x.id == itemID))
            {
                int index = _charInventory.FindIndex(x => x.id == itemID);
                if (index != -1)
                {
                    return _charInventory[index];
                }
            }
            return null;
        }

        public List<Inventory> ShowInventory()
        {
            List<Inventory> inventoryListCopy = new List<Inventory>();
            inventoryListCopy = _charInventory;
            return inventoryListCopy;
        }
    }
}