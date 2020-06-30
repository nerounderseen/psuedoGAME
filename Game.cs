using System.Collections.Generic;
namespace psuedoGAME
{
    class Game
    {
        private List<Account> _accountList { get; set; }
        private List<Kafra> _accountStorage { get; set; }
        public Game()
        {
            _accountStorage = new List<Kafra>();
            _accountList = new List<Account>();
        }

        public void Registration(string username, string password, int pin)
        {
            _accountList.Add(new Account { username = username, password = password, securePIN = pin });
        }

        public Account Login(string username, string password)
        {
            foreach (Account accnt in _accountList)
            {
                if (accnt.username == username && accnt.password == password)
                    return accnt;
            }
            return null;
        }

        public Account ForgotPassword(string username, int pin)
        {
            List<Account> copyAccoutList = new List<Account>();
            copyAccoutList = _accountList;
            foreach (Account cpAccnt in copyAccoutList)
            {
                if (cpAccnt.username == username && cpAccnt.securePIN == pin)
                    return cpAccnt;
            }
            return null;
        }
    }
}