using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class SearchTests
    {
        [DataTestMethod]
        [DataRow(new int[]
        {
            63,
            91,
            44,
            70,
            39
        }, 91, 1)]
        [DataRow(new int[]
        {
            88,
            38,
            19,
            69,
            90,
            25
        }, 91, -1)]
        public void LinearTest(int[] list, int target, int expected)
        {
            var actual = Search.Search.Linear(list.ToList(), target);
            Assert.AreEqual(expected, actual);
        }
    }
}