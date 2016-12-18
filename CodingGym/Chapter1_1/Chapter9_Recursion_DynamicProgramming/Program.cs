using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Chapter9_Recursion_DynamicProgramming
{
    class Program
    {
        static int[] map = new int[10];
        static void Main(string[] args)
        {
            //#region 9.1
            //int count2 = CountWaysTopDown(5);
            
            //for (int i = 0; i < 10; i++)
            //{
            //    map[i] = -1;
            //}
            //int count3 = CountWaysDP(5, map);
            //#endregion

           // #region 9.2
           // List<Point> path = new List<Point>();
           // Boolean isPath = GetPath(4, 4, path);

           // if (isPath)
           // {
           //     foreach (Point p in path)
           //         Console.Write(" - {0,1}", p.x, p.y);
           // }
           //#endregion

            //#region 9.5
            //String s = "abc";
            //List<String> perms = GetPermutations(s);
            //foreach (String str in perms)
            //    Console.WriteLine(str);
            //#endregion

            //#region 9.6
            //foreach (String s in GenerateParens(3))
            //{
            //    Console.WriteLine(s);
            //}
            //#endregion

            //#region 9.9
            //List<int[]> results = new List<int[]>();
            //int[] columns = new int[GRID_SIZE];
            
            //PlaceQueens(0, columns,results);
            //Console.WriteLine(" {0}", results.Count);
            //Console.Read();
            //foreach(int[] s in results)
            //{
            //    for (int i = 0; i < s.Length; i++)
            //        Console.Write(" {0}", s[i]);
            //    Console.WriteLine();
            //}
            //#endregion


            Console.Read();

        }

        #region Staircase N Problem question 9.1
        public static int CountWaysTopDown(int n)
        {
            if (n < 0) return 0;
            else if (n == 0) return 1;
            else
                return CountWaysTopDown(n - 1) + CountWaysTopDown(n - 2) + CountWaysTopDown(n - 3);

        }
        public static int CountWaysDP(int n, int[] map)
        {
            if (n < 0) { return 0; }
            else if (n == 0) { return 1; }
            else if (map[n] > -1)
            {
                return map[n];
            }
            else
            {
                map[n] = CountWaysDP(n - 1, map) + CountWaysDP(n - 2, map) + CountWaysDP(n - 3, map);
                return map[n];
            }

        }
        #endregion

        #region question 9.2 Robot
        public class Point
        {
            public int x, y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public static Boolean IsFree(int x, int y)
            {
                return (new Random().Next(0, 2))==0?false:true;
            }
        }

        public static Boolean GetPath(int x, int y, List<Point> path)
        {
            Point p = new Point(x, y);
            path.Add(p);
            if (x == 0 && y == 0)
            {
                return true;
            }
            Boolean success = false;
            if(x>=1 && Point.IsFree(x-1,y))
            {
                success = GetPath(x - 1, y,path);
            }
            if (!success && y >= 1 && Point.IsFree(x, y - 1))
            {
                success = GetPath(x, y - 1, path);
            }

            if (!success)
                path.Remove(p);
            return success;
            
            
        }
        public static Boolean GetPathDP(int x, int y, List<Point> path, Dictionary<Point, Boolean> cache)
        {
            Point p = new Point(x, y);
            if(cache.ContainsKey(p))
            {
                Boolean visited=false;
                return cache.TryGetValue(p,out visited);
            }
            path.Add(p);
            if (x == 0 && y == 0)
            {
                return true;
            }
            Boolean success = false;
            if (x >= 1 && Point.IsFree(x - 1, y))
            {
                success = GetPathDP(x - 1, y, path,cache);
            }
            if (!success && y >= 1 && Point.IsFree(x, y - 1))
            {
                success = GetPathDP(x, y - 1, path,cache);
            }

            if (!success)
                path.Remove(p);

            cache.Add(p, true); // Cache result
            return success;


        }

        #endregion

        #region question 9.3 Magic Index
        
        // No duplicates
        public static int GetMagicIndex(int[] arr, int lo, int hi)
        {
            if (hi < lo || lo < 0 || hi>=arr.Length)
                return -1;
            int mid = lo + (hi - lo) / 2;
            if (mid == arr[mid])
            {
                return mid;
            }
            else if (mid > arr[mid])
            {
                return GetMagicIndex(arr, mid+1, hi);
            }
            else 
            {
                return GetMagicIndex(arr, lo, mid-1);
            }
            
        }
        // With duplicates
        public static int GetMagicIndexDup(int[] arr, int lo, int hi)
        {
            if (hi < lo || lo < 0 || hi >= arr.Length)
                return -1;
            int midIndex = lo + (hi - lo) / 2;
            int midValue = arr[midIndex];
            if (midIndex == midValue)
            {
                return midIndex;
            }

            // Search Left
            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = GetMagicIndexDup(arr, lo, leftIndex);
            if (left>=0)
            {
                return left;
            }
            // Search Right
            int rightIndex = Math.Max(midIndex + 1, midValue);
            int right = GetMagicIndexDup(arr, rightIndex, hi);
            
            return right;
            

        }
        #endregion

        #region question 9.4 All subsets of a set
        public static List<List<int>> GetSubSets(List<int> set)
        {
            List<List<int>> allSubsets = new List<List<int>>();
            int max = 1 << set.Count; // Compute 2^n

            for (int i = 0; i < max; i++)
            {
                List<int> subset = ConvertToSet(i, set);
                allSubsets.Add(subset);
            }
            return allSubsets;
        }
        private static List<int> ConvertToSet(int x, List<int> set)
        {
            List<int> subset = new List<int>();
            int index = 0; // Must Remember this

            for (int k = x; k > 0; k >>= 1)
            {
                if ((k & 1) == 1)
                {
                    subset.Add(set[index]);
                }
                index++;
            }
            return subset;
        }
        #endregion

        #region question 9.5 Permutations of a string
        public static List<String> GetPermutations(String str)
        {
            if (str == null)
            {
                return null;
            }
            List<String> permutations = new List<string>();
            if (str.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }
            char first = str[0]; //Get the first character
            String remaining = str.Substring(1);
            List<String> remainPerms = GetPermutations(remaining);

            foreach (String word in remainPerms)
            {
                for (int i = 0; i <= word.Length; i++)
                {
                    String s = word.Insert(i, first.ToString());
                    permutations.Add(s);
                }
            }
            return permutations;

        }
        #endregion

        #region question 9.6 All valid pairs of parenthesis
        public static List<String> GenerateParens(int N)
        {
            if (N < 0) return (new List<string>()); //return empty list
            char[] str = new char[2 * N];
            List<String> list = new List<string>();

            addParen(list, N, N, str, 0);
            return list;

        }
        private static void addParen(List<String> list, int leftRem, int rightRem, char[] str, int index)
        {
            if (leftRem < 0 || rightRem < leftRem) return;
            if (leftRem == 0 && rightRem == 0)
            {
                list.Add(new String(str));
            }
            else
            {
                if (leftRem > 0)
                {
                    str[index] = '(';
                    addParen(list, leftRem - 1, rightRem, str, index + 1);
                }
                if (rightRem > leftRem)
                {
                    str[index] = ')';
                    addParen(list, leftRem, rightRem-1, str, index + 1);
                }
            }

        }
        #endregion

        #region question 9.7 "Paint Fill" function
        public enum Color
        {
            Black,White,Red,Yellow,Green
        }
        private static Boolean paintFill(Color[,] screen , int x, int y,Color ocolor,Color ncolor)
        {
            if(x<0 || x >= screen.GetLength(1) || y<0 || y>= screen.GetLength(0))
            {
                return false;
            }
            if(screen[y,x]== ocolor)
            {
                paintFill(screen, x - 1, y, ocolor, ncolor);
                paintFill(screen, x +1, y, ocolor, ncolor);
                paintFill(screen, x , y-1, ocolor, ncolor);
                paintFill(screen, x , y+1, ocolor, ncolor);
            }
            return true;
        }
        public static Boolean paintFill(Color[,] screen, int x, int y, Color ncolor)
        {
            return paintFill(screen, x, y, screen[y, x], ncolor);
        }
        #endregion

        #region question 9.8 No of ways representing N cents
        public static int MakeChange(int n, int denom)
        {
            int next_denom = 0;

            switch (denom)
            {
                case 25:
                    next_denom = 10;
                    break;
                case 10:
                    next_denom = 5;
                    break;
                case 5:
                    next_denom = 1;
                    break;
                case 1:
                    return 1;
            }

            int ways = 0;
            for (int i = 0; i * denom <= n; i++)
            {
                ways = ways + MakeChange(n - i * denom, next_denom);
            }
            return ways;
        }
        #endregion

        #region question 9.9 Eight Queens on chess board
        public static int GRID_SIZE = 8;
        public static void PlaceQueens(int row, int[] columns, List<int[]>results)
        {
            if (row == GRID_SIZE)
            {
                results.Add(columns);
            }
            else
            {
                for(int col=0;col<GRID_SIZE;col++)
                {
                    if(CheckValid(columns,row,col))
                    {
                        columns[row] = col;
                        PlaceQueens(row + 1, columns, results);
                    }
                }
            }
        }
        private static Boolean CheckValid(int[] columns,int row1, int col1)
        {
            for(int row2=0;row2<row1;row2++)
            {
                int column2=columns[row2];

                // Check Columns first
                if(col1==column2)
                {
                    return false;
                }
                //Now Check Diagonals
                int colDistance = Math.Abs(column2 - col1);
                int rowDistance = row1 - row2;
                if (rowDistance == colDistance)
                {
                    return false;
                }
             }
            return true;

        }
        #endregion

        #region question 9.10 Stack of N boxes
        public class Box
        {
            public int length,width,height;
            public Box(int length, int width, int height)
            {
                this.length = length;
                this.width = width;
                this.height=height;
            }
            public Boolean CanBeAbove(Box box)
            {
                if (length < box.length && width < box.width && height < box.height)
                    return true;
                return false;
            }

        }
        private int StackHeight(List<Box> stack)
        {
            int height = 0;
            foreach (Box b in stack)
                height = height + b.height;
            return height;
        }
        public List<Box> CreateStackR(Box[] boxes, Box bottom)
        {
            int max_height = 0;
            List<Box> max_stack = null;

            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].CanBeAbove(bottom))
                {
                    List<Box> new_stack = CreateStackR(boxes, boxes[i]);
                    int new_height = StackHeight(new_stack);
                    if (new_height > max_height)
                    {
                        max_stack = new_stack;
                        max_height = new_height;
                    }
                }
            }
            if (max_stack == null)
            {
                max_stack = new List<Box>();
            }
            if (bottom != null)
            {
                max_stack.Add(bottom);
            }
            return max_stack;

        }
        public List<Box> CreateStackDP(Box[] boxes, Box bottom, Dictionary<Box,List<Box>> stack_map)
        {
            if (bottom != null && stack_map.ContainsKey(bottom))
            {
                List<Box> value;
                stack_map.TryGetValue(bottom, out value);
                return value;
            }
            
            int max_height = 0;
            List<Box> max_stack = null;

            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].CanBeAbove(bottom))
                {
                    List<Box> new_stack = CreateStackDP(boxes, boxes[i],stack_map);
                    int new_height = StackHeight(new_stack);
                    if (new_height > max_height)
                    {
                        max_stack = new_stack;
                        max_height = new_height;
                    }
                }
            }
            if (max_stack == null)
            {
                max_stack = new List<Box>();
            }
            if (bottom != null)
            {
                max_stack.Add(bottom);
            }
            stack_map.Add(bottom, max_stack);
            return max_stack;

        }
        #endregion
    }
}
