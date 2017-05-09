using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertCurrency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void txtV1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV2.Text = txtV1.Text != "" ? (Double.Parse(txtV1.Text) * Double.Parse(txtRate.Text)).ToString() : "";
            }
            catch
            {
                txtV2.Text = "";
            }
        }

        private void txtV2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV1.Text = txtV2.Text != "" ? (Double.Parse(txtV2.Text) / Double.Parse(txtRate.Text)).ToString() : "";
            }
            catch
            {
                txtV1.Text = "";
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtV1_TextChanged(sender, e);
            txtV2_TextChanged(sender, e);
        }

        private void txtV1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV1.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtV2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV2.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtRate.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        //////////

        private void txtV12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV22.Text = txtV12.Text != "" ? (Double.Parse(txtV12.Text) * Double.Parse(txtRate2.Text)).ToString() : "";
            }
            catch
            {
                txtV22.Text = "";
            }
        }

        private void txtV22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV12.Text = txtV22.Text != "" ? (Double.Parse(txtV22.Text) / Double.Parse(txtRate2.Text)).ToString() : "";
            }
            catch
            {
                txtV12.Text = "";
            }
        }

        private void txtRate2_TextChanged(object sender, EventArgs e)
        {
            txtV12_TextChanged(sender, e);
            txtV22_TextChanged(sender, e);
        }

        private void txtV12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV12.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtV22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV22.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtRate2.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        //////////

        private void txtV13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV23.Text = txtV13.Text != "" ? (Double.Parse(txtV13.Text) * Double.Parse(txtRate3.Text)).ToString() : "";
            }
            catch
            {
                txtV23.Text = "";
            }
        }

        private void txtV23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV13.Text = txtV23.Text != "" ? (Double.Parse(txtV23.Text) / Double.Parse(txtRate3.Text)).ToString() : "";
            }
            catch
            {
                txtV13.Text = "";
            }
        }

        private void txtRate3_TextChanged(object sender, EventArgs e)
        {
            txtV13_TextChanged(sender, e);
            txtV23_TextChanged(sender, e);
        }

        private void txtV13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV13.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtV23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV23.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtRate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtRate3.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        //////////

        private void txtV14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV24.Text = txtV14.Text != "" ? (Double.Parse(txtV14.Text) * Double.Parse(txtRate4.Text)).ToString() : "";
            }
            catch
            {
                txtV24.Text = "";
            }
        }

        private void txtV24_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtV14.Text = txtV24.Text != "" ? (Double.Parse(txtV24.Text) / Double.Parse(txtRate4.Text)).ToString() : "";
            }
            catch
            {
                txtV14.Text = "";
            }
        }

        private void txtRate4_TextChanged(object sender, EventArgs e)
        {
            txtV14_TextChanged(sender, e);
            txtV24_TextChanged(sender, e);
        }

        private void txtV14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV14.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtV24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtV24.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtRate4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if (e.KeyChar == '.' && txtRate4.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
