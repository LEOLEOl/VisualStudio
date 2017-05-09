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
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Ionic.Zip;

namespace CryptoSystemExpert
{
    public partial class FormMain : Form
    {
        private User _u;

        private User uImport;
        OpenFileDialog openDlg;
        SaveFileDialog saveDlg;
        FolderBrowserDialog browserDlg;
        EncryptDecrypt ed = new EncryptDecrypt();
        CommonFunction cf = new CommonFunction();
        FormInputPass formPass;
        FormShowPass formShowPass;
        string PasswordUnzip;
        // Bien giu duong dan de paste
        string pathCopy;

        // Variables using when enable or disable s.th
        bool isChoosingFile;
        bool isChoosingFiles;
        bool isChoosingZipFile;

        // Cac bien de quan ly cac cua so 1, 2, 3
        bool isUsingMouseToNavigate1 = true;
        bool isUsingMouseToNavigate2 = true;
        bool isUsingMouseToNavigate3 = true;
        bool isUsingMouseToNavigate4 = true;
        int lastUsing = 1;


        // Function using for FormMain
        public void SetUser(User u)
        {
            _u = u;
        }
        private void UpdateUserInfo(User u)
        {
            _u = u;
            userToolStripMenuItem.Text = _u.fullname + " - " + _u.email;
        }


        // Form Main event
        public FormMain()
        {
            InitializeComponent();
            this.Opacity = 0.15;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Show();
            loadTextPath1();
            loadTextPath2();
            loadTextPath3();
            loadTextPath4();

            isChoosingFile = false;
            isChoosingFiles = false;
            isChoosingZipFile = false;

            FormSignInUp f = new FormSignInUp();
            f.ShowDialog(this);
            if (!f.IsLoginSuccess) Application.ExitThread();

            // Login succeed.
            SetUser(f.GetUser());
            userToolStripMenuItem.Text = _u.fullname + " - " + _u.email;
            this.Text = "CryptoSystemExpert - " + _u.email;

            string t = cf.userPath + "/" + _u.email + "/";
            string path1 = System.IO.File.ReadAllText(t + Program.fileContainPath1);
            string path2 = System.IO.File.ReadAllText(t + Program.fileContainPath2);
            string path3 = System.IO.File.ReadAllText(t + Program.fileContainPath3);
            string path4 = System.IO.File.ReadAllText(t + Program.fileContainPath4);
            string sOpacity = System.IO.File.ReadAllText(t + Program.pathSetting);

            // set opacity
            Program.opacity = Convert.ToDouble(sOpacity);
            this.Opacity = Program.opacity;

            // set path
            if (Directory.Exists(path1))
            {
                txtPath1.Text = path1;
                shellView1.Navigate(path1);
            }
            else shellView1.Navigate(Environment.SpecialFolder.MyComputer);
            if (Directory.Exists(path2))
            {
                txtPath2.Text = path2;
                shellView2.Navigate(path2);
            }
            else shellView2.Navigate(Environment.SpecialFolder.MyComputer);
            if (Directory.Exists(path3))
            {
                txtPath3.Text = path3;
                shellView3.Navigate(path3);
            }
            else shellView3.Navigate(Environment.SpecialFolder.MyComputer);
            if (Directory.Exists(path4))
            {
                txtPath4.Text = path4;
                shellView4.Navigate(path4);
            }
            else shellView4.Navigate(Environment.SpecialFolder.MyComputer);
        }
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.L)
                    if (lastUsing == 1) txtPath1.Focus();
                    else if (lastUsing == 2) txtPath2.Focus();
                    else if (lastUsing == 3) txtPath3.Focus();
                    else if (lastUsing == 4) txtPath4.Focus();

                if (e.KeyCode == Keys.W) this.Close();

                if (e.KeyCode == Keys.M)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }

            if (e.KeyCode == Keys.F8) this.WindowState = FormWindowState.Minimized;
            if (e.KeyCode == Keys.F11)
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
                else this.WindowState = FormWindowState.Maximized;
            }
            
            if (e.KeyCode == Keys.F4)
                if (lastUsing == 1) txtPath1.Focus();
                else if (lastUsing == 2) txtPath2.Focus();
                else if (lastUsing == 3) txtPath3.Focus();
                else if (lastUsing == 4) txtPath4.Focus();


            if (e.Alt && e.KeyCode == Keys.Left)
                if (lastUsing == 1) btnBack1_Click(sender, e);
                else if (lastUsing == 2) btnBack2_Click(sender, e);
                else if (lastUsing == 3) btnBack3_Click(sender, e);
                else if (lastUsing == 4) btnBack4_Click(sender, e);
            if (e.Alt && e.KeyCode == Keys.Right)
                if (lastUsing == 1) btnForward1_Click(sender, e);
                else if (lastUsing == 2) btnForward2_Click(sender, e);
                else if (lastUsing == 3) btnForward3_Click(sender, e);
                else if (lastUsing == 4) btnForward4_Click(sender, e);
            if (e.Alt && e.KeyCode == Keys.Up)
                if (lastUsing == 1) btnUp1_Click(sender, e);
                else if (lastUsing == 2) btnUp2_Click(sender, e);
                else if (lastUsing == 3) btnUp3_Click(sender, e);
                else if (lastUsing == 4) btnUp4_Click(sender, e);
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(this, "Do you want to quit?", "Confirm quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialog == DialogResult.Yes)
            {
                string t = cf.userPath + "/" + _u.email + "/";
                System.IO.File.WriteAllText(t + Program.fileContainPath1, txtPath1.Text);
                System.IO.File.WriteAllText(t + Program.fileContainPath2, txtPath2.Text);
                System.IO.File.WriteAllText(t + Program.fileContainPath3, txtPath3.Text);
                System.IO.File.WriteAllText(t + Program.fileContainPath4, txtPath4.Text);

                System.IO.File.WriteAllText(t + Program.pathSetting, Program.opacity.ToString());

                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        // Menustrip event
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "All file|*.*";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "Untitled";
            saveDlg.Title = "Choose a folder and a name to save certificate file";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                RunExport();
            }
        }
        private void RunExport()
        {
            Thread t = new Thread(new ThreadStart(RunExportThread));
            t.Start();
        }
        private void RunExportThread()
        {
            EnableButton(true);

            byte[] bDataEn = System.IO.File.ReadAllBytes(cf.userPath + _u.email + "/" + _u.email + ".dataen");

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(System.IO.File.ReadAllText(cf.serverKeyToSignExportImport));
            byte[] sigBDataEn = (new SignatureSalt(rsa)).CreateSignatureSalt(bDataEn);

            BinaryWriter bw = new BinaryWriter(new FileStream(saveDlg.FileName, FileMode.Create));
            bw.Write(bDataEn.Length);
            bw.Write(bDataEn);
            bw.Write(sigBDataEn.Length);
            bw.Write(sigBDataEn);
            bw.Close();
            MessageBox.Show(this, "Export successful");

            EnableButton(false);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDlg = new OpenFileDialog();
            openDlg.Filter = "All file|*.*";
            openDlg.Title = "Choose the file you want to view certificate";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                RunImport();
            }
        }
        private void RunImport()
        {
            Thread t = new Thread(new ThreadStart(RunImportThread));
            t.Start();
            t.Join();

            if (uImport != null)
            {
                FormImport f = new FormImport();
                f.SetUser(uImport);
                f.ShowDialog(this);
            }
        }
        private void RunImportThread()
        {
            EnableButton(true);

            try
            {
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
                    string temp = Directory.GetCurrentDirectory() + "/";
                    System.IO.File.WriteAllBytes(temp + ".dataen", bDataEn);

                    // Split file .data first                    
                    string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                    cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

                    uImport = new User();
                    uImport.email = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".email"));
                    uImport.publickey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));
                    rsa.FromXmlString(uImport.publickey);
                    uImport.keysize = rsa.KeySize;

                    for (int i = 0; i < dest.Length; ++i)
                        System.IO.File.Delete(dest[i]);

                }
                else
                {
                    uImport = null;
                    MessageBox.Show(this, "Forged information");
                }
            }
            catch
            {
                uImport = null;
                MessageBox.Show(this, "Wrong format");
            }

            EnableButton(false);
        }

        private void updateInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputPassword f = new FormInputPassword();
            f.SetUser(_u);
            f.ShowDialog(this);

            if (f.isOK)
                if (f.InputPassword == _u.password)
                {
                    RunUpdateInfo();
                }
        }
        private void RunUpdateInfo()
        {
            Thread t = new Thread(new ThreadStart(RunUpdateInfoThread));
            t.Start();
        }
        private void RunUpdateInfoThread()
        {
            EnableButton(true);
            FormUpdateInfo f = new FormUpdateInfo();
            f.SetUser(_u);
            f.ShowDialog(this);

            if (f.isUpdate)
                UpdateUserInfo(f.GetUser());
            EnableButton(false);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputPassword f = new FormInputPassword();
            f.SetUser(_u);
            f.ShowDialog(this);

            if (f.isOK)
                if (f.InputPassword == _u.password)
                {
                    RunChangePass();
                }
        }
        private void RunChangePass()
        {
            Thread t = new Thread(new ThreadStart(RunChangePassThread));
            t.Start();
        }
        private void RunChangePassThread()
        {
            EnableButton(true);
            FormChangePass f = new FormChangePass();
            f.SetUser(_u);
            f.ShowDialog(this);

            if (f.isUpdate)
                UpdateUserInfo(f.GetUser());
            EnableButton(false);
        }

        private void viewPublicKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewPublicPrivateKey f = new FormViewPublicPrivateKey();
            f.SetUser(_u);

            f.LabelKey = "Public Key";
            f.ButtonSave = "Save public key";
            f.Text = _u.email + " - " + _u.fullname + " - " + "public key";
            f.Key = _u.publickey;

            f.ShowDialog(this);
        }
        private void viewPrivateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputPassword fin = new FormInputPassword();
            fin.SetUser(_u);
            fin.ShowDialog(this);

            if (fin.isOK)
                if (fin.InputPassword == _u.password)
                {
                    FormViewPublicPrivateKey f = new FormViewPublicPrivateKey();
                    f.SetUser(_u);

                    f.LabelKey = "Private Key";
                    f.ButtonSave = "Save private key";
                    f.Text = _u.email + " - " + _u.fullname + " - " + "private key";
                    f.Key = _u.privatekey;

                    f.ShowDialog(this);
                }

        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to sign out?", "Confirm sign out", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Opacity = 0.15;
                userToolStripMenuItem.Text = "User";
                this.Text = "CryptoSystemExpert";

                // Ghi dữ liệu path xuống file
                string t = cf.userPath + "/" + _u.email + "/";
                System.IO.File.WriteAllText(t + Program.fileContainPath1, txtPath1.Text);
                System.IO.File.WriteAllText(t + Program.fileContainPath2, txtPath2.Text);
                System.IO.File.WriteAllText(t + Program.fileContainPath3, txtPath3.Text);
                System.IO.File.WriteAllText(t + Program.fileContainPath4, txtPath4.Text);
                System.IO.File.WriteAllText(t + Program.pathSetting, Program.opacity.ToString());

                isChoosingFiles = isChoosingFile = isChoosingZipFile = false;

                // Hien thi lai MyComputer
                shellView1.Navigate(Environment.SpecialFolder.MyComputer);
                shellView2.Navigate(Environment.SpecialFolder.MyComputer);
                shellView3.Navigate(Environment.SpecialFolder.MyComputer);
                shellView4.Navigate(Environment.SpecialFolder.MyComputer);

                // Hien thi form sign in
                FormSignInUp f = new FormSignInUp();
                f.ShowDialog(this);
                if (!f.IsLoginSuccess) Application.ExitThread();

                // Đã đăng nhập thành công
                SetUser(f.GetUser());
                userToolStripMenuItem.Text = _u.fullname + " - " + _u.email;
                this.Text = "CryptoSystemExpert - " + _u.email;

                t = cf.userPath + "/" + _u.email + "/";
                string path1 = System.IO.File.ReadAllText(t + Program.fileContainPath1);
                string path2 = System.IO.File.ReadAllText(t + Program.fileContainPath2);
                string path3 = System.IO.File.ReadAllText(t + Program.fileContainPath3);
                string path4 = System.IO.File.ReadAllText(t + Program.fileContainPath4);
                string sOpacity = System.IO.File.ReadAllText(t + Program.pathSetting);

                // Set path
                if (Directory.Exists(path1))
                {
                    txtPath1.Text = path1;
                    shellView1.Navigate(path1);
                }
                else shellView1.Navigate(Environment.SpecialFolder.MyComputer);
                if (Directory.Exists(path2))
                {
                    txtPath2.Text = path2;
                    shellView2.Navigate(path2);
                }
                else shellView2.Navigate(Environment.SpecialFolder.MyComputer);
                if (Directory.Exists(path3))
                {
                    txtPath3.Text = path3;
                    shellView3.Navigate(path3);
                }
                else shellView3.Navigate(Environment.SpecialFolder.MyComputer);
                if (Directory.Exists(path4))
                {
                    txtPath4.Text = path4;
                    shellView4.Navigate(path4);
                }
                else shellView4.Navigate(Environment.SpecialFolder.MyComputer);

                // Set opacity
                Program.opacity = Convert.ToDouble(sOpacity);
                this.Opacity = Program.opacity;
            }
        }


        // Common function using in this file
        public static bool IsLink(string shortcutFilename)
        {
            //return (Path.GetExtension(shortcutFilename) == ".lnk");

            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                return folderItem.IsLink;
            }
            return false; // not found
        }
        public static string GetShortcutTarget(string shortcutFilename)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                if (folderItem.IsLink)
                {
                    Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                    return link.Path;
                }
                return shortcutFilename;
            }
            return "";  // not found
        }

        public void copyDirectory(string Src, string Dst)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                    copyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory
                else
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }
        private void CopyDirectory(string Source, string Dest)
        {
            Directory.CreateDirectory(Dest + "/" + Path.GetFileName(Source));
            copyDirectory(Source, Dest + "/" + Path.GetFileName(Source));
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

            br.Close(); bw.Close(); return 0;
        }
        private int DecryptFile2(string pathInput, string pathOutput, string XMLPrivateKey)
        {
            string tempFile = Directory.GetCurrentDirectory() + "/temp.zizi";
            int r = DecryptFile(pathInput, tempFile, XMLPrivateKey);

            try
            {
                using (ZipFile zip = ZipFile.Read(tempFile))
                {
                    foreach (ZipEntry z in zip)
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
            return r;
        }


        // Shellviews' events
        private void shellView1_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(Program._currentChosenItem))
            {
                if (IsLink(Program._currentChosenItem))
                {
                    string target = GetShortcutTarget(Program._currentChosenItem);
                    if (File.Exists(target)) System.Diagnostics.Process.Start(Program._currentChosenItem);
                    else shellView1.Navigate(target);
                }
                else System.Diagnostics.Process.Start(Program._currentChosenItem);
            }
        }
        private void shellView2_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(Program._currentChosenItem))
            {
                if (IsLink(Program._currentChosenItem))
                {
                    string target = GetShortcutTarget(Program._currentChosenItem);
                    if (File.Exists(target)) System.Diagnostics.Process.Start(Program._currentChosenItem);
                    else shellView2.Navigate(target);
                }
                else System.Diagnostics.Process.Start(Program._currentChosenItem);
            }
        }
        private void shellView3_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(Program._currentChosenItem))
            {
                if (IsLink(Program._currentChosenItem))
                {
                    string target = GetShortcutTarget(Program._currentChosenItem);
                    if (File.Exists(target)) System.Diagnostics.Process.Start(Program._currentChosenItem);
                    else shellView3.Navigate(target);
                }
                else System.Diagnostics.Process.Start(Program._currentChosenItem);
            }
        }
        private void shellView4_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(Program._currentChosenItem))
            {
                if (IsLink(Program._currentChosenItem))
                {
                    string target = GetShortcutTarget(Program._currentChosenItem);
                    if (File.Exists(target)) System.Diagnostics.Process.Start(Program._currentChosenItem);
                    else shellView4.Navigate(target);
                }
                else System.Diagnostics.Process.Start(Program._currentChosenItem);
            }
        }

        private void shellView1_Navigated(object sender, EventArgs e)
        {
            //if (isUsingMouseToNavigate1)
                loadTextPath1();
            lastUsing = 1;
        }
        private void shellView2_Navigated(object sender, EventArgs e)
        {
            //if (isUsingMouseToNavigate2)
                loadTextPath2();
            lastUsing = 2;
        }
        private void shellView3_Navigated(object sender, EventArgs e)
        {
            //if (isUsingMouseToNavigate3)
                loadTextPath3();
            lastUsing = 3;
        }
        private void shellView4_Navigated(object sender, EventArgs e)
        {
            //if (isUsingMouseToNavigate4)
                loadTextPath4();
            lastUsing = 4;
        }

        private void shellView1_SelectionChanged(object sender, EventArgs e)
        {
            isUsingMouseToNavigate1 = true;
            lastUsing = 1;
            int len = shellView1.SelectedItems.Length;

            if (len > 0)
            {
                Program._currentChosenItems = new string[len];
                if (len == 1)
                {
                    Program._currentChosenItem = Program._currentChosenItems[0] = Path.GetFullPath(txtPath1.Text) + "\\" + shellView1.SelectedItems[0].DisplayName;
                }
                else
                {
                    Program._currentChosenItem = null;
                    for (int j = 0; j < len; j++)
                    {
                        Program._currentChosenItems[j] = Path.GetFullPath(txtPath1.Text) + "\\" + shellView1.SelectedItems[j].DisplayName;
                    }
                }
            }
            else
            {
                Program._currentChosenItem = null; Program._currentChosenItems = null;
            }

            EnableFeatureButton();
        }
        private void shellView2_SelectionChanged(object sender, EventArgs e)
        {
            isUsingMouseToNavigate2 = true;
            lastUsing = 2;
            int len = shellView2.SelectedItems.Length;

            if (len > 0)
            {
                Program._currentChosenItems = new string[len];
                if (len == 1)
                {
                    Program._currentChosenItem = Program._currentChosenItems[0] = Path.GetFullPath(txtPath2.Text) + "\\" + shellView2.SelectedItems[0].DisplayName;
                }
                else
                {
                    Program._currentChosenItem = null;
                    for (int j = 0; j < len; ++j)
                    {
                        Program._currentChosenItems[j] = Path.GetFullPath(txtPath2.Text) + "\\" + shellView2.SelectedItems[j].DisplayName;
                    }
                }
            }
            else
            {
                Program._currentChosenItem = null; Program._currentChosenItems = null;
            }
            EnableFeatureButton();
        }
        private void shellView3_SelectionChanged(object sender, EventArgs e)
        {
            isUsingMouseToNavigate3 = true;
            lastUsing = 3;
            int len = shellView3.SelectedItems.Length;

            if (len > 0)
            {
                Program._currentChosenItems = new string[len];
                if (len == 1)
                {
                    Program._currentChosenItem = Program._currentChosenItems[0] = Path.GetFullPath(txtPath3.Text) + "\\" + shellView3.SelectedItems[0].DisplayName;
                }
                else
                {
                    Program._currentChosenItem = null;
                    for (int j = 0; j < len; ++j)
                    {
                        Program._currentChosenItems[j] = Path.GetFullPath(txtPath3.Text) + "\\" + shellView3.SelectedItems[j].DisplayName;
                    }
                }
            }
            else
            {
                Program._currentChosenItem = null; Program._currentChosenItems = null;
            }

            EnableFeatureButton();
        }
        private void shellView4_SelectionChanged(object sender, EventArgs e)
        {
            isUsingMouseToNavigate4 = true;
            lastUsing = 4;
            int len = shellView4.SelectedItems.Length;

            if (len > 0)
            {
                Program._currentChosenItems = new string[len];
                if (len == 1)
                {
                    Program._currentChosenItem = Program._currentChosenItems[0] = Path.GetFullPath(txtPath4.Text) + "\\" + shellView4.SelectedItems[0].DisplayName;
                }
                else
                {
                    Program._currentChosenItem = null;
                    for (int j = 0; j < len; ++j)
                    {
                        Program._currentChosenItems[j] = Path.GetFullPath(txtPath4.Text) + "\\" + shellView4.SelectedItems[j].DisplayName;
                    }
                }
            }
            else
            {
                Program._currentChosenItem = null; Program._currentChosenItems = null;
            }

            EnableFeatureButton();
        }

        private void shellView_PreviewKeyDown_common(object sender, PreviewKeyDownEventArgs e, int ShellViewindex)
        {
            // Shift Delete
            if (e.Shift && e.KeyCode == Keys.Delete)
                if (MessageBox.Show(this, "Do you want to permanent delete files?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    RunDelete();

            // Open file and folder
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < Program._currentChosenItems.Length; ++i)
                    if (File.Exists(Program._currentChosenItems[i]))
                        System.Diagnostics.Process.Start(Program._currentChosenItems[i]);
            }
            // Show properties
            if (e.Alt && e.Shift) cf.ShowFileProperties(Program._currentChosenItem);

            if (e.Control)
            {
                // Ctrl W
                if (e.KeyCode == Keys.W) this.Close();
                // Minimize
                if (e.KeyCode == Keys.M) this.WindowState = FormWindowState.Minimized;
                // Copy to Clipboard
                if (e.KeyCode == Keys.C)
                {
                    StringCollection paths = new StringCollection();
                    for (int i = 0; i < Program._currentChosenItems.Length; ++i)
                        paths.Add(Program._currentChosenItems[i]);
                    Clipboard.SetFileDropList(paths);
                }
            }

            if (e.KeyCode == Keys.F8) this.WindowState = FormWindowState.Minimized;
            if (e.KeyCode == Keys.F11)
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
                else this.WindowState = FormWindowState.Maximized;
            }

            ////////////////////////
            ////////////////////////
            ContextMenu buttonMenu = new ContextMenu();
            ContextMenu buttonMenu2 = new ContextMenu();
            MenuItem[] menuItems = new MenuItem[] { 
                new MenuItem("Open", menuItemOpen_Click), 
                new MenuItem("Zip", menuItemZip_Click),  new MenuItem("Zip with input Password", menuItemZipPass_Click), new MenuItem("Zip with PriKey", menuItemZipPriKey_Click), new MenuItem("Unzip", menuItemUnzip_Click), 

                    new MenuItem("Encrypt Hybrid", menuItemEn_Click), new MenuItem("Decrypt Hybrid", menuItemDe_Click), 
                    new MenuItem("Encrypt Symmetric", menuItemEncryptSym_Click), new MenuItem("Decrypt Symmetric", menuItemDecryptSym_Click), 
                    new MenuItem("Encrypt RSA", menuItemEncryptRSA_Click), new MenuItem("Decrypt RSA", menuItemDecryptRSA_Click),

                    new MenuItem("Create Signature", menuItemSign_Click), new MenuItem("Verify Signature", menuItemCheck_Click), 

                    new MenuItem("Hash Calculator", menuItemHash_Click),                     
                    
                    new MenuItem("Settings", menuItemSettings_Click),
                    new MenuItem("4 explorer windows", menuItem4explorer_Click),
                    new MenuItem("3 explorer windows", menuItem3explorer_Click),
                    new MenuItem("2 explorer windows", menuItem2explorer_Click) };
            menuItems[0].DefaultItem = true;
            menuItems[5].BarBreak = true;
            menuItems[11].BarBreak = true;
            menuItems[13].BarBreak = true;
            menuItems[14].BarBreak = true;
            menuItems[15].Checked = true;
            menuItems[15].Enabled = false;

            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[0]);
            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[1]);
            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[2]);
            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[3]);
            if (isChoosingZipFile) buttonMenu.MenuItems.Add(menuItems[4]);

            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[5]);
            if (isChoosingFile) buttonMenu.MenuItems.Add(menuItems[6]);
            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[7]);
            if (isChoosingFile) buttonMenu.MenuItems.Add(menuItems[8]);
            if (isChoosingFiles) buttonMenu.MenuItems.Add(menuItems[9]);
            if (isChoosingFile) buttonMenu.MenuItems.Add(menuItems[10]);

            if (isChoosingFile) buttonMenu.MenuItems.Add(menuItems[11]);
            if (isChoosingFile) buttonMenu.MenuItems.Add(menuItems[12]);

            if (isChoosingFile) buttonMenu.MenuItems.Add(menuItems[13]);

            buttonMenu.MenuItems.Add(menuItems[14]);
            buttonMenu.MenuItems.Add(menuItems[15]);
            buttonMenu.MenuItems.Add(menuItems[16]);
            buttonMenu.MenuItems.Add(menuItems[17]);

            if (ShellViewindex == 1)
            {
                // Rename
                if (e.KeyCode == Keys.F2) shellView1.RenameSelectedItem();
                // Ctrl L
                if (e.KeyCode == Keys.F4 || (e.Control && e.KeyCode == Keys.L)) txtPath1.Focus();
                // Refresh
                if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
                {
                    shellView1.Refresh(); shellView1.RefreshContents();
                }
                // Show Context Menu
                if (e.Shift && e.KeyCode == Keys.F10) buttonMenu2.Show(shellView1, new System.Drawing.Point(20, 20));

                // Navigate button
                if (e.Alt)
                {
                    // Back
                    if (e.KeyCode == Keys.Left) btnBack1_Click(sender, e);
                    // Forward
                    if (e.KeyCode == Keys.Right) btnForward1_Click(sender, e);
                    // Up - go to parent
                    if (e.KeyCode == Keys.Up) btnUp1_Click(sender, e);
                }


                // Ctrl Shift N (create new folder)
                if (e.Shift && e.KeyCode == Keys.N)
                    if (shellView1.CanCreateFolder) shellView1.CreateNewFolder();

                // Personal ContextMenu
                if (e.Control && e.Alt)
                {
                    buttonMenu.Show(shellView1, new System.Drawing.Point(20, 20));
                }

                // Paste from Clipboard
                if (e.Control && e.KeyCode == Keys.V)
                {
                    pathCopy = txtPath1.Text;
                    RunPasteThread();
                }
            }
            else if (ShellViewindex == 2)
            {
                // Rename
                if (e.KeyCode == Keys.F2) shellView2.RenameSelectedItem();
                // Ctrl L
                if (e.KeyCode == Keys.F4 || (e.Control && e.KeyCode == Keys.L)) txtPath2.Focus();
                // Refresh
                if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
                {
                    shellView2.Refresh(); shellView2.RefreshContents();
                }
                // Show Context Menu
                if (e.Shift && e.KeyCode == Keys.F10) buttonMenu2.Show(shellView2, new System.Drawing.Point(20, 20));

                // Navigate button
                if (e.Alt)
                {
                    // Back
                    if (e.KeyCode == Keys.Left) btnBack2_Click(sender, e);
                    // Forward
                    if (e.KeyCode == Keys.Right) btnForward2_Click(sender, e);
                    // Up - go to parent
                    if (e.KeyCode == Keys.Up) btnUp2_Click(sender, e);
                }


                // Ctrl Shift N (create new folder)
                if (e.Shift && e.KeyCode == Keys.N)
                    if (shellView2.CanCreateFolder) shellView2.CreateNewFolder();

                // Personal ContextMenu
                if (e.Control && e.Alt)
                {
                    buttonMenu.Show(shellView2, new System.Drawing.Point(20, 20));
                }

                // Paste from Clipboard
                if (e.Control && e.KeyCode == Keys.V)
                {
                    pathCopy = txtPath2.Text;
                    RunPasteThread();
                }
            }
            else if (ShellViewindex == 3)
            {
                // Rename
                if (e.KeyCode == Keys.F2) shellView3.RenameSelectedItem();
                // Ctrl L
                if (e.KeyCode == Keys.F4 || (e.Control && e.KeyCode == Keys.L)) txtPath3.Focus();
                // Refresh
                if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
                {
                    shellView3.Refresh(); shellView3.RefreshContents();
                }
                // Show Context Menu
                if (e.Shift && e.KeyCode == Keys.F10) buttonMenu2.Show(shellView3, new System.Drawing.Point(20, 20));

                // Navigate button
                if (e.Alt)
                {
                    // Back
                    if (e.KeyCode == Keys.Left) btnBack3_Click(sender, e);
                    // Forward
                    if (e.KeyCode == Keys.Right) btnForward3_Click(sender, e);
                    // Up - go to parent
                    if (e.KeyCode == Keys.Up) btnUp3_Click(sender, e);
                }


                // Ctrl Shift N (create new folder)
                if (e.Shift && e.KeyCode == Keys.N)
                    if (shellView3.CanCreateFolder) shellView3.CreateNewFolder();

                // Personal ContextMenu
                if (e.Control && e.Alt)
                {
                    buttonMenu.Show(shellView3, new System.Drawing.Point(20, 20));
                }

                // Paste from Clipboard
                if (e.Control && e.KeyCode == Keys.V)
                {
                    pathCopy = txtPath3.Text;
                    RunPasteThread();
                }
            }
            else if (ShellViewindex == 4)
            {
                // Rename
                if (e.KeyCode == Keys.F2) shellView4.RenameSelectedItem();
                // Ctrl L
                if (e.KeyCode == Keys.F4 || (e.Control && e.KeyCode == Keys.L)) txtPath4.Focus();
                // Refresh
                if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
                {
                    shellView4.Refresh(); shellView4.RefreshContents();
                }
                // Show Context Menu
                if (e.Shift && e.KeyCode == Keys.F10) buttonMenu2.Show(shellView4, new System.Drawing.Point(20, 20));

                // Navigate button
                if (e.Alt)
                {
                    // Back
                    if (e.KeyCode == Keys.Left) btnBack4_Click(sender, e);
                    // Forward
                    if (e.KeyCode == Keys.Right) btnForward4_Click(sender, e);
                    // Up - go to parent
                    if (e.KeyCode == Keys.Up) btnUp4_Click(sender, e);
                }


                // Ctrl Shift N (create new folder)
                if (e.Shift && e.KeyCode == Keys.N)
                    if (shellView4.CanCreateFolder) shellView4.CreateNewFolder();

                // Personal ContextMenu
                if (e.Control && e.Alt)
                {
                    buttonMenu.Show(shellView4, new System.Drawing.Point(20, 20));
                }

                // Paste from Clipboard
                if (e.Control && e.KeyCode == Keys.V)
                {
                    pathCopy = txtPath4.Text;
                    RunPaste();
                }
            }

        }
        private void shellView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            shellView_PreviewKeyDown_common(sender, e, 1);
        }
        private void shellView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            shellView_PreviewKeyDown_common(sender, e, 2);
        }
        private void shellView3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            shellView_PreviewKeyDown_common(sender, e, 3);
        }
        private void shellView4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            shellView_PreviewKeyDown_common(sender, e, 4);
        }


        // textPaths' event
        private void txtPath1_KeyDown(object sender, KeyEventArgs e)
        {
            isUsingMouseToNavigate1 = false;
            lastUsing = 1;
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(txtPath1.Text))
                {
                    shellView1.Navigate(txtPath1.Text);
                }
                else if (File.Exists(txtPath1.Text))
                {
                    System.Diagnostics.Process.Start(txtPath1.Text);
                    loadTextPath1();
                }
                else
                {
                    loadTextPath1();
                    MessageBox.Show(this, "The path is invalid");
                }
            }
        }
        private void txtPath2_KeyDown(object sender, KeyEventArgs e)
        {
            isUsingMouseToNavigate2 = false;
            lastUsing = 2;
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(txtPath2.Text))
                {
                    shellView2.Navigate(txtPath2.Text);
                }
                else if (File.Exists(txtPath2.Text))
                {
                    System.Diagnostics.Process.Start(txtPath2.Text);
                    loadTextPath2();
                }
                else
                {
                    loadTextPath2();
                    MessageBox.Show(this, "The path is invalid");
                }
            }
        }
        private void txtPath3_KeyDown(object sender, KeyEventArgs e)
        {
            isUsingMouseToNavigate3 = false;
            lastUsing = 3;
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(txtPath3.Text))
                {
                    shellView3.Navigate(txtPath3.Text);
                }
                else if (File.Exists(txtPath3.Text))
                {
                    System.Diagnostics.Process.Start(txtPath3.Text);
                    loadTextPath3();
                }
                else
                {
                    loadTextPath3();
                    MessageBox.Show(this, "The path is invalid");
                }
            }
        }
        private void txtPath4_KeyDown(object sender, KeyEventArgs e)
        {
            isUsingMouseToNavigate4 = false;
            lastUsing = 4;
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(txtPath4.Text))
                {
                    shellView4.Navigate(txtPath4.Text);
                }
                else if (File.Exists(txtPath4.Text))
                {
                    System.Diagnostics.Process.Start(txtPath4.Text);
                    loadTextPath4();
                }
                else
                {
                    loadTextPath4();
                    MessageBox.Show(this, "The path is invalid");
                }
            }
        }


        // buttons' event in shellView (navigating button)
        private void btnBack1_Click(object sender, EventArgs e)
        {
            if (shellView1.CanNavigateBack)
                shellView1.NavigateBack();
            loadTextPath1();
        }
        private void btnUp1_Click(object sender, EventArgs e)
        {
            if (shellView1.CanNavigateParent)
                shellView1.NavigateParent();
            loadTextPath1();
        }
        private void btnForward1_Click(object sender, EventArgs e)
        {
            if (shellView1.CanNavigateForward)
                shellView1.NavigateForward();
            loadTextPath1();
        }
        private void btnBack2_Click(object sender, EventArgs e)
        {
            if (shellView2.CanNavigateBack)
                shellView2.NavigateBack();
            loadTextPath2();
        }
        private void btnUp2_Click(object sender, EventArgs e)
        {
            if (shellView2.CanNavigateParent)
                shellView2.NavigateParent();
            loadTextPath2();
        }
        private void btnForward2_Click(object sender, EventArgs e)
        {
            if (shellView2.CanNavigateForward)
                shellView2.NavigateForward();
            loadTextPath2();
        }
        private void btnBack3_Click(object sender, EventArgs e)
        {
            if (shellView3.CanNavigateBack)
                shellView3.NavigateBack();
            loadTextPath3();
        }
        private void btnUp3_Click(object sender, EventArgs e)
        {
            if (shellView3.CanNavigateParent)
                shellView3.NavigateParent();
            loadTextPath3();
        }
        private void btnForward3_Click(object sender, EventArgs e)
        {
            if (shellView3.CanNavigateForward)
                shellView3.NavigateForward();
            loadTextPath3();
        }
        private void btnBack4_Click(object sender, EventArgs e)
        {
            if (shellView4.CanNavigateBack)
                shellView4.NavigateBack();
            loadTextPath4();
        }
        private void btnUp4_Click(object sender, EventArgs e)
        {
            if (shellView4.CanNavigateParent)
                shellView4.NavigateParent();
            loadTextPath4();
        }
        private void btnForward4_Click(object sender, EventArgs e)
        {
            if (shellView4.CanNavigateForward)
                shellView4.NavigateForward();
            loadTextPath4();
        }


        // buttons' event (feature buttons)
        private void btnOpen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program._currentChosenItems.Length; ++i)
                System.Diagnostics.Process.Start(Program._currentChosenItems[i]);
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Zip file|*.zip";
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Choose a folder and a name to save zipped file";
            if (Program._currentChosenItems.Length == 1)
                saveDlg.FileName = Path.GetFileName(Program._currentChosenItems[0]) + "_nopass.zip";
            else saveDlg.FileName = Path.GetFileName(Directory.GetParent(Program._currentChosenItems[0]).ToString()) + "_nopass.zip";
            if (saveDlg.ShowDialog(this) == DialogResult.OK)
            {
                RunZip();
            }
        }
        private void RunZip()
        {
            Thread t = new Thread(new ThreadStart(RunZipThread));
            t.Start();
        }
        private void RunZipThread()
        {
            EnableButton(true);

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (MessageBox.Show(this, "Do you want to best compress these files?", "Best compression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    else
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                    for (int j = 0; j < Program._currentChosenItems.Length; j++)
                    {
                        string tmp = Environment.ExpandEnvironmentVariables(Program._currentChosenItems[j]);
                        zip.AddItem(tmp, "./");
                    }
                    zip.Save(saveDlg.FileName);
                    MessageBox.Show(this, "Zip files successful");
                }
            }
            catch
            {
                MessageBox.Show(this, "Zip files fail");
            }

            EnableButton(false);
        }

        private void btnZipPass_Click(object sender, EventArgs e)
        {
            saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Zip file|*.zip";
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Choose a folder and a name to save Password zipped file";
            if (Program._currentChosenItems.Length == 1)
                saveDlg.FileName = Path.GetFileName(Program._currentChosenItems[0]) + "_pass.zip";
            else saveDlg.FileName = Path.GetFileName(Directory.GetParent(Program._currentChosenItems[0]).ToString()) + "_pass.zip";
            if (saveDlg.ShowDialog(this) == DialogResult.OK)
            {
                RunZipPass();
            }
        }
        private void RunZipPass()
        {
            Thread t = new Thread(new ThreadStart(RunZipPassThread));
            t.Start();
        }
        private void RunZipPassThread()
        {
            EnableButton(true);

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (MessageBox.Show(this, "Do you want to best compress these files?", "Best compression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    else
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                    FormInputPass f = new FormInputPass();
                    f.LabelInputPass = "Input password";
                    f.IsShowTextPassword = false;
                    f.Text = "Input new password to zip files";
                    f.ShowDialog(this);

                    if (f.IsOK)
                    {
                        zip.Password = f.InputPassword;

                        for (int j = 0; j < Program._currentChosenItems.Length; j++)
                        {
                            string tmp = Environment.ExpandEnvironmentVariables(Program._currentChosenItems[j]);
                            zip.AddItem(tmp, "./");
                        }
                        zip.Save(saveDlg.FileName);
                        MessageBox.Show(this, "Zip files successful");
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "Zip files fail");
            }

            EnableButton(false);
        }

        private void btnZipPriKey_Click(object sender, EventArgs e)
        {
            FormInputPassword f = new FormInputPassword();
            f.SetUser(_u);
            f.Text = "Input password to use private key to zip";
            f.ShowDialog(this);

            if (f.isOK)
                if (f.InputPassword == _u.password)
                {
                    saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "Zip file|*.zip";
                    saveDlg.RestoreDirectory = true;
                    saveDlg.Title = "Choose a folder and a name to save Private zipped file";
                    if (Program._currentChosenItems.Length == 1)
                        saveDlg.FileName = Path.GetFileName(Program._currentChosenItems[0]) + "_prikey.zip";
                    else saveDlg.FileName = Path.GetFileName(Directory.GetParent(Program._currentChosenItems[0]).ToString()) + "_prikey.zip";
                    if (saveDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        RunZipPriKey();
                    }
                }
        }
        private void RunZipPriKey()
        {
            Thread t = new Thread(new ThreadStart(RunZipPriKeyThread));
            t.Start();
        }
        private void RunZipPriKeyThread()
        {
            EnableButton(true);

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = _u.privatekey;

                    if (MessageBox.Show(this, "Do you want to best compress these files?", "Best compression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    else
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                    for (int j = 0; j < Program._currentChosenItems.Length; j++)
                    {
                        string tmp = Environment.ExpandEnvironmentVariables(Program._currentChosenItems[j]);
                        zip.AddItem(tmp, "./");
                    }
                    zip.Save(saveDlg.FileName);
                    MessageBox.Show(this, "Zip files successful");
                }
            }
            catch
            {
                MessageBox.Show(this, "Zip files fail");
            }

            EnableButton(false);
        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            if (ZipFile.CheckZipPassword(Program._currentChosenItem, ""))
            { // No pass                     
                goto execute;
            }
            else
            {
                DialogResult ds = MessageBox.Show(this, "Someone zipped this file with password \n\nPress Yes to use your private key to unzip \nPress No to input password yourself \nPress Cancel to abort", "Confirm unzip password file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    FormInputPassword f = new FormInputPassword();
                    f.SetUser(_u);
                    f.Text = "Input password to use privatekey to unzip";
                    f.ShowDialog(this);

                    if (f.isOK)
                        if (f.InputPassword == _u.password)
                        {
                            PasswordUnzip = _u.privatekey;
                            if (ZipFile.CheckZipPassword(Program._currentChosenItem, PasswordUnzip) == false)
                            {
                                MessageBox.Show(this, "You might have no permission to unzip this file");
                                return;
                            }
                            else
                            {
                                goto execute;
                            }
                        }
                        else return;
                    else return;
                }
                else if (ds == System.Windows.Forms.DialogResult.No)
                {
                    FormInputPass f = new FormInputPass();
                    f.LabelInputPass = "Input password";
                    f.Text = "Input password to unzip";
                    f.ShowDialog(this);

                    if (f.IsOK)
                    {
                        PasswordUnzip = f.InputPassword;
                        if (ZipFile.CheckZipPassword(Program._currentChosenItem, PasswordUnzip) == false)
                        {
                            MessageBox.Show(this, "You might have no permission to unzip this file");
                            return;
                        }
                        else
                        {
                            goto execute;
                        }
                    }
                    else return;
                }
                else
                { // Cancel
                    return;
                }
            }

        execute: ;
            browserDlg = new FolderBrowserDialog();
            browserDlg.Description = "Select folder to contain unzipped files";
            if (browserDlg.ShowDialog(this) == DialogResult.OK)
            {
                RunUnzip();
            }

        }
        private void RunUnzip()
        {
            Thread t = new Thread(new ThreadStart(RunUnzipThread));
            t.Start();
        }
        private void RunUnzipThread()
        {
            EnableButton(true);

            try
            {
                string tmp = Environment.ExpandEnvironmentVariables(Program._currentChosenItem);

                using (ZipFile zip = ZipFile.Read(tmp))
                {
                    zip.Password = PasswordUnzip;
                    foreach (ZipEntry z in zip)
                        z.Extract(browserDlg.SelectedPath, ExtractExistingFileAction.OverwriteSilently);
                    MessageBox.Show(this, "Unzip file successful");
                }
            }
            catch
            {
                MessageBox.Show(this, "Unzip file fail");
            }

            EnableButton(false);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            FormEncrypt f = new FormEncrypt();
            f.SetUser(_u);

            f.currentChosenItems = Program._currentChosenItems;
            if (Program._currentChosenItems.Length == 1)
            {
                f.SourceFilePath = Program._currentChosenItems[0];
                f.TargetFilePath = Program._currentChosenItems[0] + "_encrypt";
            }
            else
            {
                int i = 0;
                for (; i < Program._currentChosenItems.Length - 1; ++i)
                    f.SourceFilePath += "\"" + Program._currentChosenItems[i] + "\"" + " ";
                f.SourceFilePath += "\"" + Program._currentChosenItems[i] + "\"";
                f.TargetFilePath = Directory.GetParent(Program._currentChosenItems[0]).ToString() + "_encrypt";
            }

            f.ShowDialog(this);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            FormInputPassword f = new FormInputPassword();
            f.SetUser(_u);
            f.ShowDialog(this);

            if (f.isOK)
                if (f.InputPassword == _u.password)
                {
                    browserDlg = new FolderBrowserDialog();
                    browserDlg.Description = "Select folder to contain hybrid decrypted files";
                    if (browserDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        RunDecrypt();
                    }
                }
        }
        private void RunDecrypt()
        {
            Thread t = new Thread(new ThreadStart(RunDecryptThread));
            t.Start();
        }
        private void RunDecryptThread()
        {
            EnableButton(true);

            try
            {
                int err = DecryptFile2(Program._currentChosenItem, browserDlg.SelectedPath, _u.privatekey);
                if (err == 0) MessageBox.Show(this, "Decrypt successful");
                else if (err == 1) MessageBox.Show(this, "Error happen");
                else if (err == 2) MessageBox.Show(this, "Wrong password");
            }
            catch
            {
                MessageBox.Show(this, "Decrypt fail");
            }

            EnableButton(false);
        }

        private void btnEncryptSym_Click(object sender, EventArgs e)
        {
            FormSymmetricEncAndDec f = new FormSymmetricEncAndDec();
            f.EnableButtonWhenEncrypt();

            f.currentChosenItems = Program._currentChosenItems;
            if (Program._currentChosenItems.Length == 1)
            {
                f.SourceEn = Program._currentChosenItems[0];
                f.TargetEn = Program._currentChosenItems[0] + "_sym_encrypt";
            }
            else
            {
                int i = 0;
                for (; i < Program._currentChosenItems.Length - 1; ++i)
                    f.SourceEn += "\"" + Program._currentChosenItems[i] + "\"" + " ";
                f.SourceEn += "\"" + Program._currentChosenItems[i] + "\"";
                f.TargetEn = Directory.GetParent(Program._currentChosenItems[0]).ToString() + "_sym_encrypt";
            }

            f.ShowDialog(this);
        }

        private void btnDecryptSym_Click(object sender, EventArgs e)
        {
            FormSymmetricEncAndDec f = new FormSymmetricEncAndDec();
            f.EnableButtonWhenDecrypt();

            f.currentChosenItems = Program._currentChosenItems;
            f.SourceDe = Program._currentChosenItems[0];

            f.ShowDialog(this);
        }

        private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            FormRSAEncryptDecrypt f = new FormRSAEncryptDecrypt();
            f.EnableButtonWhenEncrypt();

            f.currentChosenItems = Program._currentChosenItems;
            if (Program._currentChosenItems.Length == 1)
            {
                f.SourceEn = Program._currentChosenItems[0];
                f.TargetEn = Program._currentChosenItems[0] + "_RSA_encrypt";
            }
            else
            {
                int i = 0;
                for (; i < Program._currentChosenItems.Length - 1; ++i)
                    f.SourceEn += "\"" + Program._currentChosenItems[i] + "\"" + " ";
                f.SourceEn += "\"" + Program._currentChosenItems[i] + "\"";
                f.TargetEn = Directory.GetParent(Program._currentChosenItems[0]).ToString() + "_RSA_encrypt";
            }

            f.ShowDialog(this);
        }

        private void btnDecryptRSA_Click(object sender, EventArgs e)
        {
            FormRSAEncryptDecrypt f = new FormRSAEncryptDecrypt();
            f.EnableButtonWhenDecrypt();

            f.currentChosenItems = Program._currentChosenItems;
            f.SourceDe = Program._currentChosenItems[0];

            f.ShowDialog(this);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            FormInputPassword f = new FormInputPassword();
            f.SetUser(_u);
            f.ShowDialog(this);

            if (f.isOK)
                if (f.InputPassword == _u.password)
                {
                    RunSign();
                }
        }
        private void RunSign()
        {
            Thread t = new Thread(new ThreadStart(RunSignThread));
            t.Start();
        }
        private void RunSignThread()
        {
            EnableButton(true);

            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(_u.privatekey);
                (new SignatureSalt(rsa)).CreateFileSignatureSalt(System.IO.File.ReadAllBytes(Program._currentChosenItem), Program._currentChosenItem + ".sig");

                MessageBox.Show(this, "Create signature successful");
            }
            catch
            {
                MessageBox.Show(this, "File is too large. Create signature fail");
            }

            EnableButton(false);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            RunCheck();
        }
        private void RunCheck()
        {
            Thread t = new Thread(new ThreadStart(RunCheckThread));
            t.Start();
        }
        private void RunCheckThread()
        {
            EnableButton(true);
            try
            {
                string[] users = System.IO.Directory.GetDirectories(cf.userPath);

                // Mở hộp thoại open để lấy đường dẫn file .sig
                string sigFile;
                openDlg = new OpenFileDialog();
                openDlg.Filter = "SIG file|*.sig";
                openDlg.Title = "Choose the signature file";
                if (openDlg.ShowDialog(this) == DialogResult.OK)
                {
                    sigFile = openDlg.FileName;
                }
                else
                {
                    goto Final;
                }

                // For each user
                for (int i = 0; i < users.Length; ++i)
                {
                    users[i] = System.IO.Directory.GetFiles(users[i])[0];

                    // Split file .data first
                    string temp = users[i].Substring(0, users[i].Length - 7);
                    string[] dest = { temp + ".email", temp + ".info", temp + ".pass", temp + ".public", temp + ".private" };
                    cf.SplitFile_Delete_Decrypt(temp + ".data", dest);

                    // Get Email and publickey
                    string email = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".email"));
                    string publickey = Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(temp + ".public"));

                    cf.JoinFile_Delete_Encrypt(dest, temp + ".data");

                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.FromXmlString(publickey);

                    bool check = (new SignatureSalt(rsa)).CheckFileSignatureSalt(System.IO.File.ReadAllBytes(Program._currentChosenItem), sigFile);
                    if (check)
                    {
                        MessageBox.Show(this, "This is a signature of " + email + " and Public Key size is " + rsa.KeySize.ToString() + " on the file " + Program._currentChosenItem);
                        goto Final;
                    }
                }

                MessageBox.Show(this, "We do not know who signs that signature");
            }
            catch
            {
                MessageBox.Show(this, "Check signature fail");
            }

        Final:
            EnableButton(false);
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            FormHash f = new FormHash();
            f.PathFile = Program._currentChosenItem;
            f.ShowDialog(this);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings f = new FormSettings();
            f.SetFormMain(this);
            f.ShowDialog(this);
        }



        // Function using in this file
        private void loadTextPath1()
        {
            txtPath1.Text = shellView1.CurrentFolder.ParsingName;

            btnBack1.Enabled = shellView1.CanNavigateBack;
            btnForward1.Enabled = shellView1.CanNavigateForward;
            btnUp1.Enabled = shellView1.CanNavigateParent;
        }
        private void loadTextPath2()
        {
            txtPath2.Text = shellView2.CurrentFolder.ParsingName;

            btnBack2.Enabled = shellView2.CanNavigateBack;
            btnForward2.Enabled = shellView2.CanNavigateForward;
            btnUp2.Enabled = shellView2.CanNavigateParent;
        }
        private void loadTextPath3()
        {
            txtPath3.Text = shellView3.CurrentFolder.ParsingName;

            btnBack3.Enabled = shellView3.CanNavigateBack;
            btnForward3.Enabled = shellView3.CanNavigateForward;
            btnUp3.Enabled = shellView3.CanNavigateParent;
        }
        private void loadTextPath4()
        {
            txtPath4.Text = shellView4.CurrentFolder.ParsingName;

            btnBack4.Enabled = shellView4.CanNavigateBack;
            btnForward4.Enabled = shellView4.CanNavigateForward;
            btnUp4.Enabled = shellView4.CanNavigateParent;
        }
        private void EnableButton(bool isRunning)
        {
            certificateToolStripMenuItem.Enabled = userToolStripMenuItem.Enabled =
            shellView1.Enabled = shellView2.Enabled = shellView3.Enabled = shellView4.Enabled =
            shellTreeView1.Enabled = shellTreeView2.Enabled = shellTreeView3.Enabled = shellTreeView4.Enabled =
            !isRunning;
        }
        private void EnableFeatureButton()
        {
            if (Program._currentChosenItems != null)
            {
                isChoosingFiles = true;
                if (System.IO.File.Exists(Program._currentChosenItem))
                {
                    isChoosingFile = true;
                    isChoosingZipFile = ZipFile.IsZipFile(Program._currentChosenItem);
                }
                else
                {
                    isChoosingFile = false;
                    isChoosingZipFile = false;
                }
            }
            else
            {
                isChoosingFiles = false;
                isChoosingFile = false;
                isChoosingZipFile = false;
            }
        }


        // MenuItems' event
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }
        private void menuItemZip_Click(object sender, EventArgs e)
        {
            btnZip_Click(sender, e);
        }
        private void menuItemZipPass_Click(object sender, EventArgs e)
        {
            btnZipPass_Click(sender, e);
        }
        private void menuItemZipPriKey_Click(object sender, EventArgs e)
        {
            btnZipPriKey_Click(sender, e);
        }
        private void menuItemUnzip_Click(object sender, EventArgs e)
        {
            btnUnzip_Click(sender, e);
        }

        private void menuItemEn_Click(object sender, EventArgs e)
        {
            btnEncrypt_Click(sender, e);
        }
        private void menuItemDe_Click(object sender, EventArgs e)
        {
            btnDecrypt_Click(sender, e);
        }
        private void menuItemEncryptSym_Click(object sender, EventArgs e)
        {
            btnEncryptSym_Click(sender, e);
        }
        private void menuItemDecryptSym_Click(object sender, EventArgs e)
        {
            btnDecryptSym_Click(sender, e);
        }
        private void menuItemEncryptRSA_Click(object sender, EventArgs e)
        {
            btnEncryptRSA_Click(sender, e);
        }
        private void menuItemDecryptRSA_Click(object sender, EventArgs e)
        {
            btnDecryptRSA_Click(sender, e);
        }

        private void menuItemSign_Click(object sender, EventArgs e)
        {
            btnSign_Click(sender, e);
        }
        private void menuItemCheck_Click(object sender, EventArgs e)
        {
            btnCheck_Click(sender, e);
        }

        private void menuItemHash_Click(object sender, EventArgs e)
        {
            btnHash_Click(sender, e);
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            btnSettings_Click(sender, e);
        }
        private void menuItem4explorer_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            System.Diagnostics.Process.Start(Program.program4explorer);   
        }
        private void menuItem3explorer_Click(object sender, EventArgs e)
        {
            string t = cf.userPath + "/" + _u.email + "/";
            System.IO.File.WriteAllText(t + Program.fileContainPath1, txtPath1.Text);
            System.IO.File.WriteAllText(t + Program.fileContainPath2, txtPath2.Text);
            System.IO.File.WriteAllText(t + Program.fileContainPath3, txtPath3.Text);
            System.IO.File.WriteAllText(t + Program.fileContainPath4, txtPath4.Text);

            System.IO.File.WriteAllText(t + Program.pathSetting, Program.opacity.ToString());

            Application.ExitThread();
            System.Diagnostics.Process.Start(Program.program3explorer);   
        }
        private void menuItem2explorer_Click(object sender, EventArgs e)
        {
            string t = cf.userPath + "/" + _u.email + "/";
            System.IO.File.WriteAllText(t + Program.fileContainPath1, txtPath1.Text);
            System.IO.File.WriteAllText(t + Program.fileContainPath2, txtPath2.Text);
            System.IO.File.WriteAllText(t + Program.fileContainPath3, txtPath3.Text);
            System.IO.File.WriteAllText(t + Program.fileContainPath4, txtPath4.Text);

            System.IO.File.WriteAllText(t + Program.pathSetting, Program.opacity.ToString());

            Application.ExitThread();
            System.Diagnostics.Process.Start(Program.program2explorer);
        }


        // Feature function 0 (Hidden feature function)
        private void RunDelete()
        {
            Thread t = new Thread(new ThreadStart(RunDeleteThread));
            t.Start();
        }
        private void RunDeleteThread()
        {
            EnableButton(true);
            try
            {
                for (int i = 0; i < Program._currentChosenItems.Length; ++i)
                    if (System.IO.File.Exists(Program._currentChosenItems[i]))
                        System.IO.File.Delete(Program._currentChosenItems[i]);
                    else
                        Directory.Delete(Program._currentChosenItems[i], true);
            }
            catch
            {
                MessageBox.Show(this, "Choose files and folders again to delete");
            }
            finally
            {
                EnableButton(false);
            }
        }
        private void RunPaste()
        {
            Thread t = new Thread(new ThreadStart(RunPasteThread));
            t.Start();
        }
        private void RunPasteThread()
        {
            EnableButton(true);
            try
            {
                IDataObject data_object = Clipboard.GetDataObject();
                if (data_object.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])data_object.GetData(DataFormats.FileDrop);
                    foreach (string file_name in files)
                        if (System.IO.File.Exists(file_name)) System.IO.File.Copy(file_name, pathCopy + "/" + Path.GetFileName(file_name), true);
                        else CopyDirectory(file_name, pathCopy);
                }
                MessageBox.Show(this, "Copy successful");
            }
            catch
            {
                MessageBox.Show(pathCopy);
                MessageBox.Show(this, "Copy fail");
            }
            finally
            {
                EnableButton(false);
            }
        }
    }
}
