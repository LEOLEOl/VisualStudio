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

namespace CryptoSystemExpert
{
    public partial class FormChangePass : Form
    {
        private User _u;
        public bool isUpdate;
        CommonFunction cf = new CommonFunction();
        string oldpass, newpass, renewpass;

        public void SetUser(User u)
        {
            _u = u;
        }

        public User GetUser()
        {
            return _u;
        }
        public FormChangePass()
        {
            InitializeComponent();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            oldpass = txtOldPass.Text;
            newpass = txtNewPass.Text;
            renewpass = txtReNewPass.Text;

            if (newpass != renewpass || newpass.Length > 50 || newpass == "")
            {
                MessageBox.Show(this, "Check the parameters");
                isUpdate = false;
                return;
            }

            RunChangePass();            
        }

        private void RunChangePass()
        {
            Thread t = new Thread(new ThreadStart(RunChangePassThread));
            t.Start();
        }

        private void RunChangePassThread()
        {
            EnableButton(true);

            // Split file .data first
            string temp = cf.userPath + _u.email + "/" + _u.email;
            string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
            cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

            if ((new HashSalt()).CheckFileHashSalt(Encoding.UTF8.GetBytes(oldpass), temp + ".pass"))
            {
                _u.password = newpass;
                isUpdate = true;

                EncryptDecrypt ed = new EncryptDecrypt();
                // Giai ma file private key
                ed.DecryptFileSym(temp + ".private", temp + ".pri", oldpass);

                // Tao file .private moi
                ed.EncryptFileSym(temp + ".pri", temp + ".private", newpass, 0, 0, 0);

                // Xoa file .pri
                System.IO.File.Delete(temp + ".pri");

                // Tao ra file .pass moi
                HashSalt hs = new HashSalt();// Tao doi tuong HashSalt
                hs.CreateFileHashSalt(Encoding.UTF8.GetBytes(newpass), temp + ".pass");

                // Join Files
                string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                cf.JoinFile_Delete_Encrypt(source, temp + ".data");

                MessageBox.Show(this, "Change password successful");
            }
            else
            {
                // Join Files
                string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                cf.JoinFile_Delete_Encrypt(source, temp + ".data");

                MessageBox.Show(this, "Wrong password");
                isUpdate = false;
            }

            EnableButton(false);
            this.Close();
        }

        private void EnableButton(bool isRunning)
        {
            txtOldPass.Enabled = txtNewPass.Enabled = txtReNewPass.Enabled = btnUpdatePassword.Enabled = 
            this.ControlBox = !isRunning;
        }
        
        private void FormChangePass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdatePassword_Click(sender, e);
            }
        }
    }
}
