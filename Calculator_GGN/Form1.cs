using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_GGN
{
    public partial class Calculator : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;
        double memory = 0;
        bool memoryFlag = false;

        public Calculator()
        {
            InitializeComponent();

            btnMR.Enabled = false;
            btnMC.Enabled = false;
        }

        private void btn_click(object sender, EventArgs e)
        {
            if ((tbField.Text == "0") || (isOperationPerformed) || memoryFlag == true)
            {
                tbField.Clear();

                isOperationPerformed = false;
                memoryFlag = false;

                Button btn = (Button)sender;
                if (btn.Text == ",")
                {
                    if (!tbField.Text.Contains(","))
                    {
                        tbField.Text = tbField.Text + btn.Text;
                    }
                }
                else
                    tbField.Text = tbField.Text + btn.Text;
            }
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if(resultValue!=0)
            {
                btnEqual.PerformClick();
                operationPerformed = btn.Text;
                lbResult.Visible = true;
                lbResult.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = btn.Text;
                resultValue = double.Parse(tbField.Text);
                lbResult.Visible = true;
                lbResult.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            tbField.Text = "0";
            resultValue = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbField.Text = "0";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tbField.Text.Length > 0)
            {
                tbField.Text = tbField.Text.Remove(tbField.Text.Length - 1);
            }
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            tbField.Text = "0";
            memory = 0;
            btnMC.Enabled = false;
            btnMR.Enabled = false;

        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            tbField.Text = memory.ToString();
            memoryFlag = true;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memory = double.Parse(tbField.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            memoryFlag = true;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memory = memory + double.Parse(tbField.Text);
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memory = memory - double.Parse(tbField.Text);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    tbField.Text = (resultValue + double.Parse(tbField.Text)).ToString();
                    break;
                case "-":
                    tbField.Text = (resultValue - double.Parse(tbField.Text)).ToString();
                    break;
                case "*":
                    tbField.Text = (resultValue * double.Parse(tbField.Text)).ToString();
                    break;
                case "/":
                    tbField.Text = (resultValue / double.Parse(tbField.Text)).ToString();
                    break;
                default:
                    break;

            }
            resultValue = double.Parse(tbField.Text);
            lbResult.Text = " ";
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            lbResult.Visible = true;
            lbResult.Text = tbField.Text + "^";
            tbField.Text = (double.Parse(tbField.Text) * double.Parse(tbField.Text)).ToString();
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            lbResult.Visible = true;
            lbResult.Text = "√" + tbField.Text;
            tbField.Text = Math.Sqrt(double.Parse(tbField.Text)).ToString();
        }
    }
}
