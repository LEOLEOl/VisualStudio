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
using System.Threading;
using System.Security.Cryptography;


namespace CryptoSystem
{
    public partial class FormSignUp : Form
    {
        CommonFunction cf = new CommonFunction();

        public FormSignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {            
            RunSignUp();           
        }

        private void RunSignUp()
        {
            Thread t = new Thread(new ThreadStart(RunSignUpThread));
            t.Start();
        }

        private void RunSignUpThread()
        {
            EnableButton(true);

            int i;
            // Check parameters
            if (txtPassword.Text != txtPassword2.Text
                || txtEmail.Text == "" || txtPassword.Text == "" || txtFullName.Text == ""
                || txtPhone.Text == "" || txtAddress.Text == "" || txtKeySize.Text == ""
                || txtEmail.Text.Length > 50 || txtPassword.Text.Length > 50 || txtFullName.Text.Length > 50
                || txtPhone.Text.Length > 50 || txtAddress.Text.Length > 50 || txtKeySize.Text.Length > 50)
            {
                MessageBox.Show(this, "Check the parameters");
                goto Finish;                
            }
            else
            {
                int indexAt = txtEmail.Text.ToLower().IndexOf('@'), indexDot = txtEmail.Text.ToLower().IndexOf('.');
                if (indexAt == -1 || indexAt == txtEmail.Text.Length - 1 || txtEmail.Text.ToLower().IndexOf('@', indexAt + 1) != -1 ||
                    indexDot == -1 || indexDot == txtEmail.Text.Length - 1 || txtEmail.Text.ToLower().IndexOf('.', indexDot + 1) != -1 ||
                    indexDot - indexAt < 2 ||
                    indexAt == 0)
                {
                    MessageBox.Show(this, "Wrong email format");
                    goto Finish;
                }
                if (!Int32.TryParse(txtKeySize.Text, out i))
                {
                    MessageBox.Show(this, "Wrong keysize format");
                    goto Finish;
                }
            }

            User u = new User();
            u.email = txtEmail.Text;
            u.password = txtPassword.Text;
            u.fullname = txtFullName.Text;
            u.DOB = dateTimeDOB.Text;
            u.phone = txtPhone.Text;
            u.address = txtAddress.Text;
            u.keysize = i;
            
            if (!Directory.Exists(cf.userPath + u.email))
            {
                string temp = cf.userPath + u.email + "/" + u.email;

                // Normalize
                if (u.keysize < 2048) u.keysize = 2048;
                if (u.keysize > 4096) u.keysize = 4096;
                u.keysize = u.keysize - u.keysize % 64;

                Random r = new Random();
                EncryptDecrypt ed = new EncryptDecrypt();

                // Create and Generate RSA Key
                RSA uRSA = new RSA(u.keysize);
                uRSA.Generate();
                MessageBox.Show(this, "Generated with RSA Key with size " + u.keysize.ToString());
                u.publickey = uRSA.publicKey;
                u.privatekey = uRSA.privateKey;

                // Tao thu muc 
                System.IO.Directory.CreateDirectory(cf.userPath + u.email);

                // Tao doi tuong HashSalt
                HashSalt hs = new HashSalt();
                hs.CreateFileHashSalt(Encoding.UTF8.GetBytes(u.password), temp + ".pass");

                // Ghi file email
                System.IO.File.WriteAllBytes(temp + ".email", Encoding.UTF8.GetBytes(u.email));

                // Ghi file public key 
                System.IO.File.WriteAllBytes(temp + ".public", Encoding.UTF8.GetBytes(uRSA.publicKey));
                // Ghi file private key
                System.IO.File.WriteAllText(temp + ".pri", uRSA.privateKey);
                ed.EncryptFileSym(temp + ".pri", temp + ".private", u.password, 0, 0, 0);
                System.IO.File.Delete(temp + ".pri");

                // Ghi info
                BinaryWriter bw = new BinaryWriter(new FileStream(temp + ".info", FileMode.Create));

                // Encrypt name
                byte[] efullname = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(u.fullname), uRSA.publicKey, false);
                bw.Write(efullname.Length);
                bw.Write(efullname);

                // Encrypt DOB
                byte[] eDOB = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(u.DOB), uRSA.publicKey, false);
                bw.Write(eDOB.Length);
                bw.Write(eDOB);

                // Encrypt phone 
                byte[] ephone = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(u.phone), uRSA.publicKey, false);
                bw.Write(ephone.Length);
                bw.Write(ephone);

                // Encrypt phone 
                byte[] eaddress = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(u.address), uRSA.publicKey, false);
                bw.Write(eaddress.Length);
                bw.Write(eaddress);

                bw.Close();

                // Join Files
                string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                cf.JoinFile_Delete_Encrypt(source, temp + ".data");

                // Tao file path1, path2, path3
                System.IO.File.WriteAllText(cf.userPath + "/" + u.email + "/" + Program.fileContainPath1, "");
                System.IO.File.WriteAllText(cf.userPath + "/" + u.email + "/" + Program.fileContainPath2, "");
                System.IO.File.WriteAllText(cf.userPath + "/" + u.email + "/" + Program.fileContainPath3, "");
                System.IO.File.WriteAllText(cf.userPath + "/" + u.email + "/" + Program.pathSetting, "0.9");

                MessageBox.Show(this, "Sign up successful");
                //this.Hide();
            }
            else
            {
                MessageBox.Show(this, "Username is not available");
            }

        Finish:

            EnableButton(false);
        }

        private void EnableButton(bool isRunning)
        {
            txtEmail.Enabled = txtPassword.Enabled = txtPassword2.Enabled = txtFullName.Enabled =
                dateTimeDOB.Enabled = txtPhone.Enabled = txtAddress.Enabled = txtKeySize.Enabled = 
            btnSignUp.Enabled = this.ControlBox = !isRunning;
        }

        private void FormSignUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }
    }
}
