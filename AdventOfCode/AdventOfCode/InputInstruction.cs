using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class InputInstruction : Instruction
    {
        public InputInstruction(int instructionPointer) : base(instructionPointer)
        {
        }

        public override int GetParameterCount()
        {
            return 1;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            int[] positions = new int[1];
            int i = 0;
            foreach (ParameterMode paramMode in Parameters)
            {
                positions[i] = instructions[InstructionPointer + i + 1];
                i++;
            }

            instructions[positions[0]] = 5;
            return ProcessResult.Continue;
        }
    }
}
