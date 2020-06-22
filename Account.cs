namespace psuedoGAME
{
    class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        private Character[] newCharacters { get; set; }
        public Account()
        {
            newCharacters = new Character[3];
        }
    }
}