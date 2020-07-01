using System.Collections.Generic;
namespace psuedoGAME
{
    class Account
    {
        public string username;
        public string password;
        public int securePIN;
        private Character[] _charNew { get; set; }
        private List<Kafra> _accountStorage { get; set; }
        private int _totalChar;

        public Account()
        {
            _accountStorage = new List<Kafra>();
            _charNew = new Character[3];
            _totalChar = 0;
        }

        public void CharacterCreate(string cName, char cGender)
        {
            _charNew[_totalChar] = new Character
            {
                charCount = _totalChar,
                name = cName,
                gender = cGender,
                baselevel = 1,
                joblevel = 1
            };
            _totalChar++;
        }

        public void DeleteCharacter(string ign)
        {
            int x = GetIndex(ign);
            if (x != -1)
            {
                var firstHalf = new Character[x];
                AppendTo(_charNew, firstHalf, 0, x);
                var secondHalf = new Character[_charNew.Length - firstHalf.Length];
                AppendTo(_charNew, secondHalf, x + 1, x + secondHalf.Length);
                var _charNewTemp = new Character[3];
                firstHalf.CopyTo(_charNewTemp, 0);
                secondHalf.CopyTo(_charNewTemp, x);
                _charNew = _charNewTemp;
                _totalChar--;
            }
        }

        public int GetIndex(string ign)
        {
            foreach (Character character in _charNew)
            {
                if (character.name == ign)
                {
                    return character.charCount;
                }
            }
            return -1;
        }

        public void AppendTo(Character[] source, Character[] temp, int begin, int end)
        {
            for (int x = begin; x < end; x++)
            {
                temp[x - begin] = source[x];
            }
        }

        public Character GetCharacter(string ign)
        {
            foreach (Character character in _charNew)
            {
                if (character.name == ign)
                    return character;
            }
            return null;
        }

        public void ItemTransfer(Character targetAccount, Inventory item, int quantity)
        {
            var rcvrChar = targetAccount;
            rcvrChar.AppendItem(item, quantity);
        }

        public Character[] ShowChar()
        {
            Character[] CopiedCharArray = new Character[_totalChar];
            for (int i = 0; i < _totalChar; i++)
            {
                CopiedCharArray[i] = _charNew[i];
            }
            return CopiedCharArray;
        }

        public void KafraStoreItem(Inventory item, int itemID, int quantity)
        {
            if (_accountStorage.Exists(x => x.id == item.id))
            {
                int index = _accountStorage.FindIndex(x => x.id == item.id);
                if (index != -1)
                {
                    _accountStorage[index].quantity = _accountStorage[index].quantity + quantity;
                }
            }
            else
            {
                _accountStorage.Add(new Kafra
                {
                    id = item.id,
                    name = item.name,
                    slot = item.slot,
                    quantity = quantity
                });
            }
        }

        public void KafraRemoveItem(Character character, Inventory item, int quantity)
        {
            var rcvrChar = character;
            rcvrChar.AppendItem(item, quantity);
        }

        public Kafra StorageCheck(int itemID)
        {
            if (_accountStorage.Exists(x => x.id == itemID))
            {
                int index = _accountStorage.FindIndex(x => x.id == itemID);
                if (index != -1)
                {
                    return _accountStorage[index];
                }
            }
            return null;
        }

        public Kafra StorageDeductItem(int itemID, int quantity)
        {
            if (_accountStorage.Exists(x => x.id == itemID))
            {
                int index = _accountStorage.FindIndex(x => x.id == itemID);
                if (index != -1)
                {
                    _accountStorage[index].quantity -= quantity;
                }
            }
            return null;
        }

        public List<Kafra> ShowStorage()
        {
            List<Kafra> copyStorage = new List<Kafra>();
            copyStorage = _accountStorage;
            return copyStorage;
        }

    }
}