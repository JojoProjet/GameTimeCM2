using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
