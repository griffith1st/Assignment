namespace OrderManagementWinForm
{
    partial class FormOrderEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.groupBoxProduct.SuspendLayout();
            this.SuspendLayout();

            // tableLayoutPanel1：设置为2列，行数根据需要设定
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // 订单号行
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // 客户ID行
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // 客户名称行
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F)); // 订单明细
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F)); // 商品明细输入区域
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // 保存按钮行

            // 添加各控件到tableLayoutPanel1
            // 订单号
            this.lblOrderNumber.Text = "订单号：";
            this.lblOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.lblOrderNumber, 0, 0);
            this.txtOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.txtOrderNumber, 1, 0);

            // 客户ID
            this.lblCustomerId.Text = "客户ID：";
            this.lblCustomerId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerId, 0, 1);
            this.txtCustomerId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.txtCustomerId, 1, 1);

            // 客户名称
            this.lblCustomerName.Text = "客户名称：";
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerName, 0, 2);
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.txtCustomerName, 1, 2);

            // 订单明细 DataGridView（跨两列）
            this.dgvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvOrderDetails, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvOrderDetails, 0, 3);

            // groupBoxProduct：用于输入商品明细信息
            this.groupBoxProduct.Text = "添加商品明细";
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            // 在 groupBox 内部使用子布局，采用4列2行，第一行为标签，第二行为输入框
            System.Windows.Forms.TableLayoutPanel productLayout = new System.Windows.Forms.TableLayoutPanel();
            productLayout.ColumnCount = 4;
            productLayout.RowCount = 2;
            productLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            productLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            productLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            productLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            productLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            // 第一行标签
            this.lblProductId.Text = "产品ID";
            this.lblProductName.Text = "产品名称";
            this.lblProductPrice.Text = "单价";
            this.lblQuantity.Text = "数量";
            productLayout.Controls.Add(this.lblProductId, 0, 0);
            productLayout.Controls.Add(this.lblProductName, 1, 0);
            productLayout.Controls.Add(this.lblProductPrice, 2, 0);
            productLayout.Controls.Add(this.lblQuantity, 3, 0);

            // 第二行文本框
            this.txtProductId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            productLayout.Controls.Add(this.txtProductId, 0, 1);
            productLayout.Controls.Add(this.txtProductName, 1, 1);
            productLayout.Controls.Add(this.txtProductPrice, 2, 1);
            productLayout.Controls.Add(this.txtQuantity, 3, 1);

            // 添加产品输入区到 groupBoxProduct，并添加添加明细按钮
            this.btnAddDetail.Text = "添加明细";
            this.btnAddDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            this.groupBoxProduct.Controls.Add(productLayout);
            this.groupBoxProduct.Controls.Add(this.btnAddDetail);
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxProduct, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxProduct, 0, 4);

            // 保存订单按钮
            this.btnSave.Text = "保存订单";
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 5);

            // FormOrderEdit 窗体设置
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Text = "订单编辑";

            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
