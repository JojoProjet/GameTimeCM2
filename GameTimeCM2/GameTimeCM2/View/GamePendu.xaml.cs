using GameTimeCM2.Src.Game.GPendu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        private List<TextBlock> Labels { get; set; }
        private Image StageImage { get; set; }

        public GamePendu()
        {
            this.InitializeComponent();
            Labels = new List<TextBlock>();
            Buttons = new List<Button>();
            CreateNewGameBtn();
        }

        private void NewGameBtnClick(object sender, RoutedEventArgs e)
        {

            string[] words = new string[] {
                "word", "test", "language", "default",
                "world", "ship", "fleet", "blueprint"};
            InitializeGameField(words[new Random().Next(0, words.Length)]);
        }

        private void CharacterBtnClick(object sender, RoutedEventArgs e)
        {
            int[] temp = HangmanGame.TakeCharacter((sender as Button).Content.ToString()[0]);

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    Labels[i].Text = $"{HangmanGame.Word[i]}";
                }
            }

            StageImage.Source = HangmanGame.GetStageImage();

            if (Labels.Count(l => l.Text == null) == 0)
            {
                FinishGame("You Win!");
            }
            else if (HangmanGame.IsGameOver())
            {
                FinishGame("You Lose!");
            }
            else
            {
                (sender as Button).IsEnabled = false;
            }
        }

        private void FinishGame(string message)
        {
            //MessageBox.Show(message);
            //Buttons.ForEach(b => b.IsEnabled = false);
        }

        private void InitializeGameField(string word)
        {
            HangmanGame = new Game(word);

            Labels.Clear();
            Buttons.Clear();
            GameGrid.Children.Clear();

            CreateImage();
            StageImage.Source = HangmanGame.GetStageImage();

            CreateNewGameBtn();
            CreateCharacterBtns(HangmanGame.Alphabet);
            CreateCharacterLbl(HangmanGame.Lenght);
        }

        #region Game Field Initialization
        private void CreateNewGameBtn()
        {
            Button button = new Button();
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Width = 150;
            button.Height = 35;

            button.Content = "New Game";
            button.Click += new RoutedEventHandler(NewGameBtnClick);

            GameGrid.Children.Add(button);
        }

        private void CreateImage()
        {
            StageImage = new Image();

            StageImage.Name = "StageImage";
            StageImage.VerticalAlignment = VerticalAlignment.Center;
            StageImage.HorizontalAlignment = HorizontalAlignment.Center;
            StageImage.Width = 150;
            StageImage.Height = 150;

            GameGrid.Children.Add(StageImage);
        }

        private void CreateCharacterLbl(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                TextBlock label = new TextBlock();
                label.FontSize = 20;
                label.FontWeight = FontWeight;
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.VerticalAlignment = VerticalAlignment.Center;
                label.Height = label.Width = 38;
                label.HorizontalAlignment = HorizontalAlignment.Left;
                label.VerticalAlignment = VerticalAlignment.Top;

                label.Name = "Character" + i.ToString();

                label.Margin = new Thickness(i * label.Width, 0d, 0d, 0d);

                Labels.Add(label);

                GameGrid.Children.Add(label);
            }
        }

        private void CreateCharacterBtns(char[] alph)
        {
            double bot = 0;
            int count = 0;
            for (int i = 0; i < alph.Length; i++, count++)
            {
                Button button = new Button();
                button.FontSize = 20;
                button.FontWeight = FontWeight;
                button.HorizontalContentAlignment = HorizontalAlignment.Center;
                button.VerticalContentAlignment = VerticalAlignment.Center;
                button.Height = button.Width = 38;
                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.VerticalAlignment = VerticalAlignment.Bottom;

                button.Content = alph[i].ToString();

                if ((count + 1) * button.Width > GameGrid.Width)
                {
                    count = 0;
                    bot += button.Height;
                }

                button.Margin = new Thickness(count * button.Width, 0, 0, bot);
                button.Click += new RoutedEventHandler(CharacterBtnClick);

                Buttons.Add(button);

                GameGrid.Children.Add(button);
            }
        }
        #endregion

    }
}
