using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Year2015
{
    public class Day6 : Day
    {
        private string url = "https://adventofcode.com/2015/day/6/input";
        private Dictionary<string, int> key = new Dictionary<string, int>()
        {
            { "turn on",  1 }, 
            { "turn off", 0 }, 
            { "toggle",   2 },
        };
        private int[][] input;
        private bool[][] lights = new bool [1000][];

        private int ParseOp(string op)
        {
            if (key.ContainsKey(op))
                return key[op];
            
            return Int32.Parse(op);
        }

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            //Almost completely not necessary, but good practice to account for changing operations
            string split = "";
            foreach (string value in key.Keys.ToArray())
            {
                split += value + "|";
            }

            split = $"(?<={split.TrimEnd('|')}) | through|,";
            
            string[][] parsed = input.TrimEnd().Split('\n')
                .Select(c =>
                    Regex.Split(c, split).Where(d => d != "").ToArray())
                .ToArray();

            this.input = parsed.Select(c => c.Select(ParseOp).ToArray()).ToArray();
        }

        private void Clear()
        {
            for (int i = 0; i < lights.Length; i++)
                lights[i] = new bool[1000];
            
            OperateLights(new int[] {0, 0, 0, 999, 999});
        }

        private bool ModifyLight(int op, bool state)
        {
            switch (op)
            {
                case 0:
                case 1:
                    return op == 1 ? true : false;    

                case 2:
                    return !state;
                default:
                    throw new Exception("Invalid Light Operation");
            }
        }

        private void OperateLights(int[] entry)
        {
            for (int row = entry[2]; row <= entry[4]; row++)
            {
                for (int col = entry[1]; col <= entry[3]; col++)
                {
                    lights[row][col] = ModifyLight(entry[0], lights[row][col]);
                }
            }
        }

        public int Part1()
        {
            Clear();

            foreach (int[] entry in input)
            {
                OperateLights(entry);
            }
            
            return lights.Select(c => c.Count(d => d)).Sum();
        }

        public int Part2()
        {
            Clear();
            return -1;
        }

        public void Test()
        {
            Clear();
            string tests = "turn on 0,0 through 999,999\ntoggle 0,0 through 999,0\nturn off 499,499 through 500,500";
            LoadInputs(tests);
            Console.WriteLine("Test 1: {0}", Part1());
        }
    }
}