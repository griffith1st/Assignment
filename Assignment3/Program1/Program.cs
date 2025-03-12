using System;

namespace ShapeExample
{
    // 抽象类：Shape
    public abstract class Shape
    {
        // 计算面积的抽象方法
        public abstract double GetArea();

        // 判断形状是否合法的抽象属性
        public abstract bool IsValid { get; }
    }

    // 长方形类
    public class Rectangle : Shape
    {
        // 长度属性
        public double Length { get; set; }
        // 宽度属性
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        // 重写计算面积的方法
        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("长方形的尺寸不合法。");
            }
            return Length * Width;
        }

        // 重写判断合法性的属性：长和宽必须大于 0
        public override bool IsValid
        {
            get { return Length > 0 && Width > 0; }
        }
    }

    // 正方形类
    public class Square : Shape
    {
        // 边长属性
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
    }

    // 三角形类
    public class Triangle : Shape
    {
        // 三边属性
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
            // 使用海伦公式计算面积
            double s = (SideA + SideB + SideC) / 2.0;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        // 合法性：所有边长大于 0，且任意两边之和大于第三边
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
    }

    // 测试程序入口
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 测试长方形
                Rectangle rect = new Rectangle(5, 10);
                Console.WriteLine($"长方形面积: {rect.GetArea()}");

                // 测试正方形
                Square square = new Square(4);
                Console.WriteLine($"正方形面积: {square.GetArea()}");

                // 测试三角形
                Triangle triangle = new Triangle(3, 4, 5);
                Console.WriteLine($"三角形面积: {triangle.GetArea()}");

                // 测试不合法的三角形
                Triangle invalidTriangle = new Triangle(1, 2, 3);
                Console.WriteLine($"三角形是否合法: {invalidTriangle.IsValid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }
    }
}
