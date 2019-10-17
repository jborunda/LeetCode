using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string haystack = "hello", needle = "ll";


            Console.WriteLine(StrStr(haystack, needle));
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
            for (int i = 0; i < iteration; i++)
            {
                int foo = number % 10;
                reverse = String.Concat(reverse, Math.Abs(foo));
                number /= 10;
            }
            reverse = reverse.TrimStart('0');
            if (neg)
                return -1 * Convert.ToInt32(reverse);
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


            for (int i = length - 2; i >= 0; i--)
            {
                if (dictionary[s.ElementAt(i + 1)] <= dictionary[s.ElementAt(i)])
                {
                    result += dictionary[s.ElementAt(i)];
                }
                else if (dictionary[s.ElementAt(i + 1)] > dictionary[s.ElementAt(i)])
                {
                    result -= dictionary[s.ElementAt(i)];
                }
            }

            return result;

        }
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || strs == null)
                return "";
            string longestPrefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                int j = 0;
                string currentString = strs[i];

                while (j < longestPrefix.Length && j < currentString.Length && longestPrefix[j] == currentString[j])
                {
                    j++;
                }

                longestPrefix = longestPrefix.Substring(0, j);


            }

            return longestPrefix;
        }
        public static bool IsValid(string s)
        {

            Stack<char> stack = new Stack<char>();



            foreach (char c in s.ToCharArray())
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (!(stack.Count == 0) && Helper(stack.Peek(), c))
                    {
                        stack.Pop();
                    }
                    else return false;
                }



            }


            return stack.Count == 0;
        }

        public static bool Helper(char left, char right)
        {
            if (left == ' ' || right == ' ')
                return false;
            return left == '(' && right == ')' || left == '[' && right == ']' || left == '{' && right == '}';
        }

        public static ListNode MergeTwoListNodes(ListNode l1, ListNode l2)
        {
            ListNode x = new ListNode(0);
            ListNode newList = x;

            while (l1 != null && l2 != null)
            {
                if (l1.value <= l2.value)
                {
                    newList.next = l1;
                    l1 = l1.next;
                }
                else if (l2.value < l1.value)
                {
                    newList.next = l2;
                    l2 = l2.next;
                }

                newList = newList.next;


            }

            if (l1 != null) newList.next = l1;
            if (l2 != null) newList.next = l2;

            return x.next;
        }


        //Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        public static int Len(int[] nums)
        {
            //[1,1,2]
            if (nums == null || nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {

                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];

                }

            }
            return i + 1;
        }



        public static int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int j = 0;
            //[0,1,2,2,3,0,4,2]
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j] = nums[i];
                    j++;
                }

            }



            return j;

        }

        public static int StrStr(string haystack, string needle)
        {

            if (haystack == null || needle == null)
                return -1;


            for(int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                int j;
                for(j = 0; j < needle.Length; j++)
                {
                    if(haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }
                if (j == needle.Length)
                    return i;
                
            }

            return -1;

        }
        
    }
}

