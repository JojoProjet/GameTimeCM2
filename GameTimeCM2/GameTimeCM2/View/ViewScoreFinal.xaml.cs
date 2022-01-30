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
using Windows.UI;

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
            Init();
        }

        public void InitStackPanel(StackPanel stackPanel)
        {
            stackPanel.Width = 400;
            stackPanel.Height = 50;
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public void InitListViewItem(ListViewItem listViewItem)
        {
            listViewItem.Width = 400;
            listViewItem.Height = 50;
            listViewItem.VerticalAlignment = VerticalAlignment.Center;
            listViewItem.HorizontalAlignment = HorizontalAlignment.Center;
        }

        public void InitTextBlock(TextBlock textBlock)
        {
            textBlock.Width = 200;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
             
        private void Init()
        {

            ButtonReturnAccueil.Content = Constants.BUTTON_CONTENT_RETURN_HOME;

            IEnumerable<User> lUserPerScoreASC = db.GetUsers().OrderByDescending(user => user.Score).Take(10);

            foreach(User item in lUserPerScoreASC)
            {
                StackPanel stackPanel = new StackPanel();
                ListViewItem listViewItem = new ListViewItem();
                TextBlock textBlockUser = new TextBlock()
                {
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                TextBlock textBlockScore = new TextBlock()
                {
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Colors.Red)
                };

                InitStackPanel(stackPanel);
                InitListViewItem(listViewItem);
                InitTextBlock(textBlockUser);
                InitTextBlock(textBlockScore);

                textBlockUser.Text = item.Name;
                textBlockScore.Text = item.Score.ToString();

                stackPanel.Children.Add(textBlockUser);
                stackPanel.Children.Add(textBlockScore);
                listViewItem.Content = stackPanel;

                listUserScoreFinal.Items.Add(listViewItem);
            };

        }

        private void Btn_ReturnAccueil(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccueilGame));
        }

        private void Loaded_Page(object sender, RoutedEventArgs e)
        {
            Animation.AnimatePage(Page, Stack).Begin();
        }

    }
}
