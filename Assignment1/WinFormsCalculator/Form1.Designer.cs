namespace WinFormsCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCalculate = new Button();
            txtNum1 = new TextBox();
            txtNum2 = new TextBox();
            lblResult = new Label();
            cmbOperator = new ComboBox();
            SuspendLayout();
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(297, 226);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(112, 34);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "计算";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // txtNum1
            // 
            txtNum1.Location = new Point(176, 172);
            txtNum1.Name = "txtNum1";
            txtNum1.Size = new Size(144, 30);
            txtNum1.TabIndex = 1;
            // 
            // txtNum2
            // 
            txtNum2.Location = new Point(387, 172);
            txtNum2.Name = "txtNum2";
            txtNum2.Size = new Size(150, 30);
            txtNum2.TabIndex = 2;
            // 
            // lblResult
            // 
            lblResult.Location = new Point(256, 289);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(192, 27);
            lblResult.TabIndex = 3;
            lblResult.Text = "结果：";
            // 
            // cmbOperator
            // 
            cmbOperator.FormattingEnabled = true;
            cmbOperator.Items.AddRange(new object[] { "+", "-", "×", "÷" });
            cmbOperator.Location = new Point(326, 170);
            cmbOperator.MaxDropDownItems = 4;
            cmbOperator.Name = "cmbOperator";
            cmbOperator.Size = new Size(55, 32);
            cmbOperator.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 450);
            Controls.Add(cmbOperator);
            Controls.Add(lblResult);
            Controls.Add(txtNum2);
            Controls.Add(txtNum1);
            Controls.Add(btnCalculate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalculate;
        private TextBox txtNum1;
        private TextBox txtNum2;
        private Label lblResult;
        private ComboBox cmbOperator;
    }
}