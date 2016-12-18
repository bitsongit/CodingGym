using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter9_1
{
    class Program
    {
        static int[] ways = new int[10];
      

        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                ways[i] = -1;
            }
            int count1 = CountWays(5);
            int count2 = GetNoOfWays(5);

        }

        public static int GetNoOfWays(int n)
        {
            if (n < 0) { return 0; }
            else if (n == 0) { return 1; }
            else if (ways[n] > -1)
            {
                return ways[n];
            }
            else
            {
                ways[n] = GetNoOfWays(n - 1) + GetNoOfWays(n - 2) + GetNoOfWays(n - 3);
                return ways[n];
            }
               
        }

        public static int CountWays(int n)
        {
            if (n < 0) return 0;
            else if (n == 0) return 1;
            else
                return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);
            
        }
    }
}
