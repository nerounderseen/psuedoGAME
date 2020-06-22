namespace psuedoGAME
{
    class Account
    {
        private int _totalChar;
        public string username { get; set; }
        public string password { get; set; }
        private Character[] newCharacter { get; set; }
        public Account()
        {
            newCharacter = new Character[3];
            _totalChar = 0;
        }
        public void CharacterCreate(string cName, string cJob)
        {
            newCharacter[_totalChar] = new Character
            {
                charCounter = _totalChar,
                name = cName,
                job = cJob,
            };
        }
    }
}