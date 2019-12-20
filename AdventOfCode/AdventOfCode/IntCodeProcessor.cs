
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AdventOfCode
{
    public enum OpCode : int
    {
        Add = 1,
        Multiply = 2,
        OpCode3 = 3,
        OpCode4 = 4,
        Exit = 99
    }
    public enum ParameterMode : int
    {
        PositionMode = 0,
        ImmediateMode = 1
    }

    public enum ProcessResult : int
    {
        Continue = 1,
        Exit = 2
    }

    public class IntCodeProcessor
    {
        public void ProcessInput(List<int> input)
        {
            List<Instruction> instructions = new List<Instruction>();
            int instructionPointer = 0;
            while(instructionPointer < input.Count)
            {
                OpCode opCode = (OpCode)input[instructionPointer];
                Instruction instruction;
                switch (opCode)
                {
                    case OpCode.Add:
                    {
                        instruction = new AddInstruction(instructionPointer);
                    }
                        break;
                    case OpCode.Multiply:
                    {
                        instruction = new MultiplyInstruction(instructionPointer);
                    }
                        break;
                    case OpCode.Exit:
                    {
                        instruction = new ExitInstruction(instructionPointer);
                    }
                        break;

                    default:
                        throw new Exception();
                }

                instructionPointer += instruction.ParameterCount;
                instructions.Add(instruction);

                if (instruction.ParameterCount == -1)
                {
                    break;
                }
            }

            foreach (Instruction instruction in instructions)
            {
                instruction.Process(ref input);
            }
        }
    }

    public abstract class Instruction
    {
        private int _instructionPointer;

        public int ParameterCount
        {
            get
            {
                return GetParameterCount();
            }
        }

        public int InstructionPointer
        {
            get
            {
                return _instructionPointer;
            }
        }

        public Instruction(int instructionPointer)
        {
            _instructionPointer = instructionPointer;
        }

        public abstract int GetParameterCount();

        public abstract ProcessResult Process(ref List<int> instructions);
    }

    public class AddInstruction : Instruction
    {
        public AddInstruction(int instructionPointer) : base(instructionPointer)
        {
            
        }
        
        public override int GetParameterCount()
        {
            return 4;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            int position1 = instructions[InstructionPointer + 1];
            int position2 = instructions[InstructionPointer + 2];
            int position3 = instructions[InstructionPointer + 3];
            instructions[position3] = instructions[position1] + instructions[position2];

            return ProcessResult.Continue;
        }
    }

    public class MultiplyInstruction : Instruction
    {
        public MultiplyInstruction(int instructionPointer) : base(instructionPointer)
        {
            
        }

        public override int GetParameterCount()
        {
            return 4;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            int position1 = instructions[InstructionPointer + 1];
            int position2 = instructions[InstructionPointer + 2];
            int position3 = instructions[InstructionPointer + 3];
            instructions[position3] = instructions[position1] * instructions[position2];

            return ProcessResult.Continue;
        }
    }

    public class ExitInstruction : Instruction
    {
        public ExitInstruction(int instructionPointer) : base(instructionPointer)
        {
            
        }

        public override int GetParameterCount()
        {
            return -1;
        }

        public override ProcessResult Process(ref List<int> instructions)
        {
            return ProcessResult.Exit;
        }
    }
}
