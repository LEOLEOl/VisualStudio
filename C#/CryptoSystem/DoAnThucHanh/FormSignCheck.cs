using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;

namespace DoAnThucHanh
{
    public partial class FormSignCheck : Form
    {
        private User _u;
        OpenFileDialog openDlg;

        public void SetUser(User u)
        {
            _u = u;
        }
        public FormSignCheck()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (txtSourceSign.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
            }
            else
            {
                if (txtPassword.Text == _u.password)
                    RunSign();
                else
                    MessageBox.Show(this, "Wrong password");
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtSourceCheck.Text == "" || txtSignCheck.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
            }
            else
            {
                RunCheck();
            }
        }

        private void btnSourceSign_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSourceSign.Text = openDlg.FileName;
            }
        }

        private void btnSourceCheck_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSourceCheck.Text = openDlg.FileName;
            }
        }

        private void btnSignCheck_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSignCheck.Text = openDlg.FileName;
            }
        }

        private void RunSign()
        {
            Thread t = new Thread(new ThreadStart(RunSignThread));
            t.Start();
        }

        private void RunCheck()
        {
            Thread t = new Thread(new ThreadStart(RunCheckThread));
            t.Start();
        }
        private void RunSignThread()
        {
            btnSourceSign.Enabled = btnSign.Enabled = false;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_u.privatekey);
            (new SignatureSalt(rsa)).CreateFileSignatureSalt(System.IO.File.ReadAllBytes(txtSourceSign.Text), txtSourceSign.Text + ".sig");

            MessageBox.Show(this, "Create signature successful");

            btnSourceSign.Enabled = btnSign.Enabled = true;
        }

        private void RunCheckThread()
        {
            btnSourceCheck.Enabled = btnSignCheck.Enabled = btnCheck.Enabled = false;

            CommonFunction cf = new CommonFunction();
            string[] users = System.IO.Directory.GetDirectories(cf.userPath);

            // For each user
            for (int i = 0; i < users.Length; ++i)
            {
                users[i] = System.IO.Directory.GetFiles(users[i])[0];

                // Split file .data first
                string temp = users[i].Substring(0, users[i].Length - 7);                
                string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                cf.SplitFile_Delete_Decrypt(temp + ".data", dest);
                
                // Get Email and publickey
                string email = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".email"));
                string publickey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));

                cf.JoinFile_Delete_Encrypt(dest, temp + ".data");
                
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publickey);
                
                bool check = (new SignatureSalt(rsa)).CheckFileSignatureSalt(System.IO.File.ReadAllBytes(txtSourceCheck.Text), txtSignCheck.Text);
                if (check)
                {
                    btnSourceCheck.Enabled = btnSignCheck.Enabled = btnCheck.Enabled = true;
                    MessageBox.Show(this, "This is a document of " + email + " and Public Key size is " + rsa.KeySize.ToString());                    
                    return;
                }
            }
            btnSourceCheck.Enabled = btnSignCheck.Enabled = btnCheck.Enabled = true;
            MessageBox.Show(this, "We do not know where the document comes from");  
        }
    }
}
