
using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class DayFiveTests
    {
        private IntCodeProcessor _processor;

        [TestInitialize]
        public void Initialize()
        {
            _processor = new IntCodeProcessor();
        }

        [TestMethod]
        public void DayFivePartOneTest()
        {
            string[] lines = File.ReadAllText("input_5_1.txt").Split(',');
            List<int> input = new List<int>();

            foreach (string line in lines)
            {
                input.Add(Convert.ToInt32(line));
            }
            
            _processor.ProcessInput(input);
        }


        [TestMethod]
        public void DayFivePartTwoTest()
        {
            string[] lines = File.ReadAllText("input_5_1.txt").Split(',');
            List<int> input = new List<int>();

            foreach (string line in lines)
            {
                input.Add(Convert.ToInt32(line));
            }

            _processor.ProcessInput(input);
        }
    }
}
