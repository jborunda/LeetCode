﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Palidrome2(12321));
            Console.WriteLine(RomanToInt("IVX"));
            Console.ReadLine();
        }

        public static int Reverse(int number)
        {

            bool neg = false;
            string reverse = "";
            if (Convert.ToString(number).Length == 1)
                return number;
            if (number < 0)
                neg = true;


            int iteration = number.ToString().Length;
            //12345
            for (int i = 0; i < iteration;i++)
            {
                int foo = number % 10;
                reverse = String.Concat(reverse,Math.Abs(foo));   
                number /= 10;
            }
            reverse = reverse.TrimStart('0');
            if (neg)
                return -1*Convert.ToInt32(reverse);
            else
                return Convert.ToInt32(reverse);
        }
        public static bool Palidrome(int number)
        {
            int temp = number;
            string reverse = "";
            if (number < 0)
                return false;

            int iteration = number.ToString().Length;
            //12345
            for (int i = 0; i < iteration; i++)
            {
                int foo = number % 10;
                reverse = String.Concat(reverse, Math.Abs(foo));
                number /= 10;
            }
            Debug.WriteLine(reverse);
            Debug.WriteLine(temp);
            if (temp == Convert.ToInt64(reverse))
                return true;
            else
                return false;

        }
         
        public static bool Palidrome2(int x)
        {
                if (x < 0 || x % 10 == 0 && x != 10)
                    return false;

                int half = 0;
                

                //12321
                while (x > half)
                {
                    half = half * 10 + x % 10;
                    x /= 10;
                }

            return x == half || x == half / 10;
        }
        public static int RomanToInt(string s)
        {
            if (s == null || s.Length == 0)
                return 0;


            Dictionary<Char, int> dictionary = new Dictionary<char, int>();
            dictionary.Add('I', 1);
            dictionary.Add('V', 5);
            dictionary.Add('X', 10);
            dictionary.Add('L', 50);
            dictionary.Add('C', 100);
            dictionary.Add('D', 500);
            dictionary.Add('M', 1000);

            int length = s.Length;
            int result = dictionary[s.ElementAt(length - 1)];


            for(int i = length - 2; i >= 0; i--)
            {
                if(dictionary[s.ElementAt(i+1)] <= dictionary[s.ElementAt(i)] )
                {
                    result += dictionary[s.ElementAt(i)];
                }
                else if(dictionary[s.ElementAt(i+1)] > dictionary[s.ElementAt(i)])
                {
                    result -= dictionary[s.ElementAt(i)];
                }
            }

            return result;

        }
    }
}