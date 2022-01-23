using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Game
    {

        private int IdDataJson = 1;
        private int Score { get; set; }
        private const string STRING_SCORE = "Votre Score :";

        private bool UserFinishGame { get; set; }
        public static int TWinGame { get; set; }

        private Cards LCards { get; set; }
        private Animations Animations { get; set; }
        private StackPanel StackPanelCards { get; set; }
        private TextBlock TextBlockQuestion { get; set; }

        public static TextBlock TextWinOrLoose { get; set; }
        public static TextBlock TextFinishScore { get; set; }
        public static Storyboard StoryBoardFinish { get; set; }

        private List<Data> ListData { get; set; }
        private IOrderedEnumerable<Data> ListRandomized { get; set; }
        public Data Data
        {
            get => ListRandomized.SingleOrDefault(item => item.Id == IdDataJson);
        }

        public Game(StackPanel stackPanel, TextBlock textBlockQuestion, TextBlock textBlockScore)
        {
            StackPanelCards = stackPanel;
            TextBlockQuestion = textBlockQuestion;

            // get the json response question
            InitDataJson();

            LCards = new Cards(stackPanel, Data.Response);
            Animations = new Animations();

            Score = 0;
            textBlockScore.Text = $"{STRING_SCORE} {Score}";
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
            Random rnd = new Random();
            ListRandomized = ListData.OrderBy(item => rnd.Next());
            int index = 1;
            foreach (Data data in ListRandomized)
            {
                data.Id = index++;
            }
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

        public void DoAnimationCard(TextBlock text, StackPanel s1, StackPanel s2, Button b)
        {
            // Value de data < Data.Count Stop it and anim win or loose and set in db

            // Hide card front
            LCards.ForEach(card =>
            {
                StackPanel stackPanel = (StackPanel)StackPanelCards.FindName(card.IdName);
                stackPanel.Background = card.BackgroundImageBrushBackCard();
                card.Text = "";
            });
            Animations.ForEach(animation => animation.AnimateCard(text, s1, s2, b, this));
        }

        public void SetNewValueTextCard(Button b)
        {
            try
            {
                if (IdDataJson > 6) throw new Exception();
                // Nouvelle valeur de text
                else
                {
                    LCards.ElementAt(0).Text = Data.Conjugaison1;
                    LCards.ElementAt(1).Text = Data.Conjugaison2;
                    LCards.ElementAt(2).Text = Data.Conjugaison3;
                    LCards.ElementAt(3).Text = Data.Conjugaison4;

                    TextBlockQuestion.Text = Data.Question;

                    LCards.Response = Data.Response;
                }
            }
            catch (Exception)
            {
                // Affiche popup here
                b.IsEnabled = false;
                LCards.ForEach(card =>
                {
                    StackPanel stackPanel = (StackPanel)StackPanelCards.FindName(card.IdName);
                    stackPanel.Tapped -= new TappedEventHandler(card.Tapped_Card);
                });
                TextBlockQuestion.Text = "";
                TWinGame += Score > 1 ? 1 : 0;
                TextWinOrLoose.Text = Score > 1 ? "Bien joué !" : "Vous avez perdu !";
                TextFinishScore.Text = $"Votre Score : {Score}";
                StoryBoardFinish.Begin();
            }
        }

        public void ShowScore(TextBlock textScore)
        {
            textScore.Text =  $"{STRING_SCORE} {Score}";
        }

        public bool Check(Card card)
        {
            if (card.Text == LCards.Response) {
                ++Score;
                return true;
            }
            return false;
        }

        public void ShowSelectResponse(TextBlock textSelectResponse)
        {
            const string STRING_SELECT_RESPONSE = "Sélectionner une carte !";
            textSelectResponse.Text = STRING_SELECT_RESPONSE;
        }

        public bool CheckReponse(TextBlock textScore)
        {
            Card card = (Card)Application.Current.Resources[Constants.APPLICATION_RESSOURCES_CARD];
            bool check = Check(card);
            IdDataJson++;
            Application.Current.Resources.Remove(Constants.APPLICATION_RESSOURCES_CARD);
            ShowScore(textScore);
            return check;
        }

    }
}
