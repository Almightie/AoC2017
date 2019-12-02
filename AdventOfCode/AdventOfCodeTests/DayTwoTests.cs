using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class DayTwoTests
    {
        private DayTwo _dayTwo;

        [TestInitialize]
        public void TestInit()
        {
            _dayTwo = new DayTwo();
        }

        [TestMethod]
        public void DayTwoPartOneTest()
        {
            string[] lines = File.ReadAllText("input_2_1.txt").Split(',');
            List<int> input = new List<int>();

            foreach (string line in lines)
            {
                input.Add(Convert.ToInt32(line));
            }

            input[1] = 12;
            input[2] = 2;

            List<int> result = _dayTwo.ProcessInput(input);

        }
    }
}
