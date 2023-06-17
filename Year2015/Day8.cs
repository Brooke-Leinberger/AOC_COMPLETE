
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Year2015
{
    public class Day8 : Day
    {
        private string url = "https://adventofcode.com/2015/day/8/input";
        private string[] input;

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            this.input = input.TrimEnd().Split('\n');
        }

        private void Clear()
        {
        
        }

        public int Part1()
        {
            return input.Select(c => c.Length - Regex.Unescape(c.Trim('"')).Length).Sum();
        }

        public int Part2()
        {
            return -1;
        }

        public void Test()
        {
            string tests = "\"\"\n\"abc\"\n\"aaa\\\"aaa\"\n\"\\x27\"";
            LoadInputs(tests);
            Console.WriteLine("Test 1: {0}", Part1());
        }
    }
}