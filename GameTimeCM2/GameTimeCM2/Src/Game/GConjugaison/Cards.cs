using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

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

        public void Init()
        {
            ForEach(card =>
            {
                
                StackPanelCards.Children.Add(card.Init());
            });
        }

    }
}
