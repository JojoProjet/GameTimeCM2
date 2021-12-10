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
            user = (User)Application.Current.Resources["User"];
            Title.Text = $"Bonjour {user.Name}";
        }

        public void init()
        {
            //InitJson.UJsonTextReader()
        }

        private void Btn_LaunchGamePendu(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(GamePendu));
        private void Btn_LaunchGameMemoire(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(GameMemoire));
        private void Btn_LaunchGameConjugaison(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(GameConjugaison));
        private void Btn_LaunchGameEscape(object sender, RoutedEventArgs e) => rootFrame.Navigate(typeof(EscapeGame));


    }
}
