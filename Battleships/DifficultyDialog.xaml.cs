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
using System.Windows.Shapes;

namespace Battleships
{
    /// <summary>
    /// Interaction logic for DifficultyDialog.xaml
    /// </summary>
    public partial class DifficultyDialog : Window
    {
        public int Difficulty { get; set; }
        public DifficultyDialog()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 4;
            DialogResult = true;
        }

        private void mediumButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 5;
            DialogResult = true;
        }

        private void hardButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 7;
            DialogResult = true;
        }

        private void extremeButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 9;
            DialogResult = true;
        }
    }
}
