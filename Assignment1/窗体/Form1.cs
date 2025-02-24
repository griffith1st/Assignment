using System;
using System.Windows.Forms;

namespace WinFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 初始化运算符选项（必须在 InitializeComponent() 之后）
            cmbOperator.Items.AddRange(new object[] { "+", "-", "×", "÷" });
            cmbOperator.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 输入验证
            if (!double.TryParse(txtNum1.Text, out double num1))
            {
                MessageBox.Show("第一个数字无效", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtNum2.Text, out double num2))
            {
                MessageBox.Show("第二个数字无效", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string op = cmbOperator.SelectedItem?.ToString() ?? "";
                double result;
                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "×":
                        result = num1 * num2;
                        break;
                    case "÷":
                        result = num2 != 0 ? num1 / num2 : throw new DivideByZeroException();
                        break;
                    default: throw new InvalidOperationException("无效运算符");
                };
                lblResult.Text = $"{num1} {op} {num2} = {result}";
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("除数不能为零", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}