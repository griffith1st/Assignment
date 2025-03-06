using System;
using System.Collections.Generic;

namespace SieveOfEratosthenesApp
{
    class Program
    {
        static void Main()
        {
            const int upperLimit = 100;
            List<int> primes = PrimeSieve.GeneratePrimes(upperLimit);
            ResultDisplay.ShowPrimes(upperLimit, primes);
        }
    }

    static class PrimeSieve
    {
        public static List<int> GeneratePrimes(int maxNumber)
        {
            // 初始化标记数组，索引对应数字，值表示是否为素数
            bool[] isPrime = new bool[maxNumber + 1];

            // 初始假定所有大于1的数都是素数
            InitializeArray(isPrime);

            // 筛法核心算法
            ExecuteSieve(isPrime);

            return CollectPrimes(isPrime);
        }

        private static void InitializeArray(bool[] isPrime)
        {
            for (int i = 2; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }
        }

        private static void ExecuteSieve(bool[] isPrime)
        {
            for (int p = 2; p * p < isPrime.Length; p++)
            {
                if (isPrime[p])
                {
                    MarkMultiples(isPrime, p);
                }
            }
        }

        private static void MarkMultiples(bool[] isPrime, int prime)
        {
            for (int multiple = prime * prime; multiple < isPrime.Length; multiple += prime)
            {
                isPrime[multiple] = false;
            }
        }

        private static List<int> CollectPrimes(bool[] isPrime)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }

    static class ResultDisplay
    {
        public static void ShowPrimes(int upperLimit, List<int> primes)
        {
            Console.WriteLine($"2~{upperLimit}范围内的素数（共{primes.Count}个）：");
            Console.WriteLine(string.Join(" ", primes));
        }
    }
}