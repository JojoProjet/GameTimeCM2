using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Game
    {

        private int Score { get; set; }
        private bool UserFinishGame { get; set; }

        private Cards LCards { get; set; }
        private Animations Animations { get; set; }
        private StackPanel StackPanelCards { get; set; }

        public Game(StackPanel stackPanel)
        {
            StackPanelCards = stackPanel;

            // get the json response question


            LCards = new Cards(stackPanel, "resp");
            Animations = new Animations();

            Score = 0;
            UserFinishGame = false;
        }

        public void Init()
        {
            CreateCards();
            CreateAnimationCard();
        }

        public void setDataJson()
        {

        }

        public void CreateCards()
        {

            string card = "Card";

            int angleLeft = -10;
            int angleLeftBase = -1;
            int angleRightBase = 1;
            int angleRight = 10;

            int TransformTranslateXLeft = -25;
            int TransformTranslateXRight = 25;
            int TransformTranslateYTop1 = 50;
            int TransformTranslateYTop2 = 10;

            Card card1 = new Card($"{card}1", "aze", angleLeft, TransformTranslateXLeft, TransformTranslateYTop1);
            Card card2 = new Card($"{card}2", "azezaeaz", angleLeftBase);
            Card card3 = new Card($"{card}3", "aeazeaeze", angleRightBase);
            Card card4 = new Card($"{card}4", "azaeazeze", angleRight, TransformTranslateXRight, TransformTranslateYTop2);

            LCards.Add(card1);
            LCards.Add(card2);
            LCards.Add(card3);
            LCards.Add(card4);

            LCards.InitCards();

        }

        public void CreateAnimationCard()
        {
            LCards.ForEach(card =>
            {
                Animation animation = new Animation(card, StackPanelCards);
                Animations.Add(animation);                
                animation.CreateAnimation();
            });
        }

        public void DoAnimationCard(string side)
        {
            LCards.ForEach(card => card.Text = "Popo");
            Animations.ForEach(animation => animation.AnimateCard(side));
        }


        public void CheckReponse(TextBlock textScore)
        {
            Card card = (Card)Application.Current.Resources["Card"];
            if(card.Text == LCards.Response)
            {
                textScore.Text += $"{Score++}";
            } else
            {
                textScore.Text += $"{Score}";
            }
        }

    }
}
