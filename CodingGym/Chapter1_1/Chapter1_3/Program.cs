using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter 2 Strings : ");
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();


                Console.WriteLine("Given Strings are Permutations of each other: {0}", HashIt(str1,str2));
            }
        }



        public static Boolean HashIt(String str1, String str2)
        {
            int[] hashCount1 = new int[256];
            int[] hashCount2 = new int[256];  //Assumption - the size of the character set is ASCII: 256 but always ask to interviewer Unicode/ASCII
            
            if (!String.IsNullOrEmpty(str1) && !String.IsNullOrEmpty(str2))
            {
                if (str1.Length != str2.Length) return false; //Optimization
                
                foreach (char ch in str1)
                {
                    hashCount1[ch] = hashCount1[ch] + 1;

                }

                foreach (char ch in str2)
                {
                    hashCount2[ch] = hashCount2[ch] + 1;

                }

                for (int i = 0; i < hashCount1.Length; i++)
                {
                    if (hashCount1[i] != hashCount2[i])
                    {
                        return false;
                    }
                }
                
                return true;
            }

            return false;
        }
    }
}
