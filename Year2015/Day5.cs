using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Year2015
{
    public class Day5 : Day
    {
        private string url = "https://adventofcode.com/2015/day/5/input";
        private HashSet<string> bannedSet = new HashSet<string>() {"ab", "cd", "pq", "xy"};
        private string[] input;

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            this.input = input.Split('\n').Where(c => c != "").ToArray();
        }

        private void Clear()
        {
            
        }

        private bool IsVowel(char c)
        {
            switch (c)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return true;
                default:
                    return false;
            }
        }

        private bool IsNice(string str)
        {
            if (str.Where(IsVowel).Count() < 3)
                return false;

            bool found = false;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return false;

            foreach (string entry in bannedSet)
            {
                if (str.Contains(entry))
                    return false;
            }

            return true;
        }

        public int Part1()
        {
            return input.Count(IsNice);
        }

        public int Part2()
        {
            return -1;
        }

        public void Test()
        {
            List<string> tests = new List<string>()
            {
                "ugknbfddgicrmopn",
                "aaa",
                "jchzalrnumimnmhp",
                "haegwjzuvuyypxyu",
                "dvszwmarrgswjxmb"
            };

            foreach (string entry in tests)
            {
                Console.WriteLine("{0}: {1}", entry, IsNice(entry) ? "Nice": "Naughty");
            }
        }
    }
}