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
            { "turn on",   1 }, 
            { "turn off", -1 }, 
            { "toggle",    2 },
        };
        private int[][] input;
        private int[][] lights = new int [1000][];

        

        private int ModifyLight(int op, int state)
        {
            if (op != key["toggle"])
                return op;

            return state > 0 ? key["turn off"] : key["turn on"];
        }
        
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
                lights[i] = new int[1000];
            
            for (int row = 0; row < lights.Length; row++)
            {
                for (int col = 0; col < lights[row].Length; col++)
                {
                    lights[row][col] = 0;
                }
            }
        }

        public int Part1()
        {
            Clear();

            foreach (int[] entry in input)
            {
                for (int row = entry[2]; row <= entry[4]; row++)
                {
                    for (int col = entry[1]; col <= entry[3]; col++)
                    {
                        lights[row][col] = entry[0] != key["toggle"] 
                            ? entry[0] 
                            : (lights[row][col] > 0 ? key["turn off"] : key["turn on"]);
                    }
                }
            }
            
            return lights.Select(c => c.Count(d => d > 0)).Sum();
        }

        public int Part2()
        {
            Clear();

            foreach (int[] entry in input)
            {
                for (int row = entry[2]; row <= entry[4]; row++)
                {
                    for (int col = entry[1]; col <= entry[3]; col++)
                    {
                        lights[row][col] += entry[0];
                        if (lights[row][col] < 0)
                            lights[row][col] = 0;
                    }
                }
            }
            
            return lights.Select(c => c.Sum()).Sum();
        }

        public void Test()
        {
            string tests;
            
            Clear();
            tests = "turn on 0,0 through 999,999\ntoggle 0,0 through 999,0\nturn off 499,499 through 500,500";
            LoadInputs(tests);
            Console.WriteLine("Test 1: {0}", Part1());
            
            Clear();
            tests = "toggle 0,0 through 999,999";
            LoadInputs(tests);
            Console.WriteLine("Test 2: {0}", Part2());
        }
    }
}