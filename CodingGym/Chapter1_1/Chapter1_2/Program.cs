using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter String : ");
                string str = Console.ReadLine();

                Console.Write("Reverse of the Given String is:{0} ", Reverse(str));
                
                Console.WriteLine();
            }
        }

        public static String Reverse(String str)
        {
            if (String.IsNullOrEmpty(str)) return null;
            char[] array = str.ToCharArray();

            int start = 0;
            int end = array.Length - 1;
            
            for (; start < end; start++, end--)
            {
                char temp = array[end];
                array[end] = array[start];
                array[start] = temp;
                
            }

            return new String(array);
        }
    }
}
