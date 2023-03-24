using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccount
{
    public partial class Form1 : Form
    {
        private decimal balance = 0;
        private int depositCount = 0;
        private decimal depositTotal = 0;
        private int checkCount = 0;
        private decimal checkTotal = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = decimal.Parse(textBox1.Text);
                if (rbDeposit.Checked)
                {
                    balance += amount;
                    depositCount++;
                    depositTotal += amount;
                }
                else if (rbCheck.Checked)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                        checkCount++;
                        checkTotal += amount;
                    }
                    else
                    {
                        MessageBox.Show("Insufficient Funds");
                        balance -= 10;
                        rbServiceCharge.Checked = true;
                        rbServiceCharge.Enabled = false;
                    }
                }
                else if (rbServiceCharge.Checked)
                {
                    balance -= amount;
                }
                if (balance < 0)
                {
                    MessageBox.Show("New Balance is Negative");
                }

             
                textBox2.Text = "Balance: ₱" + balance.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rbDeposit.Checked = true;
            rbServiceCharge.Enabled = true;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            string message =
           "Deposit Count: " + depositCount + "\n" +
           "Deposit Total: ₱" + depositTotal.ToString("#,##0.00") + "\n" +
           "Check Count: " + checkCount + "\n" +
           "Check Total: ₱" + checkTotal.ToString("#,##0.00");
            MessageBox.Show(message);
        }
    }
}
