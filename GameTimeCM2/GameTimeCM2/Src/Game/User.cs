using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Game
{
    class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }
        public string Time { get; set; }

        public User(int id, string name, string score, string time)
        {
            Id = id;
            Name = name;
            Score = score;
            Time = time;
        }
            
    }
}
