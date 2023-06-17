using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Year2015
{
    public class Day7 : Day
    {
        private string url = "https://adventofcode.com/2015/day/7/input";
        private string[][] inputs;
        private Dictionary<string, UInt16> signals = new Dictionary<string, UInt16>();

        private Dictionary<string, OPS> key = new Dictionary<string, OPS>()
        {
            { "AND", OPS.AND },
            { "OR", OPS.OR },
            { "NOT", OPS.NOT },
            { "LSHIFT", OPS.LSHIFT },
            { "RSHIFT", OPS.RSHIFT },
        };

        private enum OPS
        {
            AND     =   0,
            OR      =   1,
            NOT     =   2,
            LSHIFT  =   3,
            RSHIFT  =   4,
        }

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            inputs = input.TrimEnd().Split('\n').Select(c => Regex.Split(c, " -> | ")).ToArray();
            
            //Standardize Inputs so all have 2 inputs, an operation, and an assignment
            for (int i = 0; i < inputs.Length; i++)
            {
                // "X -> Y" to "X OR 1 -> Y"
                if (inputs[i].Length == 2)
                    inputs[i] = new string[] {inputs[i][0], "OR", "0", inputs[i][1]};

                // "NOT X -> Y" to "X NOT 1 -> Y"
                if (inputs[i][0] == "NOT")
                    inputs[i] = new string[] {inputs[i][1], inputs[i][0], "1", inputs[i][2]};
            }
            //Organize inputs so they can be traversed in order
            //Start with operations that have constant inputs
            
        }

        private bool IsConst(string str)
        {
            return Regex.IsMatch(str, @"\d");
        }

        private UInt16 CalculateSignal(string signal)
        {
            if (signals.ContainsKey(signal))
                return signals[signal];
            
            if (IsConst(signal))
                return UInt16.Parse(signal);
            
            string[] definition = inputs.Where(c => c.Last() == signal).ToArray()[0];
            UInt16 value =  CalculateOperation(CalculateSignal(definition[0]), CalculateSignal(definition[2]), key[definition[1]]);
            signals.Add(signal, value);
            return value;
        }

        private UInt16 CalculateOperation(UInt16 a, UInt16 b, OPS op)
        {
            switch (op)
            {
                case OPS.AND:
                    return (UInt16)(a & b);
                case OPS.OR:
                    return (UInt16)(a | b);
                case OPS.LSHIFT:
                    return (UInt16)(a << b);
                case OPS.RSHIFT:
                    return (UInt16)(a >> b);
                case OPS.NOT:
                    return (UInt16)(~a);
                default:
                    throw new Exception();
            }
        }

        private void Clear()
        {
            signals = new Dictionary<string, UInt16>();
        }

        public int Part1()
        {
            Clear();
            return CalculateSignal("a");
        }

        public int Part2()
        {
            Clear();
            UInt16 val = CalculateSignal("a");
            Clear();
            signals.Add("b", val);
            return CalculateSignal("a");
        }

        public void Test()
        {
            string tests =
                "123 -> x\n" +
                "456 -> y\n" +
                "x AND y -> d\n" +
                "x OR y -> e\n" +
                "x LSHIFT 2 -> f\n" +
                "y RSHIFT 2 -> g\n" +
                "NOT x -> h\n" +
                "NOT y -> i\n";
            
            LoadInputs(tests);
            foreach (string signal in inputs.Select(c => c[3]))
            {
                Console.WriteLine("Signal {0}: {1}", signal, CalculateSignal(signal));
            }
        }
    }
}