namespace OrderManagementWinForm
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtQueryOrderNumber;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQueryOrderNumber = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();

            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();

            // tableLayoutPanel1：两列、三行（第一行用于标题或预留，后两行为主数据展示区）
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;

            // dgvOrders：显示订单列表
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.dgvOrders, 0, 1);

            // dgvOrderDetails：显示选中订单的明细
            this.dgvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.dgvOrderDetails, 0, 2);

            // 右侧按钮区使用 FlowLayoutPanel 实现垂直排列
            System.Windows.Forms.FlowLayoutPanel flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowPanel.Controls.Add(this.btnAdd);
            flowPanel.Controls.Add(this.btnModify);
            flowPanel.Controls.Add(this.btnDelete);
            flowPanel.Controls.Add(this.lblQuery);
            flowPanel.Controls.Add(this.txtQueryOrderNumber);
            flowPanel.Controls.Add(this.btnQuery);
            this.tableLayoutPanel1.Controls.Add(flowPanel, 1, 1);
            this.tableLayoutPanel1.SetRowSpan(flowPanel, 2);

            // 按钮及查询输入框设置
            this.btnAdd.Text = "新建订单";
            this.btnAdd.AutoSize = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnModify.Text = "修改订单";
            this.btnModify.AutoSize = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);

            this.btnDelete.Text = "删除订单";
            this.btnDelete.AutoSize = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblQuery.Text = "订单号查询：";
            this.txtQueryOrderNumber.Width = 100;

            this.btnQuery.Text = "查询订单";
            this.btnQuery.AutoSize = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);

            // 主窗体设置
            this.Controls.Add(this.tableLayoutPanel1);
            this.Text = "订单管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
