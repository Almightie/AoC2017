using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class OutputInstruction : Instruction
    {
        public OutputInstruction(int instructionPointer) : base(instructionPointer)
        {
            DefaultParamCount = 1;
        }

        public override int GetParameterCount()
        {
            return DefaultParamCount;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            int[] positions = GetPositions(instructions);

            Console.WriteLine(instructions[positions[0]]);
            return ProcessResult.Continue;
        }
    }
}
