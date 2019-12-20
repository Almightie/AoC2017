using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class ExitInstruction : Instruction
    {
        public ExitInstruction(int instructionPointer) : base(instructionPointer)
        {
        }

        public override int GetParameterCount()
        {
            return 0;
        }


        public override ProcessResult Process(ref List<int> instructions)
        {
            return ProcessResult.Exit;
        }
    }
}
