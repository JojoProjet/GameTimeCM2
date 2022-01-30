using GameTimeCM2.Src.Game;
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
using Windows.UI.Xaml.Navigation;
using GameTimeCM2.View;
using Windows.UI;
using Windows.UI.Xaml.Media.Animation;
using System.Diagnostics;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AccueilGame : Page
    {
        readonly Frame rootFrame = Window.Current.Content as Frame;

        public User user;

        private const string RESSOURCES_INT_WIN_GAME_PENDU = "IntWinGamePendu";
        private const string RESSOURCES_INT_WIN_GAME_MEMORY = "IntWinGameMemory";
        private const string RESSOURCES_INT_WIN_GAME_CONJUGAISON = "IntWinGameConjugaison";
        private const string RESSOURCES_INT_WIN_GAME_ESCAPE = "IntWinGameEscape";

        private int IndexPenduWinListGame = 1;
        private int IndexMemoryWinListGame = 2;
        private int IndexConugaisonWinListGame = 3;
        private int IndexEscapeWinListGame = 4;

        // 1 -> Pendu, 2 -> Memory, 3 -> Conjugaison, 4 -> Escape Game
        public List<int> WinListGame { get; set; }

        public AccueilGame()
        {
            this.InitializeComponent();
            Init();

            // Disable escape game when only one win in three game
            btn_escape_game.IsEnabled = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Db db = new Db();


            user = (User)Application.Current.Resources["User"];

            int winGamePendu = (int)Application.Current.Resources["IntWinGamePendu"];
            int winGameMemory = (int)Application.Current.Resources["IntWinGameMemory"];
            int winGameConugaison = (int)Application.Current.Resources["IntWinGameConjugaison"];
            int winGameEsape = (int)Application.Current.Resources["IntWinGameEscape"];

            CheckCanGameEscape(winGamePendu, winGameMemory, winGameConugaison, user);

            WinListGame[IndexPenduWinListGame] = winGamePendu;
            WinListGame[IndexMemoryWinListGame] = winGameMemory;
            WinListGame[IndexConugaisonWinListGame] = winGameConugaison;
            WinListGame[IndexEscapeWinListGame] = winGameEsape;

            int newScore = user.Score + winGameConugaison + winGameMemory + winGameConugaison + winGameEsape;
            db.UpdateScoreUser(newScore, user);

            //Title.Text = $"Bonjour {user.Name}";
        }

        public void SendDataWinListGame(string resources, int index)
        {
            Application.Current.Resources[resources] = WinListGame[index];
        }

        public void LaunchGamePendu()
        {
            SendDataWinListGame(RESSOURCES_INT_WIN_GAME_PENDU, IndexPenduWinListGame);
            rootFrame.Navigate(typeof(GamePendu));
        }

        public void LaunchGameMemoire()
        {
            SendDataWinListGame(RESSOURCES_INT_WIN_GAME_MEMORY, IndexMemoryWinListGame);
            rootFrame.Navigate(typeof(GameMemoire));
        }

        public void LaunchGameConjugaison()
        {
            SendDataWinListGame(RESSOURCES_INT_WIN_GAME_CONJUGAISON, IndexConugaisonWinListGame);
            rootFrame.Navigate(typeof(ViewBeginGameConjugaison));
        }

        public void LaunchGameEscape()
        {
            SendDataWinListGame(RESSOURCES_INT_WIN_GAME_ESCAPE, IndexEscapeWinListGame);
            rootFrame.Navigate(typeof(BeginEscapeGame));
        }

        private void CheckCanGameEscape(int winP, int winM, int winC, User user)
        {
            // if (winP > 0 && winM > 0 && winC > 0) btn_escape_game.IsEnabled = true;
            if (winP > 0 && winM > 0 && winC > 0 || user.Score >= 3) btn_escape_game.IsEnabled = true;
        }

        public void Init()
        {
            //InitJson.UJsonTextReader()
            WinListGame = new List<int>
            {
                0, 0, 0, 0, 0
            };
            if (!Application.Current.Resources.ContainsKey(RESSOURCES_INT_WIN_GAME_PENDU) &&
                !Application.Current.Resources.ContainsKey(RESSOURCES_INT_WIN_GAME_MEMORY) &&
                !Application.Current.Resources.ContainsKey(RESSOURCES_INT_WIN_GAME_CONJUGAISON) &&
                !Application.Current.Resources.ContainsKey(RESSOURCES_INT_WIN_GAME_ESCAPE)
            )
            {
                Application.Current.Resources[RESSOURCES_INT_WIN_GAME_PENDU] = 0;
                Application.Current.Resources[RESSOURCES_INT_WIN_GAME_MEMORY] = 0;
                Application.Current.Resources[RESSOURCES_INT_WIN_GAME_CONJUGAISON] = 0;
                Application.Current.Resources[RESSOURCES_INT_WIN_GAME_ESCAPE] = 0;
            }
        }

        private void Btn_LaunchGamePendu(object sender, RoutedEventArgs e) => LaunchGamePendu();
        private void Btn_LaunchGameMemoire(object sender, RoutedEventArgs e) => LaunchGameMemoire();
        private void Btn_LaunchGameConjugaison(object sender, RoutedEventArgs e) => LaunchGameConjugaison();
        private void Btn_LaunchGameEscape(object sender, RoutedEventArgs e) => LaunchGameEscape();


        private void Border_TappedInfo(object sender, RoutedEventArgs e)
        {

        }

        private void Border_TappedTopTen(object sender, RoutedEventArgs e)
        {
            //LoadPbar.IsLoading = true;
            rootFrame.Navigate(typeof(ViewScoreFinal));
        }


        private void Img_QuitGame(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MainPage));
        }

        private void Border_PMTopTen(object sender, PointerRoutedEventArgs e)
        {
            UtilBorderPM(ImgTopTen);
        }

        private void Border_ExitedTopTen(object sender, PointerRoutedEventArgs e)
        {
            UtilBorderExited(ImgTopTen);
        }

        private void Border_PMInfo(object sender, PointerRoutedEventArgs e)
        {
            UtilBorderPM(ImgInfo);
        }

        private void Border_ExitedInfo(object sender, PointerRoutedEventArgs e)
        {
            UtilBorderExited(ImgInfo);
        }


        private void UtilBorder(Border border, SolidColorBrush solidColorBrush, Thickness thickness)
        {
            Border uBorder = new Border()
            {
                BorderBrush = solidColorBrush,
                BorderThickness = thickness
            };
            border.BorderBrush = uBorder.BorderBrush;
            border.BorderThickness = uBorder.BorderThickness;

        }

        private void UtilBorderPM(Border border)
        {
            UtilBorder(border, new SolidColorBrush(Colors.Red), new Thickness(5));
        }

        private void UtilBorderExited(Border border)
        {
            UtilBorder(border, new SolidColorBrush(Colors.White), new Thickness(0));
        }

        private void Loaded_Page(object sender, RoutedEventArgs e)
        {
            Animation.AnimatePage(AccueilGamePage, StackPanelPage).Begin();
        }

        private void btn_escape_game_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
