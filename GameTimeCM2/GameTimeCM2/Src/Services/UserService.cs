using GameTimeCM2.Src.Game;
using GameTimeCM2.Src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Services
{
    public interface IUserService
    {
        User GetUser(string name);
        List<User> GetUsers();
    }

    class UserService : IUserService
    {

        private Db db = new Db();

        public UserService()
        {

        }

        public User GetUser(string name)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

    }
}
