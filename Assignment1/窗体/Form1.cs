using System;
using System.Windows.Forms;

namespace WinFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ��ʼ�������ѡ������� InitializeComponent() ֮��
            cmbOperator.Items.AddRange(new object[] { "+", "-", "��", "��" });
            cmbOperator.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // ������֤
            if (!double.TryParse(txtNum1.Text, out double num1))
            {
                MessageBox.Show("��һ��������Ч", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtNum2.Text, out double num2))
            {
                MessageBox.Show("�ڶ���������Ч", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case "��":
                        result = num1 * num2;
                        break;
                    case "��":
                        result = num2 != 0 ? num1 / num2 : throw new DivideByZeroException();
                        break;
                    default: throw new InvalidOperationException("��Ч�����");
                };
                lblResult.Text = $"{num1} {op} {num2} = {result}";
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("��������Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}