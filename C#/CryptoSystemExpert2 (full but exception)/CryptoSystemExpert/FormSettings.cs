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
    public partial class FormSettings : Form
    {
        public void SetFormMain(FormMain form)
        {
            _form = form;
        }

        private FormMain _form;

        public FormSettings()
        {
            InitializeComponent();
        }


        private void FormSettings_Load(object sender, EventArgs e)
        {
            trackBarOpacity.Value = Convert.ToInt32(_form.Opacity * 100);
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            _form.Opacity = (double)trackBarOpacity.Value / 100;
            Program.opacity = (double)trackBarOpacity.Value / 100;
        }
    }
}
