using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace GameTimeCM2.Src.Game.GPendu
{
    class Game
    {

        public string Word { get; private set; }
        public int Lenght { get; private set; }
        private int Stage { get; set; }
        public char[] Alphabet { get; private set; }

        public Game(string word)
        {
            Word = word;
            Lenght = Word.Length;
            Stage = 0;
            InitializeAlphabet();
        }
         
        private void InitializeAlphabet()
        {
                    Alphabet = new char[] {'A', 'B', 'C', 'D', 'E',
                        'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                        'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
                        'X', 'Y', 'Z'};
        }

        public BitmapImage GetStageImage()
        {
            const string URI_ASSETS_IMAGES = "ms-appx:///Assets/AGamePendu/";
            const string EXTENSION_IMAGE = ".png";


            return new BitmapImage(
                new Uri(URI_ASSETS_IMAGES + Stage + EXTENSION_IMAGE)
            );
        }

        public int[] TakeCharacter(char ch)
        {
            int[] temp = new int[Word.Length];

            for (int i = 0; i < Word.Length; i++)
            {
                if (Word.ToUpper()[i] == ch)
                    temp[i] = 1;
                else
                    temp[i] = 0;
            }

            if (temp.Count(i => i == 1) == 0)
                Stage = Stage == 9 ? Stage : Stage+1;

            return temp;
        }

        public bool IsGameOver()
        {
            return Stage == 9;
        }

    }
}

