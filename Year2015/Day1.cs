using System;
using System.Linq;

namespace Year2015
{
    public class Day1 : Day
    {
        private string input;
        private string url = "https://adventofcode.com/2015/day/1/input";
        
        public int Part1()
        {
            int ups = input.Count(c => c == '(');
            int downs = input.Count(c => c == ')');

            return ups - downs;
        }

        public int Part2()
        {
            int floor = 0;
            int i = 0;

            for (; i < input.Length && floor > -1; i++)
            {
                if (input[i] == '(')
                    floor++;
                
                if (input[i] == ')')
                    floor--;
            }
            
            return i;
        }

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string inputs)
        {
            this.input = inputs;
        }
    }
}