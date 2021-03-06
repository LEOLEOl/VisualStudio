﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace DoAnThucHanh
{
    public partial class FormSignInUp : Form
    {
        private User _u = new User();
        public FormSignInUp()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
                return;
            }

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            CommonFunction cf = new CommonFunction();

            if (!Directory.Exists(cf.userPath + email))
            {
                MessageBox.Show(this, "Username does not exist");
                return;
            }
            else
            {
                // Split file .data first
                string temp = cf.userPath + email + "/" + email;
                string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };                
                cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

                if ((new HashSalt()).CheckFileHashSalt(Encoding.UTF8.GetBytes(password), temp + ".pass"))
                {
                    // Tao doi tuong EncryptDecrypt
                    EncryptDecrypt ed = new EncryptDecrypt();
                    
                    // Giai ma file private key bang password
                    ed.DecryptFileSym(temp + ".private", temp + ".pri", password);
                    string XMLprivateKey = System.IO.File.ReadAllText(temp + ".pri");
                    System.IO.File.Delete(temp + ".pri");
                    
                    // Giai ma info bang private key
                    int l;
                    BinaryReader br = new BinaryReader(new FileStream(temp + ".info", FileMode.Open));

                    // Decrypt name
                    l = br.ReadInt32();
                    byte[] buff = br.ReadBytes(l);
                    byte[] bname = ed.RSA_Decrypt(buff, XMLprivateKey, false);
                    string name = Encoding.UTF8.GetString(bname);

                    // Decrypt DOB
                    l = br.ReadInt32();
                    buff = br.ReadBytes(l);
                    byte[] bDOB = ed.RSA_Decrypt(buff, XMLprivateKey, false);
                    string DOB = Encoding.UTF8.GetString(bDOB);

                    // Decrypt phone
                    l = br.ReadInt32();
                    buff = br.ReadBytes(l);
                    byte[] bphone = ed.RSA_Decrypt(buff, XMLprivateKey, false);
                    string phone = Encoding.UTF8.GetString(bphone);

                    // Decrypt address
                    l = br.ReadInt32();
                    buff = br.ReadBytes(l);
                    byte[] baddress = ed.RSA_Decrypt(buff, XMLprivateKey, false);
                    string address = Encoding.UTF8.GetString(baddress);

                    br.Close();
                                                            
                    _u.email = email;
                    _u.password = password;
                    _u.fullname = name;
                    _u.DOB = DOB;
                    _u.phone = phone;
                    _u.address = address;
                    _u.publickey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));
                    _u.privatekey = XMLprivateKey;

                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.FromXmlString(Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(cf.userPath + _u.email + "/" + _u.email + ".public")));
                    _u.keysize = rsa.KeySize;
                    
                    // Join Files
                    string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                    cf.JoinFile_Delete_Encrypt(source, temp + ".data");
                    
                    MessageBox.Show(this, "Welcome " + name);
                    this.Hide();

                    // Show main
                    FormMain f = new FormMain();
                    f.SetUser(_u); // Passing value to form Main
                    f.ShowDialog();
                    this.Close(); // Close form Sign In Up
                }
                else
                {
                    // Join Files
                    string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                    (new CommonFunction()).JoinFile_Delete_Encrypt(source, temp + ".data");

                    MessageBox.Show(this, "Wrong password");
                    return;
                }            
            }
        }
        
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp fSignUp = new FormSignUp();
            fSignUp.ShowDialog(this);
        }

        private void FormSignInUp_Load(object sender, EventArgs e)
        {
            string userpath = (new CommonFunction()).userPath;
            if (!System.IO.Directory.Exists(userpath))
            {
                System.IO.Directory.CreateDirectory(userpath);
            }
        }
    }
}
