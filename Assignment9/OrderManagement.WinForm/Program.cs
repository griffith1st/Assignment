using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OrderManagement;

var builder = WebApplication.CreateBuilder(args);

// 1. ��ȡ�����ַ���
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. ע�� DbContext��Scoped���� OrderService
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr))  // �Զ����������汾&#8203;:contentReference[oaicite:1]{index=1}
);
builder.Services.AddScoped<OrderService>();

// 3. ��� Controllers �� Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �м��
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
