using GameTimeCM2.Src.Game.GMemoire;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class GameMemoire : Page
    {
        private readonly Game game;
        public GameMemoire()
        {
            this.InitializeComponent();
            Game.Stack_FinishGame = Stack_FinishGame;
            Game.TextBlock_ScoreCoupFinal = TextNbCoup;
            game = new Game(Memory, grid);
            game.Init();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Game.TWinGame = (int)Application.Current.Resources["IntWinGameMemory"];
        }

        public void Click_BtnOtherGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["IntWinGameMemory"] = Game.TWinGame;
            Frame.Navigate(typeof(AccueilGame));
        }

        public void Click_BtnReGame(object sender, RoutedEventArgs e)
        {
            game.SetNewGame(Storyboard_StackNewGame, Stack_FinishGame);
        }

    }
}
