using System;
using System.Collections.Generic;

namespace AdventOfCode
{

    public class MinMaxList<T> : List<T>
    {
        private int _minValue;
        private int _maxValue;

        public MinMaxList()
        {
            _minValue = Int32.MaxValue;
            _maxValue = Int32.MinValue;
        }

        public void Add(T value)
        {
            int integerValue = Convert.ToInt32(value);
            if (integerValue > _maxValue)
            {
                _maxValue = integerValue;
            }

            if (integerValue < _minValue)
            {
                _minValue = integerValue;
            }

            base.Add(value);
        }

        public int GetMinMaxDifference()
        {
            return Math.Abs(_maxValue - _minValue);
        }
    }

    public class DayTwo
    {
        public int DifferenceBetweenMinAndMaxOfRow(string row)
        {
            string[] parts = row.Split(';');
            MinMaxList<int> minMaxList = new MinMaxList<int>();

            for (int i = 0; i < parts.Length; i++)
            {
                minMaxList.Add(Convert.ToInt32(parts[i]));
            }

            return minMaxList.GetMinMaxDifference();
        }

        public int SumOfRows(string[] rows)
        {
            int sum = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                sum += DifferenceBetweenMinAndMaxOfRow(rows[i]);
            }
            return sum;
        }

        public int GetDeviseableNumber(string row)
        {
            string[] parts = row.Split(';');
            List<int> list = new List<int>();
            for (int i = 0; i < parts.Length; i++)
            {
                list.Add(Convert.ToInt32(parts[i]));
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i] % list[j] == 0)
                        {
                            return list[i] / list[j];
                        } 
                    }
                }
            }
            return 0;
        }

        public int SumOfRowsPartTwo(string[] rows)
        {
            int sum = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                sum += GetDeviseableNumber(rows[i]);
            }
            return sum;
        }
    }
}
