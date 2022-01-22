using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace GameTimeCM2.Src.Game.GMemoire
{
    class Card
    {

        public int Id { get; set; }
        public string Source { get; set; }

        public Image Image { get; set; }
        public StackPanel StackPanel { get; set; }

        public Card(int id, string source)
        {
            Id = id;
            Source = source;
        }

        public StackPanel Create(int row, int column)
        {
            Image = new Image()
            {
                Name = $"Img{Id}",
                Height = 150,
                Source = new BitmapImage(new Uri(Source)),
                Opacity = 0
            };

            StackPanel = new StackPanel()
            {
                Name = $"{Id}",
                Width = 200,
                Height = 150,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = new SolidColorBrush(Colors.Black),
                Margin = new Thickness(20, 0, 20, 0),
                IsTapEnabled = true,
                IsDoubleTapEnabled = false
            };

            Grid.SetRow(StackPanel, row);
            Grid.SetColumn(StackPanel, column);

            StackPanel.Tapped += new TappedEventHandler(Tapped_CardMemory);

            StackPanel.Children.Add(Image);
            return StackPanel;
        }

        public void Tapped_CardMemory(object sender, TappedRoutedEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;

            Storyboard storyVisible = (Storyboard)Game.StackPanelGame.Resources[$"AnimateCardVisile{Id}"];
            Storyboard storyNotVisible = (Storyboard)Game.StackPanelGame.Resources[$"AnimateCardNotVisible{Id}"];

            storyVisible.Begin();
            StackPanel.Tapped -= new TappedEventHandler(Tapped_CardMemory); 

            Game.Select++;
            Application.Current.Resources[$"Card{Game.Select}"] = this;
            if (Game.Select == 2)
            {
                Game.DesactiveTapped();
                Game.ScoreCoupFinal += 1;
            }
        }

    }
}
