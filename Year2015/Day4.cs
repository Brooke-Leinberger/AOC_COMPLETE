using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Year2015
{
    public class Day4 : Day
    {
        private string url = "https://adventofcode.com/2015/day/4/input";
        private string input = "";
        private MD5 hasher = MD5.Create();

        public string getURL()
        {
            return url;
        }

        public void LoadInputs(string input)
        {
            //this.input = input;
            this.input = input.TrimEnd();
        }

        private void clear()
        {
            
        }

        private int GetNibble(byte[] arr, int index)
        {
            int value = arr[index / 2];
            
            if (index % 2 == 0)
                return (value & 0xF0) >> 4;
            
            return value & 0x0F;
        }

        private bool Validate(byte[] hash, int nibbles)
        {
            for (int j = 0; j < nibbles; j++)
                if (GetNibble(hash, j) != 0)
                    return false;

            return true;
        }

        private int Part(int nibbles)
        {
            hasher.Initialize();
            string target;
            int i = 0;
            
            for (; i < Int32.MaxValue; i++)
            {
                target = input + i;
                byte[] hash = hasher.ComputeHash(Encoding.ASCII.GetBytes(target)); //always 2^7 bits long (2^4 bytes)

                if (Validate(hash, nibbles))
                    return i;
            }
            
            hasher.Dispose();
            return i;
        }

        public int Part1()
        {
            return Part(5);
        }

        public int Part2()
        {
            return Part(6);
        }
    }
}