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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    
    public sealed partial class ViewScoreFinal : Page
    {
        private List<User> ListUser { get; set; }

        private Db db = new Db();

        public ViewScoreFinal()
        {
            this.InitializeComponent();
            ListUser = new List<User>();
            initData();
            //listUserScoreFinal.Items.Add(ListUser.OrderBy(item => item.Score));
        }

        private void initData()
        {
            ListViewItem listViewItem = new ListViewItem();
            StackPanel stackPanel = new StackPanel();
            TextBlock textBlockUser = new TextBlock();
            TextBlock textBlockScore = new TextBlock();


            listViewItem.VerticalAlignment = VerticalAlignment.Center;
            listViewItem.HorizontalAlignment = HorizontalAlignment.Center;

            stackPanel.Width = 400;
            stackPanel.Height = 50;
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            stackPanel.VerticalAlignment = VerticalAlignment.Stretch;

            textBlockUser.Name = "user";
            textBlockUser.Width = 200;
            textBlockUser.Height = 50;
            textBlockUser.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlockUser.VerticalAlignment = VerticalAlignment.Center;

            textBlockScore.Name = "score";
            textBlockScore.Width = 200;
            textBlockScore.Height = 50;
            textBlockScore.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlockScore.VerticalAlignment = VerticalAlignment.Center;

            MySqlDataReader mysqlread = db.GetDataDb(db.SetCommandDb("SELECT * FROM User;"));
            while (mysqlread.Read())
            {
                textBlockUser.Text = mysqlread["Name"].ToString();
                textBlockScore.Text = mysqlread["Score"].ToString();

                stackPanel.Children.Add(textBlockUser);
                stackPanel.Children.Add(textBlockScore);
                listUserScoreFinal.Items.Add(listViewItem);
               // ListUser.Add(new User(int.Parse(mysqlread["Id"].ToString()), mysqlread["Name"].ToString(), int.Parse(mysqlread["Score"].ToString()), int.Parse(mysqlread["Time"].ToString()) ) );
            }
        }

        private void btn_ReturnAccueil(object sender, RoutedEventArgs e)
        {

        }
    }
}
