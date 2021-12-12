using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Card : INotifyPropertyChanged
    {

        // Props
        private readonly int Width = 250;
        private readonly int Height = 300;

        public string IdName { get; set; }


        private string text;

        public string Text
        {
            get => text; 
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }


        public int AngleProps { get; set; }
        public int TranslateX { get; set; }
        public int TranslateY { get; set; }

        public Card(string id, string text, int angleProps, int translateX = 0, int translateY = 0)
        {
            IdName = id;
            this.text = text;
            AngleProps = angleProps;
            TranslateX = translateX;
            TranslateY = translateY;
        }

        public PlaneProjection InitPlaneProjection()
        {
            return new PlaneProjection()
            {
                RotationX = -10,
                RotationY = 0,
                RotationZ = 0,
                CenterOfRotationX = 1
            };
        }

        public CompositeTransform InitCompositeTransform()
        {
            return new CompositeTransform()
            {
                Rotation = AngleProps,
                TranslateX = TranslateX,
                TranslateY = TranslateY,
            };
        }

        public CornerRadius InitCornerRadius()
        {
            return new CornerRadius()
            {
                TopRight = 10,
                TopLeft = 10,
                BottomRight = 10,
                BottomLeft = 10
            };
        }

        public ImageBrush InitImageBrush()
        {
            const string URI_ASSETS_BRIQUE = "ms-appx:///Assets/AGames/brique.jpg";

            Image image = new Image()
            {
                Source = new BitmapImage(new Uri(URI_ASSETS_BRIQUE))
            };

            return new ImageBrush()
            {
                ImageSource = image.Source
            };
        }

        public TextBlock InitTextBlock()
        {
            
            TextBlock textblock = new TextBlock()
            {
                Name = $"Text{IdName}",
                Text = text,
                Width = Width,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                FontSize = 24,
                FontStyle = Windows.UI.Text.FontStyle.Italic,
                TextWrapping = TextWrapping.Wrap,
            };

            return textblock;

        }

        public Binding InitBinding()
        {
            return new Binding()
            {
                Source = this,
                Path = new PropertyPath("Text"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay
            };
        }

        public StackPanel InitCard()
        {

            StackPanel stackPanel= new StackPanel()
            {
                Name = IdName,
                Width = Width,
                Height = Height,
                IsTapEnabled = true,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = InitImageBrush(),
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, -150, 50, 0),
                Padding = new Thickness(0, 50, 0, 0),
                BorderThickness = new Thickness(5, 5, 5, 5),
                CornerRadius = InitCornerRadius(),
                Projection = InitPlaneProjection(),
                RenderTransform = InitCompositeTransform(),
            };

            stackPanel.Tapped += new TappedEventHandler(Tapped_CardTapped);

            TextBlock textBlock = InitTextBlock();

            textBlock.SetBinding(TextBlock.TextProperty, InitBinding());

            stackPanel.Children.Add(textBlock);

            return stackPanel;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Tapped_CardTapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;

            Card card;

            if(Application.Current.Resources.ContainsKey("Card")) 
            {
                card = (Card)Application.Current.Resources["Card"];
                if (card.IdName != IdName)
                {
                    Application.Current.Resources["Card"] = this;
                    stackPanel.BorderBrush = new SolidColorBrush(Colors.Red);
                } else
                {
                    stackPanel.BorderBrush = null;
                }
            }
            else
            {
                Application.Current.Resources["Card"] = this;
            }
            
        }

    }
}
