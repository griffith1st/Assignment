using System;

namespace ShapeExample
{
    // 抽象基类：Shape
    public abstract class Shape
    {
        // 抽象方法：计算面积
        public abstract double GetArea();

        // 抽象属性：判断形状是否合法
        public abstract bool IsValid { get; }
    }

    // 长方形类
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("长方形的尺寸不合法。");
            }
            return Length * Width;
        }

        // 合法性：长和宽必须大于 0
        public override bool IsValid
        {
            get { return Length > 0 && Width > 0; }
        }

        public override string ToString()
        {
            return $"Rectangle(Length={Length:F2}, Width={Width:F2})";
        }
    }

    // 正方形类
    public class Square : Shape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("正方形的边长不合法。");
            }
            return Side * Side;
        }

        // 合法性：边长必须大于 0
        public override bool IsValid
        {
            get { return Side > 0; }
        }

        public override string ToString()
        {
            return $"Square(Side={Side:F2})";
        }
    }

    // 三角形类
    public class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("三角形的边长不满足构成三角形的条件。");
            }
            double s = (SideA + SideB + SideC) / 2.0;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        // 合法性：所有边长大于 0 且任意两边之和大于第三边
        public override bool IsValid
        {
            get
            {
                return SideA > 0 && SideB > 0 && SideC > 0 &&
                       (SideA + SideB > SideC) &&
                       (SideA + SideC > SideB) &&
                       (SideB + SideC > SideA);
            }
        }

        public override string ToString()
        {
            return $"Triangle(SideA={SideA:F2}, SideB={SideB:F2}, SideC={SideC:F2})";
        }
    }

    // 简单工厂类：用于随机创建形状对象
    public static class ShapeFactory
    {
        // 创建随机形状，传入 Random 对象以保证随机性
        public static Shape CreateRandomShape(Random rand)
        {
            // 0：长方形, 1：正方形, 2：三角形
            int shapeType = rand.Next(0, 3);
            switch (shapeType)
            {
                case 0: // 长方形
                    // 随机生成长和宽（范围 1~10）
                    double length = Math.Round(rand.NextDouble() * 9 + 1, 2);
                    double width = Math.Round(rand.NextDouble() * 9 + 1, 2);
                    return new Rectangle(length, width);
                case 1: // 正方形
                    double side = Math.Round(rand.NextDouble() * 9 + 1, 2);
                    return new Square(side);
                case 2: // 三角形
                    // 为了保证合法性，先随机生成两边，再生成第三边，使其满足三角形不等式
                    double sideA = Math.Round(rand.NextDouble() * 9 + 1, 2);
                    double sideB = Math.Round(rand.NextDouble() * 9 + 1, 2);
                    // 第三边的取值范围：(|sideA - sideB| + 0.1, sideA + sideB - 0.1)
                    double minSideC = Math.Abs(sideA - sideB) + 0.1;
                    double maxSideC = sideA + sideB - 0.1;
                    // 为防止浮点数误差，当maxSideC小于minSideC时直接取平均值
                    double sideC;
                    if (maxSideC <= minSideC)
                    {
                        sideC = minSideC;
                    }
                    else
                    {
                        sideC = Math.Round(rand.NextDouble() * (maxSideC - minSideC) + minSideC, 2);
                    }
                    return new Triangle(sideA, sideB, sideC);
                default:
                    throw new Exception("未知的形状类型");
            }
        }
    }

    // 测试程序入口
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double totalArea = 0;
            const int count = 10;

            Console.WriteLine("随机创建的形状如下：");
            for (int i = 0; i < count; i++)
            {
                Shape shape = ShapeFactory.CreateRandomShape(rand);
                // 输出形状信息
                Console.WriteLine($"{i + 1}. {shape}");
                // 如果形状合法，则累加面积
                if (shape.IsValid)
                {
                    totalArea += shape.GetArea();
                }
                else
                {
                    Console.WriteLine("  此形状不合法，无法计算面积。");
                }
            }

            Console.WriteLine($"\n所有形状的面积之和为: {totalArea:F2}");
            Console.ReadKey();
        }
    }
}
