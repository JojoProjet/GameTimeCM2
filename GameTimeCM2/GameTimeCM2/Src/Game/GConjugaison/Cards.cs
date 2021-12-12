using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Cards : List<Card>
    {

        public string Response { get; set; }

        public StackPanel StackPanelCards { get; set; }

        public List<StackPanel> ListStackPanelCards { get; set; }


        public Cards(StackPanel stackPanelCards, string response)
        {
            StackPanelCards = stackPanelCards;
            Response = response;
        }

        public void InitCards()
        {
            ForEach(card =>
            {
                StackPanelCards.Children.Add(card.InitCard());
            });
        }

        public void DoCardAnimation()
        {
            ForEach(card =>
            {
                Animate(card);
            });
        }


        public void Animate(Card card)
        {
            Animation animation = new Animation(card);
            Storyboard storyCard = animation.GetAnimateCard(animation.GetDoubleAnimationCard(-190, -10, StackPanelCards));

            if (!StackPanelCards.Resources.ContainsKey($"AnimateCard{card.IdName}")) 
                StackPanelCards.Resources.Add($"AnimateCard{card.IdName}", storyCard);

            storyCard.Begin();
        }

        public void CacheCardAnimation(Card card)
        {
            StackPanel stackPanel = (StackPanel)StackPanelCards.FindName(card.IdName);
            double rotationX = (double)stackPanel.Projection.GetValue(PlaneProjection.RotationXProperty);
            if (rotationX < -90)
            {
                stackPanel.Background = new SolidColorBrush(Colors.Red);
            }
        }


    }
}
