using System;
using System.Collections.Generic;

namespace ToeplitzMatrixChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("托普利茨矩阵验证程序");

            while (true)
            {
                try
                {
                    int[][] matrix = MatrixInputHandler.GetMatrixFromUser();
                    MatrixVisualizer.DisplayMatrix(matrix);

                    bool isToeplitz = ToeplitzVerifier.IsToeplitzMatrix(matrix);
                    Console.ForegroundColor = isToeplitz ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine($"\n该矩阵{(isToeplitz ? "是" : "不是")}托普利茨矩阵");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"错误：{ex.Message}");
                    Console.ResetColor();
                }

                if (!ContinuePrompt.ShouldContinue())
                {
                    Console.WriteLine("\n感谢使用，再见！");
                    break;
                }
            }
        }
    }

    static class MatrixInputHandler
    {
        public static int[][] GetMatrixFromUser()
        {
            Console.WriteLine("\n请输入矩阵（示例格式：1 2 3 ; 4 5 6 ; 7 8 9）：");

            while (true)
            {
                string input = Console.ReadLine().Trim();
                string[] rows = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (rows.Length == 0)
                {
                    throw new ArgumentException("输入不能为空");
                }

                List<int[]> matrix = new List<int[]>();
                int columns = -1;

                foreach (string row in rows)
                {
                    string[] elements = row.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (elements.Length == 0)
                    {
                        throw new ArgumentException("存在空行");
                    }

                    if (columns == -1)
                    {
                        columns = elements.Length;
                    }
                    else if (elements.Length != columns)
                    {
                        throw new ArgumentException("所有行的列数必须相同");
                    }

                    int[] intRow = new int[elements.Length];
                    for (int i = 0; i < elements.Length; i++)
                    {
                        if (!int.TryParse(elements[i], out int num))
                        {
                            throw new ArgumentException($"无效数字：{elements[i]}");
                        }
                        intRow[i] = num;
                    }
                    matrix.Add(intRow);
                }

                return matrix.ToArray();
            }
        }
    }

    static class ToeplitzVerifier
    {
        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return true;

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    static class MatrixVisualizer
    {
        public static void DisplayMatrix(int[][] matrix)
        {
            Console.WriteLine("\n当前矩阵：");
            foreach (var row in matrix)
            {
                Console.Write("[ ");
                Console.Write(string.Join(", ", row));
                Console.WriteLine(" ]");
            }
        }
    }

    static class ContinuePrompt
    {
        public static bool ShouldContinue()
        {
            Console.Write("\n是否继续验证其他矩阵？(y/n): ");
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y) return true;
                if (key == ConsoleKey.N) return false;
                Console.Write("\n无效输入，请按 Y 继续或 N 退出: ");
            }
        }
    }
}