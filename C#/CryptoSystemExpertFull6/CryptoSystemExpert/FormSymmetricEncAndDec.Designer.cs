namespace CryptoSystemExpert
{
    partial class FormSymmetricEncAndDec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTargetFileDe = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTargetFileDe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassDe = new System.Windows.Forms.TextBox();
            this.btnDe = new System.Windows.Forms.Button();
            this.btnOpenFileDe = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.comboCiModeS = new System.Windows.Forms.ComboBox();
            this.comboPadModeS = new System.Windows.Forms.ComboBox();
            this.comboAlgoS = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPassEnString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.rtxtDecryptedText = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtPlainText = new System.Windows.Forms.RichTextBox();
            this.rtxtEncryptedText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkCompress = new System.Windows.Forms.CheckBox();
            this.txtPassDeString = new System.Windows.Forms.TextBox();
            this.checkShowAlgo = new System.Windows.Forms.CheckBox();
            this.txtSourceFileDe = new System.Windows.Forms.TextBox();
            this.groupBoxEncryptFile = new System.Windows.Forms.GroupBox();
            this.checkRanAll = new System.Windows.Forms.CheckBox();
            this.btnTargetFileEn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTargetFileEn = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnEn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassEn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Algorithm = new System.Windows.Forms.Label();
            this.comboMode = new System.Windows.Forms.ComboBox();
            this.comboPadding = new System.Windows.Forms.ComboBox();
            this.comboAlgo = new System.Windows.Forms.ComboBox();
            this.btnOpenFileEn = new System.Windows.Forms.Button();
            this.txtSourceFileEn = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtxtIV = new System.Windows.Forms.RichTextBox();
            this.btnRandomIV = new System.Windows.Forms.Button();
            this.groupBoxDecryptFile = new System.Windows.Forms.GroupBox();
            this.groupBoxEncryptFile.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxDecryptFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "IV";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Padding Mode";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "Algorithm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Source file";
            // 
            // btnTargetFileDe
            // 
            this.btnTargetFileDe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTargetFileDe.FlatAppearance.BorderSize = 0;
            this.btnTargetFileDe.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTargetFileDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetFileDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetFileDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTargetFileDe.Location = new System.Drawing.Point(470, 83);
            this.btnTargetFileDe.Name = "btnTargetFileDe";
            this.btnTargetFileDe.Size = new System.Drawing.Size(26, 23);
            this.btnTargetFileDe.TabIndex = 25;
            this.btnTargetFileDe.Text = "...";
            this.btnTargetFileDe.UseVisualStyleBackColor = true;
            this.btnTargetFileDe.Click += new System.EventHandler(this.btnTargetFileDe_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Containing folder";
            // 
            // txtTargetFileDe
            // 
            this.txtTargetFileDe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTargetFileDe.Location = new System.Drawing.Point(117, 85);
            this.txtTargetFileDe.Name = "txtTargetFileDe";
            this.txtTargetFileDe.ReadOnly = true;
            this.txtTargetFileDe.Size = new System.Drawing.Size(338, 20);
            this.txtTargetFileDe.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Password";
            // 
            // txtPassDe
            // 
            this.txtPassDe.Location = new System.Drawing.Point(309, 130);
            this.txtPassDe.Name = "txtPassDe";
            this.txtPassDe.PasswordChar = '*';
            this.txtPassDe.Size = new System.Drawing.Size(146, 20);
            this.txtPassDe.TabIndex = 20;
            this.txtPassDe.UseSystemPasswordChar = true;
            // 
            // btnDe
            // 
            this.btnDe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDe.FlatAppearance.BorderSize = 0;
            this.btnDe.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDe.Location = new System.Drawing.Point(412, 168);
            this.btnDe.Name = "btnDe";
            this.btnDe.Size = new System.Drawing.Size(100, 23);
            this.btnDe.TabIndex = 19;
            this.btnDe.Text = "Decrypt";
            this.btnDe.UseVisualStyleBackColor = true;
            this.btnDe.Click += new System.EventHandler(this.btnDe_Click);
            // 
            // btnOpenFileDe
            // 
            this.btnOpenFileDe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenFileDe.FlatAppearance.BorderSize = 0;
            this.btnOpenFileDe.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnOpenFileDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenFileDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenFileDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFileDe.Location = new System.Drawing.Point(470, 33);
            this.btnOpenFileDe.Name = "btnOpenFileDe";
            this.btnOpenFileDe.Size = new System.Drawing.Size(26, 23);
            this.btnOpenFileDe.TabIndex = 11;
            this.btnOpenFileDe.Text = "...";
            this.btnOpenFileDe.UseVisualStyleBackColor = false;
            this.btnOpenFileDe.Click += new System.EventHandler(this.btnOpenFileDe_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 227);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Mode of operation";
            // 
            // comboCiModeS
            // 
            this.comboCiModeS.FormattingEnabled = true;
            this.comboCiModeS.Location = new System.Drawing.Point(115, 224);
            this.comboCiModeS.Name = "comboCiModeS";
            this.comboCiModeS.Size = new System.Drawing.Size(121, 21);
            this.comboCiModeS.TabIndex = 27;
            // 
            // comboPadModeS
            // 
            this.comboPadModeS.FormattingEnabled = true;
            this.comboPadModeS.Location = new System.Drawing.Point(115, 185);
            this.comboPadModeS.Name = "comboPadModeS";
            this.comboPadModeS.Size = new System.Drawing.Size(121, 21);
            this.comboPadModeS.TabIndex = 26;
            // 
            // comboAlgoS
            // 
            this.comboAlgoS.FormattingEnabled = true;
            this.comboAlgoS.Location = new System.Drawing.Point(115, 145);
            this.comboAlgoS.Name = "comboAlgoS";
            this.comboAlgoS.Size = new System.Drawing.Size(121, 21);
            this.comboAlgoS.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 361);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Password";
            // 
            // txtPassEnString
            // 
            this.txtPassEnString.Location = new System.Drawing.Point(115, 105);
            this.txtPassEnString.Name = "txtPassEnString";
            this.txtPassEnString.Size = new System.Drawing.Size(323, 20);
            this.txtPassEnString.TabIndex = 22;
            this.txtPassEnString.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Password";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDecrypt.FlatAppearance.BorderSize = 0;
            this.btnDecrypt.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDecrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.Location = new System.Drawing.Point(115, 384);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(86, 23);
            this.btnDecrypt.TabIndex = 20;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Location = new System.Drawing.Point(115, 267);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(86, 23);
            this.btnEncrypt.TabIndex = 19;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // rtxtDecryptedText
            // 
            this.rtxtDecryptedText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtDecryptedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtDecryptedText.Location = new System.Drawing.Point(115, 413);
            this.rtxtDecryptedText.Name = "rtxtDecryptedText";
            this.rtxtDecryptedText.ReadOnly = true;
            this.rtxtDecryptedText.Size = new System.Drawing.Size(323, 48);
            this.rtxtDecryptedText.TabIndex = 18;
            this.rtxtDecryptedText.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Decrypted text";
            // 
            // rtxtPlainText
            // 
            this.rtxtPlainText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtPlainText.Location = new System.Drawing.Point(115, 34);
            this.rtxtPlainText.Name = "rtxtPlainText";
            this.rtxtPlainText.Size = new System.Drawing.Size(323, 48);
            this.rtxtPlainText.TabIndex = 14;
            this.rtxtPlainText.Text = "";
            // 
            // rtxtEncryptedText
            // 
            this.rtxtEncryptedText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtEncryptedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtEncryptedText.Location = new System.Drawing.Point(115, 296);
            this.rtxtEncryptedText.Name = "rtxtEncryptedText";
            this.rtxtEncryptedText.ReadOnly = true;
            this.rtxtEncryptedText.Size = new System.Drawing.Size(323, 48);
            this.rtxtEncryptedText.TabIndex = 16;
            this.rtxtEncryptedText.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Plain text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Encrypted text";
            // 
            // checkCompress
            // 
            this.checkCompress.AutoSize = true;
            this.checkCompress.Checked = true;
            this.checkCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCompress.Location = new System.Drawing.Point(253, 202);
            this.checkCompress.Name = "checkCompress";
            this.checkCompress.Size = new System.Drawing.Size(157, 17);
            this.checkCompress.TabIndex = 25;
            this.checkCompress.Text = "Compress before encryption";
            this.checkCompress.UseVisualStyleBackColor = true;
            // 
            // txtPassDeString
            // 
            this.txtPassDeString.Location = new System.Drawing.Point(115, 358);
            this.txtPassDeString.Name = "txtPassDeString";
            this.txtPassDeString.Size = new System.Drawing.Size(323, 20);
            this.txtPassDeString.TabIndex = 24;
            this.txtPassDeString.UseSystemPasswordChar = true;
            // 
            // checkShowAlgo
            // 
            this.checkShowAlgo.AutoSize = true;
            this.checkShowAlgo.Checked = true;
            this.checkShowAlgo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAlgo.Location = new System.Drawing.Point(253, 177);
            this.checkShowAlgo.Name = "checkShowAlgo";
            this.checkShowAlgo.Size = new System.Drawing.Size(174, 17);
            this.checkShowAlgo.TabIndex = 24;
            this.checkShowAlgo.Text = "Show running random algorithm";
            this.checkShowAlgo.UseVisualStyleBackColor = true;
            // 
            // txtSourceFileDe
            // 
            this.txtSourceFileDe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSourceFileDe.Location = new System.Drawing.Point(117, 35);
            this.txtSourceFileDe.Name = "txtSourceFileDe";
            this.txtSourceFileDe.ReadOnly = true;
            this.txtSourceFileDe.Size = new System.Drawing.Size(338, 20);
            this.txtSourceFileDe.TabIndex = 10;
            // 
            // groupBoxEncryptFile
            // 
            this.groupBoxEncryptFile.Controls.Add(this.checkCompress);
            this.groupBoxEncryptFile.Controls.Add(this.checkRanAll);
            this.groupBoxEncryptFile.Controls.Add(this.checkShowAlgo);
            this.groupBoxEncryptFile.Controls.Add(this.btnTargetFileEn);
            this.groupBoxEncryptFile.Controls.Add(this.label12);
            this.groupBoxEncryptFile.Controls.Add(this.txtTargetFileEn);
            this.groupBoxEncryptFile.Controls.Add(this.label11);
            this.groupBoxEncryptFile.Controls.Add(this.btnEn);
            this.groupBoxEncryptFile.Controls.Add(this.label9);
            this.groupBoxEncryptFile.Controls.Add(this.txtPassEn);
            this.groupBoxEncryptFile.Controls.Add(this.label8);
            this.groupBoxEncryptFile.Controls.Add(this.label7);
            this.groupBoxEncryptFile.Controls.Add(this.Algorithm);
            this.groupBoxEncryptFile.Controls.Add(this.comboMode);
            this.groupBoxEncryptFile.Controls.Add(this.comboPadding);
            this.groupBoxEncryptFile.Controls.Add(this.comboAlgo);
            this.groupBoxEncryptFile.Controls.Add(this.btnOpenFileEn);
            this.groupBoxEncryptFile.Controls.Add(this.txtSourceFileEn);
            this.groupBoxEncryptFile.Location = new System.Drawing.Point(468, 11);
            this.groupBoxEncryptFile.Name = "groupBoxEncryptFile";
            this.groupBoxEncryptFile.Size = new System.Drawing.Size(523, 255);
            this.groupBoxEncryptFile.TabIndex = 7;
            this.groupBoxEncryptFile.TabStop = false;
            this.groupBoxEncryptFile.Text = "Encrypt File";
            // 
            // checkRanAll
            // 
            this.checkRanAll.AutoSize = true;
            this.checkRanAll.Location = new System.Drawing.Point(253, 152);
            this.checkRanAll.Name = "checkRanAll";
            this.checkRanAll.Size = new System.Drawing.Size(259, 17);
            this.checkRanAll.TabIndex = 23;
            this.checkRanAll.Text = "Random (Algorithm, Padding Mode, Cipher Mode)";
            this.checkRanAll.UseVisualStyleBackColor = true;
            this.checkRanAll.Click += new System.EventHandler(this.checkRanAll_CheckedChanged);
            // 
            // btnTargetFileEn
            // 
            this.btnTargetFileEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTargetFileEn.FlatAppearance.BorderSize = 0;
            this.btnTargetFileEn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnTargetFileEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetFileEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetFileEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTargetFileEn.Location = new System.Drawing.Point(470, 67);
            this.btnTargetFileEn.Name = "btnTargetFileEn";
            this.btnTargetFileEn.Size = new System.Drawing.Size(26, 23);
            this.btnTargetFileEn.TabIndex = 22;
            this.btnTargetFileEn.Text = "...";
            this.btnTargetFileEn.UseVisualStyleBackColor = true;
            this.btnTargetFileEn.Click += new System.EventHandler(this.btnTargetFileEn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Target file";
            // 
            // txtTargetFileEn
            // 
            this.txtTargetFileEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTargetFileEn.Location = new System.Drawing.Point(117, 69);
            this.txtTargetFileEn.Name = "txtTargetFileEn";
            this.txtTargetFileEn.ReadOnly = true;
            this.txtTargetFileEn.Size = new System.Drawing.Size(338, 20);
            this.txtTargetFileEn.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Source files";
            // 
            // btnEn
            // 
            this.btnEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEn.FlatAppearance.BorderSize = 0;
            this.btnEn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEn.Location = new System.Drawing.Point(412, 224);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(100, 23);
            this.btnEn.TabIndex = 18;
            this.btnEn.Text = "Encrypt";
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Password";
            // 
            // txtPassEn
            // 
            this.txtPassEn.Location = new System.Drawing.Point(309, 116);
            this.txtPassEn.Name = "txtPassEn";
            this.txtPassEn.PasswordChar = '*';
            this.txtPassEn.Size = new System.Drawing.Size(146, 20);
            this.txtPassEn.TabIndex = 16;
            this.txtPassEn.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cipher Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Padding Mode";
            // 
            // Algorithm
            // 
            this.Algorithm.AutoSize = true;
            this.Algorithm.Location = new System.Drawing.Point(18, 119);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(50, 13);
            this.Algorithm.TabIndex = 13;
            this.Algorithm.Text = "Algorithm";
            // 
            // comboMode
            // 
            this.comboMode.FormattingEnabled = true;
            this.comboMode.Location = new System.Drawing.Point(117, 213);
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(121, 21);
            this.comboMode.TabIndex = 12;
            // 
            // comboPadding
            // 
            this.comboPadding.FormattingEnabled = true;
            this.comboPadding.Location = new System.Drawing.Point(117, 164);
            this.comboPadding.Name = "comboPadding";
            this.comboPadding.Size = new System.Drawing.Size(121, 21);
            this.comboPadding.TabIndex = 11;
            // 
            // comboAlgo
            // 
            this.comboAlgo.FormattingEnabled = true;
            this.comboAlgo.Location = new System.Drawing.Point(117, 116);
            this.comboAlgo.Name = "comboAlgo";
            this.comboAlgo.Size = new System.Drawing.Size(121, 21);
            this.comboAlgo.TabIndex = 10;
            // 
            // btnOpenFileEn
            // 
            this.btnOpenFileEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenFileEn.FlatAppearance.BorderSize = 0;
            this.btnOpenFileEn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnOpenFileEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenFileEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenFileEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFileEn.Location = new System.Drawing.Point(470, 20);
            this.btnOpenFileEn.Name = "btnOpenFileEn";
            this.btnOpenFileEn.Size = new System.Drawing.Size(26, 23);
            this.btnOpenFileEn.TabIndex = 9;
            this.btnOpenFileEn.Text = "...";
            this.btnOpenFileEn.UseVisualStyleBackColor = false;
            this.btnOpenFileEn.Visible = false;
            this.btnOpenFileEn.Click += new System.EventHandler(this.btnOpenFileEn_Click);
            // 
            // txtSourceFileEn
            // 
            this.txtSourceFileEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSourceFileEn.Location = new System.Drawing.Point(117, 22);
            this.txtSourceFileEn.Name = "txtSourceFileEn";
            this.txtSourceFileEn.ReadOnly = true;
            this.txtSourceFileEn.Size = new System.Drawing.Size(338, 20);
            this.txtSourceFileEn.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxtIV);
            this.groupBox3.Controls.Add(this.btnRandomIV);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.comboCiModeS);
            this.groupBox3.Controls.Add(this.comboPadModeS);
            this.groupBox3.Controls.Add(this.comboAlgoS);
            this.groupBox3.Controls.Add(this.txtPassDeString);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtPassEnString);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnDecrypt);
            this.groupBox3.Controls.Add(this.btnEncrypt);
            this.groupBox3.Controls.Add(this.rtxtDecryptedText);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.rtxtPlainText);
            this.groupBox3.Controls.Add(this.rtxtEncryptedText);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 472);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encrypt && Decrypt String";
            // 
            // rtxtIV
            // 
            this.rtxtIV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtIV.Location = new System.Drawing.Point(279, 145);
            this.rtxtIV.Name = "rtxtIV";
            this.rtxtIV.Size = new System.Drawing.Size(159, 71);
            this.rtxtIV.TabIndex = 34;
            this.rtxtIV.Text = "";
            // 
            // btnRandomIV
            // 
            this.btnRandomIV.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRandomIV.FlatAppearance.BorderSize = 0;
            this.btnRandomIV.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnRandomIV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRandomIV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRandomIV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandomIV.Location = new System.Drawing.Point(363, 222);
            this.btnRandomIV.Name = "btnRandomIV";
            this.btnRandomIV.Size = new System.Drawing.Size(75, 23);
            this.btnRandomIV.TabIndex = 33;
            this.btnRandomIV.Text = "Random IV";
            this.btnRandomIV.UseVisualStyleBackColor = true;
            this.btnRandomIV.Click += new System.EventHandler(this.btnRandomIV_Click);
            // 
            // groupBoxDecryptFile
            // 
            this.groupBoxDecryptFile.Controls.Add(this.label14);
            this.groupBoxDecryptFile.Controls.Add(this.btnTargetFileDe);
            this.groupBoxDecryptFile.Controls.Add(this.label13);
            this.groupBoxDecryptFile.Controls.Add(this.txtTargetFileDe);
            this.groupBoxDecryptFile.Controls.Add(this.label10);
            this.groupBoxDecryptFile.Controls.Add(this.txtPassDe);
            this.groupBoxDecryptFile.Controls.Add(this.btnDe);
            this.groupBoxDecryptFile.Controls.Add(this.btnOpenFileDe);
            this.groupBoxDecryptFile.Controls.Add(this.txtSourceFileDe);
            this.groupBoxDecryptFile.Location = new System.Drawing.Point(468, 272);
            this.groupBoxDecryptFile.Name = "groupBoxDecryptFile";
            this.groupBoxDecryptFile.Size = new System.Drawing.Size(523, 211);
            this.groupBoxDecryptFile.TabIndex = 8;
            this.groupBoxDecryptFile.TabStop = false;
            this.groupBoxDecryptFile.Text = "Decrypt File";
            // 
            // FormSymmetricEncAndDec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1004, 495);
            this.Controls.Add(this.groupBoxEncryptFile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxDecryptFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSymmetricEncAndDec";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Symmetric Encryption and Decryption";
            this.Load += new System.EventHandler(this.FormSymmetricEncAndDec_Load);
            this.groupBoxEncryptFile.ResumeLayout(false);
            this.groupBoxEncryptFile.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxDecryptFile.ResumeLayout(false);
            this.groupBoxDecryptFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTargetFileDe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTargetFileDe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPassDe;
        private System.Windows.Forms.Button btnDe;
        private System.Windows.Forms.Button btnOpenFileDe;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboCiModeS;
        private System.Windows.Forms.ComboBox comboPadModeS;
        private System.Windows.Forms.ComboBox comboAlgoS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPassEnString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.RichTextBox rtxtDecryptedText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxtPlainText;
        private System.Windows.Forms.RichTextBox rtxtEncryptedText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkCompress;
        private System.Windows.Forms.TextBox txtPassDeString;
        private System.Windows.Forms.CheckBox checkShowAlgo;
        private System.Windows.Forms.TextBox txtSourceFileDe;
        private System.Windows.Forms.GroupBox groupBoxEncryptFile;
        private System.Windows.Forms.CheckBox checkRanAll;
        private System.Windows.Forms.Button btnTargetFileEn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTargetFileEn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassEn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Algorithm;
        private System.Windows.Forms.ComboBox comboMode;
        private System.Windows.Forms.ComboBox comboPadding;
        private System.Windows.Forms.ComboBox comboAlgo;
        private System.Windows.Forms.Button btnOpenFileEn;
        private System.Windows.Forms.TextBox txtSourceFileEn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtxtIV;
        private System.Windows.Forms.Button btnRandomIV;
        private System.Windows.Forms.GroupBox groupBoxDecryptFile;
    }
}