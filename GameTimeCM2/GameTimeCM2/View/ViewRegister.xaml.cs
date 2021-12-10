using GameTimeCM2.Src;
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
    public sealed partial class ViewRegister : Page
    {

        private readonly AccountService accountService = new AccountService();

        public ViewRegister()
        {
            this.InitializeComponent();
        }

        public void UBoolEnable(bool enable)
        {
            IName.IsEnabled = enable;
            IMotDePasse.IsEnabled = enable;
            BtnRegister.IsEnabled = enable;
        }

        public void UAllEnable(bool enable, TextBlock textBlock, Popup popup, string regi)
        {
            UBoolEnable(enable);
            textBlock.Text = regi;
            popup.IsOpen = !enable;
        }

        public void Btn_Register(object sender, RoutedEventArgs e)
        {
            string name = IName.Text;
            string password = IMotDePasse.Text;
            string regi = accountService.Register(name, password);
            if(regi == Constants.STRING_INSCRIPTION_GOOD && regi != Constants.STRING_INSCRIPTION_ERROR)
                UAllEnable(false, TextSuccess, SuccessPopup, regi);
            else
                UAllEnable(false, TextError, ErrorPopup, regi);
        }

        private void Btn_ReturnMain(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Btn_PopupLoginClick(object sender, RoutedEventArgs e)
        {
            SuccessPopup.IsOpen = false;
            Frame.Navigate(typeof(MainPage));
        }
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            ErrorPopup.IsOpen = false;
            UBoolEnable(true);
        }

    }
}
