using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoSystem
{
    public partial class FormInputPassword : Form
    {
        private User _u;
        
        private string pass;
        public bool isOK = false;

        public void SetUser(User u)
        {
            _u = u;
        }

        public string InputPassword
        {
            get { return pass; }
            set { pass = value; }
        }
        public string LabelPassword
        {
            get { return labelInputPass.Text; }
            set { labelInputPass.Text = value; }
        }

        public FormInputPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pass = txtInputPass.Text;
            
            if (pass == _u.password)
            {
                isOK = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show(this, "Wrong password");
                return;
            }
        }

        private void FormInputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
