using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OrderManagement;

var builder = WebApplication.CreateBuilder(args);

// 1. 读取连接字符串
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. 注册 DbContext（Scoped）和 OrderService
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr))  // 自动检测服务器版本&#8203;:contentReference[oaicite:1]{index=1}
);
builder.Services.AddScoped<OrderService>();

// 3. 添加 Controllers 与 Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 中间件
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

namespace OrderManagementWinForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
