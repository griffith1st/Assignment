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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblOrderNumber = new Label();
            txtOrderNumber = new TextBox();
            lblCustomerId = new Label();
            txtCustomerId = new TextBox();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            dgvOrderDetails = new DataGridView();
            groupBoxProduct = new GroupBox();
            productLayout = new TableLayoutPanel();
            lblProductId = new Label();
            lblProductName = new Label();
            lblProductPrice = new Label();
            lblQuantity = new Label();
            txtProductId = new TextBox();
            txtProductName = new TextBox();
            txtProductPrice = new TextBox();
            txtQuantity = new TextBox();
            btnAddDetail = new Button();
            btnSave = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            groupBoxProduct.SuspendLayout();
            productLayout.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblOrderNumber, 0, 0);
            tableLayoutPanel1.Controls.Add(txtOrderNumber, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCustomerId, 0, 1);
            tableLayoutPanel1.Controls.Add(txtCustomerId, 1, 1);
            tableLayoutPanel1.Controls.Add(lblCustomerName, 0, 2);
            tableLayoutPanel1.Controls.Add(txtCustomerName, 1, 2);
            tableLayoutPanel1.Controls.Add(dgvOrderDetails, 0, 3);
            tableLayoutPanel1.Controls.Add(groupBoxProduct, 0, 4);
            tableLayoutPanel1.Controls.Add(btnSave, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(600, 400);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.Dock = DockStyle.Fill;
            lblOrderNumber.Location = new Point(3, 0);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(294, 40);
            lblOrderNumber.TabIndex = 0;
            lblOrderNumber.Text = "订单号：";
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Dock = DockStyle.Fill;
            txtOrderNumber.Location = new Point(303, 3);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new Size(294, 30);
            txtOrderNumber.TabIndex = 1;
            // 
            // lblCustomerId
            // 
            lblCustomerId.Dock = DockStyle.Fill;
            lblCustomerId.Location = new Point(3, 40);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(294, 40);
            lblCustomerId.TabIndex = 2;
            lblCustomerId.Text = "客户ID：";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Dock = DockStyle.Fill;
            txtCustomerId.Location = new Point(303, 43);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(294, 30);
            txtCustomerId.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Dock = DockStyle.Fill;
            lblCustomerName.Location = new Point(3, 80);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(294, 40);
            lblCustomerName.TabIndex = 4;
            lblCustomerName.Text = "客户名称：";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Dock = DockStyle.Fill;
            txtCustomerName.Location = new Point(303, 83);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(294, 30);
            txtCustomerName.TabIndex = 5;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ColumnHeadersHeight = 34;
            tableLayoutPanel1.SetColumnSpan(dgvOrderDetails, 2);
            dgvOrderDetails.Dock = DockStyle.Fill;
            dgvOrderDetails.Location = new Point(3, 123);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.RowHeadersWidth = 62;
            dgvOrderDetails.Size = new Size(594, 134);
            dgvOrderDetails.TabIndex = 6;
            // 
            // groupBoxProduct
            // 
            tableLayoutPanel1.SetColumnSpan(groupBoxProduct, 2);
            groupBoxProduct.Controls.Add(productLayout);
            groupBoxProduct.Controls.Add(btnAddDetail);
            groupBoxProduct.Dock = DockStyle.Fill;
            groupBoxProduct.Location = new Point(3, 263);
            groupBoxProduct.Name = "groupBoxProduct";
            groupBoxProduct.Size = new Size(594, 94);
            groupBoxProduct.TabIndex = 7;
            groupBoxProduct.TabStop = false;
            groupBoxProduct.Text = "添加商品明细";
            // 
            // productLayout
            // 
            productLayout.ColumnCount = 4;
            productLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            productLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            productLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            productLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            productLayout.Controls.Add(lblProductId, 0, 0);
            productLayout.Controls.Add(lblProductName, 1, 0);
            productLayout.Controls.Add(lblProductPrice, 2, 0);
            productLayout.Controls.Add(lblQuantity, 3, 0);
            productLayout.Controls.Add(txtProductId, 0, 1);
            productLayout.Controls.Add(txtProductName, 1, 1);
            productLayout.Controls.Add(txtProductPrice, 2, 1);
            productLayout.Controls.Add(txtQuantity, 3, 1);
            productLayout.Dock = DockStyle.Fill;
            productLayout.Location = new Point(3, 26);
            productLayout.Name = "productLayout";
            productLayout.RowCount = 2;
            productLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            productLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            productLayout.Size = new Size(588, 42);
            productLayout.TabIndex = 0;
            // 
            // lblProductId
            // 
            lblProductId.Location = new Point(3, 0);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(100, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "产品ID";
            // 
            // lblProductName
            // 
            lblProductName.Location = new Point(150, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(100, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "产品名称";
            // 
            // lblProductPrice
            // 
            lblProductPrice.Location = new Point(297, 0);
            lblProductPrice.Name = "lblProductPrice";
            lblProductPrice.Size = new Size(100, 20);
            lblProductPrice.TabIndex = 2;
            lblProductPrice.Text = "单价";
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(444, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 20);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "数量";
            // 
            // txtProductId
            // 
            txtProductId.Dock = DockStyle.Fill;
            txtProductId.Location = new Point(3, 23);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(141, 30);
            txtProductId.TabIndex = 4;
            // 
            // txtProductName
            // 
            txtProductName.Dock = DockStyle.Fill;
            txtProductName.Location = new Point(150, 23);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(141, 30);
            txtProductName.TabIndex = 5;
            // 
            // txtProductPrice
            // 
            txtProductPrice.Dock = DockStyle.Fill;
            txtProductPrice.Location = new Point(297, 23);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(141, 30);
            txtProductPrice.TabIndex = 6;
            // 
            // txtQuantity
            // 
            txtQuantity.Dock = DockStyle.Fill;
            txtQuantity.Location = new Point(444, 23);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(141, 30);
            txtQuantity.TabIndex = 7;
            // 
            // btnAddDetail
            // 
            btnAddDetail.Dock = DockStyle.Bottom;
            btnAddDetail.Location = new Point(3, 68);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(588, 23);
            btnAddDetail.TabIndex = 1;
            btnAddDetail.Text = "添加明细";
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // btnSave
            // 
            tableLayoutPanel1.SetColumnSpan(btnSave, 2);
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 363);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(594, 34);
            btnSave.TabIndex = 8;
            btnSave.Text = "保存订单";
            btnSave.Click += btnSave_Click;
            // 
            // FormOrderEdit
            // 
            ClientSize = new Size(600, 400);
            Controls.Add(tableLayoutPanel1);
            Name = "FormOrderEdit";
            Text = "订单编辑";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            groupBoxProduct.ResumeLayout(false);
            productLayout.ResumeLayout(false);
            productLayout.PerformLayout();
            ResumeLayout(false);
        }
        private TableLayoutPanel productLayout;
    }
}
