using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class JumpIfTrueInstruction : Instruction
    {
        public JumpIfTrueInstruction(int instructionPointer) : base(instructionPointer)
        {
            DefaultParamCount = 2;
        }

        public override int GetParameterCount()
        {
            return DefaultParamCount;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            int[] positions = GetPositions(instructions);

            if (instructions[positions[0]] != 0)
            {
                DefaultParamCount = ((InstructionPointer * -1) + instructions[positions[1]]) - 1;
            }

            return ProcessResult.Continue;
        }
    }
}
