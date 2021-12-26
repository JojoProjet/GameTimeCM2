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

        public PlaneProjection PropertyPlaneProjection()
        {
            return new PlaneProjection()
            {
                RotationX = -10,
                RotationY = 0,
                RotationZ = 0,
                CenterOfRotationX = 1
            };
        }

        public CompositeTransform PropertyCompositeTransform()
        {
            return new CompositeTransform()
            {
                Rotation = AngleProps,
                TranslateX = TranslateX,
                TranslateY = TranslateY,
            };
        }

        public CornerRadius PropertyCornerRadius()
        {
            return new CornerRadius()
            {
                TopRight = 10,
                TopLeft = 10,
                BottomRight = 10,
                BottomLeft = 10
            };
        }

        // Front Card
        public ImageBrush PropertyImageBrush()
        {
            const string URI_ASSETS_BRIQUE = "ms-appx:///Assets/AGames/brique.jpg";

            return new ImageBrush()
            {
                ImageSource = new Image()
                {
                    Source = new BitmapImage(new Uri(URI_ASSETS_BRIQUE))
                }.Source
            };
        }

        public TextBlock PropertyTextBlock()
        {
            return new TextBlock()
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
        }

        public Binding PropertyBinding()
        {
            const string PROPERTY_PATH_TEXT = "Text";

            return new Binding()
            {
                Source = this,
                Path = new PropertyPath(PROPERTY_PATH_TEXT),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay
            };
        }

        // Initliase Card
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
                Background = PropertyImageBrush(),
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, -150, 50, 0),
                Padding = new Thickness(0, 50, 0, 0),
                BorderThickness = new Thickness(5, 5, 5, 5),
                CornerRadius = PropertyCornerRadius(),
                Projection = PropertyPlaneProjection(),
                RenderTransform = PropertyCompositeTransform(),
            };

            stackPanel.Tapped += new TappedEventHandler(Tapped_Card);

            TextBlock textBlock = PropertyTextBlock();

            textBlock.SetBinding(TextBlock.TextProperty, PropertyBinding());

            stackPanel.Children.Add(textBlock);

            return stackPanel;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Tapped_Card(object sender, TappedRoutedEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;

            Action ThisCard = () =>
            {
                Application.Current.Resources[Constants.APPLICATION_RESSOURCES_CARD] = this;
                stackPanel.BorderBrush = new SolidColorBrush(Colors.Red);
            };

            if (Application.Current.Resources.ContainsKey(Constants.APPLICATION_RESSOURCES_CARD)) 
            {
                Card card = (Card)Application.Current.Resources[Constants.APPLICATION_RESSOURCES_CARD];
                if (card.IdName != IdName) ThisCard();
            }
            else
            {
                ThisCard();
            }

        }

        ///// Back Card /////
        public ImageBrush BackgroundImageBrushBackCard()
        {
            const string uri = "ms-appx:///Assets/AGames/img_back_card.png";

            ImageBrush imageBrush = new ImageBrush()
            {
                ImageSource = new Image()
                {
                    Source = new BitmapImage(new Uri(uri))
                }.Source
            };

            return imageBrush;
        }
        ///////////////////////

    }
}
