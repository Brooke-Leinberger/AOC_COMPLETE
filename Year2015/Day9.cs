using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Year2015
{
    public class Day9 : Day
    {
        private string url = "https://adventofcode.com/2015/day/9/input";
        private string[][] input;
        private Dictionary<string, UInt16> distances = new Dictionary<string, UInt16>();
        private HashSet<string> cities = new HashSet<string>();


        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            this.input = input.TrimEnd().Split('\n')
                .Select(c => Regex.Split(c, " to | = ")).ToArray();

            string cityA, cityB;
            for (int i = 0; i < this.input.Length; i++)
            {
                cities.Add(this.input[i][0]);
                cities.Add(this.input[i][1]);
                
                cityA = this.input[i][0];
                cityB = this.input[i][1];

                if (String.CompareOrdinal(this.input[i][0], this.input[i][1]) > 0)
                {
                    cityA = this.input[i][1];
                    cityB = this.input[i][0];
                }
                
                distances.Add(cityA + "-" + cityB, UInt16.Parse(this.input[i][2]));
            }
            
        }

        private void Clear()
        {
            
        }

        private T[] DeepCopy<T>(T[] elements)
        {
            return elements.Select(c => c).ToArray();
        }

        private UInt16 GetDistance(string cityA, string cityB)
        {

            if (String.CompareOrdinal(cityA, cityB) > 0)
            {
                (cityA, cityB) = (cityB, cityA);
            }
                
            return distances[cityA + "-" + cityB];
        }

        private UInt16 CalculatePermuation(UInt16[] indicies)
        {
            string[] citiesArr = cities.ToArray();
            UInt16 distance = 0;
            for (int i = 0; i < indicies.Length - 1; i++)
            {
                distance += GetDistance(citiesArr[indicies[i]], citiesArr[indicies[i + 1]]);
            }

            return distance;
        }

        private void HeapsAlgorithm<T>(T[] elements, List<T[]> list, int size)
        {
            if (size == 1)
                list.Add(DeepCopy<T>(elements));

            for (int i = 0; i < size; i++)
            {
                HeapsAlgorithm<T>(elements, list, size - 1);
                if (size % 2 == 1)
                {
                    (elements[0], elements[size - 1]) = (elements[size - 1], elements[0]);
                }

                else
                {
                    (elements[i], elements[size - 1]) = (elements[size - 1], elements[i]);
                }
            }
            
        }

        public int Part1()
        {
            UInt16 min = UInt16.MaxValue;
            
            //calculate permutations
            List<UInt16[]> permutations = new List<UInt16[]>();
            UInt16[] seed = new UInt16[cities.Count];
            for (int i = 0; i < seed.Length; i++)
                seed[i] = (UInt16) i;
            
            HeapsAlgorithm(seed, permutations, cities.Count);
            
            //brute force
            foreach (UInt16[] permutation in permutations)
            {
                UInt16 distance = CalculatePermuation(permutation);
                min = distance < min ? distance : min;
            }

            return min;
        }

        public int Part2()
        {
            UInt16 max = 0;
            
            //calculate permutations
            List<UInt16[]> permutations = new List<UInt16[]>();
            UInt16[] seed = new UInt16[cities.Count];
            for (int i = 0; i < seed.Length; i++)
                seed[i] = (UInt16) i;
            
            HeapsAlgorithm(seed, permutations, cities.Count);
            
            //brute force
            foreach (UInt16[] permutation in permutations)
            {
                UInt16 distance = CalculatePermuation(permutation);
                max = distance > max ? distance : max;
            }

            return max;
        }

        public void Test()
        {
            
        }
    }
}