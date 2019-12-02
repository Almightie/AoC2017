using System;
using System.IO;
using System.Net;
using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AdventOfCodeTests
{
    [TestClass]
    public class DayOneTests
    {
        private DayOne _dayOne;

        [TestInitialize]
        public void TestInit()
        {
            _dayOne = new DayOne();
        }

        [TestMethod]
        public void TestDayOnePartOne()
        {
            string[] lines = File.ReadAllLines("input_1_1.txt");


            long totalRequirements = 0;
            foreach (string line in lines)
            {
                long mass = Convert.ToInt64(line);
                long fuelRequirement = _dayOne.CalcFuelRequirements(mass);
                totalRequirements += fuelRequirement;
            }

        }


        [TestMethod]
        public void TestDayOnePartTwo()
        {
            string[] lines = File.ReadAllLines("input_1_1.txt");
            long totalRequirements = 0;
            foreach (string line in lines)
            {
                long mass = Convert.ToInt64(line);
                long fuelRequirement = 0;
                do
                {
                    fuelRequirement = _dayOne.CalcFuelRequirements(mass);
                    mass = fuelRequirement;
                    totalRequirements += fuelRequirement;
                } while (fuelRequirement > 8);
            }
        }

    }
}
