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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class EscapeGame : Page
    {
        public EscapeGame()
        {
            this.InitializeComponent();
            main.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/AGames/escapegame.jpg")), Stretch = Stretch.Fill };
        }

        private void Btn_LaunchGameSolo(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_LaunchGameMultiPlayer(object sender, RoutedEventArgs e)
        {

        }

    }
}
