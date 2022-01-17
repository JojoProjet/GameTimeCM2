using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

namespace GameTimeCM2.Src.Game.GMemoire
{
    class Game
    {
        private List<Data> ListData { get; set; }

        public static int Select { get; set; }
        public static List<int> TabCardOk { get; set; }

        public static StackPanel StackPanelGame { get; set; }
        public static StackPanel Stack_FinishGame { get; set; }

        public Grid Grid { get; set;}

        public static Cards Cards { get; set; }

        public Game(StackPanel stackPanelGame, Grid grid)
        {
            InitDataJson();
            StackPanelGame = stackPanelGame;
            Grid = grid;
        }

        public void InitDataJson()
        {
            StreamReader file = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), "Json/data.json"));
            ListData = new JsonSerializer().Deserialize<List<Data>>(new JsonTextReader(file));
        }

        public void Init()
        {
            Select = 0;
            TabCardOk = new List<int>
            {
                0
            };
            Cards = new Cards(Grid);
            Random rnd = new Random();
            IOrderedEnumerable<Data> listRandomized = ListData.OrderBy(item => rnd.Next());

            foreach(Data data in listRandomized)
            {
                Cards.Add(new Card(data.Id, data.Image)); ;
            }

            Cards.Init();

            Cards.ForEach(card =>
            {
                Animation animation = new Animation(card, StackPanelGame);
                animation.Create();
            });

            
            // LoadStoryBeginGame();
        }

        private void LoadStoryBeginGame()
        {
            DesactiveTapped();
            for (int i = 1; i <= 12; i++)
            {
                Storyboard storyVisible = (Storyboard)StackPanelGame.Resources[$"AnimateCardVisile{i}"];
                if (i == 12)
                {
                    storyVisible.Completed += (o, s) =>
                    {
                        Thread.Sleep(2000);
                        for (int u = 1; u <= 12; u++)
                        {
                            Storyboard storyNotVisible = (Storyboard)StackPanelGame.Resources[$"AnimateCardNotVisible{u}"];
                            storyNotVisible.Begin();
                        }
                        ActiveTapped();
                        storyVisible.Completed -= null;
                    };
                } 
                storyVisible.Begin();
            }
        }

        public static void DesactiveTapped()
        {
            Cards.ForEach(card =>
            {
                card.StackPanel.Tapped -= new TappedEventHandler(card.Tapped_CardMemory);
            });
        }

        public static void ActiveTapped()
        {
            Storyboard story = (Storyboard)StackPanelGame.Resources["Storyboard_StackFinishGame"];
            Cards.ForEach(card =>
            {
                if(TabCardOk.Contains(card.Id) == false)
                    card.StackPanel.Tapped += new TappedEventHandler(card.Tapped_CardMemory);
            });

            if (TabCardOk.ToArray().Length >= 12)
            {
                Stack_FinishGame.Visibility = Visibility.Visible;
                story.Begin();
            }

        }

        public void SetNewGame(Storyboard Storyboard_StackNewGame, StackPanel Stack_FinishGame)
        {
            Cards.RemoveElementInGrid();
            Storyboard_StackNewGame.Completed += (o1, s1) =>
            {
                Stack_FinishGame.Visibility = Visibility.Collapsed;
                for (int i = 1; i <= 12; i++)
                {
                    Storyboard story = (Storyboard)StackPanelGame.Resources[$"AnimateCardNotVisible{i}"];
                    if (i == 12) story.Completed += (o2, s2) => Init();
                    story.Begin();
                }
            };
            Storyboard_StackNewGame.Begin();
        }

    }
}