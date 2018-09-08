using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRectangle
{
    class LargMat
    {
         static void Main(string[] args)
        {
            int[,] one =
           {
                {0, 1, 1, 1, 0},
                {0, 1, 1, 1, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0}
            };
            LargestRectangle(one);
            Console.ReadKey();
        }
        static void LargestRectangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxArea = -1, tempArea = -1;
            int a1 = 0, b1 = 0, a2 = 0, b2 = 0;
            int[] d = new int[m];
            for (int i = 0; i < m; i++)
            {
                d[i] = -1;
            }
            int[] d1 = new int[m];
            int[] d2 = new int[m];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
               
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        d[j] = i;
                    }
                }

                stack.Clear();
                for (int j = 0; j < m; j++)
                {
                    while (stack.Count > 0 && d[stack.Peek()] <= d[j])
                    {
                        stack.Pop();
                    }

                   
                    d1[j] = (stack.Count == 0) ? -1 : stack.Peek();

                    stack.Push(j);
                }

                stack.Clear();
                
                for (int j = m - 1; j >= 0; j--)
                {
                    while (stack.Count > 0 && d[stack.Peek()] <= d[j])
                    {
                        stack.Pop();
                    }

                    d2[j] = (stack.Count == 0) ? m : stack.Peek();

                    stack.Push(j);
                }
                for (int j = 0; j < m; j++)
                {
                   
                    tempArea = (i - d[j]) * (d2[j] - d1[j] - 1);

                    if (tempArea > maxArea)
                    {
                        maxArea = tempArea;

                       
                        a1 = d1[j] + 1;
                        b1 = d[j] + 1;

                       
                        a2 = d2[j] - 1;
                        b2 = i;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(maxArea);
            Console.WriteLine(String.Format("({0}, {1}) to ({2}, {3})", a1, b1, a2, b2));

            Console.WriteLine();
            Console.WriteLine("Original");

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    Console.Write(String.Format("{0} ", matrix[y, x]));
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Maximum submatrix");

            for (int b = 0; b < n; b++)
            {
                for (int a = 0; a < m; a++)
                {
                    if (a >= a1 && a <= a2 && b >= b1 && b <= b2)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(String.Format("{0} ", matrix[b, a]));
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
