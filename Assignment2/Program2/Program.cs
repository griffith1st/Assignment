using System;
using System.Linq;

namespace ArrayStatisticsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = DataInputHandler.GetValidArray();
            ArrayStatistics results = ArrayAnalyzer.CalculateStatistics(numbers);
            ResultDisplayer.ShowStatistics(results);
        }
    }

    static class DataInputHandler
    {
        public static int[] GetValidArray()
        {
            while (true)
            {
                Console.Write("请输入整数数组（用空格分隔）：");
                string input = Console.ReadLine();

                if (TryParseArray(input, out int[] array))
                {
                    return array;
                }

                Console.WriteLine("输入无效，请确保输入的是整数且至少包含一个元素");
            }
        }

        private static bool TryParseArray(string input, out int[] result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string[] segments = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] tempArray = new int[segments.Length];

            for (int i = 0; i < segments.Length; i++)
            {
                if (!int.TryParse(segments[i], out tempArray[i]))
                {
                    return false;
                }
            }

            result = tempArray;
            return true;
        }
    }

    class ArrayStatistics
    {
        public int Maximum { get; set; }
        public int Minimum { get; set; }
        public double Average { get; set; }
        public long Sum { get; set; }
    }

    static class ArrayAnalyzer
    {
        public static ArrayStatistics CalculateStatistics(int[] numbers)
        {
            ValidateArray(numbers);

            return new ArrayStatistics
            {
                Maximum = numbers.Max(),
                Minimum = numbers.Min(),
                Sum = numbers.Sum(),
                Average = numbers.Average()
            };
        }

        private static void ValidateArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("数组不能为空");
            }
        }
    }

    static class ResultDisplayer
    {
        public static void ShowStatistics(ArrayStatistics stats)
        {
            Console.WriteLine("统计结果：");
            Console.WriteLine($"最大值：{stats.Maximum}");
            Console.WriteLine($"最小值：{stats.Minimum}");
            Console.WriteLine($"总和：{stats.Sum}");
            Console.WriteLine($"平均值：{stats.Average:F2}");
        }
    }
}