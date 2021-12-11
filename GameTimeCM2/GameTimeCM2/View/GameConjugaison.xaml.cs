using GameTimeCM2.Src.Game.GConjugaison;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GameConjugaison : Page
    {
        public GameConjugaison()
        {
            this.InitializeComponent();
            //story.Begin();
            InitGame();
        }

        public void InitGame()
        {
            string card = "Card";

            Cards cards = new Cards(Cards, "aze");

            int angleLeft = -10;
            int angleLeftBase = -1;
            int angleRightBase = 1;
            int angleRight = 10;

            int TransformTranslateXLeft = -25;
            int TransformTranslateXRight = 25;
            int TransformTranslateYTop1 = 50;
            int TransformTranslateYTop2 = 10;

            Card card1 = new Card($"{card}1", "aze", angleLeft, TransformTranslateXLeft, TransformTranslateYTop1);
            Card card2 = new Card($"{card}1", "azezaeaz", angleLeftBase);
            Card card3 = new Card($"{card}1", "aeazeaeze", angleRightBase);
            Card card4 = new Card($"{card}1", "azaeazeze", angleRight, TransformTranslateXRight, TransformTranslateYTop2);

            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);
            cards.Add(card4);

            cards.Init();

        }



    }
}
