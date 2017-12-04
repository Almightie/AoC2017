using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class CircularBuffer<T>
    {
        private T[] _buffer;
        private int _nextFree;

        public CircularBuffer(int length)
        {
            _buffer = new T[length];
            _nextFree = 0;
        }

        public void Add(T o)
        {
            _buffer[_nextFree] = o;
            _nextFree = (_nextFree + 1) % _buffer.Length;
        }

        public T Get(int index)
        {
            int actualIndex = index % _buffer.Length;
            return _buffer[actualIndex];
        }

        public int Length
        {
            get { return _buffer.Length; }
        }
    }

    public class DayOne
    {
        private const int cCharOffset = 48;

        public int SumOfDigitsThatMatchTheNextDigitInCollection(string digits)
        {

            CircularBuffer<int> buffer = GetCircularBuffer(digits);
            int sum = 0;            

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer.Get(i) == buffer.Get(i + 1))
                {
                    sum += buffer.Get(i);
                }
            }

            return sum;
        }

        public int SumOfDigitsThatMatchSecondHalf(string digits)
        {
            CircularBuffer<int> buffer = GetCircularBuffer(digits);
            int sum = 0;
            int halfBufferLength = buffer.Length / 2;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer.Get(i) == buffer.Get(i + halfBufferLength))
                {
                    sum += buffer.Get(i);
                }
            }

            return sum;
        }

        private CircularBuffer<int> GetCircularBuffer(string digits)
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>(digits.Length);
            for (int i = 0; i < digits.Length; i++)
            {
                buffer.Add(Convert.ToInt32(digits[i]) - cCharOffset);
            }
            return buffer;
        }
    }
}
