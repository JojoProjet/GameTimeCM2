using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace GameTimeCM2.Src.Game.GConjugaison
{
    class Cards : List<Card>
    {

        public string Response { get; set; }

        public StackPanel StackPanelCards { get; set; }

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

            StackPanelCards.Tapped += new TappedEventHandler(Tapped_Cards);
        }

        private void Tapped_Cards(object sender, TappedRoutedEventArgs e)
        {
            if (Application.Current.Resources.ContainsKey(Constants.APPLICATION_RESSOURCES_CARD))
            {
                Card c = (Card)Application.Current.Resources[Constants.APPLICATION_RESSOURCES_CARD];

                ForEach(card =>
                {
                    StackPanel stackPanel = (StackPanel)StackPanelCards.FindName(card.IdName);
                    if (card.IdName != c.IdName) stackPanel.BorderBrush = null;    
                } );
            }

        }

    }
}
