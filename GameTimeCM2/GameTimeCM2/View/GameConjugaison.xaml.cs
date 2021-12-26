using GameTimeCM2.Src.Game.GConjugaison;
using GameTimeCM2.Src.Utils;
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
using System.Windows;
using Windows.UI.Xaml.Media.Imaging;
using GameTimeCM2.Src;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GameConjugaison : Page
    {

        private bool ResponseInValidate = false;

        private Game Game { get; set; }

        public GameConjugaison()
        {
            this.InitializeComponent();
            InitGame();
        }

        public void InitGame()
        {
            Game = new Game(Cards, TextQuestion);
            Game.Init();
        }


        private void Btn_QuitGame(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccueilGame));
        }

        private void Btn_CheckReponse(object sender, RoutedEventArgs e)
        {
            Game.DoAnimationCard(ResponseInValidate ? Constants.ANIMATE_SIDE_BACK : Constants.ANIMATE_SIDE_FRONT);
            // Animation reponse faux ou juste

            if(ResponseInValidate)
            {
                TextQuestion.Visibility = Visibility.Visible;
                Vrai.Visibility = Visibility.Collapsed;
                Faux.Visibility = Visibility.Collapsed;
            } 
            else
            {
                TextQuestion.Visibility = Visibility.Collapsed;
                bool check = Game.CheckReponse(TextScore);
                if (check)
                {
                    Vrai.Visibility = Visibility.Visible;
                    Faux.Visibility = Visibility.Collapsed;
                    Src.Utils.Animation.AnimateEmoji(Page, Vrai).Begin();
                }
                else
                {
                    Vrai.Visibility = Visibility.Collapsed;
                    Faux.Visibility = Visibility.Visible;
                    Src.Utils.Animation.AnimateEmoji(Page, Faux).Begin();
                }
            }

            ResponseInValidate = ResponseInValidate ? false : true;

        }

    }
}
