using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean result = Compare("ab", "ab");
            result = Compare("ab", "*ab");
            result = Compare("aaab", "aa*b");
            result = Compare("aaab", "aa?b");
            result = Compare("aab", "ab");
            result = Compare("aab", "a??b");
            result = Compare("aab", "??b");
        }


        public static Boolean Compare(String str, String pattern)
        {
            if (str == null && pattern != null)
            {
                return false;
            }
            if (str != null && pattern == null)
            {
                return true;
            }


            return CompareRecurse(str, 0, pattern, 0);
        }

        private static Boolean CompareRecurse(String str, int str_start, String pattern, int pat_start)
        {

            // Base Case : When the pattern string is over
            if (pat_start == pattern.Length)
                return true;

            // Base Case : When the main searched string is over
            if (str_start == str.Length)
            {
                if (pattern[pat_start] == '*' && pat_start == pattern.Length - 1)
                  return false;
                return true;
            }
            
                               
            if (pattern[pat_start] == '?')
            {
                return CompareRecurse(str, str_start + 1, pattern, pat_start + 1);
            }

            else if (pattern[pat_start] == '*')
            {
                
               return CompareStar(str, pattern, pat_start+1);
            }
            else if (str[str_start] == pattern[pat_start])
            {

                return CompareRecurse(str, str_start + 1, pattern, pat_start + 1);

            }

            //Is my main string complete return true - else false

            return (str_start == str.Length);
            
       }

        private static bool CompareStar(string str, string pattern, int pat_start)
        {
            int i = 0;
            do
            {
                if (CompareRecurse(str, i, pattern, pat_start)) return true;
                i++;
            } while (i <= str.Length);

            return false;
        }

       


    }
}
