using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoSystemExpert
{
    public partial class FormInputPass : Form
    {
        private string pass;
        private bool isOK;
        
        public string InputPassword
        {
            get { return pass; }
            //set { pass = value; }
        }
        public bool IsOK
        {
            get { return isOK; }
        }

        public string LabelInputPass
        {
            get { return labelInputPass.Text; }
            set { labelInputPass.Text = value; }
        }
        public bool IsShowTextPassword
        {
            get { return txtInputPass.UseSystemPasswordChar; }
            set { txtInputPass.UseSystemPasswordChar = value; }
        }

        public FormInputPass()
        {
            InitializeComponent();            
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInputPass.Text.Length < 5 || txtInputPass.Text.Length > 64)
            {
                isOK = false;
                MessageBox.Show(this, "Password must be >= 5 and <= 64 characters");
            }
            else
            {
                isOK = true;
                pass = txtInputPass.Text;
                this.Hide();
            }
            txtInputPass.Focus();
        }

        private void FormInputPass_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void labelInputPass_Click(object sender, EventArgs e)
        {

        }

        private void txtInputPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
