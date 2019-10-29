using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode a = new TreeNode(12);
            //a.left = new TreeNode(5);
            //a.right = new TreeNode(6);

            //a.left.left = new TreeNode(4);
            //a.left.right = new TreeNode(9);

            ////a.right.left = new TreeNode(1);
            //a.right.right = new TreeNode(2);
            //Console.WriteLine(MaxDepth(a));
            //foreach(int n in PostOrderTraversal(a))
            //{
            //    Console.WriteLine(n);
            //    Debug.WriteLine(n);
            //}
            Console.WriteLine(StringCompresion("wwwwaaadexxxxxxywww"));
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


        //Given an array nums and a value val, remove all instances of that value in-place and return the new length.
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
        //Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
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

        //return the index where you would insert a int into an array of ints
        public static int SearchInsert(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            

            //Input: [1,3,5,6], 5
            while (start + 1  < end)
            {
                int mid = start + (end-start) / 2;
                if (nums[mid] == target)
                    return mid;

                if(nums[mid] < target)
                {
                    start = mid;
                }
                else if(nums[mid] > target)
                {
                    end = mid;
                }
            }

            if (nums[start] >= target)
            {
                return start;
            }
            else if (nums[end] < target)
                return end + 1;
            else
                return end;



        }

        public static List<TreeNode> PreOrderIterative(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            //if (root == null) return errorexception();

            Stack<TreeNode> s = new Stack<TreeNode>();

            s.Push(root);
            while(! (s.Count() == 0))
            {
                root = s.Pop();
                list.Add(root);
                if (root.right != null)
                    s.Push(root.right);
                if (root.left != null)
                    s.Push(root.left);

            }
            return list;
        }

        public static List<int> InOrderIterative(TreeNode root)
        {
            Stack<TreeNode> s = new Stack<TreeNode>();

            List<int> list = new List<int>();

            //add the first rootnode into the stack
            while(true)
            {

                if(root != null)
                {
                    s.Push(root); 
                    root = root.left;
                    
                }
                else
                {
                    if (s.Count() == 0) break;
                    root = s.Pop();
                    //we want to add the value of the node we pop in order
                    list.Add(root.val);
                    Debug.WriteLine(root.val);
                    root = root.right;
                    
                }
                


            }
            return list;


        }

        public static List<int> PostOrderTraversal(TreeNode root) {
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2 = new Stack<TreeNode>();
            List<int> list = new List<int>();
            s1.Push(root);

            while(! (s1.Count == 0))
            {
                root = s1.Pop();
                s2.Push(root);

                if (root.left != null)
                    s1.Push(root.left);
                if (root.right != null)
                    s1.Push(root.right);

            }

            while(!(s2.Count() == 0))
            {

                list.Add(s2.Pop().val);


            }
            return list;
        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int leftHeight =  MaxDepth(root.left);
            int rightHeight = MaxDepth(root.right);



            return 1 + Math.Max(leftHeight,rightHeight);
        }

        public static string CountAndSay(int n)
        {
            string result = "";

            return result;
            
        }

        //checks to see if a string is unique using a hashtable
        public static bool IsUnique(string s )
        {
            bool value = true;
            


            Hashtable ht = new Hashtable();
            for(int i = 0; i < s.Length; i++ )
            {
                
                if (ht.Contains(s[i]))
                    return false;
                else
                    ht.Add(s[i], i);
            }

            return value;

        }


        //Given two strings, write a method to decide if one is a permutation of the other
        public static bool CheckPermutation(string s1, string s2)
        {
            bool value = false;
            int l1 = s1.Length;
            int l2 = s2.Length;

            if (!(l1 == l2))
                return value;

            char[] array1 = s1.ToCharArray();
            char[] array2 = s2.ToCharArray();

            Array.Sort(array1);
            Array.Sort(array2);

            for(int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                        return value;
            }

            return true;
        }

        //Write a method to replace all spaces in a string with '%20: You may assume that the string has sufficient space at the end to hold the additional characters, 
        //and that you are given the "true" length of the string
        public static string ReplaceStringSpace(string s, int len)
        {
            char[] chars = s.ToCharArray();

            int spaceCount = 0;
            
            
            for(int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ' ')
                    spaceCount++;


            }
            int index = (len -1) + (spaceCount*2);

            char[] newChar = new char[index + 1 ];
            for (int i = len - 1; i>=0 && index >= 0; i--)
            {

                if (chars[i] == ' ')
                {

                    newChar[index] = '0';
                    newChar[index - 1] = '2';
                    newChar[index - 2] = '%';
                    index -= 3;

                }
                else

                    Debug.WriteLine(index +"+" +i);
                    newChar[index] = chars[i];
                    index--;
                  


            }

            return new String(newChar).Trim(' ');
        }

        public static bool PalidromeString(string s)
        {
            
            s = s.Trim(' ');
            Debug.WriteLine(s);
            bool value = true;
            int len = s.Length;
            int end = len - 1;
            int i = 0;
            


            while (i != end && i< len && end > 0)
            {
                if (s[i] != s[end])
                    return false;
                else

                {
                    end--;
                    i++;
                }

            }
            Debug.WriteLine(i + " " + end);
            return value;
        }

        public static bool PalidromePermutation(string s)
        {
            s = s.Trim(' ');
            List<char> list = new List<char>();
            foreach (char c in s.ToCharArray())
            {
                if(list.Contains(c))
                {
                    list.Remove(c);


                }else
                    list.Add(c);
            }
            if(list.ToArray().Length > 1)
            {
                return false;
            }

            return true;
            
        }


        public static string StringCompresion(string s)
        {
            int count;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                count = 1;
                while (s[i] == s[i + 1] && i+1 < s.Length )
                {
                    count++;
                    i++;
                }
                

                sb = sb.Append(s[i]);
                sb = sb.Append(count);
                Debug.WriteLine(sb);
            }


            //int count = 0, k = 0, m = 0;
            //int i = str.Length;
            //string name1 = String.Empty;

            //for (int j = 0; j < i; j++)
            //{
            //    char name = str[m];

            //    while (j < i)
            //    {
            //        if (str[j].ToString() == name.ToString())
            //        {
            //            count++;
            //            k++;
            //        }
            //        j++;

            //    }
            //    j = k - 1;

            //    name1 = name1 + str[m].ToString() + count;
            //    m = k;
            //    count = 0;


            //}
            //Console.WriteLine("{0}", name1);
            //Console.ReadKey();
            //j1a1i1m2e1
            return sb.ToString();
        }
    }
}

