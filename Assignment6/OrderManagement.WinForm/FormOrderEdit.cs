using System;
using System.Windows.Forms;
using OrderManagement;
using System.Collections.Generic;

namespace OrderManagementWinForm
{
    public partial class FormOrderEdit : Form
    {
        // 用于返回或修改的订单数据
        public Order OrderData { get; private set; }
        private BindingSource orderDetailsBindingSource = new BindingSource();

        // 新建订单构造函数
        public FormOrderEdit()
        {
            InitializeComponent();
            InitializeDataBinding();
        }

        // 修改订单构造函数（复制原订单数据）
        public FormOrderEdit(Order order) : this()
        {
            OrderData = new Order(order.OrderNumber, order.Customer);
            foreach (var detail in order.Details)
            {
                OrderData.Details.Add(new OrderDetails(detail.Product, detail.Quantity));
            }
            // 将数据填入控件
            txtOrderNumber.Text = OrderData.OrderNumber.ToString();
            txtCustomerId.Text = OrderData.Customer.Id.ToString();
            txtCustomerName.Text = OrderData.Customer.Name;
            orderDetailsBindingSource.DataSource = OrderData.Details;
        }

        // 初始化订单明细的绑定
        private void InitializeDataBinding()
        {
            orderDetailsBindingSource.DataSource = new List<OrderDetails>();
            dgvOrderDetails.DataSource = orderDetailsBindingSource;
        }

        // 添加订单明细：根据文本框输入的产品信息和数量创建订单明细
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProductId.Text, out int productId) &&
                !string.IsNullOrEmpty(txtProductName.Text) &&
                double.TryParse(txtProductPrice.Text, out double productPrice) &&
                int.TryParse(txtQuantity.Text, out int quantity))
            {
                Product product = new Product(productId, txtProductName.Text, productPrice);
                OrderDetails detail = new OrderDetails(product, quantity);
                orderDetailsBindingSource.Add(detail);
            }
            else
            {
                MessageBox.Show("请输入有效的商品信息和数量！");
            }
        }

        // 保存订单信息
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtOrderNumber.Text, out int orderNumber) &&
                int.TryParse(txtCustomerId.Text, out int customerId) &&
                !string.IsNullOrEmpty(txtCustomerName.Text))
            {
                Customer customer = new Customer(customerId, txtCustomerName.Text);
                OrderData = new Order(orderNumber, customer);
                foreach (OrderDetails detail in orderDetailsBindingSource.List)
                {
                    OrderData.Details.Add(detail);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入有效的订单信息！");
            }
        }
    }
}
