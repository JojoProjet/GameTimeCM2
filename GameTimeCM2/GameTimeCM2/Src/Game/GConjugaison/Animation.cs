using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Animation
    {

        private Card Card { get; set; }
        private StackPanel StackPaneLCards { get; set; }

        private readonly int MilliSecondes = 1500;

        private const string Target_Property_Projection_PlaneProjecton_RotationX = "(UIElement.Projection).(PlaneProjection.RotationX)";

        private const string RESSOURCES_ANIMATE_CARD_FRONT = "AnimateCardFront";
        private const string RESSOURCES_ANIMATE_CARD_BACK = "AnimateCardBack";

        public const string ANIMATE_SIDE_FRONT = "Front";
        public const string ANIMATE_SIDE_BACK = "Back";


        public Animation(Card card, StackPanel stackPanelCards)
        {
            Card = card;
            StackPaneLCards = stackPanelCards;
        }

        private string GetStringAnimationCardFrontIdName() => $"{RESSOURCES_ANIMATE_CARD_FRONT}{Card.IdName}";

        private string GetStringAnimationCardBackIdName() => $"{RESSOURCES_ANIMATE_CARD_BACK}{Card.IdName}";

        public void CreateAnimation()
        {

            int propsX1 = -10;
            int propsX2 = -190;

            Storyboard storyCardBack = GetAnimateCard(GetDoubleAnimationCard(propsX1, propsX2, StackPaneLCards));
            Storyboard storyCardFront = GetAnimateCard(GetDoubleAnimationCard(propsX2, propsX1, StackPaneLCards));

            if (!StackPaneLCards.Resources.ContainsKey(GetStringAnimationCardFrontIdName()) && !StackPaneLCards.Resources.ContainsKey(GetStringAnimationCardBackIdName()))
            {
                StackPaneLCards.Resources.Add(GetStringAnimationCardFrontIdName(), storyCardBack);
                StackPaneLCards.Resources.Add(GetStringAnimationCardBackIdName(), storyCardFront);
            }

        }

        public void AnimateCard(TextBlock text, StackPanel s1, StackPanel s2, Button b, Game game)
        {
            Storyboard storyFront = StackPaneLCards.Resources[GetStringAnimationCardFrontIdName()] as Storyboard;
            Storyboard storyBack = StackPaneLCards.Resources[GetStringAnimationCardBackIdName()] as Storyboard;

            storyFront.Completed += (e, s) =>
            {
                StackPanel stackPanel = (StackPanel)StackPaneLCards.FindName(Card.IdName);

                if (Card.IdName == "Card4")
                {
                    Thread.Sleep(1000);

                    storyBack.Completed += (a, r) =>
                    {
                        b.IsEnabled = true;
                        game.SetNewValueTextCard(b);
                        text.Visibility = Visibility.Visible;
                        s1.Visibility = Visibility.Collapsed;
                        s2.Visibility = Visibility.Collapsed;
                    };
                }
                storyBack.Begin();

            };

            storyFront.Begin();
        }

        public static Storyboard AnimateEmoji(Page page, StackPanel image)
        {
            Storyboard storyboardEmoji = Utils.Animation.CreateStoryboard_TranslateY_Opacity(image);

            if (!page.Resources.ContainsKey($"Animate{image.Name}"))
                page.Resources.Add($"Animate{image.Name}", storyboardEmoji);

            Storyboard storyboard = page.Resources[$"Animate{image.Name}"] as Storyboard;

            return storyboard;
        }


        public DoubleAnimation GetDoubleAnimationCard(int from, int to, StackPanel stack)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(MilliSecondes));

            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = duration
            };

            doubleAnimation.Completed += (s, e) =>
            {
                StackPanel stackPanel = (StackPanel)stack.FindName(Card.IdName);

                double rotationX = (double)stackPanel.Projection.GetValue(PlaneProjection.RotationXProperty);

                string cardTextDefaultBackCard = "";

                // Change le background par rapport à la rotationX
                if (rotationX < -90)
                {
                    stackPanel.BorderBrush = null;
                    stackPanel.Background = Card.BackgroundImageBrushBackCard();
                    Card.Text = cardTextDefaultBackCard;
                }
                else
                {
                    stackPanel.Background = Card.PropertyImageBrush();
                }
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


        public void CacheCardAnimation()
        {
            StackPanel stackPanel = (StackPanel)StackPaneLCards.FindName(Card.IdName);
            double rotationX = (double)stackPanel.Projection.GetValue(PlaneProjection.RotationXProperty);
            if (rotationX < -90)
            {
                stackPanel.Background = new SolidColorBrush(Colors.Red);
            }
        }

    }
}
