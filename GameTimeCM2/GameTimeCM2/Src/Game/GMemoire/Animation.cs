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

namespace GameTimeCM2.Src.Game.GMemoire
{
    class Animation
    {

        public Card Card { get; set; }
        public StackPanel StackPanel { get; set; }

        private Duration Duration { get; set; }

        public Animation(Card card, StackPanel stackPanel)
        {
            Card = card;
            StackPanel = stackPanel;
            Duration = new Duration(TimeSpan.FromMilliseconds(1500));
        }

        public void Create()
        {
            ColorAnimation doubleAnmationBackgroundToNull = CreateDoubleAnimationBackgroundNull();
            DoubleAnimation doubleAnmationVisibilityToOpacity1 = CreateDoubleAnimationOpacity(0, 1);

            ColorAnimation doubleAnmationBackgroundToBlack = CreateDoubleAnimationBackgroundBlack();
            DoubleAnimation doubleAnmationVisibilityToOpacity0 = CreateDoubleAnimationOpacity(1, 0);

            Storyboard storyboardCardVisible = CreateStoryboard(doubleAnmationBackgroundToNull, doubleAnmationVisibilityToOpacity1);
            Storyboard storyboardCardNotVisible = CreateStoryboard(doubleAnmationBackgroundToBlack, doubleAnmationVisibilityToOpacity0);

            storyboardCardVisible.Completed += (s, e) =>
            {
                if (Game.Select == 2)
                {
                    Card card1 = (Card)Application.Current.Resources["Card1"];
                    Card card2 = (Card)Application.Current.Resources["Card2"];
                    Storyboard storyNotVisible1 = (Storyboard)Game.StackPanelGame.Resources[$"AnimateCardNotVisible{card1.Id}"];
                    Storyboard storyNotVisible2 = (Storyboard)Game.StackPanelGame.Resources[$"AnimateCardNotVisible{card2.Id}"];

                    bool check = card1.Source == card2.Source;
                    if (!check)
                    {
                        storyNotVisible1.Begin();
                        storyNotVisible2.Begin();
                    }
                    else if (check)
                    {
                        Game.TabCardOk.Add(card1.Id);
                        Game.TabCardOk.Add(card2.Id);
                    }
                    Game.ActiveTapped();
                    Game.Select = 0;
                }
            };

            if (!StackPanel.Resources.ContainsKey($"AnimateCardVisile{Card.Id}") && !StackPanel.Resources.ContainsKey($"AnimateCardNotVisible{Card.Id}"))
            {
                StackPanel.Resources.Add($"AnimateCardVisile{Card.Id}", storyboardCardVisible);
                StackPanel.Resources.Add($"AnimateCardNotVisible{Card.Id}", storyboardCardNotVisible);
            }

        }

        public void Storyboard_CompletedVisible(object sender, EventArgs e)
        {

        }

        private DoubleAnimation CreateDoubleAnimationOpacity(int from, int to)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = Duration
            };
            return doubleAnimation;
        }

        public ColorAnimation CreateDoubleAnimationBackgroundNull()
        {
            return new ColorAnimation()
            {
                From = Colors.Black,
                To = Colors.White,
                Duration = Duration
            };
        }

        public ColorAnimation CreateDoubleAnimationBackgroundBlack()
        {
            return new ColorAnimation()
            {
                From = Colors.White,
                To = Colors.Black,
                Duration = Duration
            };
        }


        public Storyboard CreateStoryboard(ColorAnimation colorAnimationBackground, DoubleAnimation doubleAnimationVisibility)
        {
            Storyboard storyboardCard = new Storyboard();
            storyboardCard.Children.Add(colorAnimationBackground);
            storyboardCard.Children.Add(doubleAnimationVisibility);

            Storyboard.SetTargetName(colorAnimationBackground, $"{Card.Id}");
            Storyboard.SetTargetProperty(colorAnimationBackground, "(StackPanel.Background).(SolidColorBrush.Color)");

            Storyboard.SetTargetName(doubleAnimationVisibility, $"Img{Card.Id}");
            Storyboard.SetTargetProperty(doubleAnimationVisibility, "Opacity");

            return storyboardCard;

        }

    }
}
