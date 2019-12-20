
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace AdventOfCode
{
    public enum OpCode : int
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Exit = 99
    }
    public enum ParameterMode : int
    {
        Undefined = -1,
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
            //List<Instruction> instructions = new List<Instruction>();
            int instructionPointer = 0;
            while(instructionPointer < input.Count)
            {
                OpCode opCode = (OpCode) (input[instructionPointer] % 100);
                Instruction instruction;
                switch (opCode)
                {
                    case OpCode.Add:
                    {
                        instruction = new AddInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.Multiply:
                    {
                        instruction = new MultiplyInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.Exit:
                    {
                        return;
                    }
                    case OpCode.Output:
                    {
                        instruction = new OutputInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.Input:
                    {
                        instruction = new InputInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.JumpIfTrue:
                    {
                        instruction = new JumpIfTrueInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.JumpIfFalse:
                    {
                        instruction = new JumpIfFalseInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.LessThan:
                    {
                        instruction = new LessThanInstruction(instructionPointer);
                        break;
                    }
                    case OpCode.Equals:
                    {
                        instruction = new EqualsInstruction(instructionPointer);
                        break;
                    }

                    default:
                        throw new Exception("Vervroegd pensioen!");
                }

                instruction.ParseInstructionDefinition(input[instruction.InstructionPointer]);

                switch (instruction.Process(ref input))
                {
                    case ProcessResult.Exit:
                        break;
                }

                instructionPointer += instruction.GetParameterCount() + 1;
            }
        }

      
    }

}
