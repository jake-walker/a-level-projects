using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleships
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<Coordinates, Rectangle> player1GridRectangles = new Dictionary<Coordinates, Rectangle>();
        public Dictionary<Coordinates, Label> player1GridLabels = new Dictionary<Coordinates, Label>();

        public MainWindow()
        {
            InitializeComponent();

            SetupGrid(5, 5);

            

            player1GridRectangles[new Coordinates(1, 1)].Fill = new SolidColorBrush(Colors.Red);
            foreach (Coordinates k in player1GridRectangles.Keys)
            {
                System.Diagnostics.Debug.WriteLine(k.ToDigits());
            }
        }

        public void SetupGrid(int cols, int rows)
        {
            player1Grid.ColumnDefinitions.Clear();
            player1Grid.RowDefinitions.Clear();
            player1GridRectangles.Clear();
            player1Grid.Children.Clear();

            for (var c = 0; c < (cols + 1); c++)
            {
                player1Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (var r = 0; r < (rows + 1); r++)
            {
                player1Grid.RowDefinitions.Add(new RowDefinition());
            }


            for (var c = 0; c < (cols + 1); c++)
            {
                for (var r = 0; r < (rows + 1); r++)
                {
                    var currentCoords = new Coordinates(r, c);

                    if ((c == 0 || r == 0))
                    {
                        // Create a label
                        Label label = new Label
                        {
                            Content = currentCoords.ToSingleChar(),
                            FontSize = 20,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        Grid.SetRow(label, r);
                        Grid.SetColumn(label, c);

                        player1GridLabels.Add(currentCoords, label);

                        player1Grid.Children.Add(label);
                    } else
                    {
                        Rectangle rect = new Rectangle
                        {
                            Stroke = new SolidColorBrush(Colors.Black)
                        };

                        Grid.SetRow(rect, r);
                        Grid.SetColumn(rect, c);

                        player1GridRectangles.Add(currentCoords, rect);

                        player1Grid.Children.Add(rect);
                    }
                }
            }
        }
    }
}
