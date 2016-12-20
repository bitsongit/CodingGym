using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter String : ");
                string str = Console.ReadLine();

                // string str = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";

                Console.WriteLine("Longest file path length will be : {0}", lengthLongestPath(str).ToString());

            }

        }

        // https://leetcode.com/problems/longest-absolute-file-path/
        public static int lengthLongestPath(string input)
        {
            int max = 0;
            int current = 0;
            char[] separator = new char[] { '\n' };
            string[] paths = input.Split(separator);
            if (paths.Length == 0)
            {
                return max;
            }
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < paths.Length; i++)
            {
                while (stack.Count != 0 && stack.Peek().LastIndexOf("\t") >= paths[i].LastIndexOf("\t"))
                {
                    current -= compute(stack.Peek()) + 1;
                    stack.Pop();
                }
                current += compute(paths[i]) + 1;
                if (isFile(paths[i]))
                {
                    max = Math.Max(max, current);
                }
                stack.Push(paths[i]);
            }

            return max == 0 ? 0 : max - 1;
        }

        private static bool isFile(string path)
        {
            return path.Contains(".");
        }

        private static int compute(string path)
        {
            return path.Length - path.LastIndexOf("\t") - 1;
        }
    }
}
