using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Year2015
{
    public class Day10 : Day
    {
        private string url = "https://adventofcode.com/2015/day/4/input";
        private List<char> input = new List<char>();
        private List<char> part1 = new List<char>();

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            this.input.AddRange("3113322113".ToCharArray());
        }

        private void Clear()
        {
            
        }

        private List<char> Iterate(List<char> seed)
        {
            List<char> output = new List<char>();

            int counter = 0;
            char ch = seed[0];
            for (int i = 0; i < seed.Count; i++)
            {
                if (seed[i] == ch)
                {
                    counter++;
                }
                
                else
                {
                    output.AddRange($"{counter}".ToCharArray());
                    output.Add(ch);
                    ch = seed[i];
                    counter = 1;
                }
            }
            
            output.AddRange($"{counter}".ToCharArray());
            output.Add(ch);
            
            return output;
        }

        public int Part1()
        {
            List<char> iter = input;
            for (int i = 0; i < 40; i++)
            {
                iter = Iterate(iter);
            }
            part1 = iter;
            return iter.Count;
        }

        public int Part2()
        {
            List<char> iter = part1;
            for (int i = 40; i < 50; i++)
            {
                iter = Iterate(iter);
            }
            
            return iter.Count;
        }

        public void Test()
        {
            Console.WriteLine("Beware, this is a very long process");
            List<char> test = new List<char>("1");
            for (int i = 0; i < 4; i++)
            {
                test = Iterate(test);
            }
            
            Console.WriteLine("Test: " + new string(test.ToArray()));
        }
    }
}