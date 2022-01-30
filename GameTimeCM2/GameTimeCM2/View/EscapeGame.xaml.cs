using GameTimeCM2.Src.Game.GEscapeGame;
using GameTimeCM2.Src.Utils;
using GameTimeCM2.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class EscapeGame : Page
    {
        private int IdDataJson = 1;
        private ScrollViewer ImageScroller { get; set; }
        private int NumberGame { get; set; }
        private List<Button> ListButton { get; set; }
        private List<Data> ListData { get; set; }
        private Data Data => ListData.SingleOrDefault(item => item.Id == IdDataJson);
        private int TWinGame { get; set; }

        public EscapeGame()
        {
            this.InitializeComponent();
            InitDataJson();
            ImageScroller = NameImageScroller;
            ListButton = new List<Button>()
            {
                new Button(), new Button(), new Button()
            };
            NumberGame = 1;
            CheckZoom();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TWinGame = (int)Application.Current.Resources["IntWinGameEscape"];
        }

        private List<Button> InitNewButton()
        {
            return new List<Button>()
            {
                new Button(), new Button(), new Button(),
            };
        }

        private void SwapGridGameToGame()
        {
            GridGame.Visibility = Visibility.Collapsed;
            Game.Visibility = Visibility.Visible;
            Storyboard_GridToGame.Begin();
        }

        private void SwapGameToGridGame()
        {
            GridGame.Visibility = Visibility.Visible;
            Game.Visibility = Visibility.Collapsed;
            Storyboard_GameToGrid.Begin();
        }

        private void Btn_EnterGame(object sender, TappedRoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name.Contains($"Game{NumberGame}"))
            {
                int number = NumberGame;
                StackPanel stackPanel = (StackPanel)GridGame.FindName($"Game{NumberGame}");
                ImageBrush imageBrush = (ImageBrush)GridGame.FindName($"ImageGame{NumberGame}");
                Button buttonNow = (Button)GridGame.FindName($"BtnGame{NumberGame}");
                Button buttonAfter;

                ImgVisualizer.Source = imageBrush.ImageSource;

                if (NumberGame <= 13)
                {
                    Storyboard story = (Storyboard)main.Resources[$"StoryboardGame{--NumberGame}ToGame{++NumberGame}"];

                    story.Completed += (i, o) =>
                    {
                        NumberGame = number + 1;
                        buttonAfter = (Button)GridGame.FindName($"BtnGame{NumberGame}");
                        buttonNow.Visibility = Visibility.Collapsed;
                        InitInStoryboard();
                        SwapGridGameToGame();
                        if(NumberGame <= 13 ) buttonAfter.Visibility = Visibility.Visible;
                    };

                    story.Begin();
                }

            }

        }

        public void InitDataJson()
        {
            StreamReader file = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), "Json/dataEscapeGame.json"));
            ListData = new JsonSerializer().Deserialize<List<Data>>(new JsonTextReader(file));
        }

        public void InitInStoryboard()
        {
            Btn_Valider.IsEnabled = false;
            Btn_Suivant.IsEnabled = false;
            ListButton.ForEach(elm =>
            {
                elm.Background = new SolidColorBrush(Colors.Black);
            });

            if(IdDataJson <= 13)
            {
                Title.Text = Data.Title;
                q1.Text = Data.Q1;
                q2.Text = Data.Q2;
                q3.Text = Data.Q3;
                r1_1.Content = Data.R1_1;
                r1_2.Content = Data.R1_2;
                r1_3.Content = Data.R1_3;
                r2_1.Content = Data.R2_1;
                r2_2.Content = Data.R2_2;
                r2_3.Content = Data.R2_3;
                r3_1.Content = Data.R3_1;
                r3_2.Content = Data.R3_2;
                r3_3.Content = Data.R3_3;
            }
        }

        public void Tapped_BtnSuivant(object sender, RoutedEventArgs e)
        {
            SwapGameToGridGame();
        }

        public void Tapped_Area(object sender, RoutedEventArgs e)
        {
            SwapGridGameToGame();
        }


        private int intZoomScroll = 1;
        private const int ZOOM_SCROLL_MIN = 1;
        private const int ZOOM_SCROLL_MAX = 4;

        private void CheckZoom()
        {
            ZoomOut.IsEnabled = NameImageScroller.ZoomFactor == ZOOM_SCROLL_MIN ? false : true;
            ZoomIn.IsEnabled = NameImageScroller.ZoomFactor == ZOOM_SCROLL_MAX ? false : true;
        }

        private async void Tapped_ZoomScrollViewer(object sender, TappedRoutedEventArgs e)
        {
            NameImageScroller.ZoomToFactor(++intZoomScroll);
            CheckZoom();
        }

        private async void Tapped_DeZoomScrollViewer(object sender, TappedRoutedEventArgs e)
        {
            NameImageScroller.ZoomToFactor(--intZoomScroll);
            CheckZoom();
        }

        private void Btn_LaunchGameSolo(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_LaunchGameMultiPlayer(object sender, RoutedEventArgs e)
        {

        }

        private int indexeurNb = 0;
        private int indexeurNb1 = 0;
        private int indexeurNb2 = 0;
        private int indexeurNb3 = 0;

        private void Tapped_BtnValider(object sender, RoutedEventArgs e)
        {
            if (IdDataJson == 13)
            {
                BtnLeaveEscape.Visibility = Visibility.Visible;
            }

            int score = 0;
            ListButton.ForEach(elm =>
            {
                if (elm.Content.ToString() == Data.R1 || elm.Content.ToString() == Data.R2 || elm.Content.ToString() == Data.R3)
                {
                    elm.Background = new SolidColorBrush(Colors.Green);
                    score += 1;
                }
                else elm.Background = new SolidColorBrush(Colors.Red);
            });
            if(score >= 1)
            {
                indexeurNb = 0;
                Btn_Valider.IsEnabled = false;
                Btn_Suivant.IsEnabled = true;
                indexeurNb1 = indexeurNb2 = indexeurNb3 = 0;
                IdDataJson++;
            }
        }

        private void Tapped_BtnSelectResponse(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            StackPanel stackChildren = null;
            if (btn.Name == "r1_1" || btn.Name == "r1_2" || btn.Name == "r1_3")
            {
                stackChildren = r1;
                ListButton[0] = btn;
                indexeurNb1 = 1;
            }
            else if (btn.Name == "r2_1" || btn.Name == "r2_2" || btn.Name == "r2_3")
            {
                stackChildren = r2;
                ListButton[1] = btn;
                indexeurNb2 = 1;
            }
            else if (btn.Name == "r3_1" || btn.Name == "r3_2" || btn.Name == "r3_3")
            {
                stackChildren = r3;
                ListButton[2] = btn;
                indexeurNb3 = 1;
            }

            indexeurNb = indexeurNb1 + indexeurNb2 + indexeurNb3;

            if (indexeurNb == 3) Btn_Valider.IsEnabled = true;
            else Btn_Valider.IsEnabled = false;

            foreach (Button b in stackChildren.Children)
            {
                b.Background = new SolidColorBrush(Colors.Black);
            }

            btn.Background = new SolidColorBrush(Colors.Orange);

        }

        private void Btn_LeaveEscape(object sender, RoutedEventArgs e)
        {
            TWinGame += 1;
            Application.Current.Resources["IntWinGameEscape"] = TWinGame;
            Frame.Navigate(typeof(EndEscapeGame));
        }

        private void Loaded_Page(object sender, RoutedEventArgs e)
        {
            Animation.AnimatePage(main, StackEscapeGame).Begin();
        }

    }
}
