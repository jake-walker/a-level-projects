using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap_Year
{
    public class Leap
    {
        // This checks if the value is a leap year using switch/case statements
        // which is a requirement of the task.
        public static bool IsLeapYear(int year)
        {
            // Get the remainder of the year divided by 4.
            switch (year % 4)
            {
                // If the year divided by 4 leaves no remainder.
                case 0:
                    // Move onto the next switch statement.
                    break;
                // If the year divided by 100 leaves any remainder.
                default:
                    // The year is not a leap year.
                    return false;
            }

            // Get the remainder of the year divided by 100.
            switch (year % 100)
            {
                // If the year divided by 100 leaves no remainder.
                case 0:
                    // Move onto the next switch statement.
                    break;
                // If the year divided by 100 leaves any remainder.
                default:
                    // The year is a leap year.
                    return true;
            }

            // Get the remainder of the year divided by 400.
            switch (year % 400)
            {
                // If the year divided by 400 leaves no remainder.
                case 0:
                    // The year is a leap year.
                    return true;
                // If the year divided by 100 leaves any remainder.
                default:
                    // The year is not a leap year.
                    return false;
            }
        }
    }
}
