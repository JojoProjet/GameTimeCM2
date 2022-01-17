using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Game.GMemoire
{
    class Data
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public Data(int id, string image)
        {
            Id = id;
            Image = image;
        }

    }
}
