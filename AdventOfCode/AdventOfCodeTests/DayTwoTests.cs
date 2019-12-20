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
        private IntCodeProcessor _processor;

        [TestInitialize]
        public void TestInit()
        {
            _processor = new IntCodeProcessor();
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

            _processor.ProcessInput(input);
            Assert.IsTrue(input[0] == 3267740);
        }

        [TestMethod]
        public void DayTwoPartTwoTest()
        {
            string[] lines = File.ReadAllText("input_2_1.txt").Split(',');


            List<int> originalInput = new List<int>();
            foreach (string line in lines)
            {
                originalInput.Add(Convert.ToInt32(line));
            }

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    List<int> input = new List<int>(originalInput);
                    input[1] = i;
                    input[2] = j;

                    try
                    {
                        _processor.ProcessInput(input);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (input[0] == 19690720)
                    {
                        Console.WriteLine($"100 * {i} + {j} = {(i*100)+j}");
                    }
                }
            }


        }
    }
}
