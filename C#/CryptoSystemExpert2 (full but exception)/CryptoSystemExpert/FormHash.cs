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
using System.Threading;
using System.IO;
using DamienG.Security.Cryptography;
using softwareunion;
using FileHelper;
using CSharpTest.Net.Crypto;
using Mono.Security.Cryptography;

namespace CryptoSystem
{
    public partial class FormHash : Form
    {
        int radioButtonChosen = 0;
        int radioButtonChosenF = 0;

        public string PathFile
        {
            get { return txtPath.Text; }
            set {txtPath.Text = value; }
        }

        public FormHash()
        {
            InitializeComponent();
        }


        public string Hash(string string_or_filepath, int indexHashAlgorithm, bool isFile = false)
        {
            byte[] bytes;
            if (isFile) bytes = System.IO.File.ReadAllBytes(string_or_filepath);
            else bytes = Encoding.UTF8.GetBytes(string_or_filepath);

            switch (indexHashAlgorithm)
            {
                case 0:
                    bytes = (new MD5CryptoServiceProvider()).ComputeHash(bytes);
                    break;
                case 1:
                    bytes = (new SHA1CryptoServiceProvider()).ComputeHash(bytes);
                    break;
                case 2:
                    bytes = (new SHA256CryptoServiceProvider()).ComputeHash(bytes);
                    break;
                case 3:
                    bytes = (new SHA384CryptoServiceProvider()).ComputeHash(bytes);
                    break;
                case 4:
                    bytes = (new SHA512CryptoServiceProvider()).ComputeHash(bytes);
                    break;
                case 5:
                    bytes = (new RIPEMD160Managed()).ComputeHash(bytes);
                    break;
                case 6:
                    bytes = (new Crc32()).ComputeHash(bytes);
                    break;
                case 7:
                    bytes = (new Tiger().ComputeHash(bytes));
                    break;
                case 8:
                    bytes = (new Crc64Iso()).ComputeHash(bytes);
                    break;
                case 9:
                    AdlerChecksum acs = new AdlerChecksum();
                    acs.MakeForBuff(bytes);
                    return acs.ToString();
                    break;
                case 10:
                    bytes = (new MD4()).ComputeHash(bytes);
                    break;
                case 11:
                    bytes = (new WhirlpoolManaged()).ComputeHash(bytes);
                    break;
                case 12:
                    bytes = (new MD2Managed()).ComputeHash(bytes);
                    break;
                case 13:
                    return (new HashTableHashing.MurmurHash2Simple()).Hash(bytes, 64).ToString("X2");
                    break;
            }            

            string result = "";
            foreach (byte b in bytes)
                if (checkUppercase.Checked) result += b.ToString("X2").ToUpper();
                else result += b.ToString("X2").ToLower();
            return result;
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                if (radio == radioMD5) radioButtonChosen = 0;
                else if (radio == radioSHA1) radioButtonChosen = 1;
                else if (radio == radioSHA256) radioButtonChosen = 2;
                else if (radio == radioSHA384) radioButtonChosen = 3;
                else if (radio == radioSHA512) radioButtonChosen = 4;
                else if (radio == radioRIPEMD160) radioButtonChosen = 5;
                else if (radio == radioCRC32) radioButtonChosen = 6;
                else if (radio == radioTIGER1923) radioButtonChosen = 7;
                else if (radio == radioCRC64) radioButtonChosen = 8;
                else if (radio == radioAdler32) radioButtonChosen = 9;
                else if (radio == radioMD4) radioButtonChosen = 10;
                else if (radio == radioWhirlpool) radioButtonChosen = 11;
                else if (radio == radioMD2) radioButtonChosen = 12;
                else if (radio == radioMurmur2_64) radioButtonChosen = 13;

                rtxtStringHash.Text = Hash(txtString.Text, radioButtonChosen);
            }
        }

        private void radioButtonsFile_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            if (radio.Checked)
            {
                if (radio == radioFMD5) radioButtonChosenF = 0;
                else if (radio == radioFSHA1) radioButtonChosenF = 1;
                else if (radio == radioFSHA256) radioButtonChosenF = 2;
                else if (radio == radioFSHA384) radioButtonChosenF = 3;
                else if (radio == radioFSHA512) radioButtonChosenF = 4;
                else if (radio == radioFRIPEMD160) radioButtonChosenF = 5;
                else if (radio == radioFCRC32) radioButtonChosenF = 6;
                else if (radio == radioFTIGER1923) radioButtonChosenF = 7;
                else if (radio == radioFCRC64) radioButtonChosenF = 8;
                else if (radio == radioFAdler32) radioButtonChosenF = 9;
                else if (radio == radioFMD4) radioButtonChosenF = 10;
                else if (radio == radioFWhirlpool) radioButtonChosenF = 11;
                else if (radio == radioFMD2) radioButtonChosenF = 12;
                else if (radio == radioFMurmur2_64) radioButtonChosenF = 13;

                RunHashFile();                
            }
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            rtxtStringHash.Text = Hash(txtString.Text, radioButtonChosen);
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(txtPath.Text);
            labelFileSize.Text = file.Length.ToString() + " bytes";

            RunHashFile();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            openDlg.Title = "Choose the file you want to calculate hash value";
            if (openDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = openDlg.FileName;
            }
        }

        private void RunHashFile()
        {
            if (!System.IO.File.Exists(txtPath.Text))
            {
                MessageBox.Show(this, "File does not exist");
                return;
            }

            Thread t = new Thread(new ThreadStart(RunHashFileThread));
            t.Start();
            
        }
        private void RunHashFileThread()
        {
            EnableButton(true);
            try
            {
                rtxtFileHash.Text = Hash(txtPath.Text, radioButtonChosenF, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "File is too large");                
            }
            finally
            {
                EnableButton(false);
            }           
            
        }

        private void EnableButton(bool isRunning)
        {
            radioFMD5.Enabled = radioFSHA1.Enabled = radioFSHA256.Enabled = radioFSHA384.Enabled = radioFSHA512.Enabled =
                radioFRIPEMD160.Enabled = radioFCRC32.Enabled = radioFTIGER1923.Enabled = radioFCRC64.Enabled =
                radioFAdler32.Enabled = radioFMD4.Enabled = radioFWhirlpool.Enabled = radioFMD2.Enabled =
                radioFMurmur2_64.Enabled =
                btnBrowseFile.Enabled = btnCopyFile.Enabled = !isRunning;
        }

        private void rtxtCompare_TextChanged(object sender, EventArgs e)
        {
            if (rtxtFileHash.Text.ToUpper() == rtxtCompare.Text.ToUpper()) labelRB.Text = "Right";
            else labelRB.Text = "Wrong";
        }

        private void rtxtFileHash_TextChanged(object sender, EventArgs e)
        {
            rtxtCompare_TextChanged(sender, e);
        }

        private void checkUppercase_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUppercase.Checked)
            {
                rtxtStringHash.Text = rtxtStringHash.Text.ToString().ToUpper();
                rtxtFileHash.Text = rtxtFileHash.Text.ToString().ToUpper();
            }
            else
            {
                rtxtStringHash.Text = rtxtStringHash.Text.ToString().ToLower();
                rtxtFileHash.Text = rtxtFileHash.Text.ToString().ToLower();
            }
        }

        private void btnCopyString_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtxtStringHash.Text);
            MessageBox.Show(this, "Copied to clipboard");
        }

        private void buttonCopyFile_Click(object sender, EventArgs e)
        {
            if (rtxtFileHash.Text != "")
            {
                Clipboard.SetText(rtxtFileHash.Text);
                MessageBox.Show(this, "Copied to clipboard");
            }
        }

        private void rtxtCompareString_TextChanged(object sender, EventArgs e)
        {
            if (rtxtStringHash.Text.ToUpper() == rtxtCompareString.Text.ToUpper()) labelRBString.Text = "Right";
            else labelRBString.Text = "Wrong";
        }

        private void rtxtStringHash_TextChanged(object sender, EventArgs e)
        {
            rtxtCompareString_TextChanged(sender, e);
        }
    }
}
