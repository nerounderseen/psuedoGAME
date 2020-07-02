using System.Collections.Generic;

namespace psuedoGAME
{
    class Character
    {
        public int charCount { get; set; }
        public string name { get; set; }
        public int baselevel = 1;
        public int joblevel = 1;
        public string job = "Novice";
        public char gender { get; set; }
        public int freePoints = 48;
        private int _newPoints;
        private int _tempStat;
        public int str = 1;
        public int agi = 1;
        public int vit = 1;
        public int intel = 1;
        public int dex = 1;
        public int luk = 1;
        private Item _item;
        private Job _job = new Job();
        private List<Inventory> _charInventory = new List<Inventory>();
        public Character()
        {
            _charInventory = new List<Inventory>();
            BeginnerLoadout(501, 10);
            BeginnerLoadout(1203, 1);
            BeginnerLoadout(2305, 1);
        }

        public void AddSTR()
        {
            if (str < 99 && freePoints > 0)
            {
                _tempStat = ((str - 1) / 10) + 2;
                freePoints = freePoints - _tempStat;
                str += 1;
            }
            else
            {
                str += 0;
            }
        }

        public void AddAGI()
        {
            if (agi < 99 && freePoints > 11)
            {
                _tempStat = ((agi - 1) / 10) + 2;
                freePoints = freePoints - _tempStat;
                agi += 1;
            }
            else
            {
                agi += 0;
            }
        }

        public void AddVIT()
        {
            if (vit < 99 && freePoints > 11)
            {
                _tempStat = ((vit - 1) / 10) + 2;
                freePoints = freePoints - _tempStat;
                vit += 1;
            }
            else
            {
                vit += 0;
            }
        }

        public void AddINT()
        {
            if (intel < 99 && freePoints > 11)
            {
                _tempStat = ((intel - 1) / 10) + 2;
                freePoints = freePoints - _tempStat;
                intel += 1;
            }
            else
            {
                intel += 0;
            }
        }

        public void AddDEX()
        {
            if (dex < 99 && freePoints > 11)
            {
                _tempStat = ((dex - 1) / 10) + 2;
                freePoints = freePoints - _tempStat;
                dex += 1;
            }
            else
            {
                dex += 0;
            }
        }

        public void AddLUK()
        {
            if (luk < 99 && freePoints > 11)
            {
                _tempStat = ((luk - 1) / 10) + 2;
                freePoints = freePoints - _tempStat;
                luk += 1;
            }
            else
            {
                luk += 0;
            }
        }

        public void IncBaseLVL()
        {
            if (baselevel < 99)
            {
                _newPoints = (baselevel / 5) + 2;
                freePoints = freePoints + _newPoints;
                baselevel += 1;
            }
            else
            {
                baselevel += 0;
            }
        }

        public void IncJobLVL()
        {
            if (joblevel < 10)
                joblevel += 1;
            else if (joblevel >= 10 && joblevel < 50 && job != "Novice")
                joblevel += 1;
            else
                joblevel += 0;
        }

        public Job ChangeJob(Character character, string charJob)
        {
            if (_job.ShowFirstJobList().Exists(x => x.identifier == charJob))
            {
                _job = new Job();
                Job job = _job.InputItem(charJob);
                character.job = job.name;
                joblevel = 1;
                return job;
            }
            else
            {
                return null;
            }
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
                    if (_charInventory[index].quantity == 0)
                    {
                        _charInventory.Remove(_charInventory[index]);
                    }
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