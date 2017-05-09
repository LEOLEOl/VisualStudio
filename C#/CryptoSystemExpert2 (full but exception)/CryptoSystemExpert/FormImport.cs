using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CryptoSystem
{
    public partial class FormImport : Form
    {
        public User _u;
        SaveFileDialog saveDlg;

        public void SetUser(User u)
        {
            _u = u;
        }

        public FormImport()
        {
            InitializeComponent();
        }

        private void FormImport_Load(object sender, EventArgs e)
        {
            txtEmail.Text = _u.email;
            txtKeySize.Text = _u.keysize.ToString();                        
            rtxtPublicKey.Text = _u.publickey;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "HDV file|*.hdv";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = _u.email + "_public_key";
            saveDlg.Title = "Choose a folder and a name to save public key file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDlg.FileName, rtxtPublicKey.Text);
                MessageBox.Show(this, "Save public key of " + _u.email + " successful");
            }
        }

        private void FormImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
