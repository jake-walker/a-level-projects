using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Diagnostics;

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

            int rows = targetNumber / 10;
            int toAdd = (int)(targetNumber / 10) * 10;

            Debug.WriteLine($"Need to add {toAdd} rows");

            /*for (var i = 1; i < toAdd; i++)
            {
                gridRows.Add(new RowDefinition());
            }*/

            foreach (RowDefinition gridRow in gridRows)
            {
                Debug.WriteLine("Adding row...");
                SeiveGrid.RowDefinitions.Add(gridRow);
            }

            Debug.WriteLine($"Created {SeiveGrid.RowDefinitions.Count} rows!");
            
            for (var r = 0; r < (gridRows.Count - 1); r++)
            {
                for (var c = 0; c < 9; c++)
                {
                    Debug.WriteLine($"Adding label at row {r}, column {c}...");
                    Label l = new Label();
                    l.Content = $"{r},{c}";
                    labels.Add(l);
                    Grid.SetColumn(l, c);
                    Grid.SetRow(l, r);
                    SeiveGrid.Children.Add(l);
                }
            }
        }
    }
}
