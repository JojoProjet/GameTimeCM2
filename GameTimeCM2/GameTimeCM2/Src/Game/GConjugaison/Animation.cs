using System;
using System.Collections.Generic;
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
    class Animation
    {

        private Card Card { get; set; }

        private readonly int MilliSecondes = 1500;

        private const string Target_Property_Projection_PlaneProjecton_RotationX = "(UIElement.Projection).(PlaneProjection.RotationX)";

        public Animation(Card card)
        {
            Card = card;
        }

        private bool boolAnimate = true;

        public DoubleAnimation GetDoubleAnimationCard(int from, int to, StackPanel stack)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(MilliSecondes));

            DoubleAnimation doubleAnimation = new DoubleAnimation();

            doubleAnimation.From = from;
            doubleAnimation.To = to;
            doubleAnimation.Duration = duration;
            doubleAnimation.Completed += (s, e) =>
            {
                StackPanel stackPanel = (StackPanel)stack.FindName(Card.IdName);
                boolAnimate = true ? false : true;
                boolAnimate == false ? 
                    stackPanel.Background = new SolidColorBrush(Colors.Red) : 
                    stackPanel.Background = Card.InitImageBrush();
            };

            return doubleAnimation;

        }


        public Storyboard GetAnimateCard(DoubleAnimation animation)
        {

            Storyboard storyboardCard = new Storyboard();
            storyboardCard.Children.Add(animation);

            Storyboard.SetTargetName(animation, Card.IdName);
            Storyboard.SetTargetProperty(animation, Target_Property_Projection_PlaneProjecton_RotationX);

            return storyboardCard;
        }


    }
}
