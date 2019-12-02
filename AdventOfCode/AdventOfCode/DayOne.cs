
using System;

namespace AdventOfCode
{
    public class DayOne
    {
        public long CalcFuelRequirements(long mass)
        {
            long value = Convert.ToInt64(Math.Floor((double) mass / 3.0));
            value -= 2;

            return value;
        }
    }
}
