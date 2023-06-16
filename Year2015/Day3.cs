using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Year2015
{
    public class Day3 : Day
    {
        private class ArrComparator : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                if (x.Length != y.Length)
                    return false;
                
                for(int i = 0; i < x.Length; i++)
                    if (x[i] != y[i])
                        return false;

                return true;
            }

            public int GetHashCode(int[] obj)
            {
                return obj[0] << 16 & obj[1];
            }
        }

        private string url = "https://adventofcode.com/2015/day/3/input";
        private string input = "";
        private Dictionary<char, int[]> key = new Dictionary<char, int[]>()
        {
            { '^', new int[] {  0,  1 }},
            { '>', new int[] {  1,  0 }},
            { '<', new int[] { -1,  0 }},
            { 'v', new int[] {  0, -1 }}
        };
        private int[][] coor = {new int[] {0, 0}, new int[] {0, 0}};
        private HashSet<int[]> history = new HashSet<int[]>(new ArrComparator());

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            //this.input = input;
            this.input = input;
        }

        private void Move(char ch, int index)
        {
            coor[index][0] += key[ch][0];
            coor[index][1] += key[ch][1];
            history.Add(DeepCopy(coor[index]));
        }

        private static int[] DeepCopy(int[] arr)
        {
            return arr.Select(a => a).ToArray();
        }

        private void clear()
        {
            coor = new int[][]{new int[] {0, 0}, new int[] {0, 0}};
            history = new HashSet<int[]>(new ArrComparator());
        }

        public int Part1()
        {
            clear();
            history.Add(DeepCopy(coor[0]));
            for (int i = 0; i < input.Length; i++)
                Move(input[i], 0);

            return history.Count;
        }

        public int Part2()
        {
            clear();
            history.Add(DeepCopy(coor[0]));
            for (int i = 0; i < input.Length; i++)
                Move(input[i], i % 2);

            return history.Count;
        }

        public void Test()
        {
            
        }
    }
}