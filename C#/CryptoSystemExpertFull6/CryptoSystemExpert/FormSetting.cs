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
    public partial class FormSetting : Form
    {
        public void SetFormMain(FormMain form)
        {
            _form = form;
        }

        private FormMain _form;

        public FormSetting()
        {
            InitializeComponent();
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            trackBarOpacity.Value = Convert.ToInt32(_form.Opacity * 100);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
