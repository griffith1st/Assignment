using System;

namespace GenericLinkedListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个整型的泛型链表
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(10);
            list.Add(5);
            list.Add(20);
            list.Add(1);

            // 1. 打印链表所有元素
            Console.WriteLine("链表元素：");
            list.ForEach(x => Console.WriteLine(x));

            // 2. 求最大值
            int max = int.MinValue;
            list.ForEach(x => { if (x > max) max = x; });
            Console.WriteLine($"最大值：{max}");

            // 3. 求最小值
            int min = int.MaxValue;
            list.ForEach(x => { if (x < min) min = x; });
            Console.WriteLine($"最小值：{min}");

            // 4. 求和
            int sum = 0;
            list.ForEach(x => sum += x);
            Console.WriteLine($"总和：{sum}");

            Console.ReadLine();
        }
    }


    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class MyLinkedList<T>
    {
        private Node<T> head;   // 头节点
        private Node<T> tail;   // 尾节点
        private int count;      // 元素个数

 
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

  
        public int Count
        {
            get { return count; }
        }

        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
    }
}
