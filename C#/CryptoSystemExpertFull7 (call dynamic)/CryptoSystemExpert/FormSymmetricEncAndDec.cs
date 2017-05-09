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
using Ionic.Zip;
using System.Threading;
using BlowFishCS;

namespace CryptoSystemExpert
{
    public partial class FormSymmetricEncAndDec : Form
    {
        CommonFunction cf = new CommonFunction();
        EncryptDecrypt ed = new EncryptDecrypt();
        
        OpenFileDialog openDlg;
        SaveFileDialog saveDlg;
        FolderBrowserDialog browserDlg;

        public string[] currentChosenItems;

        public string SourceEn
        {
            get { return txtSourceFileEn.Text; }
            set { txtSourceFileEn.Text = value; }
        }
        public string TargetEn
        {
            get { return txtTargetFileEn.Text; }
            set { txtTargetFileEn.Text = value; }
        }
        public string SourceDe
        {
            get { return txtSourceFileDe.Text; }
            set { txtSourceFileDe.Text = value; }
        }
        public string TargetDe
        {
            get { return txtTargetFileDe.Text; }
            set { txtTargetFileDe.Text = value; }
        }

        public FormSymmetricEncAndDec()
        {
            InitializeComponent();
        }

        public void EnableButtonWhenEncrypt()
        {
            groupBoxDecryptFile.Enabled = false;
        }
        public void EnableButtonWhenDecrypt()
        {
            groupBoxEncryptFile.Enabled = false;
        }

        private int TryEncryptAlgorithms(bool isRan = false)
        {
            string password = txtPassEn.Text;
            
            try
            {
                Random r = new Random();
                int ranAlgo, ranPadMode, ranCiMode;
                if (isRan)
                {
                    ranAlgo = r.Next(0, cf.Algorithms.Length);
                    ranPadMode = r.Next(0, cf.__paddingmode.Length);
                    ranCiMode = r.Next(0, cf.__modeofoperation.Length);
                }
                else
                {
                    ranAlgo = comboAlgo.SelectedIndex;
                    ranPadMode = comboPadding.SelectedIndex;
                    ranCiMode = comboMode.SelectedIndex;
                }

                string temp = ranAlgo.ToString() + ranPadMode.ToString() + ranCiMode.ToString();
                if (checkShowAlgo.Checked == true)
                    btnEn.Text = "Try " + temp + " ...";

                int err = EncryptFile2(currentChosenItems, txtTargetFileEn.Text, password, ranAlgo, ranPadMode, ranCiMode, checkCompress.Checked);

                btnEn.Text = "Encrypt";
                if (checkShowAlgo.Checked == true) MessageBox.Show(this, "Encrypt successful with " + temp);
                else MessageBox.Show(this, "Encrypt successful");
                return 0;
            }
            catch
            {
                btnEn.Text = "Encrypt";
                return -1;
            }
        }

        private void EncryptFile(string pathInput, string pathOutput, string password, int algo, int padMode, int ciMode)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordHeader = SHA256.Create().ComputeHash(passwordBytes); // Create password hash for encrypt header

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            // Random IV
            byte[] IV = new byte[16];
            (new Random()).NextBytes(IV);

            //// Get byte of Algorithm, padding, cipher mode and IV to encrypt, then saveDlg to encrypted file.
            byte[] bAlgo = BitConverter.GetBytes(algo);
            byte[] bPad = BitConverter.GetBytes(padMode);
            byte[] bCi = BitConverter.GetBytes(ciMode);

            // Copy (algo, padMode, ciMode, IV) to header.
            byte[] header = new byte[28];
            System.Buffer.BlockCopy(bAlgo, 0, header, 0, bAlgo.Length);
            System.Buffer.BlockCopy(bPad, 0, header, bAlgo.Length, bPad.Length);
            System.Buffer.BlockCopy(bCi, 0, header, bAlgo.Length + bPad.Length, bCi.Length);
            System.Buffer.BlockCopy(IV, 0, header, bAlgo.Length + bPad.Length + bCi.Length, IV.Length);

            // Create IV for encrypt header
            byte[] headerIV = new byte[16];
            for (int i = 0; i < 16; ++i) headerIV[i] = (byte)((i * i * i + i * i - i) % 256);

            // Encrypt header using AES algorithm.            
            byte[] encryptedHeader;
            try
            {
                encryptedHeader = ed.AES_Encrypt(header, passwordHeader, 0, 0, headerIV);
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
        }

        private int EncryptFile2(string[] pathInputs, string pathOutput, string password, int algo, int padMode, int ciMode, bool isCompress)
        {
            string tempFile = Directory.GetCurrentDirectory() + "/temp.zizi";
            
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = password;

                    if (isCompress) zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    else zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                    for (int i = 0; i < pathInputs.Length; ++i)
                        zip.AddItem(pathInputs[i], "./");
                    zip.Save(tempFile);                    
                    EncryptFile(tempFile, pathOutput, password, algo, padMode, ciMode);                    
                    System.IO.File.Delete(tempFile);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                System.IO.File.Delete(tempFile);
                throw ex;
            }
        }

        private void DecryptFile(string pathInput, string pathOutput, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordHeader = SHA256.Create().ComputeHash(passwordBytes); // Create password hash for decrypt header

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));


            // Read encrypted header
            byte[] encryptedHeader = new byte[32];
            br.Read(encryptedHeader, 0, encryptedHeader.Length);

            // Create IV for decrypt header
            byte[] headerIV = new byte[16];
            for (int i = 0; i < 16; ++i) headerIV[i] = (byte)((i * i * i + i * i - i) % 256);

            // Decrypt header
            byte[] decryptedHeader;
            try
            {
                decryptedHeader = ed.AES_Decrypt(encryptedHeader, passwordHeader, 0, 0, headerIV);
            }
            catch (Exception ex)
            {
                br.Close(); bw.Close();
                throw ex;
            }

            // Split memory to each member of (algo, padMode, ciMode, IV)            
            byte[] IV = new byte[16], bAlgo = new byte[4], bPad = new byte[4], bCi = new byte[4];
            Array.Copy(decryptedHeader, 0, bAlgo, 0, 4);
            Array.Copy(decryptedHeader, 4, bPad, 0, 4);
            Array.Copy(decryptedHeader, 8, bCi, 0, 4);
            Array.Copy(decryptedHeader, 12, IV, 0, 16);

            // Convert byte[] to int
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bAlgo);
                Array.Reverse(bPad);
                Array.Reverse(bCi);
            }
            int algo = BitConverter.ToInt32(bAlgo, 0), padMode = BitConverter.ToInt32(bPad, 0), ciMode = BitConverter.ToInt32(bCi, 0);


            // ===== Decrypt Content of File Process.        
            long fileLength = br.BaseStream.Length;

            while (true)
            {
                int plus = algo == 0 ? 16 : 8;
                if (algo == 4) plus = 0;

                try
                {
                    byte[] buffer = br.ReadBytes(cf.MAX_READ_BYTE + plus); // SỐ 16 này có thể thay đổi tùy theo thuật toán, có thể không +16 cho buffer cuối.
                    byte[] decryptBuff;

                    if (algo == 0) decryptBuff = ed.AES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 1) decryptBuff = ed.TDES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 2) decryptBuff = ed.DES_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else if (algo == 3) decryptBuff = ed.RC2_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);
                    else decryptBuff = ed.Blowfish_Decrypt(buffer, passwordBytes, padMode, ciMode, IV);


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
        }

        private int DecryptFile2(string pathInput, string pathOutput, string password)
        {
            string tempFile = Directory.GetCurrentDirectory() + "/temp.zizi";

            DecryptFile(pathInput, tempFile, password);

            try
            {
                using (ZipFile zip = ZipFile.Read(tempFile))
                {
                    zip.Password = password;
                    foreach (ZipEntry z in zip)
                    {
                        z.Extract(pathOutput, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch
            {
                System.IO.File.Delete(tempFile);
                return 1; //Error happen
            }

            System.IO.File.Delete(tempFile);
            return 0;
        }

        private string EncryptString(string input, string password, int algo, int padMode, int ciMode, byte[] IV)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] bytesEncrypted;
            if (algo == 0) bytesEncrypted = ed.AES_Encrypt(bytesToBeEncrypted, passwordBytes, padMode, ciMode, IV);
            else if (algo == 1) bytesEncrypted = ed.TDES_Encrypt(bytesToBeEncrypted, passwordBytes, padMode, ciMode, IV);
            else if (algo == 2) bytesEncrypted = ed.DES_Encrypt(bytesToBeEncrypted, passwordBytes, padMode, ciMode, IV);
            else if (algo == 3) bytesEncrypted = ed.RC2_Encrypt(bytesToBeEncrypted, passwordBytes, padMode, ciMode, IV);
            else bytesEncrypted = ed.Blowfish_Encrypt(bytesToBeEncrypted, passwordBytes, padMode, ciMode, IV);

            return Convert.ToBase64String(bytesEncrypted);
        }

        private string DecryptString(string input, string password, int algo, int padMode, int ciMode, byte[] IV)
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] bytesDecrypted;
            if (algo == 0) bytesDecrypted = ed.AES_Decrypt(bytesToBeDecrypted, passwordBytes, padMode, ciMode, IV);
            else if (algo == 1) bytesDecrypted = ed.TDES_Decrypt(bytesToBeDecrypted, passwordBytes, padMode, ciMode, IV);
            else if (algo == 2) bytesDecrypted = ed.DES_Decrypt(bytesToBeDecrypted, passwordBytes, padMode, ciMode, IV);
            else if (algo == 3) bytesDecrypted = ed.RC2_Decrypt(bytesToBeDecrypted, passwordBytes, padMode, ciMode, IV);
            else bytesDecrypted = ed.Blowfish_Decrypt(bytesToBeDecrypted, passwordBytes, padMode, ciMode, IV);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private void FormSymmetricEncAndDec_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < cf.Algorithms.Length; ++i)
            {
                comboAlgo.Items.Add(cf.Algorithms[i]);
                comboAlgoS.Items.Add(cf.Algorithms[i]);
            }
            comboAlgo.SelectedIndex = 0;
            comboAlgoS.SelectedIndex = 0;

            for (int i = 0; i < cf.PaddingModes.Length; ++i)
            {
                comboPadding.Items.Add(cf.PaddingModes[i]);
                comboPadModeS.Items.Add(cf.PaddingModes[i]);
            }
            comboPadding.SelectedIndex = 0;
            comboPadModeS.SelectedIndex = 0;

            for (int i = 0; i < cf.ModeOperations.Length; ++i)
            {
                comboMode.Items.Add(cf.ModeOperations[i]);
                comboCiModeS.Items.Add(cf.ModeOperations[i]);
            }
            comboMode.SelectedIndex = 0;
            comboCiModeS.SelectedIndex = 0;
        }

        private void btnOpenFileEn_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All File|*.*";
            openDlg.Title = "Choose the file you want to symmetric encrypt";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSourceFileEn.Text = openDlg.FileName;
            }
        }

        private void btnOpenFileDe_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All File|*.*";
            openDlg.Title = "Choose the file you want to symmetric decrypt";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtSourceFileDe.Text = openDlg.FileName;
            }
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            if (txtPassEn.TextLength < 5 || txtPassEn.TextLength > 32)
            {
                MessageBox.Show(this, "Password must be >= 5 and <= 32 characters"); return;
            }

            if (txtSourceFileEn.Text == "" || txtTargetFileEn.Text == "")
            {
                MessageBox.Show(this, "You must choose file first"); return;
            }
            RunEncrypt();
        }

        private void btnTargetFileEn_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "All file|*.*";
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Choose a folder and a name to save symmetric encrypted file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtTargetFileEn.Text = saveDlg.FileName;
            }
        }

        private void btnTargetFileDe_Click(object sender, EventArgs e)
        {
            browserDlg = new FolderBrowserDialog();
            browserDlg.Description = "Select folder to contain symmetric decrypted files";
            if (browserDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtTargetFileDe.Text = browserDlg.SelectedPath;
            }
        }

        private void btnDe_Click(object sender, EventArgs e)
        {
            if (txtPassDe.TextLength < 5 || txtPassDe.TextLength > 32)
            {
                MessageBox.Show(this, "Password must be >= 5 and <= 32 characters"); return;
            }

            if (txtSourceFileDe.Text == "" || txtTargetFileDe.Text == "")
            {
                MessageBox.Show(this, "You must choose file first"); return;
            }
            RunDecrypt();
        }

        private void RunDecryptThread()
        {
            btnDe.Enabled = btnOpenFileDe.Enabled = btnTargetFileDe.Enabled =
                txtPassDe.Enabled = false;
            try
            {
                int err = DecryptFile2(txtSourceFileDe.Text, txtTargetFileDe.Text, txtPassDe.Text);
                if (err == 0) MessageBox.Show(this, "Decrypt successful");
                else if (err == 1) MessageBox.Show(this, "Error happen");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Decrypt fail");
            }
            btnDe.Enabled = btnOpenFileDe.Enabled = btnTargetFileDe.Enabled =
                txtPassDe.Enabled = true;
        }
        private void RunDecrypt()
        {
            Thread t = new Thread(new ThreadStart(RunDecryptThread));
            t.Start();
        }

        private void RunEncryptThread()
        {

            btnEn.Enabled = btnOpenFileEn.Enabled = btnTargetFileEn.Enabled = txtPassEn.Enabled =                
                checkRanAll.Enabled = checkShowAlgo.Enabled = checkCompress.Enabled = false;
            comboAlgo.Enabled = comboPadding.Enabled = comboMode.Enabled = false;


            if (checkRanAll.Checked)
            {
                while (TryEncryptAlgorithms(true) == -1) ;
            }
            else
            {
                if (TryEncryptAlgorithms(false) == -1)
                {
                    MessageBox.Show(this, "Encrypt fail. Choose another (Algorithm, Padding Mode, Cipher Mode)");
                }
            }

            btnEn.Enabled = btnOpenFileEn.Enabled = btnTargetFileEn.Enabled = txtPassEn.Enabled =                
                checkRanAll.Enabled = checkShowAlgo.Enabled = checkCompress.Enabled = true;
            comboAlgo.Enabled = comboPadding.Enabled = comboMode.Enabled = !checkRanAll.Checked;
        }
        private void RunEncrypt()
        {
            Thread t = new Thread(new ThreadStart(RunEncryptThread));
            t.Start();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] IV = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(rtxtIV.Text));
                rtxtEncryptedText.Text = EncryptString(rtxtPlainText.Text, txtPassEnString.Text, comboAlgoS.SelectedIndex, comboPadModeS.SelectedIndex, comboCiModeS.SelectedIndex, IV);
            }
            catch
            {
                rtxtEncryptedText.Text = "";
                MessageBox.Show(this, "Encrypt fail. Choose another (algorithm, padding mode, mode of operation)");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] IV = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(rtxtIV.Text));
                rtxtDecryptedText.Text = DecryptString(rtxtEncryptedText.Text, txtPassDeString.Text, comboAlgoS.SelectedIndex, comboPadModeS.SelectedIndex, comboCiModeS.SelectedIndex, IV);
            }
            catch
            {
                rtxtDecryptedText.Text = "";
                MessageBox.Show(this, "Decrypt fail");
            }
        }

        private string ByteArrayToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes)
                result += b.ToString("X2").ToUpper();
            return result;
        }

        private void btnRandomIV_Click(object sender, EventArgs e)
        {
            byte[] IV = new byte[16];
            (new Random()).NextBytes(IV);

            rtxtIV.Text = ByteArrayToString(IV);
        }

        private void checkRanAll_CheckedChanged(object sender, EventArgs e)
        {
            comboAlgo.Enabled = comboPadding.Enabled = comboMode.Enabled = !checkRanAll.Checked;

        }
    }
}
