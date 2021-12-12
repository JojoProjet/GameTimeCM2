﻿using System;
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
        private StackPanel StackPaneLCards { get; set; }

        private readonly int MilliSecondes = 1500;

        private const string Target_Property_Projection_PlaneProjecton_RotationX = "(UIElement.Projection).(PlaneProjection.RotationX)";

        private const string RESSOURCES_ANIMATE_CARD_FRONT = "AnimateCardFront";
        private const string RESSOURCES_ANIMATE_CARD_BACK = "AnimateCardBack";

        public const string ANIMATE_SIDE_FRONT = "Front";
        public const string ANIMATE_SIDE_BACK = "Back";

        private bool BoolAnimate { get; set; }

        public Animation(Card card, StackPanel stackPanelCards)
        {
            Card = card;
            StackPaneLCards = stackPanelCards;
            BoolAnimate = true;
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

        public void AnimateCard(string animateSide)
        {
            Storyboard story = StackPaneLCards.Resources[animateSide == ANIMATE_SIDE_FRONT ? GetStringAnimationCardFrontIdName() : GetStringAnimationCardBackIdName()] as Storyboard;
            story.Begin();
        }


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

                double rotationX = (double)stackPanel.Projection.GetValue(PlaneProjection.RotationXProperty);

                if (rotationX < -90) stackPanel.Background = new SolidColorBrush(Colors.Red);
                else stackPanel.Background = Card.InitImageBrush();

                BoolAnimate = BoolAnimate ? false : true;
                //boolAnimate == false ? 
                //    stackPanel.Background = new SolidColorBrush(Colors.Red) : 
                //    stackPanel.Background = Card.InitImageBrush();
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