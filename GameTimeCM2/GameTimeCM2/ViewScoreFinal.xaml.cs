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
using GameTimeCM2.Src.Game;
using GameTimeCM2.Src.Utils;
using MySql.Data.MySqlClient;
using GameTimeCM2.Src;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    
    public sealed partial class ViewScoreFinal : Page
    {

        private Db db = new Db();

        public ViewScoreFinal()
        {
            this.InitializeComponent();
            init();
        }

        private void init()
        {
            ListViewItem listViewItem = new ListViewItem();
            StackPanel stackPanel = new StackPanel();
            TextBlock textBlockUser = new TextBlock();
            TextBlock textBlockScore = new TextBlock();

            // Props
            int P_WIDTH_1 = 400;
            int P_WIDTH_2 = 200;
            int P_HEIGHT_1 = 50;

            listViewItem.Width = P_WIDTH_1;
            listViewItem.Height = P_HEIGHT_1;
            listViewItem.VerticalAlignment = VerticalAlignment.Center;
            listViewItem.HorizontalAlignment = HorizontalAlignment.Center;

            stackPanel.Width = P_WIDTH_1;
            stackPanel.Height = P_HEIGHT_1;
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            textBlockUser.Width = P_WIDTH_2;
            textBlockUser.VerticalAlignment = VerticalAlignment.Center;
            textBlockUser.HorizontalAlignment = HorizontalAlignment.Stretch;

            textBlockScore.Width = P_WIDTH_2;
            textBlockScore.VerticalAlignment = VerticalAlignment.Center;
            textBlockScore.HorizontalAlignment = HorizontalAlignment.Stretch;

            db.GetUsers().ForEach(item =>
            {
                textBlockUser.Text = item.Name;
                textBlockScore.Text = item.Score.ToString();

                stackPanel.Children.Add(textBlockUser);
                stackPanel.Children.Add(textBlockScore);
                listViewItem.Content = stackPanel;

                listUserScoreFinal.Items.Add(listViewItem);
            });

        }

        private void btn_ReturnAccueil(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccueilGame));
        }
    }
}
