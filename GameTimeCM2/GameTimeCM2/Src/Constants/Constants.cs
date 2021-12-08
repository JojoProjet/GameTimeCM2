using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src
{
    public class Constants
    {

        // DB Constants
        public static string DB_SELECT_USER = "SELECT * FROM User WHERE Name = ?name";
        public static string DB_SELECT_USERS = "SELECT * FROM User;";
        public static string DB_INSERT_USER = "INSERT INTO User(Name) VALUES(?name)";

    }
}
