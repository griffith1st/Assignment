using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderManagement;

namespace OrderManagementWinForm
{
    public partial class FormMain : Form
    {
        private OrderService orderService = new OrderService();
        private BindingSource orderBindingSource = new BindingSource();
        private BindingSource orderDetailsBindingSource = new BindingSource();

        public FormMain()
        {
            InitializeComponent();
            InitializeDataBinding();
            InitializeTestData();
        }

        // 初始化数据绑定
        private void InitializeDataBinding()
        {
            // 绑定订单列表
            orderBindingSource.DataSource = orderService.GetAllOrders();
            dgvOrders.DataSource = orderBindingSource;

            // 绑定订单明细（主从绑定）
            orderDetailsBindingSource.DataSource = orderBindingSource;
            orderDetailsBindingSource.DataMember = "Details";
            dgvOrderDetails.DataSource = orderDetailsBindingSource;
        }

        // 初始化测试数据（可根据需要调整或删除）
        private void InitializeTestData()
        {
            Customer customer1 = new Customer(1, "张三");
            Product product1 = new Product(1, "电脑", 5000);
            Product product2 = new Product(2, "手机", 3000);

            Order order1 = new Order(1001, customer1);
            order1.Details.Add(new OrderDetails(product1, 1));
            order1.Details.Add(new OrderDetails(product2, 2));
            orderService.AddOrder(order1);

            // 刷新绑定数据
            orderBindingSource.ResetBindings(false);
        }

        // 新建订单按钮点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormOrderEdit formEdit = new FormOrderEdit();
            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Order newOrder = formEdit.OrderData;
                    orderService.AddOrder(newOrder);
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                    orderBindingSource.ResetBindings(false);
                    MessageBox.Show("添加订单成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加订单失败：" + ex.Message);
                }
            }
        }

        // 修改订单按钮点击事件
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order selectedOrder)
            {
                FormOrderEdit formEdit = new FormOrderEdit(selectedOrder);
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Order updatedOrder = formEdit.OrderData;
                        orderService.UpdateOrder(updatedOrder);
                        orderBindingSource.ResetBindings(false);
                        MessageBox.Show("修改订单成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("修改订单失败：" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要修改的订单！");
            }
        }

        // 删除订单按钮点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order selectedOrder)
            {
                try
                {
                    orderService.RemoveOrder(selectedOrder.OrderNumber);
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                    orderBindingSource.ResetBindings(false);
                    MessageBox.Show("删除订单成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除订单失败：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的订单！");
            }
        }

        // 查询订单按钮点击事件（以订单号查询为例）
        private void btnQuery_Click(object sender, EventArgs e)
        {
            int orderNumber;
            if (int.TryParse(txtQueryOrderNumber.Text, out orderNumber))
            {
                List<Order> result = orderService.QueryByOrderNumber(orderNumber);
                orderBindingSource.DataSource = result;
                orderBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("请输入有效的订单号进行查询！");
            }
        }
    }
}
