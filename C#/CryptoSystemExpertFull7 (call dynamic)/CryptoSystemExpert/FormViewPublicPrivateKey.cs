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
    public partial class FormViewPublicPrivateKey : Form
    {
        private User _u;
        SaveFileDialog saveDlg = new SaveFileDialog();
        public void SetUser(User u)
        {
            _u = u;
        }
        public FormViewPublicPrivateKey()
        {
            InitializeComponent();
        }

        public string LabelKey
        {
            get { return labelKey.Text; }
            set { labelKey.Text = value; }
        }
        public string ButtonSave
        {
            get { return btnSave.Text; }
            set { btnSave.Text = value; }
        }
        public string Key
        {
            get { return rtxtKey.Text; }
            set { rtxtKey.Text = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isPublic;
            if (LabelKey == "Public Key") isPublic = true;
            else isPublic = false;

            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "HDV file|*.hdv";
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Choose a folder and a name to save key file";

            if (isPublic) saveDlg.FileName = _u.email + "_public_key";
            else saveDlg.FileName = _u.email + "_private_key"; 

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDlg.FileName, rtxtKey.Text);
                if (isPublic) MessageBox.Show(this, "Save public key of " + _u.email + " successful");
                else MessageBox.Show(this, "Save private key of " + _u.email + " successful");
            }
        }
    }
}
