using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter String : ");
                char[] str = new char[100];
                str[0] = 'h';
                str[1] = ' ';
                str[2] = 's';

                Console.WriteLine("URL will be : {0}", ReplaceSpaces(str,3));
            }
        }

        public static String ReplaceSpaces(char[] str, int trueLength)
        {
            if (str!=null)
            {
                int spaceCount = 0;
                int newLength = 0, i = 0;

                for (i = 0; i < trueLength; i++)
                {
                    if (str[i] == ' ') spaceCount++;
                }

                newLength = trueLength + spaceCount * 2;
                str[newLength] = '\0';

                for (int j = trueLength-1; j >=0; j--)
                {
                    if (str[j] == ' ')
                    {
                        str[newLength - 1] = '0';
                        str[newLength - 2] = '2';
                        str[newLength - 3] = '%';
                        newLength = newLength - 3;
                    }
                    else
                    {
                        str[newLength - 1] = str[i];
                        newLength = newLength - 1;

                    }
                }

            }
            return new String(str);
        }
    }
}
