using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter String : ");
                string str = Console.ReadLine();

                Console.WriteLine("Given String Contains Unique Characters: {0}", DecodeString(str));
                
                Console.WriteLine("Earlier length : {0} Removed 'n' Characters: {1} ", str.Length,RemoveChar(str,'e'));

            }
            
        }
        public static string DecodeString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            Stack<int> count = new Stack<int>();
            Stack<string> result = new Stack<string>();
            int i = 0;
            result.Push("");

            while (i < s.Length)
            {
                char ch = s[i];

                if (ch >= '0' && ch <= '9')
                {
                    int start = i;
                    int nextNums = 0;
                    while (s[i + 1] >= '0' && s[i + 1] <= '9')
                    {
                        i++;
                        nextNums++;
                    }
                    string temp = s.Substring(start, nextNums + 1);

                    Console.WriteLine(temp + ":" + start + ":" + (nextNums + 1));
                    count.Push(int.Parse(temp));
                }
                else if (ch == '[')
                {
                    result.Push("");
                }
                else if (ch == ']')
                {
                    String str = result.Pop();
                    StringBuilder sb = new StringBuilder();
                    int times = count.Pop();
                    for (int j = 0; j < times; j += 1)
                    {
                        sb.Append(str);
                    }
                    result.Push(result.Pop() + sb.ToString());
                }
                else
                {
                    result.Push(result.Pop() + ch);
                }

                i += 1;
            }

            return result.Pop();
        }


        public static Boolean IsUniqueChars(String str)
        {
            if(String.IsNullOrEmpty(str))
            {
                return true;
            }
            char[] hash = new char[256];                             // Learning Tip - Hashing

            foreach (char ch in str)
            {
                if (hash[ch] == ch)
                {
                    return false;
                }
                hash[ch] = ch;

            }

            return true;
        }
        public static String RemoveChar(String str, char ch)
        {
            if (str == null || String.IsNullOrEmpty(str))
                return str;
            int nextpos = 0;
            int end = 0;
            int i = 0;
            char[] arr = str.ToCharArray();
            while( i < arr.Length )
            {
                nextpos = i;
                if (arr[i] == ch)
                {
                    int j = i + 1;
                    while (arr[j] != ch && j<arr.Length)
                    {
                        arr[nextpos] = arr[j];
                        nextpos = nextpos + 1;
                        j = j + 1;
                    }

                    i = j;
                }
                else
                {
                    
                    i++;
                }

            }

            arr[nextpos] = '\0';
            string temp=new String(arr,0,nextpos);
            Console.WriteLine(temp.Length);
            return temp;
        }
    }
}
