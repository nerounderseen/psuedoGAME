namespace psuedoGAME
{
    class Account
    {
        private int _totalChar;
        public string username { get; set; }
        public string password { get; set; }
        private Character[] charNew { get; set; }
        public Account()
        {
            charNew = new Character[3];
            _totalChar = 0;
        }

        public void CharacterCreate(string cName, char cGender)
        {
            charNew[_totalChar] = new Character
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
                CopiedCharArray[i] = charNew[i];
            }
            return CopiedCharArray;
        }
    }
}