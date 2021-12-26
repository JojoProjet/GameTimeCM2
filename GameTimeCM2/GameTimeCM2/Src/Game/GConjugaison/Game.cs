using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Game
    {

        private int IdDataJson = 1;
        private int Score { get; set; }
        private bool UserFinishGame { get; set; }

        private Cards LCards { get; set; }
        private Animations Animations { get; set; }
        private StackPanel StackPanelCards { get; set; }
        private TextBlock TextBlockQuestion { get; set; }

        private List<Data> ListData { get; set; }

        public Data Data
        {
            get => ListData.SingleOrDefault(item => item.Id == IdDataJson);
        }

        public Game(StackPanel stackPanel, TextBlock textBlock)
        {
            StackPanelCards = stackPanel;
            TextBlockQuestion = textBlock;

            // get the json response question
            InitDataJson();

            LCards = new Cards(stackPanel, Data.Response);
            Animations = new Animations();

            Score = 0;
            UserFinishGame = false;
            TextBlockQuestion.Text = Data.Question;
        }

        public void Init()
        {
            CreateCards();
            CreateAnimationCard();
        }


        public void InitDataJson()
        {
            StreamReader file = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), "Json/gameConjugaison.json"));
            ListData = new JsonSerializer().Deserialize<List<Data>>(new JsonTextReader(file));
        }

        public void CreateCards()
        {

            const string CARD = "Card";

            int angleLeft = -10;
            int angleLeftBase = -1;
            int angleRightBase = 1;
            int angleRight = 10;

            int TransformTranslateXLeft = -25;
            int TransformTranslateXRight = 25;
            int TransformTranslateYTop1 = 50;
            int TransformTranslateYTop2 = 10;

            
            Card card1 = new Card($"{CARD}1", Data.Conjugaison1, angleLeft, TransformTranslateXLeft, TransformTranslateYTop1);
            Card card2 = new Card($"{CARD}2", Data.Conjugaison2, angleLeftBase);
            Card card3 = new Card($"{CARD}3", Data.Conjugaison3, angleRightBase);
            Card card4 = new Card($"{CARD}4", Data.Conjugaison4, angleRight, TransformTranslateXRight, TransformTranslateYTop2);

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
            IdDataJson++;

            // Nouvelle valeur de text
            LCards.ElementAt(0).Text = Data.Conjugaison1;
            LCards.ElementAt(1).Text = Data.Conjugaison2;
            LCards.ElementAt(2).Text = Data.Conjugaison3;
            LCards.ElementAt(3).Text = Data.Conjugaison4;

            TextBlockQuestion.Text = Data.Question;

            if("front") 
                else if ("back") ...

            LCards.Response = Data.Response;

            Animations.ForEach(animation => animation.AnimateCard(side));
        }


        public void CheckReponse(TextBlock textScore)
        {
            Card card = (Card)Application.Current.Resources[Constants.APPLICATION_RESSOURCES_CARD];
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
