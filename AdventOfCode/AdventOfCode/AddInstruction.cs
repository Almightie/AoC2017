using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class AddInstruction : Instruction
    {
        public AddInstruction(int instructionPointer) : base(instructionPointer)
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

            instructions[positions[2]] = instructions[positions[0]] + instructions[positions[1]];

            return ProcessResult.Continue;
        }
    }
}
