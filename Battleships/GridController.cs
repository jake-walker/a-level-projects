using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Battleships
{
    class GridController
    {
        public Dictionary<Coordinates, Label> Labels = new Dictionary<Coordinates, Label>();
        public Dictionary<Ship, Coordinates> Ships = new Dictionary<Ship, Coordinates>();
        public Dictionary<Coordinates, GridSquare> Squares = new Dictionary<Coordinates, GridSquare>();

        public int Rows { get; set; } = 5;
        public int Cols { get; set; } = 5;

        public GridController(int rows = 5, int cols = 5)
        {
            Rows = rows;
            Cols = cols;
        }
    }
}
