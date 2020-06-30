namespace psuedoGAME
{
    class Account
    {
        public string username;
        public string password;
        public int securePIN;
        private Character[] _charNew { get; set; }
        private int _totalChar;

        public Account()
        {
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
        public Character[] ShowChar()
        {
            Character[] CopiedCharArray = new Character[_totalChar];
            for (int i = 0; i < _totalChar; i++)
            {
                CopiedCharArray[i] = _charNew[i];
            }
            return CopiedCharArray;
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
    }
}