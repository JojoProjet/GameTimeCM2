using GameTimeCM2.Src.Game;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameTimeCM2.Src.Utils
{
    class Db
    {

        private MySqlConnection mysqlcon = new MySqlConnection("server=gametimecm2db.southcentralus.azurecontainer.io;user id=root;password=gametimecm2;database=gametimecm2");

        public Db() { }

        public MySqlCommand SetCommandDb(string command)
        {
            MySqlCommand mysqlcom = new MySqlCommand(command, mysqlcon);
            return mysqlcom;
        }

        public MySqlDataReader GetDataDb(MySqlCommand mysqlcom)
        {
            mysqlcon.Open();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return mysqlread;
        }

        public List<User> GetUsers()
        {
            MySqlDataReader mysqlread = GetDataDb(SetCommandDb(Constants.DB_SELECT_USERS));
            List<User> listUser = new List<User>();

            while (mysqlread.Read())
                listUser.Add(new User(int.Parse(mysqlread["Id"].ToString()), mysqlread["Name"].ToString(), int.Parse(mysqlread["Score"].ToString()), int.Parse(mysqlread["Time"].ToString())));

            mysqlcon.Close();

            return listUser;
        }

        public User GetUser(string name)
        {
            MySqlCommand mysqlCom = SetCommandDb(Constants.DB_SELECT_USER);
            mysqlCom.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            MySqlDataReader mysqlread = GetDataDb(mysqlCom);
            
            if(mysqlread.FieldCount == 0) return null;
            
            while(mysqlread.Read())
            {
                User user = new User(int.Parse(mysqlread["Id"].ToString()), mysqlread["Name"].ToString(), int.Parse(mysqlread["Score"].ToString()), int.Parse(mysqlread["Time"].ToString()));
                mysqlcon.Close();
                return user;
            }
       
            return null;
        }

        public void InsertUser(string name, string password)
        {
            mysqlcon.Open();
            MySqlCommand mysqlCom = SetCommandDb(Constants.DB_INSERT_USER);
            mysqlCom.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            mysqlCom.Parameters.Add("?password", MySqlDbType.VarChar).Value = password;
            mysqlCom.ExecuteNonQuery();
            mysqlcon.Close();
        }

    }
}
