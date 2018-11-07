using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows.Media;

namespace Sieve_of_Eratosthenes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int targetNumber = 120;
        private List<RowDefinition> gridRows = new List<RowDefinition>();
        private List<Label> labels = new List<Label>();

        public MainWindow()
        {
            InitializeComponent();

            DrawGrid();
        }

        private void DrawGrid()
        {
            gridRows.Clear();
            labels.Clear();
            
            int rows = (int)(targetNumber / 10) + 1;

            Debug.WriteLine($"Need to add {rows} rows");

            for (var i = 1; i < rows; i++)
            {
                gridRows.Add(new RowDefinition());
            }

            foreach (RowDefinition gridRow in gridRows)
            {
                Debug.WriteLine("Adding row...");
                SeiveGrid.RowDefinitions.Add(gridRow);
            }

            Debug.WriteLine($"Created {SeiveGrid.RowDefinitions.Count} rows!");

            var ib = 1;
            
            for (var r = 0; r < (gridRows.Count); r++)
            {
                for (var c = 0; c < 10; c++)
                {
                    Debug.WriteLine($"Adding label at row {r}, column {c}...");
                    Label l = new Label();
                    l.Content = $"{ib}";
                    labels.Add(l);
                    Grid.SetColumn(l, c);
                    Grid.SetRow(l, r);
                    SeiveGrid.Children.Add(l);

                    ib += 1;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 1; i < labels.Count; i++)
            {
                var num = i + 1;

                for (var i2 = 0; i2 < labels.Count; i2++)
                {
                    

                    var num2 = i2 + 1;

                    //labels[i2].Content = $"({num2})";

                    if (num2 % num == 0 && num2 != num)
                    {
                        labels[i2].Background = new SolidColorBrush(Colors.Red);
                        labels[i2].FontStyle = FontStyles.Italic;
                        
                    }
                }
            }
        }
    }
}
