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
using System.Threading;
using Ionic.Zip;

namespace CryptoSystemExpert
{
    public partial class FormRSAEncryptDecrypt : Form
    {
        int keySize;
        private string privateKey;
        private string publicKey;
        SaveFileDialog saveDlg;
        OpenFileDialog openDlg;
        FolderBrowserDialog browserDlg;

        public string[] currentChosenItems;
        
        public string SourceEn
        {
            get { return txtSouceEn.Text; }
            set { txtSouceEn.Text = value; }
        }
        public string TargetEn
        {
            get { return txtTargetEn.Text; }
            set { txtTargetEn.Text = value; }
        }
        public string SourceDe
        {
            get { return txtSourceDe.Text; }
            set { txtSourceDe.Text = value; }
        }
        public string TargetDe
        {
            get { return txtTargetDe.Text; }
            set { txtTargetDe.Text = value; }
        }

        public FormRSAEncryptDecrypt()
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


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtNumBit.Text == "")
            {
                keySize = 512;
                txtNumBit.Text = keySize.ToString();
            }
            else
                keySize = Int32.Parse(txtNumBit.Text) - Int32.Parse(txtNumBit.Text) % 8;

            if (keySize < 512) keySize = 512;
            if (keySize > 16384) keySize = 16384;

            MessageBox.Show(this, "Generate with key size: " + keySize.ToString());

            RunGenerate();
        }
        private void RunGenerate()
        {
            Thread t = new Thread(new ThreadStart(RunGenerateThread));
            t.Start();

        }
        private void RunGenerateThread()
        {
            txtNumBit.Enabled = btnGenerate.Enabled = btnSavePublicKey.Enabled = btnSavePrivateKey.Enabled = false;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize);

                publicKey = rsa.ToXmlString(false);
                privateKey = rsa.ToXmlString(true);
                rtxtPublicKey.Text = publicKey;
                rtxtPrivateKey.Text = privateKey;
                MessageBox.Show(this, "Generate key done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Generate key fail");
            }
            txtNumBit.Enabled = btnGenerate.Enabled = btnSavePublicKey.Enabled = btnSavePrivateKey.Enabled = true;
        }

        private void btnSavePublicKey_Click(object sender, EventArgs e)
        {
            if (rtxtPublicKey.Text == "")
            {
                MessageBox.Show(this, "No key to save");
                return;
            }
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "HDV file|*.hdv";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "public_key";
            saveDlg.Title = "Choose a folder and a name to save public key file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDlg.FileName, publicKey);
                MessageBox.Show(this, "Save public key successful");
            }
        }

        private void btnSavePrivateKey_Click(object sender, EventArgs e)
        {
            if (rtxtPrivateKey.Text == "")
            {
                MessageBox.Show(this, "No key to save");
                return;
            }
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "HDV file|*.hdv";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "private_key";
            saveDlg.Title = "Choose a folder and a name to save private key file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDlg.FileName, privateKey);
                MessageBox.Show(this, "Save private key successful");
            }
        }

        private byte[] RSA_Encrypt(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private byte[] RSA_Decrypt(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (rtxtPublicKey.Text == "")
            {
                MessageBox.Show(this, "You must generate key first");
                return;
            }

            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publicKey);
                byte[] bytes = RSA_Encrypt(Encoding.UTF8.GetBytes(rtxtPlainText.Text), rsa.ExportParameters(false), comboRSAMode.SelectedIndex != 0);
                rtxtEncryptedText.Text = Convert.ToBase64String(bytes);
            }
            catch
            {
                rtxtEncryptedText.Text = "";
                MessageBox.Show(this, "Key size is too small and string is too long");
            }
        }


        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (rtxtPrivateKey.Text == "")
            {
                MessageBox.Show(this, "You must generate key first");
                return;
            }

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            byte[] bytes = Convert.FromBase64String(rtxtEncryptedText.Text);
            string result;

            try
            {                
                result = Encoding.UTF8.GetString(RSA_Decrypt(bytes, rsa.ExportParameters(true), comboRSAMode.SelectedIndex != 0));
                rtxtDecryptedText.Text = result;
            }
            catch
            {
                rtxtDecryptedText.Text = "";
                MessageBox.Show(this, "Decrypt fail");
            }

        }

        private void FormRSAEncryptDecrypt_Load(object sender, EventArgs e)
        {
            comboRSAMode.Items.Add("Basic");
            comboRSAMode.Items.Add("Advanced");
            comboRSAMode.SelectedIndex = 1;

            comboRSAEn.Items.Add("Basic");
            comboRSAEn.Items.Add("Advanced");
            comboRSAEn.SelectedIndex = 1;
        }

        private string ByteArrayToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes)
                if (checkUppercase.Checked) result += b.ToString("X2").ToUpper();
                else result += b.ToString("X2").ToLower();
            return result;
        }

        private byte[] StringToByteArray(string hex)
        {
            hex = hex.ToUpper();

            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        private int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        private void btnSourceEn_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            openDlg.Title = "Choose the file you want to RSA encrypt";
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
            saveDlg.Title = "Choose a folder and a name to save RSA encrypted file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtTargetEn.Text = saveDlg.FileName;
            }
        }

        private void btnKeyEn_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "HDV file|*.hdv";
            openDlg.Title = "Choose the public key file";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtKeyEn.Text = openDlg.FileName;
                rtxtKeyEn.Text = System.IO.File.ReadAllText(txtKeyEn.Text);
            }
        }

        private void btnSourceDe_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            openDlg.Title = "Choose the file you want to RSA decrypt";
            if (openDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtSourceDe.Text = openDlg.FileName;
            }
        }

        private void btnTargetDe_Click(object sender, EventArgs e)
        {
            browserDlg = new FolderBrowserDialog();
            browserDlg.Description = "Select folder to contain RSA decrypted files";
            if (browserDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtTargetDe.Text = browserDlg.SelectedPath;
            }
        }

        private void btnKeyDe_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "HDV file|*.hdv";
            openDlg.Title = "Choose the private key file";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                txtKeyDe.Text = openDlg.FileName;
                rtxtKeyDe.Text = System.IO.File.ReadAllText(txtKeyDe.Text);
            }
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            if (txtSouceEn.Text == "" || txtTargetEn.Text == "" || txtKeyEn.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
                return;
            }

            RunEncrypt();
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            if (txtSourceDe.Text == "" || txtTargetDe.Text == "" || txtKeyDe.Text == "")
            {
                MessageBox.Show(this, "Check the parameters");
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

        private void RunEncryptThread()
        {
            btnSourceEn.Enabled = btnTargetEn.Enabled = btnKeyEn.Enabled = btnEncryptFile.Enabled =
                comboRSAEn.Enabled = checkCompress.Enabled = false;

            try
            {
                int err = EncryptFileRSA2(currentChosenItems, txtTargetEn.Text, txtKeyEn.Text, comboRSAEn.SelectedIndex != 0, checkCompress.Checked);
                MessageBox.Show(this, "Encrypt successful");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Encrypt fail");
            }

            btnSourceEn.Enabled = btnTargetEn.Enabled = btnKeyEn.Enabled = btnEncryptFile.Enabled =
                comboRSAEn.Enabled = checkCompress.Enabled = true;
        }

        private void RunDecryptThread()
        {
            btnSourceDe.Enabled = btnTargetDe.Enabled = btnKeyDe.Enabled = btnDecryptFile.Enabled = false;
            try
            {
                int err = DecryptFileRSA2(txtSourceDe.Text, txtTargetDe.Text, txtKeyDe.Text);
                if (err == 0) MessageBox.Show(this, "Decrypt successful");
                else if (err == 1) MessageBox.Show(this, "Error happen");                

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Decrypt fail");
            }
            btnSourceDe.Enabled = btnTargetDe.Enabled = btnKeyDe.Enabled = btnDecryptFile.Enabled = true;
        }

        public int EncryptFileRSA(string pathInput, string pathOutput, string pathKey, bool OAEPPadding)
        {
            RSACryptoServiceProvider ersa = new RSACryptoServiceProvider();
            ersa.FromXmlString(System.IO.File.ReadAllText(pathKey));

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            if (OAEPPadding) bw.Write(1);
            else bw.Write(0);

            long fileLength = br.BaseStream.Length;
            while (true)
            {
                try
                {
                    byte[] buffer = br.ReadBytes(ersa.KeySize / 8 - 42);
                    byte[] encryptBuff = RSA_Encrypt(buffer, ersa.ExportParameters(false), OAEPPadding);

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
            return 0;
        }
        public int EncryptFileRSA2(string[] pathInputs, string pathOutput, string pathKey, bool OAEPPadding, bool isCompress)
        {
            string tempFile = Directory.GetCurrentDirectory() + "/temp.zizi";

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (isCompress) zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    else zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                    for (int i = 0; i < pathInputs.Length; ++i)
                        zip.AddItem(pathInputs[i], "./");
                    zip.Save(tempFile);

                    EncryptFileRSA(tempFile, pathOutput, pathKey, OAEPPadding);
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

        public int DecryptFileRSA(string pathInput, string pathOutput, string pathKeyFile)
        {
            RSACryptoServiceProvider drsa = new RSACryptoServiceProvider();
            drsa.FromXmlString(System.IO.File.ReadAllText(pathKeyFile));

            BinaryReader br = new BinaryReader(new FileStream(pathInput, FileMode.Open));
            BinaryWriter bw = new BinaryWriter(new FileStream(pathOutput, FileMode.Create));

            bool OAEPPadding;
            int OAEP = br.ReadInt32();
            if (OAEP == 1) OAEPPadding = true;
            else OAEPPadding = false;

            long fileLength = br.BaseStream.Length;
            while (true)
            {
                try
                {
                    byte[] buffer = br.ReadBytes(drsa.KeySize / 8);
                    byte[] decryptBuff = RSA_Decrypt(buffer, drsa.ExportParameters(true), OAEPPadding);

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
            return 0;
        }
        public int DecryptFileRSA2(string pathInput, string pathOutput, string pathKeyFile)
        {
            string tempFile = Directory.GetCurrentDirectory() + "/temp.zizi";

            DecryptFileRSA(pathInput, tempFile, pathKeyFile);

            try
            {
                using (ZipFile zip = ZipFile.Read(tempFile))
                {
                    foreach(ZipEntry z in zip)
                    {
                        z.Extract(pathOutput, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch
            {
                System.IO.File.Delete(tempFile);
                return 1; // Error happen
            }

            System.IO.File.Delete(tempFile);
            return 0;
        }
        
    }
}
