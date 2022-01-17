using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameTimeCM2.Src.Game.GMemoire
{
    class Cards : List<Card>
    {

        public Grid Grid { get; set; }

        public Cards(Grid grid)
        {
            Grid = grid;
        }

        public void Init()
        {
            int row = 0;
            int column = 0;
            ForEach(card =>
            {
                if (column >= 4)
                {
                    column = 0;
                    row++;
                }
                Grid.Children.Add(card.Create(row, column));
                column++;
            });
        }

        public void RemoveElementInGrid()
        {
            int row = 0;
            int column = 0;
            ForEach(card =>
            {
                if (column >= 4)
                {
                    column = 0;
                    row++;
                }
                Grid.Children.Remove(card.Create(row, column));
                column++;
            });
        }

    }
}
