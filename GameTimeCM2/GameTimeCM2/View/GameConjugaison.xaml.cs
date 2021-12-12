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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GameConjugaison : Page
    {

        private Game Game { get; set; }

        public GameConjugaison()
        {
            this.InitializeComponent();
            InitBackground();
            InitGame();
        }

        public void InitBackground()
        {
            const string URI_ASSETS_BACK_GAMEE = "ms-appx:///Assets/AGames/BackGameConjugaison.jpg";
            Image image = new Image() { Source = new BitmapImage(new Uri(URI_ASSETS_BACK_GAMEE)) };
            ImageBrush imageBrush = new ImageBrush() { ImageSource = image.Source };
            GameConju.Background = imageBrush;
        }

        public void InitGame()
        {
            Game = new Game(Cards);
            Game.Init();
        }


        private void Btn_QuitGame(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccueilGame));
        }


        private bool ResponseInValidate = true;

        private void Btn_CheckReponse(object sender, RoutedEventArgs e)
        {
            Game.DoAnimationCard(ResponseInValidate ? "Front" : "Back");
            ResponseInValidate = ResponseInValidate ? false : true;
            Game.CheckReponse(TextScore);
        }

    }
}
