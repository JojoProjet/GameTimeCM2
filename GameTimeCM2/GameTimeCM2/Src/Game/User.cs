using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Game
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }

        public User(int id, string name, int score, int time)
        {
            Id = id;
            Name = name;
            Score = score;
            Time = time;
        }

    }
}
