using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    // 客户类
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj is Customer other)
                return Id == other.Id && Name == other.Name;
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"客户[{Id}]: {Name}";
        }
    }

    // 货物（商品）类
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public override bool Equals(object obj)
        {
            if (obj is Product other)
                return Id == other.Id && Name == other.Name && Price == other.Price;
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode() ^ Price.GetHashCode();
        }
        public override string ToString()
        {
            return $"商品[{Id}]: {Name} 价格: {Price}";
        }
    }

    // 订单明细类
    public class OrderDetails
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderDetails(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public double Amount => Product.Price * Quantity;

        public override bool Equals(object obj)
        {
            if (obj is OrderDetails other)
                return Product.Equals(other.Product);
            return false;
        }
        public override int GetHashCode()
        {
            return Product.GetHashCode();
        }
        public override string ToString()
        {
            return $"[订单明细] {Product} 数量: {Quantity} 合计: {Amount}";
        }
    }

    // 订单类
    public class Order
    {
        public int OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public Order(int orderNumber, Customer customer)
        {
            OrderNumber = orderNumber;
            Customer = customer;
        }

        // 计算订单总金额
        public double TotalAmount => Details.Sum(d => d.Amount);

        public override bool Equals(object obj)
        {
            if (obj is Order other)
                return OrderNumber == other.OrderNumber;
            return false;
        }
        public override int GetHashCode()
        {
            return OrderNumber.GetHashCode();
        }
        public override string ToString()
        {
            string detailsStr = string.Join("\n\t", Details.Select(d => d.ToString()));
            return $"订单号: {OrderNumber}\n客户: {Customer}\n订单总金额: {TotalAmount}\n订单明细:\n\t{detailsStr}";
        }
    }

    // 订单服务类
    public class OrderService
    {
        // 保存所有订单的列表
        private List<Order> orders = new List<Order>();

        // 添加订单，要求订单不重复
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
                throw new ApplicationException($"订单号 {order.OrderNumber} 已存在！");
            orders.Add(order);
        }

        // 删除订单
        public void RemoveOrder(int orderNumber)
        {
            Order order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order == null)
                throw new ApplicationException($"订单号 {orderNumber} 不存在，无法删除！");
            orders.Remove(order);
        }

        // 修改订单（这里简单实现为先删除再添加的方式，订单号不允许更改）
        public void UpdateOrder(Order updatedOrder)
        {
            Order order = orders.FirstOrDefault(o => o.OrderNumber == updatedOrder.OrderNumber);
            if (order == null)
                throw new ApplicationException($"订单号 {updatedOrder.OrderNumber} 不存在，无法修改！");
            // 修改客户和订单明细（订单号保持不变）
            order.Customer = updatedOrder.Customer;
            order.Details = updatedOrder.Details;
        }

        // 查询订单：按订单号查询
        public List<Order> QueryByOrderNumber(int orderNumber)
        {
            var query = orders.Where(o => o.OrderNumber == orderNumber)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 查询订单：按商品名称查询（在订单明细中查询）
        public List<Order> QueryByProductName(string productName)
        {
            var query = orders.Where(o => o.Details.Any(d => d.Product.Name == productName))
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 查询订单：按客户名称查询
        public List<Order> QueryByCustomer(string customerName)
        {
            var query = orders.Where(o => o.Customer.Name == customerName)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 查询订单：按订单总金额（大于等于某个金额）查询
        public List<Order> QueryByTotalAmount(double amount)
        {
            var query = orders.Where(o => o.TotalAmount >= amount)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 默认排序：按照订单号排序
        public void SortOrders()
        {
            orders.Sort((o1, o2) => o1.OrderNumber.CompareTo(o2.OrderNumber));
        }

        // 使用 Lambda 表达式进行自定义排序
        public void SortOrders(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }

        // 获取所有订单
        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 测试用例
            try
            {
                OrderService orderService = new OrderService();

                // 创建客户
                Customer customer1 = new Customer(1, "张三");
                Customer customer2 = new Customer(2, "李四");

                // 创建产品
                Product product1 = new Product(1, "电脑", 5000);
                Product product2 = new Product(2, "手机", 3000);
                Product product3 = new Product(3, "平板", 2000);

                // 创建订单1
                Order order1 = new Order(1001, customer1);
                order1.Details.Add(new OrderDetails(product1, 1));
                order1.Details.Add(new OrderDetails(product2, 2));

                // 创建订单2
                Order order2 = new Order(1002, customer2);
                order2.Details.Add(new OrderDetails(product3, 3));
                order2.Details.Add(new OrderDetails(product2, 1));

                // 创建订单3
                Order order3 = new Order(1003, customer1);
                order3.Details.Add(new OrderDetails(product1, 2));

                // 添加订单
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);
                Console.WriteLine("添加订单成功！");

                // 测试重复添加（应抛异常）
                try
                {
                    orderService.AddOrder(order1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("添加重复订单时捕获异常：" + ex.Message);
                }

                // 查询订单：按照订单号查询
                Console.WriteLine("\n按订单号查询（1002）：");
                var query1 = orderService.QueryByOrderNumber(1002);
                query1.ForEach(o => Console.WriteLine(o));

                // 查询订单：按照商品名称查询
                Console.WriteLine("\n按商品名称查询（手机）：");
                var query2 = orderService.QueryByProductName("手机");
                query2.ForEach(o => Console.WriteLine(o));

                // 查询订单：按照客户名称查询
                Console.WriteLine("\n按客户名称查询（张三）：");
                var query3 = orderService.QueryByCustomer("张三");
                query3.ForEach(o => Console.WriteLine(o));

                // 查询订单：按照订单总金额查询
                Console.WriteLine("\n按订单总金额查询（>=10000）：");
                var query4 = orderService.QueryByTotalAmount(10000);
                query4.ForEach(o => Console.WriteLine(o));

                // 修改订单测试：修改订单1003的客户为李四，并修改订单明细
                Order updatedOrder = new Order(1003, customer2);
                updatedOrder.Details.Add(new OrderDetails(product3, 5));  // 新的订单明细
                orderService.UpdateOrder(updatedOrder);
                Console.WriteLine("\n修改订单1003成功！");
                Console.WriteLine(orderService.QueryByOrderNumber(1003)[0]);

                // 删除订单测试：删除订单1002
                orderService.RemoveOrder(1002);
                Console.WriteLine("\n删除订单1002成功！");

                // 尝试删除一个不存在的订单，捕获异常
                try
                {
                    orderService.RemoveOrder(9999);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("删除不存在订单时捕获异常：" + ex.Message);
                }

                // 默认排序：按照订单号排序
                Console.WriteLine("\n默认排序（订单号排序）：");
                orderService.SortOrders();
                orderService.GetAllOrders().ForEach(o => Console.WriteLine(o));

                // 自定义排序：按照订单总金额降序排序
                Console.WriteLine("\n自定义排序（订单总金额降序排序）：");
                orderService.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
                orderService.GetAllOrders().ForEach(o => Console.WriteLine(o));
            }
            catch (Exception ex)
            {
                Console.WriteLine("程序运行中出现异常：" + ex.Message);
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }
    }
}
