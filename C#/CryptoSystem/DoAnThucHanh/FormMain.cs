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
using System.Security.Cryptography;

namespace DoAnThucHanh
{
    public partial class FormMain : Form
    {
        private User _u;        
        public void SetUser(User u)
        {
            _u = u;
        }
        public FormMain()
        {
            InitializeComponent();
        }

        public string LabelEmail
        {
            set { labelEmail.Text = value; }
            get { return labelEmail.Text; }
        }
        public string LabelName
        {
            set { labelName.Text = value; }
            get { return labelName.Text; }
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSignInUp f = new FormSignInUp();
            f.ShowDialog();
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            labelEmail.Text = _u.email;
            labelName.Text = _u.fullname;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            FormChangePass f = new FormChangePass();
            f.SetUser(_u);
            f.ShowDialog(this);

            // Update info to main form
            if (f.isUpdate)
                UpdateUserInfo(f.GetUser());
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            FormUpdateInfo f = new FormUpdateInfo();
            f.SetUser(_u);
            f.ShowDialog(this);

            // Update info to main form
            if (f.isUpdate)
                UpdateUserInfo(f.GetUser());
            
        }

        // Update User info from "FormUpdateInfo" (pass value back from that form)
        private void UpdateUserInfo(User u)
        {
            _u = u;
            labelEmail.Text = _u.email;
            labelName.Text = _u.fullname;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "All file|*.*";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "Untitled";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                CommonFunction cf = new CommonFunction();

                byte[] bDataEn = System.IO.File.ReadAllBytes(cf.userPath + _u.email + "/" + _u.email + ".dataen");

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(System.IO.File.ReadAllText((new CommonFunction()).serverKeyToSignExportImport));
                byte[] sigBDataEn = (new SignatureSalt(rsa)).CreateSignatureSalt(bDataEn);

                BinaryWriter bw = new BinaryWriter(new FileStream(saveDlg.FileName, FileMode.Create));
                bw.Write(bDataEn.Length);
                bw.Write(bDataEn);
                bw.Write(sigBDataEn.Length);
                bw.Write(sigBDataEn);
                bw.Close();
                MessageBox.Show(this, "Export successful");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                CommonFunction cf = new CommonFunction();

                BinaryReader br = new BinaryReader(new FileStream(openDlg.FileName, FileMode.Open));
                int l = br.ReadInt32();
                byte[] bDataEn = br.ReadBytes(l);
                l = br.ReadInt32();
                byte[] sigBDataEn = br.ReadBytes(l);
                br.Close();

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(System.IO.File.ReadAllText(cf.serverKeyToCheckExportImport));
                if ((new SignatureSalt(rsa)).CheckSignatureSalt(bDataEn, sigBDataEn))
                {
                    System.IO.File.WriteAllBytes(openDlg.FileName + ".dataen", bDataEn);

                    // Split file .data first
                    string temp = openDlg.FileName;
                    string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                    cf.SplitFile_Delete_Decrypt(temp + ".data", dest);
                    
                    User u = new User();
                    u.email = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".email"));
                    u.publickey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));
                    rsa.FromXmlString(u.publickey);
                    u.keysize = rsa.KeySize;

                    for (int i = 0; i < dest.Length; ++i)
                        System.IO.File.Delete(dest[i]);

                    FormImport f = new FormImport();
                    f.SetUser(u);
                    f.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Forged information");
                    return;
                }
            }            
        }

        private void btnSignCheck_Click(object sender, EventArgs e)
        {
            FormSignCheck f = new FormSignCheck();
            f.SetUser(_u);
            f.ShowDialog(this);
        }

        private void btnEncryptDecrypt_Click(object sender, EventArgs e)
        {
            FormEncryptDecrypt f = new FormEncryptDecrypt();
            f.SetUser(_u);
            f.ShowDialog(this);
        }
    }
}
