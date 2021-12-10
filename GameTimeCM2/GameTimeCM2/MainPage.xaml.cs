using GameTimeCM2.Src;
using GameTimeCM2.Src.Game;
using GameTimeCM2.Src.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void UBoolEnable(bool enable)
        {
            IName.IsEnabled = enable;
            IMotDePasse.IsEnabled = enable;
            BtnRegister.IsEnabled = enable;
            BtnLaunchGame.IsEnabled = enable;
            ErrorPopup.IsOpen = !enable;

        }

        private void Btn_Register(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewRegister));
        }

        private void Btn_LaunchGame(object sender, RoutedEventArgs e)
        {
            Db db = new Db();
            AccountService accountService = new AccountService();
            User user = accountService.Login(IName.Text, IMotDePasse.Text);
            if(user != null)
            {
                Application.Current.Resources["User"] = user;
                Frame.Navigate(typeof(AccueilGame));
            }
            else 
                UBoolEnable(false);
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            UBoolEnable(true);
        }
    }
}
