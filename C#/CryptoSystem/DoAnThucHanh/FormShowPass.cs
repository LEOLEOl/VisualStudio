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
    public partial class FormShowPass : Form
    {
        public string PassShow
        {
            get { return txtPass.Text; }
            set { txtPass.Text = value; }
        }

        public FormShowPass()
        {
            InitializeComponent();
        }
    }
}
