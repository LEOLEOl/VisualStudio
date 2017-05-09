using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnThucHanh
{
    public partial class FormInputPass : Form
    {
        private string pass;
        
        public string InputPassword
        {
            get { return pass; }
            set { pass = value; }
        }

        public FormInputPass()
        {
            InitializeComponent();            
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInputPass.Text.Length < 5 || txtInputPass.Text.Length > 64)
            {
                MessageBox.Show(this, "Password must be >= 5 and <= 64 characters");
            }
            else
            {
                pass = txtInputPass.Text;
                this.Hide();
            }     
        }

        private void FormInputPass_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
