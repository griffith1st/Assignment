using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("控制台计算器 (输入 q 退出)");

            while (true)
            {
                try
                {
                    // 输入第一个数字
                    Console.Write("\n请输入第一个数字：");
                    string input1 = Console.ReadLine()?.Trim();
                    if (input1?.ToLower() == "q") break;
                    if (!double.TryParse(input1, out double num1))
                    {
                        Console.WriteLine("错误：无效数字格式！");
                        continue;
                    }

                    // 输入运算符
                    Console.Write("请输入运算符 (+ - * /)：");
                    string op = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(op) || "+-*/".IndexOf(op) == -1)
                    {
                        Console.WriteLine("错误：无效运算符！");
                        continue;
                    }

                    // 输入第二个数字
                    Console.Write("请输入第二个数字：");
                    string input2 = Console.ReadLine()?.Trim();
                    if (!double.TryParse(input2, out double num2))
                    {
                        Console.WriteLine("错误：无效数字格式！");
                        continue;
                    }

                    // 计算并显示结果
                    double result = op switch
                    {
                        "+" => num1 + num2,
                        "-" => num1 - num2,
                        "*" => num1 * num2,
                        "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
                        _ => throw new InvalidOperationException()
                    };

                    Console.WriteLine($"计算结果：{result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("错误：除数不能为零！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }
        }
    }
}