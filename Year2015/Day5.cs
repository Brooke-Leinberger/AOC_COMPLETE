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
        private Dictionary<string, HashSet<int>> pairs;
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

        private bool IsNice1(string str)
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

        private bool IsNice2(string str)
        {
            pairs = new Dictionary<string, HashSet<int>>();
            bool foundRepeat = false, foundCamel = false;
            for (int i = 0; i < str.Length - 1; i++)
            {
                string pair = str.Substring(i, 2);
                if (!pairs.ContainsKey(pair))
                    pairs.Add(pair, new HashSet<int>());

                pairs[pair].Add(i);

                if (pairs[pair].Count > 2 || pairs[pair].Max() - pairs[pair].Min() > 1)
                    foundRepeat = true;
                
                if (i < str.Length - 2 && str[i] == str[i + 2])
                    foundCamel = true;
                
                if (foundCamel && foundRepeat)
                    return true;
            }

            return false;
        }
        
        

        public int Part1()
        {
            return input.Count(IsNice1);
        }

        public int Part2()
        {
            return input.Count(IsNice2);
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

            Console.WriteLine("Part 1 Tests:");
            foreach (string entry in tests)
            {
                Console.WriteLine("\t{0}: {1}", entry, IsNice1(entry) ? "Nice": "Naughty");
            }
            
            tests = new List<string>()
            {
                "qjhvhtzxzqqjkmpb",
                "xxyxx",
                "uurcxstgmygtbstg",
                "ieodomkazucvgmuy",
            };
            
            Console.WriteLine("Part 2 Tests:");
            foreach (string entry in tests)
            {
                Console.WriteLine("\t{0}: {1}", entry, IsNice2(entry) ? "Nice": "Naughty");
            }
        }
    }
}