using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Card
    {

        // Props
        private int Width = 250;
        private int Height = 300;

        public string IdName { get; set; }
        public string Text { get; set; }

        public int AngleProps { get; set; }
        public int TranslateX { get; set; }
        public int TranslateY { get; set; }

        public Card(string id, string text, int angleProps, int translateX = 0, int translateY = 0)
        {
            IdName = id;
            Text = text;
            AngleProps = angleProps;
            TranslateX = translateX;
            TranslateY = translateY;
        }

        public DoubleAnimation GetDoubleAnimationCard()
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(3000));
            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = -10,
                To = -190,
                Duration = duration
            };
            return doubleAnimation;
        }

        public StackPanel Init()
        {

            PlaneProjection planeProjection = new PlaneProjection()
            {
                RotationX = -10,
                RotationY = 0,
                RotationZ = 0,
                CenterOfRotationX = 1
            };

            CompositeTransform compositeTransform = new CompositeTransform()
            {
                Rotation = AngleProps,
                TranslateX = TranslateX,
                TranslateY = TranslateY,
            };


            StackPanel stackPanel= new StackPanel()
            {
                Name = IdName,
                Width = Width,
                Height = Height,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = new SolidColorBrush(Colors.Aqua),
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 50, 50, 0),
                Projection = planeProjection,
                RenderTransform = compositeTransform,
            };

            TextBlock textBlock = new TextBlock()
            {
                Text = Text
            };


            DoubleAnimation animation = GetDoubleAnimationCard();

            Storyboard.SetTargetName(animation, stackPanel.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(PlaneProjection.RotationXProperty.ToString()).ToString());

            Storyboard storyboardCard = new Storyboard();
            storyboardCard.Children.Add(animation);

            /*stackPanel.Click += delegate(object sender, RoutedEventArgs args)
            {
                storyboardCard.Begin();
            };*/


            stackPanel.Children.Add(textBlock);

            return stackPanel;

        }

    }
}
