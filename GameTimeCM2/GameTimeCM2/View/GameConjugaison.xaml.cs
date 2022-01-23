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
using System.Windows;
using Windows.UI.Xaml.Media.Imaging;
using GameTimeCM2.Src;
using System.Runtime.InteropServices;

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

            Game.TextWinOrLoose = TextWinOrLoose;
            Game.TextFinishScore = TextFinishScore;
            Game.StoryBoardFinish = Storyboard_StackFinishGame;

            InitGame();
        }

        public void InitGame()
        {
            Game = new Game(Cards, TextQuestion, TextScore);
            Game.Init();
        }


        private void Btn_QuitGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["IntWinGameConjugaison"] = Game.TWinGame;
            Frame.Navigate(typeof(AccueilGame));
        }

        private void Btn_CheckReponse(object sender, RoutedEventArgs e)
        {
            // Animation reponse faux ou juste
            const string TEXT_NEXT = "Suivant !";
            const string VALIDATE_RES = "Valide la réponse !";
            
            try
            {
                if(!Application.Current.Resources.ContainsKey(Constants.APPLICATION_RESSOURCES_CARD)) 
                    throw new COMException();

                BtnCheckReponse.IsEnabled = false;

                bool check = Game.CheckReponse(TextScore);
                
                Game.DoAnimationCard(TextQuestion, Vrai, Faux, BtnCheckReponse);

                TextQuestion.Visibility = Visibility.Collapsed;
                if (check)
                {
                    Vrai.Visibility = Visibility.Visible;
                    Faux.Visibility = Visibility.Collapsed;
                    Animation.AnimateEmoji(Page, Vrai).Begin();
                }
                else
                {
                    Vrai.Visibility = Visibility.Collapsed;
                    Faux.Visibility = Visibility.Visible;
                    Animation.AnimateEmoji(Page, Faux).Begin();
                }
            }
            catch (COMException)
            {
                Game.ShowSelectResponse(TextScore);
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Game.TWinGame = (int)Application.Current.Resources["IntWinGameConjugaison"];
        }

        public void Click_BtnOtherGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["IntWinGameConjugaison"] = Game.TWinGame;
            Frame.Navigate(typeof(AccueilGame));
        }

    }
}
