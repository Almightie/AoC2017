using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    public class DaySix
    {
        private CircularBuffer<int> _circularBuffer;
        private Dictionary<string, int> _memoryDumps;

        public DaySix()
        {
            
        }

        public int RearrangeMemory(int[] array)
        {
            _memoryDumps = new Dictionary<string, int>();
            SetupBuffer(array);


            string memoryDump = MemoryDump();
            int i = 0;
            while (!_memoryDumps.ContainsKey(memoryDump))
            {
                _memoryDumps.Add(memoryDump, 1);
                DoRearrange();
                i++;
                memoryDump = MemoryDump();
            }
            return i;
        }

        public int RearrangeMemoryPartTwo(int[] array)
        {
            _memoryDumps = new Dictionary<string, int>();
            SetupBuffer(array);


            string memoryDump = MemoryDump();
            int i = 0;
            while (!_memoryDumps.ContainsKey(memoryDump))
            {
                _memoryDumps.Add(memoryDump, i);
                DoRearrange();
                i++;
                memoryDump = MemoryDump();
            }

            return i - _memoryDumps[memoryDump];
        }


        private void SetupBuffer(int[] array)
        {
            _circularBuffer = new CircularBuffer<int>(array.Length);
            foreach (int value in array)
            {
                _circularBuffer.Add(value);
            }
        }

        private string MemoryDump()
        {
            string output = string.Empty;
            for (int i = 0; i < _circularBuffer.Length; i++)
            {
                output += _circularBuffer.Get(i);
            }
            return output;
        }

        

        private void DoRearrange()
        {
            int biggestIndex = 0;
            int biggestValue = 0;

            for (int i = 0; i < _circularBuffer.Length; i++)
            {
                if (_circularBuffer.Get(i) > biggestValue)
                {
                    biggestValue = _circularBuffer.Get(i);
                    biggestIndex = i;
                }
            }

            _circularBuffer.Set(biggestIndex, 0);
            for (int i = biggestIndex + 1; i < biggestIndex + biggestValue + 1; i++)
            {
                _circularBuffer.Set(i, _circularBuffer.Get(i) + 1);
            }
        }
    }
}
