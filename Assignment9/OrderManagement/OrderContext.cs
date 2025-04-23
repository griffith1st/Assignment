using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement
{
    // 定义 EF 的 DbContext 类
    public class OrderContext : DbContext
    {

        // DbSet 属性：每个集合对应数据库中的一张表
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        // 通过构造函数传入 DbContextOptions
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        // 使用 Fluent API 进行实体关系配置
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置主键（如果未用属性标注）
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderNumber);
            // 订单明细中组合主键：这里简单使用 OrderDetails 的自增ID 或者指定 Order 与 Product 的组合作为唯一标识
            // 为了方便，下面添加一个主键属性
            modelBuilder.Entity<OrderDetails>().HasKey(od => od.OrderDetailsId);

            // 配置一对多关系：Order 包含多个 OrderDetails
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        // 如果不使用依赖注入，可重写 OnConfiguring 设置连接字符串
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "server=localhost;port=3306;database=OrderDB;user=root;password=951753;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
