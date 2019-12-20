using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class LessThanInstruction : Instruction
    {
        public LessThanInstruction(int instructionPointer) : base(instructionPointer)
        {
            DefaultParamCount = 3;
        }

        public override int GetParameterCount()
        {
            return DefaultParamCount;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            int[] positions = GetPositions(instructions);

            if (instructions[positions[0]] < instructions[positions[1]])
            {
                instructions[positions[2]] = 1;
            }
            else
            {
                instructions[positions[2]] = 0;
            }

            return ProcessResult.Continue;
        }
    }
}
