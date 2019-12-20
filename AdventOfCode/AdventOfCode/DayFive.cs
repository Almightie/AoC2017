using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class DayFive
    {
        private enum OpCode : int
        {
            Add = 1,
            Multiply = 2,
            OpCode3 = 3,
            OpCode4 = 4,
            Exit = 99
        }

        private enum ParameterMode : int
        {
            PositionMode = 0,
            ImmediateMode = 1
        }

        public List<int> ProcessInput(List<int> input)
        {
            int opCodeSize = 4;
            for (int instructionPosition = 0;instructionPosition < input.Count; instructionPosition = instructionPosition + opCodeSize)
            {
                string opCodeString = input[instructionPosition].ToString();
                ParameterMode paramMode = (ParameterMode) Convert.ToInt32(input[instructionPosition].ToString().Substring(opCodeString.Length - 2, 1));

                OpCode opCode = (OpCode)(input[instructionPosition] & 0x5);
                switch (opCode)
                {
                    case OpCode.Add:
                    {
                        opCodeSize = 4;
                        if (paramMode == ParameterMode.PositionMode)
                        {
                            int position1 = input[instructionPosition + 1];
                            int position2 = input[instructionPosition + 2];
                            int position3 = input[instructionPosition + 3];
                            input[position3] = input[position1] + input[position2];
                        }
                        else
                        {

                        }
                        
                    }
                        break;
                    case OpCode.Multiply:
                    {
                        opCodeSize = 4;
                        if (paramMode == ParameterMode.PositionMode)
                        {
                            int position1 = input[instructionPosition + 1];
                            int position2 = input[instructionPosition + 2];
                            int position3 = input[instructionPosition + 3];
                            input[position3] = input[position1] * input[position2];
                        }
                        else
                        {

                        }
                        
                    }
                        break;
                    case OpCode.OpCode3:
                    {
                        opCodeSize = 2;
                        if (paramMode == ParameterMode.PositionMode)
                        {

                        }
                        else
                        {
                            
                        }
                    }
                        break;
                    case OpCode.OpCode4:
                    {
                        if (paramMode == ParameterMode.PositionMode)
                        {

                        }
                        else
                        {

                        }
                    }
                        break;

                }
            }

            return new List<int>();
        }
    }
}
