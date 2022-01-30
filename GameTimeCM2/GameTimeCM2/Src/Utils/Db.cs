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

        private MySqlConnection MysqlCon { get; set; }

        public Db() 
        {
            MysqlCon = new MySqlConnection("server=gametimecm2db.southcentralus.azurecontainer.io;user id=root;password=gametimecm2;database=gametimecm2");
        }

        public void Connect()
        {

        }

        public void Closed()
        {

        }

        public void DbDestroy()
        {
        }

        public MySqlCommand SetCommandDb(string command)
        {
            MySqlCommand mysqlcom = new MySqlCommand(command, MysqlCon);
            return mysqlcom;
        }

        public MySqlDataReader GetDataDb(MySqlCommand mysqlcom)
        {
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return mysqlread;
        } 

        public List<User> GetUsers()
        {
            MysqlCon.Open();
            MySqlDataReader mysqlread = GetDataDb(SetCommandDb(Constants.DB_SELECT_USERS));
            List<User> listUser = new List<User>();

            while (mysqlread.Read())
                listUser.Add(new User(int.Parse(mysqlread["Id"].ToString()), mysqlread["Name"].ToString(), int.Parse(mysqlread["Score"].ToString()), int.Parse(mysqlread["Time"].ToString()), mysqlread["Password"].ToString()));
            
            mysqlread.Close();
            MysqlCon.Close();

            return listUser;
        }

        public User GetUser(string name)
        {
            MysqlCon.Open();
            MySqlCommand mysqlCom = SetCommandDb(Constants.DB_SELECT_USER);
            mysqlCom.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            MySqlDataReader mysqlread = mysqlCom.ExecuteReader(CommandBehavior.CloseConnection);

            if (!mysqlread.HasRows)
            {
                mysqlread.Close();
                MysqlCon.Close();
                return null;
            }

            while(mysqlread.Read())
            {
                User user = new User(int.Parse(mysqlread["Id"].ToString()), mysqlread["Name"].ToString(), int.Parse(mysqlread["Score"].ToString()), int.Parse(mysqlread["Time"].ToString()), mysqlread["Password"].ToString());
                mysqlread.Close();
                MysqlCon.Close();
                return user;
            }
       
            return null;
        }

        public void InsertUser(string name, string password)
        {
            MysqlCon.Open();
            MySqlCommand mysqlCom = SetCommandDb(Constants.DB_INSERT_USER);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            mysqlCom.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            mysqlCom.Parameters.Add("?password", MySqlDbType.VarChar).Value = passwordHash;
            mysqlCom.ExecuteNonQuery();
            MysqlCon.Close();
        }

        public void UpdateScoreUser(int score, User user)
        {
            MysqlCon.Open();
            MySqlCommand mysqlCom = SetCommandDb(Constants.DB_UPDATE_SCORE_USER);
            mysqlCom.Parameters.Add("?score", MySqlDbType.Int32).Value = score;
            mysqlCom.Parameters.Add("?name", MySqlDbType.VarChar).Value = user.Name;
            mysqlCom.ExecuteNonQuery();
            MysqlCon.Close();
        }

    }
}
