using System;
namespace PrintMatrixInSpiralOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Mat = new int[4, 4]{ {1,2,3,4},
                                     {5,6,7,8},
                                     {9,10,11,12},
                                     {13,14,15,16}
                                    };



            PrintMatrixInSpiralOrder(Mat, 4, 4);

            Console.ReadLine();

        }
        public static void PrintMatrixInSpiralOrder(int[,] Mat, int R, int C)
        {
            int i = 0;
            int row_start = 0;
            int col_start = 0;

            int row_end = R;

            int col_end = C;

            while (row_start < row_end && col_start < col_end)
            {

                for (i = col_start; i < col_end; i++)
                {
                    Console.WriteLine("{0} ", Mat[row_start, i]);
                }

                row_start++;

                for (i = row_start; i < row_end; i++)
                {
                    Console.WriteLine("{0} ", Mat[i, col_end - 1]);
                }

                col_end--;

                if (row_start < row_end)
                {
                    for (i = col_end - 1; i >= col_start; i--)
                    {
                        Console.WriteLine("{0} ", Mat[row_end - 1, i]);
                    }

                    row_end--;
                }

                if (col_start < col_end)
                {
                    for (i = row_end - 1; i >= row_start; i--)
                    {
                        Console.WriteLine("{0} ", Mat[i, col_start]);
                    }

                    col_start++;
                }

            }

        }
    }
}
