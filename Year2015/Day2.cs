using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Year2015
{
    public class Day2 : Day
    {
        private string url = "https://adventofcode.com/2015/day/2/input";
        private int[][] presents;

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            presents = input.Split('\n').Where(c => c != "").Select(c => c.Split('x').Select(int.Parse).OrderBy(e => e).ToArray()).ToArray();
        }

        private int CalculateArea(int[] present)
        {
            int area = 0;
            
            area += 3 * present[0] * present[1];
            area += 2 * present[1] * present[2];
            area += 2 * present[0] * present[2];

            return area;
        }

        private int CalculateRibbon(int[] present)
        {
            int len = 0;
            
            len += present[0] * present[1] * present[2];
            len += 2 * (present[0] + present[1]);

            return len;
        }
        

        public int Part1()
        {
            return presents.Select(CalculateArea).Sum();
        }

        public int Part2()
        {
            return presents.Select(CalculateRibbon).Sum();
        }

        public void Test()
        {
            
        }
    }
}