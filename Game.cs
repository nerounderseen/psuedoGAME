using System.Collections.Generic;
namespace psuedoGAME
{
    class Game
    {
        private List<Account> _accountList { get; set; }
        public Game()
        {
            _accountList = new List<Account>();
        }

        public void Registration(string username, string password, int pin)
        {
            _accountList.Add(new Account { username = username, password = password, securePIN = pin });
        }

        public Account IsAccountExists(string username)
        {
            foreach (Account accnt in _accountList)
                if (accnt.username == username)
                {
                    return accnt;
                }
            return null;
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

        public Account PasswordCheck(string password)
        {
            foreach (Account accnt in _accountList)
            {
                if (accnt.password == password)
                    return accnt;
            }
            return null;
        }

        public Account SecuredPINCheck(int pin)
        {
            foreach (Account accnt in _accountList)
            {
                if (accnt.securePIN == pin)
                    return accnt;
            }
            return null;
        }

        public Account ChangePassword(string username, string password, string nPassword)
        {
            foreach (var accnt in _accountList)
            {
                if (accnt.username == username && accnt.password == password)
                {
                    accnt.password = nPassword;
                }
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

        public Character IsIGNExists(string ign)
        {
            foreach (Account accnt in _accountList)
            {
                foreach (Character identity in accnt.ShowChar())
                {
                    if (identity.name == ign)
                        return identity;
                }
            }
            return null;
        }

    }
}