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

        private readonly Db db = new Db();

        public AccountService() { }

        public string Register(string name, string password)
        {
            try
            {
                if (db.GetUser(name) == null)
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                    db.InsertUser(name, passwordHash);
                    Application.Current.Resources["regi"] = Constants.STRING_INSCRIPTION_GOOD; ;
                    return Constants.STRING_INSCRIPTION_GOOD;
                }
                throw new Exception(Constants.STRING_INSCRIPTION_ERROR);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public bool Login(string name, string password)
        {
            User user = db.GetUser(name);
            return (user != null && user.Name == name && BCrypt.Net.BCrypt.Verify(password, user.Password));
        }

    }
}
