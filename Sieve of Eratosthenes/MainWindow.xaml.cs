using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sieve_of_Eratosthenes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variable for storing how high to calculate prime numbers.
        //  120 is a standard Sieve of Eratosthenes
        private const int TargetNumber = 120;

        // List for storing the programatically generated rows (changes
        // depending on the 'targetNumber' variable)
        private readonly List<RowDefinition> gridRows = new List<RowDefinition>();

        // List for storing the programatically generated labels (changes
        // depending on the 'targetNumber' variable)
        private readonly List<Label> labels = new List<Label>();

        // List for storing which numbers are not prime.
        private readonly List<int> notPrime = new List<int>();

        // This function is called when the window is instantiated.
        public MainWindow()
        {
            InitializeComponent();

            // Call the function to generate the grid of labels.
            DrawGrid();
        }

        private void DrawGrid()
        {
            // Clear the old labels and rows.
            gridRows.Clear();
            labels.Clear();
            
            // Calculate how many rows are needed.
            const int Rows = (int)(TargetNumber / 10) + 1;

            // Print out how many rows are needed for debugging purposes.
            Debug.WriteLine($"Need to add {Rows} rows");

            // For each row that is needed.
            for (var i = 1; i < Rows; i++)
            {
                // Make a new RowDefinition object and add it to the list.
                gridRows.Add(new RowDefinition());
            }

            // For each row object that we have.
            foreach (var gridRow in gridRows)
            {
                Debug.WriteLine("Adding row...");

                // Add the row to the grid that is already setup in the window.
                SeiveGrid.RowDefinitions.Add(gridRow);
            }

            var ib = 1;
            
            // For each row that we have
            for (var r = 0; r < gridRows.Count; r++)
            {
                // For each column that we have
                for (var c = 0; c < 10; c++)
                {
                    Debug.WriteLine($"Adding label at row {r}, column {c}...");

                    // Make a new label object with it's number in the grid (excluding 1)
                    var l = new Label
                                {
                                    Content = $"{(ib == 1 ? "" : ib.ToString())}",
                                    HorizontalContentAlignment = HorizontalAlignment.Center
                                };


                    // Add the new label to the list of labels.
                    labels.Add(l);

                    // Set the column and row for the label in the grid.
                    Grid.SetColumn(l, c);
                    Grid.SetRow(l, r);

                    // And finally add the label to the grid in the window.
                    SeiveGrid.Children.Add(l);

                    ib += 1;
                }
            }
        }

        // Function for getting the next color to use.
        private static int IterateColorId(int id, IReadOnlyCollection<Brush> c)
        {
            // Get the next color id.
            var newVal = id + 1;

            // If the new color id is bigger than the maximum color id, return the
            // first one.
            return newVal < c.Count ? newVal : 0;
        }

        // This function is called when the user clicks the Start button.
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // Call the sieve function.
            DoSieve();
        }

        // This function actually colours the sieve, it is a asyncronous function
        // so that it doesn't block the UI thread. If it did block the UI thread
        // animations would not work as it only updates the UI after the function
        // is finished.
        private async void DoSieve()
        {
            // This clears the not prime numbers list.
            this.notPrime.Clear();

            // Set the initial color id. It is -1 because it is iterated before
            // use so if it was set to 0 it would become 1 and not use the first
            // color.
            var colorId = -1;

            // Loop through all of the numbers in the grid
            for (var i = 1; i < labels.Count; i++)
            {
                // Set a variable which stores the number that is displayed on the grid
                // as the first label in the array would have an index of 0 but the displayed
                // number to the user would be 1.
                var num = i + 1;

                // If the number is already 'colored in', skip it.
                if (this.notPrime.Contains(num)) continue;

                // Get the next color to use.
                colorId = IterateColorId(colorId, ColourList.Brushes);

                // Loop through all of the numbers in the grid again (to color any
                // that are multiples)
                for (var i2 = 0; i2 < this.labels.Count; i2++)
                {
                    // Set a variable which stores the number that is displayed on the grid.
                    // This has the same explanation as the num variable above.
                    var num2 = i2 + 1;

                    // If the number isn't a multiple OR it equals the 1st multiple (i.e itself)
                    // then skip.
                    if (num2 % num != 0 || num2 == num) continue;

                    // Color the label's background to the multiple color (so for example all the
                    // multiples of 2 will be one color)
                    this.labels[i2].Background = ColourList.Brushes[colorId];

                    // Set the label's font style to be italic as it is not a prime number.
                    this.labels[i2].FontStyle = FontStyles.Italic;

                    // Add this number to the list of numbers that are not prime.
                    this.notPrime.Add(num2);

                    // Wait for 50 milliseconds before continuing. The await runs this
                    // asyncronously.
                    await Task.Delay(50);
                }
            }
        }
    }
}
