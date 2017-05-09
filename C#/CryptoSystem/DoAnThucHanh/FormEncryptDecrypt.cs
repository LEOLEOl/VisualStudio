using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace DoAnThucHanh
{
    public partial class FormEncryptDecrypt : Form
    {
        private User _u;
        private OpenFileDialog openDlg;
        private SaveFileDialog saveDlg;
        private FormInputPass formPass;
        FormShowPass formShowPass;
        private bool isSync;
        private string syncPassInput;

        private CommonFunction cf = new CommonFunction();
        private EncryptDecrypt ed = new EncryptDecrypt();

        public void SetUser(User u)
        {
            _u = u;
        }

        public FormEncryptDecrypt()
        {
            InitializeComponent();
        }

        private void FormEncryptDecrypt_Load(object sender, EventArgs e)
        {
            CommonFunction cf = new CommonFunction();

            // Load Recipients
            string[] users = System.IO.Directory.GetDirectories(cf.userPath);
            for (int i = 0; i < users.Length; ++i)
            {
                int startIndex = 6;// Users/ has 6 characters
                comboRecipient.Items.Add(users[i].Substring(startIndex, users[i].Length - startIndex));
            }                
            comboRecipient.SelectedIndex = 0;

            // Load algorithms
            for (int i = 0; i < cf.Algorithms.Length; ++i)
                comboAlgo.Items.Add(cf.Algorithms[i]);            
            comboAlgo.SelectedIndex = 0;
            
            // Load Padding Mode
            for (int i = 0; i < cf.PaddingModes.Length; ++i)
                comboPadMode.Items.Add(cf.PaddingModes[i]);
            comboPadMode.SelectedIndex = 0;

            // Load Cipher Mode (mode of operation)
            for (int i = 0; i < cf.ModeOperations.Length; ++i)
                comboCiMode.Items.Add(cf.ModeOperations[i]);
            comboCiMode.SelectedIndex = 0;
        }

        private void btnSourceEn_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSouceEn.Text = openDlg.FileName;
            }
        }

        private void btnTargetEn_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "All file|*.*";
            saveDlg.RestoreDirectory = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtTargetEn.Text = saveDlg.FileName;
            }
        }

        private void btnSourceDe_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            if (openDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtSouceDe.Text = openDlg.FileName;
            }
        }

        private void btnTargetDe_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "All file|*.*";
            saveDlg.RestoreDirectory = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtTargetDe.Text = saveDlg.FileName;
            }
        }
        
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtSouceEn.Text == "" || txtTargetEn.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
                return;
            }

            RunEncrypt();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtSouceDe.Text == "" || txtTargetDe.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
                return;
            }
            if (txtPassword.Text != _u.password)
            {
                MessageBox.Show(this, "Wrong password");
                return;
            }

            RunDecrypt();
        }

        private void RunEncrypt()
        {
            Thread t = new Thread(new ThreadStart(RunEncryptThread));
            t.Start();
        }

        private void RunDecrypt()
        {
            Thread t = new Thread(new ThreadStart(RunDecryptThread));
            t.Start();
        }

        // 2 thread functions
        private void RunEncryptThread()
        {
            btnSourceEn.Enabled = btnTargetEn.Enabled = comboRecipient.Enabled = btnEncrypt.Enabled =
                checkRP.Enabled = checkSP.Enabled = checkFP.Enabled = checkShowAlgo.Enabled = false;

            if (checkRanAll.Checked)
            {
                isSync = false;
                while (TryEncryptAlgorithms() == -1);
            }
            else
            {
                if (TryEncryptAlgorithms(false) == -1)
                {
                    MessageBox.Show(this, "Choose another (Algorithm, Padding Mode, Cipher Mode)");
                }
            }
            

            btnSourceEn.Enabled = btnTargetEn.Enabled = comboRecipient.Enabled = btnEncrypt.Enabled =
                checkRP.Enabled = checkSP.Enabled = checkFP.Enabled = checkShowAlgo.Enabled = true;
        }

        private void RunDecryptThread()
        {
            btnSourceDe.Enabled = btnTargetDe.Enabled = txtPassword.Enabled = btnDecrypt.Enabled = false;
            
            try
            {
                int err = DecryptFile(txtSouceDe.Text, txtTargetDe.Text, _u.privatekey);
                if (err == 0) MessageBox.Show(this, "Decrypt successful");
                else if (err == 2) MessageBox.Show(this, "Wrong password");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Decrypt fail");
            }

            btnSourceDe.Enabled = btnTargetDe.Enabled = txtPassword.Enabled = btnDecrypt.Enabled = true;
        }

        private string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        // recipientName o day la <email>
        private string GetXMLPublicKeyRecipient(string recipientName)
        {
            CommonFunction cf = new CommonFunction();
            // Split file .data first
            string temp = cf.userPath + recipientName + "/" + recipientName;
            string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
            cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

            string XMLPublicKey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));

            cf.JoinFile_Delete_Encrypt(dest, temp + ".data");
            return XMLPublicKey;
        }
                
        private int TryEncryptAlgorithms(bool isRan = true)
        {
            string XMLPublicKeyRecipient = GetXMLPublicKeyRecipient(comboRecipient.SelectedItem.ToString());

            try
            {
                Random r = new Random();
                int ranAlgo;
                int ranPadMode;
                int ranCiMode;
                if (isRan)
                {
                    ranAlgo = r.Next(0, cf.Algorithms.Length);
                    ranPadMode = r.Next(0, cf.__paddingmode.Length);
                    ranCiMode = r.Next(0, cf.__modeofoperation.Length);
                }
                else
                {
                    ranAlgo = comboAlgo.SelectedIndex;
                    ranPadMode = comboPadMode.SelectedIndex;
                    ranCiMode = comboCiMode.SelectedIndex;
                }
                
                string temp = ranAlgo.ToString() + ranPadMode.ToString() + ranCiMode.ToString();
                if (checkShowAlgo.Checked == true)
                    btnEncrypt.Text = "Try " + temp + " ...";


                int err = EncryptFile(txtSouceEn.Text, txtTargetEn.Text, XMLPublicKeyRecipient, ranAlgo, ranPadMode, ranCiMode, Convert.ToInt32(checkRP.Checked), Convert.ToInt32(checkSP.Checked), Convert.ToInt32(checkFP.Checked), isSync);

                btnEncrypt.Text = "Encrypt";
                if (checkShowAlgo.Checked == true) MessageBox.Show(this, "Encrypt successful with " + temp);
                else MessageBox.Show(this, "Encrypt successful");
                return 0;
            }
            catch (Exception ex)
            {
                isSync = true;
                btnEncrypt.Text = "Encrypt";
                return -1;
            }
        }

        // Hàm Encrypt và Decrypt file
        private int EncryptFile(string pathInput, string pathOutput, string XMLPublicKey, int algo, int padMode, int ciMode, int isRanPass, int isShowPass, int isForcePass, bool isSync)
        {
            // Tạo đối tượng RSA
            RSACryptoServiceProvider ersa = new RSACryptoServiceProvider();
            ersa.FromXmlString(XMLPublicKey);
            string password;

            // Hiện dialog nhập pass khi người dùng muốn nhập pass
            if (isRanPass == 0 && isSync == false)
            { // Hiện dialog nhập pass 
                formPass = new FormInputPass();
                formPass.ShowDialog(this);


                password = formPass.InputPassword;

                formPass.Close();
            }
            else if (isSync == true)
            {
                password = syncPassInput;
            }
            else // Random password
            {
                password = GetRandomString() + GetRandomString() + GetRandomString() + GetRandomString() + GetRandomString();
            }
            syncPassInput = password;

            // Generate password bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash password for using in multiple algorithm, AES using 32-character password, DES using 8, RC2 and TDES using 16
            if (algo == 0) passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            else if (algo == 1 || algo == 3) passwordBytes = MD5.Create().ComputeHash(passwordBytes);
            else
            {
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                Array.Resize(ref passwordBytes, 8);
            }

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            // Random IV
            byte[] IV = new byte[16];
            (new Random()).NextBytes(IV);

            //// Get byte of Algorithm, padding, cipher mode and IV, ... to encrypt, then save to encrypted file.
            byte[] bAlgo = BitConverter.GetBytes(algo);
            byte[] bPad = BitConverter.GetBytes(padMode);
            byte[] bCi = BitConverter.GetBytes(ciMode);
            byte[] bIsRP = BitConverter.GetBytes(isRanPass);
            byte[] bIsSP = BitConverter.GetBytes(isShowPass);
            byte[] bIsFP = BitConverter.GetBytes(isForcePass);

            byte[] _bPass = Encoding.UTF8.GetBytes(password);
            byte[] bLenPass = BitConverter.GetBytes(_bPass.Length);
            byte[] bPass = new byte[64];
            Array.Copy(_bPass, 0, bPass, 0, _bPass.Length);
            for (int i = _bPass.Length; i < 64; ++i) bPass[i] = 0;

            // Copy element of header to header
            byte[] header = new byte[108];
            System.Buffer.BlockCopy(bAlgo, 0, header, 0, bAlgo.Length);
            System.Buffer.BlockCopy(bPad, 0, header, bAlgo.Length, bPad.Length);
            System.Buffer.BlockCopy(bCi, 0, header, bAlgo.Length + bPad.Length, bCi.Length);
            System.Buffer.BlockCopy(IV, 0, header, bAlgo.Length + bPad.Length + bCi.Length, IV.Length);
            System.Buffer.BlockCopy(bIsRP, 0, header, bAlgo.Length + bPad.Length + bCi.Length + IV.Length, bIsRP.Length);
            System.Buffer.BlockCopy(bIsSP, 0, header, bAlgo.Length + bPad.Length + bCi.Length + IV.Length + bIsRP.Length, bIsSP.Length);
            System.Buffer.BlockCopy(bIsFP, 0, header, bAlgo.Length + bPad.Length + bCi.Length + IV.Length + bIsRP.Length + bIsSP.Length, bIsFP.Length);
            System.Buffer.BlockCopy(bLenPass, 0, header, bAlgo.Length + bPad.Length + bCi.Length + IV.Length + bIsRP.Length + bIsSP.Length + bIsFP.Length, bLenPass.Length);
            System.Buffer.BlockCopy(bPass, 0, header, bAlgo.Length + bPad.Length + bCi.Length + IV.Length + bIsRP.Length + bIsSP.Length + bIsFP.Length + bLenPass.Length, bPass.Length);

            // Encrypt header using RSA algorithm.            
            byte[] encryptedHeader;
            try
            {
                encryptedHeader = ed.RSA_Encrypt(header, ersa.ExportParameters(false), true);
            }
            catch (Exception ex)
            {
                br.Close(); bw.Close();
                throw ex;
            }

            // Write enrypted header to file.
            bw.Write(encryptedHeader);

            // ===== Encrypt Content of File Process.
            long fileLength = br.BaseStream.Length;
            while (true)
            {
                try
                {
                    byte[] buffer = br.ReadBytes((int)cf.MAX_READ_BYTE);
                    byte[] encryptBuff;

                    if (algo == 0) encryptBuff = ed.AES_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 1) encryptBuff = ed.TDES_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 2) encryptBuff = ed.DES_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else encryptBuff = ed.RC2_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);

                    bw.Write(encryptBuff);
                    if (br.BaseStream.Position >= fileLength)
                    {
                        br.Close(); bw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    br.Close(); bw.Close();
                    throw ex;
                }
            }

            br.Close(); bw.Close(); return 0;
        }

        private int DecryptFile(string pathInput, string pathOutput, string XMLPrivateKey)
        {
            RSACryptoServiceProvider drsa = new RSACryptoServiceProvider();
            drsa.FromXmlString(XMLPrivateKey);

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            // Read encrypted header
            byte[] encryptedHeader = new byte[drsa.KeySize / 8];
            br.Read(encryptedHeader, 0, encryptedHeader.Length);

            // Decrypt header
            byte[] decryptedHeader;
            try
            {
                decryptedHeader = ed.RSA_Decrypt(encryptedHeader, drsa.ExportParameters(true), true);
            }
            catch (Exception ex)
            {
                br.Close(); bw.Close();
                throw ex;
            }

            // Split memory to each member of (algo, padMode, ciMode, IV)            
            byte[] IV = new byte[16], bAlgo = new byte[4], bPad = new byte[4], bCi = new byte[4], bIsRP = new byte[4], bIsSP = new byte[4], bIsFP = new byte[4], bLenPass = new byte[4], bPass = new byte[64];
            Array.Copy(decryptedHeader, 0, bAlgo, 0, 4);
            Array.Copy(decryptedHeader, 4, bPad, 0, 4);
            Array.Copy(decryptedHeader, 8, bCi, 0, 4);
            Array.Copy(decryptedHeader, 12, IV, 0, 16);
            Array.Copy(decryptedHeader, 28, bIsRP, 0, 4);
            Array.Copy(decryptedHeader, 32, bIsSP, 0, 4);
            Array.Copy(decryptedHeader, 36, bIsFP, 0, 4);
            Array.Copy(decryptedHeader, 40, bLenPass, 0, 4);
            Array.Copy(decryptedHeader, 44, bPass, 0, 64);

            // Convert byte[] to int
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bAlgo); Array.Reverse(bPad); Array.Reverse(bCi); Array.Reverse(bIsRP); Array.Reverse(bIsSP); Array.Reverse(bIsFP); Array.Reverse(bLenPass);
            }
            int algo = BitConverter.ToInt32(bAlgo, 0), padMode = BitConverter.ToInt32(bPad, 0), ciMode = BitConverter.ToInt32(bCi, 0),
                isRP = BitConverter.ToInt32(bIsRP, 0), isSP = BitConverter.ToInt32(bIsSP, 0), isFP = BitConverter.ToInt32(bIsFP, 0),
                lenPass = BitConverter.ToInt32(bLenPass, 0);


            byte[] _bPass = new byte[lenPass];
            Array.Copy(bPass, 0, _bPass, 0, lenPass);
            string password = Encoding.UTF8.GetString(_bPass);


            if (isSP == 1)
            {
                formShowPass = new FormShowPass();
                formShowPass.PassShow = password;
                formShowPass.ShowDialog(this);
            }

            if (isFP == 1)
            {
                formPass = new FormInputPass();
                formPass.ShowDialog(this);

                string passwordUser = formPass.InputPassword;
                if (passwordUser != password)
                {
                    br.Close(); bw.Close(); return 2;
                }
                formPass.Close();
            }

            // ===== Decrypt Content of File Process.        
            long fileLength = br.BaseStream.Length;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            if (algo == 0) passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            else if (algo == 1 || algo == 3) passwordBytes = MD5.Create().ComputeHash(passwordBytes);
            else
            {
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                Array.Resize(ref passwordBytes, 8);
            }

            while (true)
            {
                int plus = algo == 0 ? 16 : 8;
                try
                {
                    byte[] buffer = br.ReadBytes(cf.MAX_READ_BYTE + plus); // SỐ 16 này có thể thay đổi tùy theo thuật toán, có thể không +16 cho buffer cuối.
                    byte[] decryptBuff;

                    if (algo == 0) decryptBuff = ed.AES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 1) decryptBuff = ed.TDES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 2) decryptBuff = ed.DES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else decryptBuff = ed.RC2_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);

                    bw.Write(decryptBuff);
                    if (br.BaseStream.Position >= fileLength)
                    {
                        br.Close(); bw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    br.Close(); bw.Close();
                    throw ex;
                }
            }

            br.Close(); bw.Close(); return 0;
        }

        private void checkRanAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRanAll.Checked)
            {
                comboAlgo.Enabled = comboPadMode.Enabled = comboCiMode.Enabled = false;
            }
            else
            {
                comboAlgo.Enabled = comboPadMode.Enabled = comboCiMode.Enabled = true;
            }
        }
    }
}
