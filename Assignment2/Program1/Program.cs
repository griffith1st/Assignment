using System;
using System.Collections.Generic;
using System.Linq;

namespace UniquePrimeFactorApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = UserInputHandler.GetValidNumber();
            List<int> uniquePrimeFactors = PrimeFactorCalculator.GetUniquePrimeFactors(number);
            ResultPresenter.DisplayFactors(number, uniquePrimeFactors);
        }
    }

    static class UserInputHandler
    {
        public static int GetValidNumber()
        {
            while (true)
            {
                Console.Write("请输入一个大于1的正整数：");
                if (int.TryParse(Console.ReadLine(), out int number) && number > 1)
                {
                    return number;
                }
                Console.WriteLine("输入无效，请输入大于1的正整数。");
            }
        }
    }

    static class PrimeFactorCalculator
    {
        public static List<int> GetUniquePrimeFactors(int targetNumber)
        {
            HashSet<int> uniqueFactors = new HashSet<int>();
            int remaining = targetNumber;

            // 处理偶数因子
            if (remaining % 2 == 0)
            {
                uniqueFactors.Add(2);
                remaining = RemoveAllFactors(remaining, 2);
            }

            // 处理奇数因子
            for (int factor = 3; factor <= Math.Sqrt(remaining); factor += 2)
            {
                if (remaining % factor == 0)
                {
                    uniqueFactors.Add(factor);
                    remaining = RemoveAllFactors(remaining, factor);
                }
            }

            // 处理剩余的大素数
            if (remaining > 1)
            {
                uniqueFactors.Add(remaining);
            }

            return uniqueFactors.OrderBy(n => n).ToList();
        }

        private static int RemoveAllFactors(int number, int factor)
        {
            while (number % factor == 0)
            {
                number /= factor;
            }
            return number;
        }
    }

    static class ResultPresenter
    {
        public static void DisplayFactors(int originalNumber, List<int> factors)
        {
            Console.WriteLine($"数字 {originalNumber} 的唯一素数因子为：");
            Console.WriteLine(string.Join(" ", factors));
        }
    }
}