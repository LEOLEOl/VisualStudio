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

namespace DoAnThucHanh
{
    public partial class FormUpdateInfo : Form
    {
        private User _u;
        public bool isUpdate;

        public void SetUser(User u)
        {
            _u = u;
        }
        public FormUpdateInfo()
        {
            InitializeComponent();
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;      

            if (txtFullName.Text == "" || txtPhone.Text == "" || txtAddress.Text == ""
                || txtFullName.Text.Length > 50 || txtPhone.Text.Length > 50 || txtAddress.Text.Length > 50)
            {
                MessageBox.Show(this, "Check the parameters");
                isUpdate = false;
                return;
            }

            CommonFunction cf = new CommonFunction();

            // Split file .data first
            string temp = cf.userPath + _u.email + "/" + _u.email;
            string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };            
            cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

            if ((new HashSalt()).CheckFileHashSalt(Encoding.UTF8.GetBytes(password), temp + ".pass"))
            { // Kiểm tra đúng password

                // Gán các giá trị
                _u.fullname = txtFullName.Text;
                _u.DOB = dateTimeDOB.Text;
                _u.phone = txtPhone.Text;
                _u.address = txtAddress.Text;
                isUpdate = true;

                // Xóa file info cũ đi
                System.IO.File.Delete(temp + ".info");

                // Tạo file .info mới
                BinaryWriter bw = new BinaryWriter(new FileStream(temp + ".info", FileMode.Create));

                // Tạo đối tượng EncryptDecrypt
                EncryptDecrypt ed = new EncryptDecrypt();

                // Lấy public key để mã hóa
                string publicKey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));

                // Encrypt name
                byte[] efullname = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(_u.fullname), publicKey, false);
                bw.Write(efullname.Length);
                bw.Write(efullname);

                // Encrypt DOB
                byte[] eDOB = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(_u.DOB), publicKey, false);
                bw.Write(eDOB.Length);
                bw.Write(eDOB);

                // Encrypt phone 
                byte[] ephone = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(_u.phone), publicKey, false);
                bw.Write(ephone.Length);
                bw.Write(ephone);

                // Encrypt phone 
                byte[] eaddress = ed.RSA_Encrypt(Encoding.UTF8.GetBytes(_u.address), publicKey, false);
                bw.Write(eaddress.Length);
                bw.Write(eaddress);

                bw.Close();
                
                // Join Files
                string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                cf.JoinFile_Delete_Encrypt(source, temp + ".data");   

                MessageBox.Show(this, "Update Info successful");
            }
            else
            {
                // Join Files
                string[] source = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                cf.JoinFile_Delete_Encrypt(source, temp + ".data");   

                MessageBox.Show(this, "Wrong password");
                isUpdate = false;
            }
   
            this.Close();
        }

        private void FormUpdateInfo_Load(object sender, EventArgs e)
        {
            txtFullName.Text = _u.fullname;
            dateTimeDOB.Text = _u.DOB;
            txtPhone.Text = _u.phone;
            txtAddress.Text = _u.address;
        }

        public User GetUser()
        {
            return _u;
        }
    }
}
