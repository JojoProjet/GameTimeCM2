using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Data
    {

        public int Id { get; set; }
        public string Question { get; set; }
        public string Conjugaison1 { get; set; }
        public string Conjugaison2 { get; set; }
        public string Conjugaison3 { get; set; }
        public string Conjugaison4 { get; set; }
        public string Response { get; set; }

        public Data(int id, string question, string conjugaison1, string conjugaison2, string conjugaison3, string conjugaison4, string response)
        {
            Id = id;
            Question = question;

            Conjugaison1 = conjugaison1;
            Conjugaison2 = conjugaison2;
            Conjugaison3 = conjugaison3;
            Conjugaison4 = conjugaison4;

            Response = response;
        }

    }
}
