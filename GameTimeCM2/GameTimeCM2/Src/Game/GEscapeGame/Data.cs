using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Game.GEscapeGame
{
    public class Data
    {
        public int Id { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }

        public string R1 { get; set; }
        public string R1_1 { get; set; }
        public string R1_2 { get; set; }
        public string R1_3 { get; set; }

        public string R2 { get; set; }
        public string R2_1 { get; set; }
        public string R2_2 { get; set; }
        public string R2_3 { get; set; }

        public string R3 { get; set; }
        public string R3_1 { get; set; }
        public string R3_2 { get; set; }
        public string R3_3 { get; set; }

        public Data(int id, string q1, string q2, string q3, 
            string r1, string r1_1, string r1_2, string r1_3,
            string r2, string r2_1, string r2_2, string r2_3,
            string r3, string r3_1, string r3_2, string r3_3)
        {
            Id = id;

            Q1 = q1;
            Q2 = q2;
            Q3 = q3;

            R1 = r1;
            R1_1 = r1_1;
            R1_2 = r1_2;
            R1_3 = r1_3;

            R2 = r2;
            R2_1 = r2_1;
            R2_2 = r2_2;
            R2_3 = r2_3;

            R3 = r3;
            R3_1 = r3_1;
            R3_2 = r3_2;
            R3_3 = r3_3;

        }

    }
}
