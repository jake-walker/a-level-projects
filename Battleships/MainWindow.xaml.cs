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
        }

        public void SetupGrid(int cols, int rows)
        {
            //player1Grid.ColumnDefinitions.Clear();
            //player1Grid.RowDefinitions.Clear();
            player1GridRectangles.Clear();

            for (var c = 0; c < (cols + 1); c++)
            {
                //player1Grid.ColumnDefinitions.Add(new ColumnDefinition());

                for (var r = 0; r < (rows + 1); r++)
                {
                    //player1Grid.RowDefinitions.Add(new RowDefinition());

                    if ((c == 0 || r == 0))
                    {
                        System.Diagnostics.Debug.WriteLine($"Adding label @ Row{r} Col{c}");

                        // Create a label
                        Label temp = new Label();
                        temp.Content = $"R{r},C{c}";
                        //temp.FontSize = 15;
                        temp.HorizontalAlignment = HorizontalAlignment.Center;
                        temp.VerticalAlignment = VerticalAlignment.Center;

                        Grid.SetRow(temp, r+1);
                        Grid.SetColumn(temp, c);

                        player1GridLabels.Add(new Coordinates(r, c), temp);

                        player1Grid.Children.Add(temp);
                    }

                    System.Diagnostics.Debug.WriteLine($"Row{r} Col{c}");
                }
            }
        }
    }
}
