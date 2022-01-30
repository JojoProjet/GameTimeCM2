using GameTimeCM2.Src.Game.GPendu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace GameTimeCM2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GamePendu : Page
    {
        private Game HangmanGame { get; set; }
        private List<Button> Buttons { get; set; }
        private List<Button> Words { get; set; }
        private Image StageImage { get; set; }
        private StackPanel Stack { get; set; }
        private StackPanel StackError { get; set; }
        private int TWinGame { get; set; }

        public GamePendu()
        {
            this.InitializeComponent();

            Buttons = new List<Button>();
            Words = new List<Button>();

            Stack = CreateStackPanelSideRight();
            StackError = CreateSackPanelError();

            InitializeGameField();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TWinGame = (int)Application.Current.Resources["IntWinGamePendu"];
        }

        private void Btn_QuitGame(object sender, RoutedEventArgs e)
        {
            TWinGame += 15;
            Application.Current.Resources["IntWinGamePendu"] = TWinGame;
            Frame.Navigate(typeof(AccueilGame));
        }

        private void NewGameBtnClick(object sender, RoutedEventArgs e)
        {
            Storyboard_StackNewGame.Begin();
            InitializeGameField();
        }

        private void InitializeGameField()
        {
            string[] words = new string[] {
                "Coq", "Cou", "Cri", "Gel", "Tic",
                "Beau", "Dame", "Joue", "Rhum", "Yogi",
                "Aimer", "Capot", "Koala", "Pomme", "Taupe",
                "Acajou", "Crayon", "Goulot", "Puzzle", "Whisky",
                "Billard", "Corbeau", "Sifflet", "Tonneau", "Vautour",
                "Aquarium", "Batterie", "Scorpion", "Triangle", "Tabouret", 
                "Ascenseur", "Ascension", "Populaire", "Narrateur", "Tambourin"
            };

            HangmanGame = new Game(words[new Random().Next(0, words.Length)]);

            Buttons.Clear();
            Words.Clear();
            Stack.Children.Clear();
            StackError.Children.Clear();
            GameGrid.Children.Clear();

            CreateImage();
            StageImage.Source = HangmanGame.GetStageImage();

            CreateCharacterLbl(HangmanGame.Lenght);
            CreateCharacterBtns(HangmanGame.Alphabet);
            Stack.Children.Add(StackError);

            GameGrid.Children.Add(Stack);
        }

        private void CharacterBtnClick(object sender, RoutedEventArgs e)
        {
            char character = (sender as Button).Content.ToString()[0];
            int[] temp = HangmanGame.TakeCharacter(character);
            bool passed = false;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    passed = true;
                    Words[i].Content = $"{HangmanGame.Word[i]}";
                }
            }
            if(!passed) 
                StackError.Children.Add(CreateButton(character.ToString(), new SolidColorBrush(Colors.Red)));


            StageImage.Source = HangmanGame.GetStageImage();

            if (Words.Count(l => l.Content == null) == 0)
            {
                FinishGame("Vous avez gagné !");
            }
            else if (HangmanGame.IsGameOver())
                FinishGame("Vous avez perdu !");
            else
                (sender as Button).IsEnabled = false;
        }

        private void FinishGame(string message)
        {
            //MessageBox.Show(message);
            Buttons.ForEach(b => b.IsEnabled = false);
            TextWinOrLoose.Text = message;
            Storyboard_StackFinishGame.Begin();
        }

        #region Game Field Initialization
        private StackPanel CreateStack()
        {
            return new StackPanel
            {
                Width = 500,
                Height = 50,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Left
            };
        }

        private StackPanel CreateStackPanelImages()
        {
            return new StackPanel
            {
                Name = "Images",
                Width = 500,
                Height = 500,
            };
        }

        private StackPanel CreateStackPanelSideRight()
        {
            return new StackPanel
            {
                Name = "SideRight",
                Width = 500,
                Height = 500
            };
        }

        private void CreateImage()
        {
            StageImage = new Image
            {
                Name = "StageImage",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 400,
                Height = 400
            };

            StackPanel stack = CreateStackPanelImages();
            stack.Children.Add(StageImage);
            GameGrid.Children.Add(stack);
        }

        private StackPanel CreateStackPanelAlpabet()
        {
            return new StackPanel
            {
                Name = "Alphabet",
                Width = 500,
                Height = 300,
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
        }

        private StackPanel CreateSackPanelError()
        {
            return new StackPanel
            {
                Name = "Errors",
                Width = 500,
                Height = 50,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
        }

        private void CreateCharacterLbl(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Button button = new Button
                {
                    Name = "Character" + i.ToString(),
                    FontSize = 20,
                    Height = 38,
                    Width = 38,
                    FontWeight = FontWeight,
                    Content = null,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Background = new SolidColorBrush(Colors.LawnGreen),
                    FocusVisualPrimaryBrush = new SolidColorBrush(Colors.LawnGreen),
                    Foreground = new SolidColorBrush(Colors.Black),
                    Margin = new Thickness(5, 5, 5, 5),
                    IsTapEnabled = false
                };

                Words.Add(button);
            }

            StackPanel stack = CreateStack();
            Words.ForEach(item =>
            {
                stack.Children.Add(item);
            });
            Stack.Children.Add(stack);
        }

        private Button CreateButton(string content, SolidColorBrush solidColorBrush)
        {
            return new Button
            {
                Name = $"Btn{content}",
                Height = 38,
                Width = 38,
                FontSize = 20,
                FontWeight = FontWeight,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Background = solidColorBrush,
                Content = content,
                Margin = new Thickness(5, 5, 5, 5),
            };
        }

        private void CreateCharacterBtns(char[] alph)
        {
            int index = 0;
            int nAlpabet = 0;

            for (int i = 0; i < alph.Length; i++)
            {
                Button button = CreateButton(alph[i].ToString(), new SolidColorBrush(Colors.Orange));

                button.Click += new RoutedEventHandler(CharacterBtnClick);

                Buttons.Add(button);
            }

            StackPanel stackAlpa = CreateStackPanelAlpabet();
            StackPanel stackStock = CreateStack();

            Buttons.ForEach(elm =>
            {
                stackStock.Children.Add(elm);
                index++;
                nAlpabet++;
                if (index == 6 || nAlpabet == 26)
                {
                    stackAlpa.Children.Add(stackStock);
                    index = 0;
                    stackStock = CreateStack();
                }
            });
            Stack.Children.Add(stackAlpa);
        }
        #endregion

    }
}
