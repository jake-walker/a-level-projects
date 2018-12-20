using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Dictionary<Coordinates, Label> player1GridLabels = new Dictionary<Coordinates, Label>();
        public Dictionary<Ship, Coordinates> player1Ships = new Dictionary<Ship, Coordinates>();
        public Dictionary<Coordinates, GridSquare> gridSquares = new Dictionary<Coordinates, GridSquare>();

        public int GridRows = 5;
        public int GridCols = 5;

        public MainWindow()
        {
            InitializeComponent();

            SetupGrid(GridRows, GridCols);
            StartGame();
            UpdateGrid();
        }

        public void StartGame()
        {
            player1Ships.Clear();
            gridSquares.Clear();

            for (var r = 1; r < GridRows + 1; r++)
            {
                for (var c = 1; c < GridCols + 1; c++)
                {
                    gridSquares.Add(new Coordinates(r, c), new GridSquare());
                    Debug.WriteLine(new Coordinates(r, c).ToString());
                }
            }

            foreach (char ship in new char[] { 'A', 'B', 'C', 'D', 'S' })
            {
                var rand = new Random();
                var randRow = -1;
                var randCol = -1;

                while (randRow == -1 || randCol == -1 || player1Ships.Values.Contains(new Coordinates(randRow, randCol)))
                {
                    randRow = rand.Next(1, GridRows);
                    randCol = rand.Next(1, GridCols);
                }

                Debug.WriteLine($"{ship} @ {randRow} {randCol}");

                player1Ships.Add(new Ship
                {
                    ShipType = ship
                }, new Coordinates(randRow, randCol));
            }
        }

        public void DoTurn(string coordinates)
        {
            var coords = Coordinates.Parse(coordinates);

            if (coords == null)
            {
                return;
            }

            gridSquares[coords].Hit = true;

            UpdateGrid();
        }

        public void UpdateGrid()
        {
            for (var r = 1; r < GridRows + 1; r++)
            {
                for (var c = 1; c < GridCols + 1; c++)
                {
                    var coords = new Coordinates(r, c);
                    if (gridSquares.ContainsKey(coords))
                    {
                        if (gridSquares[coords].Hit)
                        {
                            if (player1Ships.ContainsValue(coords))
                            {
                                // Ship
                                var ship = player1Ships.FirstOrDefault(x => x.Value == coords).Key;
                                player1GridLabels[coords].Background = new SolidColorBrush(Theme.HitColor);
                                player1GridLabels[coords].Foreground = new SolidColorBrush(Colors.White);
                                player1GridLabels[coords].Content = ship.ShipType;
                                
                            } else
                            {
                                // No Ship
                                player1GridLabels[coords].Background = new SolidColorBrush(Theme.GuessedColor);
                                player1GridLabels[coords].Foreground = new SolidColorBrush(Colors.White);
                            }
                        } else
                        {
                            player1GridLabels[coords].Background = new SolidColorBrush(Theme.NotGuessedColor);
                            player1GridLabels[coords].Foreground = new SolidColorBrush(Colors.White);
                        }
                    }
                }
            }

        }

        public void SetupGrid(int rows, int cols)
        {
            player1Grid.ColumnDefinitions.Clear();
            player1Grid.RowDefinitions.Clear();
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
                        Label label = new Label
                        {
                            FontSize = 20,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                        };

                        Grid.SetRow(label, r);
                        Grid.SetColumn(label, c);

                        player1GridLabels.Add(currentCoords, label);

                        player1Grid.Children.Add(label);
                    }
                }
            }
        }

        private void promptSubmit_Click(object sender, RoutedEventArgs e)
        {
            DoTurn(promptResponse.Text);
            promptResponse.Clear();
        }

        private void promptResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoTurn(promptResponse.Text);
                promptResponse.Clear();
            }
        }
    }
}
