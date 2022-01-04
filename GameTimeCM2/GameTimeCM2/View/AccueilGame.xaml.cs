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

        public AccueilGame()
        {
            this.InitializeComponent();

            // Disable escape game when only one win in three game
            //btn_escape_game.IsEnabled = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //user = (User)Application.Current.Resources["User"];
            //Title.Text = $"Bonjour {user.Name}";
        }

        public void init()
        {
            //InitJson.UJsonTextReader()
        }

        private void Btn_LaunchGamePendu(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(GamePendu));
        private void Btn_LaunchGameMemoire(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(GameMemoire));
        private void Btn_LaunchGameConjugaison(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(ViewBeginGameConjugaison));
        private void Btn_LaunchGameEscape(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(EscapeGame));
        
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

    }
}
