
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AdventOfCode
{
    public class DayTwo
    {
        private enum OpCode : int
        {
            Add = 1,
            Multiply = 2,
            Exit = 99
        }

        public List<int> ProcessInput(List<int> input)
        {
            
            for (int instructionPosition = 0; instructionPosition < input.Count; instructionPosition = instructionPosition + 4)
            {
                OpCode opCode = (OpCode)input[instructionPosition];
                switch (opCode)
                {
                    case OpCode.Add:
                    {
                        int position1 = input[instructionPosition + 1];
                        int position2 = input[instructionPosition + 2];
                        int position3 = input[instructionPosition + 3];
                        input[position3] = input[position1] + input[position2];
                    }
                        break;
                    case OpCode.Multiply:
                    {
                        int position1 = input[instructionPosition + 1];
                        int position2 = input[instructionPosition + 2];
                        int position3 = input[instructionPosition + 3];
                        input[position3] = input[position1] * input[position2];
                    }
                        break;
                    case OpCode.Exit:
                        return input;
                        break;

                    default:
                        throw new Exception();
                }

            }
            return new List<int>();
        }
    }
}
