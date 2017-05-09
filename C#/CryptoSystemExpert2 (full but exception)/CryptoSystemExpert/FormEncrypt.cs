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
using System.IO;
using System.Security.Cryptography;
using Ionic.Zip;
using System.IO.Compression;

namespace CryptoSystem
{
    public partial class FormEncrypt : Form
    {
        private User _u;
        private OpenFileDialog openDlg;
        private SaveFileDialog saveDlg;
        private FormInputPass formPass;        
        private bool isSync;
        private string syncPassInput;

        public string[] currentChosenItems;

        private CommonFunction cf = new CommonFunction();
        private EncryptDecrypt ed = new EncryptDecrypt();
                
        public void SetUser(User u)
        {
            _u = u;
        }

        public string SourceFilePath
        {
            get { return txtSouceEn.Text; }
            set { txtSouceEn.Text = value; }
        }

        public string TargetFilePath
        {
            get { return txtTargetEn.Text; }
            set { txtTargetEn.Text = value; }
        }

        public FormEncrypt()
        {
            InitializeComponent();
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

        private void RunEncrypt()
        {
            Thread t = new Thread(new ThreadStart(RunEncryptThread));
            t.Start();
        }

        private void RunEncryptThread()
        {
            EnableButton(true);

            if (checkRanAll.Checked)
            {
                isSync = false;
                while (TryEncryptAlgorithms() == -1) ;
            }
            else
            {
                if (TryEncryptAlgorithms(false) == -1)
                {
                    MessageBox.Show(this, "Encrypt fail. Choose another (Algorithm, Padding Mode, Cipher Mode)");
                }
            }

            EnableButton(false);
        }

        private void EnableButton(bool isRunning)
        {
            btnTargetEn.Enabled = comboRecipient.Enabled = btnEncrypt.Enabled =
                checkRP.Enabled = checkSP.Enabled = checkFP.Enabled = checkShowAlgo.Enabled = checkRanAll.Enabled = checkCompress.Enabled =                
                !isRunning;

            comboAlgo.Enabled = comboPadMode.Enabled = comboCiMode.Enabled = !isRunning & !checkRanAll.Checked;
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

                int err = EncryptFile2(currentChosenItems, txtTargetEn.Text, XMLPublicKeyRecipient, ranAlgo, ranPadMode, ranCiMode, Convert.ToInt32(checkRP.Checked), Convert.ToInt32(checkSP.Checked), Convert.ToInt32(checkFP.Checked), isSync, checkCompress.Checked);               
                
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

        private int EncryptFile(string pathInput, string pathOutput, string XMLPublicKey, int algo, int padMode, int ciMode, int isRanPass, int isShowPass, int isForcePass, bool isSync, bool isCompress = false)
        {
            // Tạo đối tượng RSA
            RSACryptoServiceProvider ersa = new RSACryptoServiceProvider();
            ersa.FromXmlString(XMLPublicKey);
            string password;

            // Hiện dialog nhập pass khi người dùng muốn nhập pass
            if (isRanPass == 0 && isSync == false)
            { // Hiện dialog nhập pass 
                formPass = new FormInputPass();
                formPass.IsShowTextPassword = false;
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

            // Sinh ra byte password từ chuỗi password (string)
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        
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
            
                        
            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

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
                    else if (algo == 3) encryptBuff = ed.RC2_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else encryptBuff = ed.Blowfish_Encrypt(buffer, passwordBytes, padMode, ciMode, IV);

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

        private int EncryptFile2(string[] pathInputs, string pathOutput, string XMLPublicKey, int algo, int padMode, int ciMode, int isRanPass, int isShowPass, int isForcePass, bool isSync, bool isCompress)
        {
            string tempFile = Directory.GetCurrentDirectory() + "/temp.zizi";

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (isCompress) zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    else zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                    for (int i = 0; i < pathInputs.Length; ++i )
                        zip.AddItem(pathInputs[i], "./");
                    zip.Save(tempFile);
                    int r = EncryptFile(tempFile, pathOutput, XMLPublicKey, algo, padMode, ciMode, isRanPass, isShowPass, isForcePass, isSync);
                    System.IO.File.Delete(tempFile);
                    return r;
                }
            }
            catch (Exception ex)
            {
                System.IO.File.Delete(tempFile);
                throw ex;
            }
        }
        
        private string GetXMLPublicKeyRecipient(string recipientName)
        {
            // Split file .data first
            string temp = cf.userPath + recipientName + "/" + recipientName;
            string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
            cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

            string XMLPublicKey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));

            cf.JoinFile_Delete_Encrypt(dest, temp + ".data");
            return XMLPublicKey;
        }

        private string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        private void btnSourceEn_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();            
            
            openDlg.Filter = "All file|*.*";
            openDlg.Title = "Choose the file you want to hybrid encrypt";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSouceEn.Text = openDlg.FileName;
                txtTargetEn.Text = openDlg.FileName + "_encrypt";
            }
        }

        private void btnTargetEn_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "All file|*.*";
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Choose a folder and a name to save hybrid encrypted file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtTargetEn.Text = saveDlg.FileName;
            }
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

        private void FormEncrypt_Load(object sender, EventArgs e)
        {
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

        private void FormEncrypt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEncrypt_Click(sender, e);
            }
        }


    }
}
