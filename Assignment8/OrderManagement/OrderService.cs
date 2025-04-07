using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement
{
    public class OrderService
    {
        // 不再使用内存 List，而使用 EF 的 DbContext
        private OrderContext context;

        // 构造函数中初始化 EF 上下文
        public OrderService()
        {
            // 这里可以直接使用 OnConfiguring 中的连接字符串配置
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            // 连接字符串同 OrderContext 中设置的保持一致
            string connectionString = "server=localhost;port=3306;database=OrderDB;user=root;password=951753;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            context = new OrderContext(optionsBuilder.Options);

            // 如需初始化数据库（自动迁移或创建），可调用 EnsureCreated
            context.Database.EnsureCreated();
        }

        // 添加订单
        public void AddOrder(Order order)
        {
            // 检查是否已存在该订单号
            if (context.Orders.Any(o => o.OrderNumber == order.OrderNumber))
                throw new ApplicationException($"订单号 {order.OrderNumber} 已存在！");

            context.Orders.Add(order);
            context.SaveChanges();
        }

        // 删除订单
        public void RemoveOrder(int orderNumber)
        {
            Order order = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order == null)
                throw new ApplicationException($"订单号 {orderNumber} 不存在，无法删除！");

            context.Orders.Remove(order);
            context.SaveChanges();
        }

        // 修改订单（先查找到原订单，再更新）
        public void UpdateOrder(Order updatedOrder)
        {
            Order order = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.OrderNumber == updatedOrder.OrderNumber);
            if (order == null)
                throw new ApplicationException($"订单号 {updatedOrder.OrderNumber} 不存在，无法修改！");

            // 修改客户（EF 会自动跟踪实体）
            order.Customer = updatedOrder.Customer;

            // 清空原有明细，添加新明细（注意级联删除）
            context.OrderDetails.RemoveRange(order.Details);
            order.Details.Clear();
            foreach (var detail in updatedOrder.Details)
            {
                order.Details.Add(detail);
            }
            context.SaveChanges();
        }

        // 按订单号查询
        public List<Order> QueryByOrderNumber(int orderNumber)
        {
            var query = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .Where(o => o.OrderNumber == orderNumber)
                .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 按商品名称查询
        public List<Order> QueryByProductName(string productName)
        {
            var query = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .Where(o => o.Details.Any(d => d.Product.Name == productName))
                .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 按客户名称查询
        public List<Order> QueryByCustomer(string customerName)
        {
            var query = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .Where(o => o.Customer.Name == customerName)
                .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 按订单总金额查询
        public List<Order> QueryByTotalAmount(double amount)
        {
            var query = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .Where(o => o.TotalAmount >= amount)
                .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 默认排序（订单号排序）和自定义排序可以由查询结果在内存中排序后返回
        public List<Order> GetAllOrders()
        {
            return context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .OrderBy(o => o.OrderNumber)
                .ToList();
        }
        public List<Order> SortOrders()
        {
            return context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .OrderBy(o => o.OrderNumber)
                .ToList();
        }
        public List<Order> SortOrders(Comparison<Order> comparison)
        {
            var orders = context.Orders
                .Include(o => o.Details)
                .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .ToList();
            orders.Sort(comparison);
            return orders;
        }


    }
}
