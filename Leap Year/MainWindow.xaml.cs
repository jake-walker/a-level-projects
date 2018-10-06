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

namespace Leap_Year
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void YearTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // If the user didn't type anything in.
            if (string.IsNullOrWhiteSpace(YearTextBox.Text))
            {
                // Set the text colour of the result label to be black.
                ResultText.Foreground = new SolidColorBrush(Colors.Black);

                // Set the text of the label to tell the user that they need to type
                // in a number.
                ResultText.Text = "Enter a year.";

                // Exit out of the function so that none of the code below runs.
                return;
            }

            // Make a new variable for storing the result of the integer parse.
            int Year;

            // Check if the textbox contents can be parsed as an integer and if it can,
            // put the result into the year variable. Sanitise the user's input to remove
            // spaces from the start or end.
            bool IsNumeric = int.TryParse(YearTextBox.Text.Trim(), out Year);

            // If the inputted year is not numeric
            if (!IsNumeric)
            {
                // Set the text colour of the result label to be orange.
                ResultText.Foreground = new SolidColorBrush(Colors.Orange);

                // Set the text of the label to tell the user that what they entered
                // was not a number.
                ResultText.Text = $"{YearTextBox.Text} is not a number.";

                // Exit out of the function so that none of the code below runs.
                return;
            }

            // Check if the year is not a leap year.
            if (!Leap.IsLeapYear(Year))
            {
                // Set the text colour of the result label to be red.
                ResultText.Foreground = new SolidColorBrush(Colors.Red);

                // Set the text of the label to tell the user that what they entered
                // was not a leap year.
                ResultText.Text = $"{YearTextBox.Text} is not a leap year.";

                // Exit out of the function so that none of the code below runs.
                return;
            }

            // Set the text colour of the result label to be green.
            ResultText.Foreground = new SolidColorBrush(Colors.Green);

            // Set the text of the label to tell the user that what they entered
            // was a leap year.
            ResultText.Text = $"{YearTextBox.Text} is a leap year.";
        }
    }
}
