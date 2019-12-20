using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public delegate int IntEvent(int value);

    public abstract class Instruction
    {
        private int _instructionPointer;
        private List<ParameterMode> _parameters;
        private int _defaultParamCount;

        protected List<ParameterMode> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public int InstructionPointer
        {
            get
            {
                return _instructionPointer;
            }
        }

        public int DefaultParamCount
        {
            get => _defaultParamCount;
            set => _defaultParamCount = value;
        }


        public Instruction(int instructionPointer)
        {
            _instructionPointer = instructionPointer;
        }

        public ParameterMode GetParameterModeForParameter(int parameterIndex)
        {
            if (parameterIndex < _parameters.Count)
            {
                return _parameters[parameterIndex];
            }

            return ParameterMode.Undefined;
        }

        public abstract int GetParameterCount();

        public abstract ProcessResult Process(ref List<int> instructions);

        public void ParseInstructionDefinition(int instructionDefinition)
        {
            List<int> digits = GetDigit(instructionDefinition).ToList();
            int noOfParameters = digits.Count() - 2;

            List<ParameterMode> parameterModes = new List<ParameterMode>();
            int paramCount = GetParameterCount();
            for (int i = 0; i < paramCount; i++)
            {
                parameterModes.Add(ParameterMode.PositionMode);
            }

            if (noOfParameters > 0)
            {
                for (int i = 0; i < noOfParameters && i < paramCount; i++)
                {
                    ParameterMode mode = ParameterMode.PositionMode;
                    switch (digits[i + 2])
                    {
                        case 1:
                            mode = ParameterMode.ImmediateMode;
                            break;
                    }

                    parameterModes[i] = mode;
                }
            }

            _parameters = parameterModes;
        }

        protected IEnumerable<int> GetDigit(int source)
        {
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                yield return digit;
            }
        }

        protected int[] GetPositions(List<int> instructions)
        {
            int[] positions = new int[DefaultParamCount];
            int i = 0;
            foreach (ParameterMode paramMode in Parameters)
            {
                if (paramMode == ParameterMode.PositionMode)
                {
                    positions[i] = instructions[InstructionPointer + i + 1];
                }
                else
                {
                    positions[i] = InstructionPointer + i + 1;
                }

                i++;
            }

            return positions;
        }
    }
}
