using GameTimeCM2.Src.Game;
using GameTimeCM2.Src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace GameTimeCM2.Src
{

    public interface IAccountService
    {
        string Register(string name, string password);
        bool Login(string name, string password);
    }

    class AccountService
    {
        private Db db = new Db();
        

        public AccountService() { }

        public string Register(string name, string password)
        {
            try
            {
                if (db.GetUser(name) == null)
                {
                    db.InsertUser(name, password);
                    return Constants.STRING_INSCRIPTION_GOOD;
                }
                throw new Exception(Constants.STRING_INSCRIPTION_ERROR);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public User Login(string name, string password)
        {
            User user = db.GetUser(name);
            if (user != null && user.Name == name && BCrypt.Net.BCrypt.Verify(password, user.Password))
                return user;
            return null;
        }

    }
}
