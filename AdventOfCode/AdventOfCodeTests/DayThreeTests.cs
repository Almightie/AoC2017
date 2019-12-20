
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    public class Vector
    {
        private int _x;
        private int _y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public Vector Add(Vector vector)
        {
            return new Vector(vector.X + _x, vector.Y + _y);
        }

        public bool IsEqual(Vector otherVector)
        {
            return otherVector.X == _x && otherVector.Y == _y;
        }
    }

    [TestClass]
    public class DayThreeTests
    {
        private DayThree _dayThree;

        [TestInitialize]
        public void Initialize()
        {
            _dayThree = new DayThree();
        }

        [TestMethod]
        public void DayOnePartOne()
        {
            string[] lineStrings = File.ReadAllLines("input_3_1.txt");
            List<Dictionary<Tuple<int, int>, int>> linesPositions = new List<Dictionary<Tuple<int, int>, int>>();

            foreach (string lineString in lineStrings)
            {
                string[] lineInstructions = lineString.Split(',');
                Dictionary<Tuple<int, int>, int> linePositions = new Dictionary<Tuple<int, int>, int>();
                Vector startVector = new Vector(0, 0);

                foreach (string lineInstruction in lineInstructions)
                {
                    Vector vector = startVector;
                    int length = Convert.ToInt32(lineInstruction.Substring(1, lineInstruction.Length - 1));

                    if (lineInstruction.StartsWith("U"))
                    {
                        for (int i = 0; i < length; i++)
                        {
                            vector = vector.Add(new Vector(0, 1));
                            var newValue = new Tuple<int, int>(vector.X, vector.Y);
                            if (!linePositions.ContainsKey(newValue))
                            {
                                linePositions.Add(newValue, 0); 
                            }
                        }
                    }
                    else if (lineInstruction.StartsWith("D"))
                    {
                        for (int i = 0; i < length; i++)
                        {
                            vector = vector.Add(new Vector(0, -1));
                            var newValue = new Tuple<int, int>(vector.X, vector.Y);
                            if (!linePositions.ContainsKey(newValue))
                            {
                                linePositions.Add(newValue, 0);
                            }
                        }
                    }
                    else if (lineInstruction.StartsWith("L"))
                    {
                        for (int i = 0; i < length; i++)
                        {
                            vector = vector.Add(new Vector(-1, 0));
                            var newValue = new Tuple<int, int>(vector.X, vector.Y);
                            if (!linePositions.ContainsKey(newValue))
                            {
                                linePositions.Add(newValue, 0);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < length; i++)
                        {
                            vector = vector.Add(new Vector(1, 0));
                            var newValue = new Tuple<int, int>(vector.X, vector.Y);
                            if (!linePositions.ContainsKey(newValue))
                            {
                                linePositions.Add(newValue, 0);
                            }
                        }
                    }

                    
                    startVector = vector;
                }

                linesPositions.Add(linePositions);
            }

            var intersections = linesPositions[0].Intersect(linesPositions[1]);
            int manhattenLength = Int32.MaxValue;

            int x = 0;
            int y = 0;

            foreach (var intersection in intersections)
            {
                int newManhattenlength = Math.Abs(intersection.Key.Item1) + Math.Abs(intersection.Key.Item2);
                if (newManhattenlength < manhattenLength)
                {
                    manhattenLength = newManhattenlength;
                    x = intersection.Key.Item1;
                    y = intersection.Key.Item2;
                }
            }
        }


        [TestMethod]
        public void TestStringEncoding()
        {
            
            string inputString = "HalloDitIsEenText123";
            List<byte> dataList = new List<byte>();
            dataList.Add((byte)inputString.Length);
            dataList.AddRange(Encoding.ASCII.GetBytes(inputString));
            byte[] data = dataList.ToArray();


            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int loopIndex = 0; loopIndex < 100; loopIndex++)
            {
                int byteOffSet = 0;
                int textLength = data[byteOffSet];
                byte[] stringData = new byte[textLength];
                for (int i = 0; i < textLength; i++)
                {
                    stringData[i] = data[byteOffSet + i];
                }
                string testString = Encoding.ASCII.GetString(stringData);

            }
            sw.Stop();
            Console.WriteLine("Test executed in " + sw.ElapsedTicks);

            sw.Start();

            for (int loopIndex = 0; loopIndex < 100; loopIndex++)
            {
                int byteOffSet = 0;
                string result = string.Empty;

                int textLength = data[byteOffSet];
                byteOffSet++;


                for (int i = 0; i < textLength; i++)
                {
                    result += Convert.ToChar(data[byteOffSet + i]);
                }

                byteOffSet += textLength;


            }
            sw.Stop();
            Console.WriteLine("Test executed in " + sw.ElapsedTicks);
        }
    }
}
