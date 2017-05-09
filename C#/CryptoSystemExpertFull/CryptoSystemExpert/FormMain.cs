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

namespace CryptoSystemExpert
{
    public partial class FormMain : Form
    {
        // Cac bien de quan ly cac cua so 1, 2, 3
        bool isUsingMouseToNavigate1 = true;
        bool isUsingMouseToNavigate2 = true;
        bool isUsingMouseToNavigate3 = true;
        bool isUsingMouseToNavigate4 = true;
        int lastUsing = 1;

        CommonFunction cf = new CommonFunction();

        // Bien giu duong dan de paste
        string pathCopy;

        public FormMain()
        {
            InitializeComponent();
        }


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

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Show();
            loadTextPath1();
            loadTextPath2();
            loadTextPath3();
            loadTextPath4();
                        
            string path1 = System.IO.File.ReadAllText(Program.fileContainPath1);
            string path2 = System.IO.File.ReadAllText(Program.fileContainPath2);
            string path3 = System.IO.File.ReadAllText(Program.fileContainPath3);
            string path4 = System.IO.File.ReadAllText(Program.fileContainPath4);
            string sOpacity = System.IO.File.ReadAllText(Program.pathSetting);

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

            // set opacity
            Program.opacity = Convert.ToDouble(sOpacity);
            this.Opacity = Program.opacity;
        }
        
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


        private void shellView1_Navigated(object sender, EventArgs e)
        {
            if (isUsingMouseToNavigate1)
                loadTextPath1();
            lastUsing = 1;
        }
        private void shellView2_Navigated(object sender, EventArgs e)
        {
            if (isUsingMouseToNavigate2)
                loadTextPath2();
            lastUsing = 2;
        }
        private void shellView3_Navigated(object sender, EventArgs e)
        {
            if (isUsingMouseToNavigate3)
                loadTextPath3();
            lastUsing = 3;
        }
        private void shellView4_Navigated(object sender, EventArgs e)
        {
            if (isUsingMouseToNavigate4)
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
        }

        private void EnableButton(bool isRunning)
        {
            shellView1.Enabled = shellView2.Enabled = shellView3.Enabled = shellView4.Enabled = this.ControlBox = !isRunning;            
        }

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

                if (e.KeyCode == Keys.M) this.WindowState = FormWindowState.Minimized;
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
                System.IO.File.WriteAllText(Program.fileContainPath1, txtPath1.Text);
                System.IO.File.WriteAllText(Program.fileContainPath2, txtPath2.Text);
                System.IO.File.WriteAllText(Program.fileContainPath3, txtPath3.Text);
                System.IO.File.WriteAllText(Program.fileContainPath4, txtPath4.Text);

                System.IO.File.WriteAllText(Program.pathSetting, Program.opacity.ToString());

                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
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
                MessageBox.Show(this, "Copy fail");
            }
            finally
            {
                EnableButton(false);
            }
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

            ////////////////////////
            ////////////////////////
            ContextMenu buttonMenu = new ContextMenu();
            ContextMenu buttonMenu2 = new ContextMenu();
            MenuItem[] menuItems = new MenuItem[] { 
                new MenuItem("Open", menuItemOpen_Click), 
                    new MenuItem("Settings", menuItemSetting_Click) };
            menuItems[0].DefaultItem = true;
            //menuItems[5].BarBreak = true;
            //menuItems[11].BarBreak = true;
            //menuItems[13].BarBreak = true;
            //menuItems[14].BarBreak = true;

            if (Program._currentChosenItems.Length >= 1) buttonMenu.MenuItems.Add(menuItems[0]);           

            buttonMenu.MenuItems.Add(menuItems[1]);

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
                    RunPaste();
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
                    RunPaste();
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
                    RunPaste();
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

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program._currentChosenItems.Length; ++i)
                System.Diagnostics.Process.Start(Program._currentChosenItems[i]);
        }
        private void menuItemSetting_Click(object sender, EventArgs e)
        {
            FormSettings f = new FormSettings();
            f.SetFormMain(this);
            f.ShowDialog(this);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewPublicKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewPrivateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
