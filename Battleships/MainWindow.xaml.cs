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
        private GridController mainGrid = new GridController(7, 7);

        private int GuessesUsed = 0;
        private int MaxGuesses = 0;

        public MainWindow()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            DifficultyDialog dialog = new DifficultyDialog();

            if (dialog.ShowDialog() == false)
            {
                return;
            }

            mainGrid = new GridController(dialog.Difficulty, dialog.Difficulty);
            SetupGrid(mainGrid.Rows, mainGrid.Cols);
            StartGame();
            UpdateGrid();
            UpdateUi();
        }

        private void UpdateUi()
        {
            shipsRemainingLabel.Content = $"Ships Remaining: {ShipsRemaining()}";

            guessesLabel.Content = $"Guesses: {GuessesUsed}/{MaxGuesses}";
        }

        private int ShipsRemaining()
        {
            int count = 0;

            foreach (Coordinates c in mainGrid.Ships.Values)
            {
                if (!mainGrid.Squares[c].Hit)
                {
                    count += 1;
                }
            }

            return count;
        }

        private int CalcualateGuesses()
        {
            var area = mainGrid.Rows * mainGrid.Cols;
            var result = (double)area / 2;
            return int.Parse(Math.Ceiling(result).ToString());
        }

        public void StartGame()
        {
            mainGrid.Ships.Clear();
            mainGrid.Squares.Clear();

            MaxGuesses = CalcualateGuesses();
            GuessesUsed = 0;

            for (var r = 1; r < mainGrid.Rows + 1; r++)
            {
                for (var c = 1; c < mainGrid.Cols + 1; c++)
                {
                    mainGrid.Squares.Add(new Coordinates(r, c), new GridSquare());
                    Debug.WriteLine(new Coordinates(r, c).ToString());
                }
            }

            foreach (char ship in new char[] { 'A', 'B', 'C', 'D', 'S' })
            {
                var rand = new Random();
                var randRow = -1;
                var randCol = -1;

                while (randRow == -1 || randCol == -1 || mainGrid.Ships.Values.Contains(new Coordinates(randRow, randCol)))
                {
                    randRow = rand.Next(1, mainGrid.Rows);
                    randCol = rand.Next(1, mainGrid.Cols);
                }

                Debug.WriteLine($"{ship} @ {randRow} {randCol}");

                mainGrid.Ships.Add(new Ship
                {
                    ShipType = ship
                }, new Coordinates(randRow, randCol));
            }
        }

        public void Finished(bool complete)
        {
            if (complete)
            {
                MessageBox.Show($"Congrats! You hit all the ships in {GuessesUsed} guesses!");
            } else
            {
                MessageBox.Show($"Better luck next time! You ran out of guesses and finished with {ShipsRemaining()} ships remaining.");
            }
        }

        public void DoTurn(string coordinates)
        {
            var coords = Coordinates.Parse(coordinates);

            if (coords == null)
            {
                MessageBox.Show("Those coordinates are invalid.");
                return;
            }

            if (coords.Row > mainGrid.Rows || coords.Column > mainGrid.Cols || coords.Row <= 0 || coords.Column <= 0)
            {
                MessageBox.Show("Those coordinates are invalid.");
                return;
            }

            if (mainGrid.Squares[coords].Hit)
            {
                MessageBox.Show("You've already hit that square.");
                return;
            }

            if (GuessesUsed >= MaxGuesses)
            {
                Finished(false);
                return;
            }

            if (ShipsRemaining() <= 0)
            {
                Finished(true);
                return;
            }

            Debug.WriteLine($"Parsed '{coordinates}' as {coords.ToString()}");

            mainGrid.Squares[coords].Hit = true;

            GuessesUsed += 1;

            UpdateGrid();
            UpdateUi();

            if (GuessesUsed >= MaxGuesses)
            {
                Finished(false);
                return;
            }

            if (ShipsRemaining() <= 0)
            {
                Finished(true);
                return;
            }
        }

        public void UpdateGrid()
        {
            for (var r = 1; r < mainGrid.Rows + 1; r++)
            {
                for (var c = 1; c < mainGrid.Cols + 1; c++)
                {
                    var coords = new Coordinates(r, c);
                    if (mainGrid.Squares.ContainsKey(coords))
                    {
                        if (mainGrid.Squares[coords].Hit)
                        {
                            if (mainGrid.Ships.ContainsValue(coords))
                            {
                                // Ship
                                var ship = mainGrid.Ships.FirstOrDefault(x => x.Value.Equals(coords)).Key;
                                mainGrid.Labels[coords].Background = new SolidColorBrush(Theme.HitColor);
                                mainGrid.Labels[coords].Foreground = new SolidColorBrush(Colors.White);
                                mainGrid.Labels[coords].Content = ship.ShipType;
                                
                            } else
                            {
                                // No Ship
                                mainGrid.Labels[coords].Background = new SolidColorBrush(Theme.GuessedColor);
                                mainGrid.Labels[coords].Foreground = new SolidColorBrush(Colors.White);
                            }
                        } else
                        {
                            mainGrid.Labels[coords].Background = new SolidColorBrush(Theme.NotGuessedColor);
                            mainGrid.Labels[coords].Foreground = new SolidColorBrush(Colors.White);
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
            mainGrid.Labels.Clear();
            mainGrid.Ships.Clear();
            mainGrid.Squares.Clear();

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

                        mainGrid.Labels.Add(currentCoords, label);

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

                        mainGrid.Labels.Add(currentCoords, label);

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

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
