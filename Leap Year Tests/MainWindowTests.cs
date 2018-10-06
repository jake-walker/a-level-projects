using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leap_Year;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Leap_Year.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        // List of all the leap years between 2000 and 2100.
        int[] LeapYearsBetween2000And2100 = new int[]
        {
            2000,
            2004,
            2008,
            2012,
            2016,
            2020,
            2024,
            2028,
            2032,
            2036,
            2040,
            2044,
            2048,
            2052,
            2056,
            2060,
            2064,
            2068,
            2072,
            2076,
            2080,
            2084,
            2088,
            2092,
            2096
        };

        [TestMethod()]
        public void IsLeapYearTest()
        {
            // Iterate through the numbers 2000 to 2100.
            for (int y = 2000; y <= 2100; y++)
            {
                // Get the result of the year from the function.
                bool ActualResult = Leap.IsLeapYear(y);
                // Get the actual result of the year from the list of leap years.
                bool ExpectedResult = LeapYearsBetween2000And2100.Contains(y);

                // Pass the test if both results are equal.
                Assert.AreEqual(ExpectedResult, ActualResult, $"Year: {y}");
            }
        }
    }
}