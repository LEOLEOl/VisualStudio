namespace CryptoSystemExpert
{
    partial class FormRSAEncryptDecrypt
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
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxDecryptFile = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rtxtKeyDe = new System.Windows.Forms.RichTextBox();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.btnKeyDe = new System.Windows.Forms.Button();
            this.btnTargetDe = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKeyDe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTargetDe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSourceDe = new System.Windows.Forms.Button();
            this.txtSourceDe = new System.Windows.Forms.TextBox();
            this.groupBoxEncryptFile = new System.Windows.Forms.GroupBox();
            this.checkCompress = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboRSAEn = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rtxtKeyEn = new System.Windows.Forms.RichTextBox();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.btnKeyEn = new System.Windows.Forms.Button();
            this.btnTargetEn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtKeyEn = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTargetEn = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSourceEn = new System.Windows.Forms.Button();
            this.txtSouceEn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumBit = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtPrivateKey = new System.Windows.Forms.RichTextBox();
            this.rtxtPublicKey = new System.Windows.Forms.RichTextBox();
            this.btnSavePrivateKey = new System.Windows.Forms.Button();
            this.btnSavePublicKey = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkUppercase = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboRSAMode = new System.Windows.Forms.ComboBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.rtxtDecryptedText = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtEncryptedText = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtPlainText = new System.Windows.Forms.RichTextBox();
            this.groupBoxDecryptFile.SuspendLayout();
            this.groupBoxEncryptFile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Plain text";
            // 
            // groupBoxDecryptFile
            // 
            this.groupBoxDecryptFile.Controls.Add(this.label11);
            this.groupBoxDecryptFile.Controls.Add(this.rtxtKeyDe);
            this.groupBoxDecryptFile.Controls.Add(this.btnDecryptFile);
            this.groupBoxDecryptFile.Controls.Add(this.btnKeyDe);
            this.groupBoxDecryptFile.Controls.Add(this.btnTargetDe);
            this.groupBoxDecryptFile.Controls.Add(this.label8);
            this.groupBoxDecryptFile.Controls.Add(this.txtKeyDe);
            this.groupBoxDecryptFile.Controls.Add(this.label9);
            this.groupBoxDecryptFile.Controls.Add(this.txtTargetDe);
            this.groupBoxDecryptFile.Controls.Add(this.label10);
            this.groupBoxDecryptFile.Controls.Add(this.btnSourceDe);
            this.groupBoxDecryptFile.Controls.Add(this.txtSourceDe);
            this.groupBoxDecryptFile.Location = new System.Drawing.Point(592, 293);
            this.groupBoxDecryptFile.Name = "groupBoxDecryptFile";
            this.groupBoxDecryptFile.Size = new System.Drawing.Size(581, 242);
            this.groupBoxDecryptFile.TabIndex = 24;
            this.groupBoxDecryptFile.TabStop = false;
            this.groupBoxDecryptFile.Text = "Decrypt File";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Key";
            // 
            // rtxtKeyDe
            // 
            this.rtxtKeyDe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtKeyDe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtKeyDe.Location = new System.Drawing.Point(139, 159);
            this.rtxtKeyDe.Name = "rtxtKeyDe";
            this.rtxtKeyDe.ReadOnly = true;
            this.rtxtKeyDe.Size = new System.Drawing.Size(332, 65);
            this.rtxtKeyDe.TabIndex = 19;
            this.rtxtKeyDe.Text = "";
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDecryptFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecryptFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecryptFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecryptFile.Location = new System.Drawing.Point(489, 201);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(75, 23);
            this.btnDecryptFile.TabIndex = 17;
            this.btnDecryptFile.Text = "Decrypt";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnKeyDe
            // 
            this.btnKeyDe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnKeyDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKeyDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKeyDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyDe.Location = new System.Drawing.Point(540, 114);
            this.btnKeyDe.Name = "btnKeyDe";
            this.btnKeyDe.Size = new System.Drawing.Size(30, 23);
            this.btnKeyDe.TabIndex = 16;
            this.btnKeyDe.Text = "...";
            this.btnKeyDe.UseVisualStyleBackColor = true;
            this.btnKeyDe.Click += new System.EventHandler(this.btnKeyDe_Click);
            // 
            // btnTargetDe
            // 
            this.btnTargetDe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTargetDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTargetDe.Location = new System.Drawing.Point(540, 73);
            this.btnTargetDe.Name = "btnTargetDe";
            this.btnTargetDe.Size = new System.Drawing.Size(30, 23);
            this.btnTargetDe.TabIndex = 15;
            this.btnTargetDe.Text = "...";
            this.btnTargetDe.UseVisualStyleBackColor = true;
            this.btnTargetDe.Click += new System.EventHandler(this.btnTargetDe_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "PriKey file ( >= 512 bit)";
            // 
            // txtKeyDe
            // 
            this.txtKeyDe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtKeyDe.Location = new System.Drawing.Point(139, 116);
            this.txtKeyDe.Name = "txtKeyDe";
            this.txtKeyDe.ReadOnly = true;
            this.txtKeyDe.Size = new System.Drawing.Size(395, 20);
            this.txtKeyDe.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Containing folder";
            // 
            // txtTargetDe
            // 
            this.txtTargetDe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTargetDe.Location = new System.Drawing.Point(139, 75);
            this.txtTargetDe.Name = "txtTargetDe";
            this.txtTargetDe.ReadOnly = true;
            this.txtTargetDe.Size = new System.Drawing.Size(395, 20);
            this.txtTargetDe.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Source file";
            // 
            // btnSourceDe
            // 
            this.btnSourceDe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSourceDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSourceDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSourceDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSourceDe.Location = new System.Drawing.Point(540, 34);
            this.btnSourceDe.Name = "btnSourceDe";
            this.btnSourceDe.Size = new System.Drawing.Size(30, 23);
            this.btnSourceDe.TabIndex = 1;
            this.btnSourceDe.Text = "...";
            this.btnSourceDe.UseVisualStyleBackColor = true;
            this.btnSourceDe.Click += new System.EventHandler(this.btnSourceDe_Click);
            // 
            // txtSourceDe
            // 
            this.txtSourceDe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSourceDe.Location = new System.Drawing.Point(139, 36);
            this.txtSourceDe.Name = "txtSourceDe";
            this.txtSourceDe.ReadOnly = true;
            this.txtSourceDe.Size = new System.Drawing.Size(395, 20);
            this.txtSourceDe.TabIndex = 0;
            // 
            // groupBoxEncryptFile
            // 
            this.groupBoxEncryptFile.Controls.Add(this.checkCompress);
            this.groupBoxEncryptFile.Controls.Add(this.label16);
            this.groupBoxEncryptFile.Controls.Add(this.comboRSAEn);
            this.groupBoxEncryptFile.Controls.Add(this.label12);
            this.groupBoxEncryptFile.Controls.Add(this.rtxtKeyEn);
            this.groupBoxEncryptFile.Controls.Add(this.btnEncryptFile);
            this.groupBoxEncryptFile.Controls.Add(this.btnKeyEn);
            this.groupBoxEncryptFile.Controls.Add(this.btnTargetEn);
            this.groupBoxEncryptFile.Controls.Add(this.label13);
            this.groupBoxEncryptFile.Controls.Add(this.txtKeyEn);
            this.groupBoxEncryptFile.Controls.Add(this.label14);
            this.groupBoxEncryptFile.Controls.Add(this.txtTargetEn);
            this.groupBoxEncryptFile.Controls.Add(this.label15);
            this.groupBoxEncryptFile.Controls.Add(this.btnSourceEn);
            this.groupBoxEncryptFile.Controls.Add(this.txtSouceEn);
            this.groupBoxEncryptFile.Location = new System.Drawing.Point(592, 10);
            this.groupBoxEncryptFile.Name = "groupBoxEncryptFile";
            this.groupBoxEncryptFile.Size = new System.Drawing.Size(581, 277);
            this.groupBoxEncryptFile.TabIndex = 23;
            this.groupBoxEncryptFile.TabStop = false;
            this.groupBoxEncryptFile.Text = "Encrypt File";
            // 
            // checkCompress
            // 
            this.checkCompress.AutoSize = true;
            this.checkCompress.Checked = true;
            this.checkCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCompress.Location = new System.Drawing.Point(377, 160);
            this.checkCompress.Name = "checkCompress";
            this.checkCompress.Size = new System.Drawing.Size(157, 17);
            this.checkCompress.TabIndex = 22;
            this.checkCompress.Text = "Compress before encryption";
            this.checkCompress.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "RSA Mode";
            // 
            // comboRSAEn
            // 
            this.comboRSAEn.FormattingEnabled = true;
            this.comboRSAEn.Location = new System.Drawing.Point(139, 158);
            this.comboRSAEn.Name = "comboRSAEn";
            this.comboRSAEn.Size = new System.Drawing.Size(121, 21);
            this.comboRSAEn.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Key";
            // 
            // rtxtKeyEn
            // 
            this.rtxtKeyEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtKeyEn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtKeyEn.Location = new System.Drawing.Point(139, 197);
            this.rtxtKeyEn.Name = "rtxtKeyEn";
            this.rtxtKeyEn.ReadOnly = true;
            this.rtxtKeyEn.Size = new System.Drawing.Size(332, 65);
            this.rtxtKeyEn.TabIndex = 18;
            this.rtxtKeyEn.Text = "";
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEncryptFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncryptFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncryptFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncryptFile.Location = new System.Drawing.Point(489, 239);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(75, 23);
            this.btnEncryptFile.TabIndex = 17;
            this.btnEncryptFile.Text = "Encrypt";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // btnKeyEn
            // 
            this.btnKeyEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnKeyEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKeyEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKeyEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyEn.Location = new System.Drawing.Point(540, 114);
            this.btnKeyEn.Name = "btnKeyEn";
            this.btnKeyEn.Size = new System.Drawing.Size(30, 23);
            this.btnKeyEn.TabIndex = 16;
            this.btnKeyEn.Text = "...";
            this.btnKeyEn.UseVisualStyleBackColor = true;
            this.btnKeyEn.Click += new System.EventHandler(this.btnKeyEn_Click);
            // 
            // btnTargetEn
            // 
            this.btnTargetEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTargetEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTargetEn.Location = new System.Drawing.Point(540, 73);
            this.btnTargetEn.Name = "btnTargetEn";
            this.btnTargetEn.Size = new System.Drawing.Size(30, 23);
            this.btnTargetEn.TabIndex = 15;
            this.btnTargetEn.Text = "...";
            this.btnTargetEn.UseVisualStyleBackColor = true;
            this.btnTargetEn.Click += new System.EventHandler(this.btnTargetEn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Pubkey file ( >= 512 bit)";
            // 
            // txtKeyEn
            // 
            this.txtKeyEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtKeyEn.Location = new System.Drawing.Point(139, 116);
            this.txtKeyEn.Name = "txtKeyEn";
            this.txtKeyEn.ReadOnly = true;
            this.txtKeyEn.Size = new System.Drawing.Size(395, 20);
            this.txtKeyEn.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Target file";
            // 
            // txtTargetEn
            // 
            this.txtTargetEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTargetEn.Location = new System.Drawing.Point(139, 75);
            this.txtTargetEn.Name = "txtTargetEn";
            this.txtTargetEn.ReadOnly = true;
            this.txtTargetEn.Size = new System.Drawing.Size(395, 20);
            this.txtTargetEn.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Source files";
            // 
            // btnSourceEn
            // 
            this.btnSourceEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSourceEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSourceEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSourceEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSourceEn.Location = new System.Drawing.Point(540, 34);
            this.btnSourceEn.Name = "btnSourceEn";
            this.btnSourceEn.Size = new System.Drawing.Size(30, 23);
            this.btnSourceEn.TabIndex = 1;
            this.btnSourceEn.Text = "...";
            this.btnSourceEn.UseVisualStyleBackColor = true;
            this.btnSourceEn.Visible = false;
            this.btnSourceEn.Click += new System.EventHandler(this.btnSourceEn_Click);
            // 
            // txtSouceEn
            // 
            this.txtSouceEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSouceEn.Location = new System.Drawing.Point(139, 36);
            this.txtSouceEn.Name = "txtSouceEn";
            this.txtSouceEn.ReadOnly = true;
            this.txtSouceEn.Size = new System.Drawing.Size(395, 20);
            this.txtSouceEn.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Encrypted text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Num bit (multiple of 8)";
            // 
            // txtNumBit
            // 
            this.txtNumBit.Location = new System.Drawing.Point(184, 29);
            this.txtNumBit.Name = "txtNumBit";
            this.txtNumBit.Size = new System.Drawing.Size(96, 20);
            this.txtNumBit.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Location = new System.Drawing.Point(461, 26);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(103, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Key";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Private Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Public Key";
            // 
            // rtxtPrivateKey
            // 
            this.rtxtPrivateKey.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtPrivateKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtPrivateKey.Location = new System.Drawing.Point(290, 97);
            this.rtxtPrivateKey.Name = "rtxtPrivateKey";
            this.rtxtPrivateKey.ReadOnly = true;
            this.rtxtPrivateKey.Size = new System.Drawing.Size(274, 77);
            this.rtxtPrivateKey.TabIndex = 11;
            this.rtxtPrivateKey.Text = "";
            // 
            // rtxtPublicKey
            // 
            this.rtxtPublicKey.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtPublicKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtPublicKey.Location = new System.Drawing.Point(6, 97);
            this.rtxtPublicKey.Name = "rtxtPublicKey";
            this.rtxtPublicKey.ReadOnly = true;
            this.rtxtPublicKey.Size = new System.Drawing.Size(274, 77);
            this.rtxtPublicKey.TabIndex = 10;
            this.rtxtPublicKey.Text = "";
            // 
            // btnSavePrivateKey
            // 
            this.btnSavePrivateKey.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSavePrivateKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSavePrivateKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSavePrivateKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePrivateKey.Location = new System.Drawing.Point(489, 180);
            this.btnSavePrivateKey.Name = "btnSavePrivateKey";
            this.btnSavePrivateKey.Size = new System.Drawing.Size(75, 23);
            this.btnSavePrivateKey.TabIndex = 9;
            this.btnSavePrivateKey.Text = "Save";
            this.btnSavePrivateKey.UseVisualStyleBackColor = true;
            this.btnSavePrivateKey.Click += new System.EventHandler(this.btnSavePrivateKey_Click);
            // 
            // btnSavePublicKey
            // 
            this.btnSavePublicKey.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSavePublicKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSavePublicKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSavePublicKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePublicKey.Location = new System.Drawing.Point(205, 180);
            this.btnSavePublicKey.Name = "btnSavePublicKey";
            this.btnSavePublicKey.Size = new System.Drawing.Size(75, 23);
            this.btnSavePublicKey.TabIndex = 8;
            this.btnSavePublicKey.Text = "Save";
            this.btnSavePublicKey.UseVisualStyleBackColor = true;
            this.btnSavePublicKey.Click += new System.EventHandler(this.btnSavePublicKey_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtPrivateKey);
            this.groupBox1.Controls.Add(this.rtxtPublicKey);
            this.groupBox1.Controls.Add(this.btnSavePrivateKey);
            this.groupBox1.Controls.Add(this.btnSavePublicKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNumBit);
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 213);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Key";
            // 
            // checkUppercase
            // 
            this.checkUppercase.AutoSize = true;
            this.checkUppercase.Checked = true;
            this.checkUppercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUppercase.Location = new System.Drawing.Point(486, 26);
            this.checkUppercase.Name = "checkUppercase";
            this.checkUppercase.Size = new System.Drawing.Size(78, 17);
            this.checkUppercase.TabIndex = 15;
            this.checkUppercase.Text = "Uppercase";
            this.checkUppercase.UseVisualStyleBackColor = true;
            this.checkUppercase.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Encrypt RSA Mode";
            // 
            // comboRSAMode
            // 
            this.comboRSAMode.FormattingEnabled = true;
            this.comboRSAMode.Location = new System.Drawing.Point(130, 27);
            this.comboRSAMode.Name = "comboRSAMode";
            this.comboRSAMode.Size = new System.Drawing.Size(121, 21);
            this.comboRSAMode.TabIndex = 13;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDecrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.Location = new System.Drawing.Point(130, 217);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(86, 23);
            this.btnDecrypt.TabIndex = 12;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Location = new System.Drawing.Point(130, 134);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(86, 23);
            this.btnEncrypt.TabIndex = 11;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // rtxtDecryptedText
            // 
            this.rtxtDecryptedText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtDecryptedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtDecryptedText.Location = new System.Drawing.Point(130, 246);
            this.rtxtDecryptedText.Name = "rtxtDecryptedText";
            this.rtxtDecryptedText.ReadOnly = true;
            this.rtxtDecryptedText.Size = new System.Drawing.Size(434, 48);
            this.rtxtDecryptedText.TabIndex = 10;
            this.rtxtDecryptedText.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Decrypted text";
            // 
            // rtxtEncryptedText
            // 
            this.rtxtEncryptedText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtEncryptedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtEncryptedText.Location = new System.Drawing.Point(130, 163);
            this.rtxtEncryptedText.Name = "rtxtEncryptedText";
            this.rtxtEncryptedText.ReadOnly = true;
            this.rtxtEncryptedText.Size = new System.Drawing.Size(434, 48);
            this.rtxtEncryptedText.TabIndex = 8;
            this.rtxtEncryptedText.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkUppercase);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboRSAMode);
            this.groupBox2.Controls.Add(this.btnDecrypt);
            this.groupBox2.Controls.Add(this.btnEncrypt);
            this.groupBox2.Controls.Add(this.rtxtDecryptedText);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rtxtPlainText);
            this.groupBox2.Controls.Add(this.rtxtEncryptedText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(11, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 306);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encrypt && Decrypt String";
            // 
            // rtxtPlainText
            // 
            this.rtxtPlainText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtPlainText.Location = new System.Drawing.Point(130, 80);
            this.rtxtPlainText.Name = "rtxtPlainText";
            this.rtxtPlainText.Size = new System.Drawing.Size(434, 48);
            this.rtxtPlainText.TabIndex = 6;
            this.rtxtPlainText.Text = "";
            // 
            // FormRSAEncryptDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1184, 544);
            this.Controls.Add(this.groupBoxDecryptFile);
            this.Controls.Add(this.groupBoxEncryptFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRSAEncryptDecrypt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSA Encrypt & Decrypt";
            this.Load += new System.EventHandler(this.FormRSAEncryptDecrypt_Load);
            this.groupBoxDecryptFile.ResumeLayout(false);
            this.groupBoxDecryptFile.PerformLayout();
            this.groupBoxEncryptFile.ResumeLayout(false);
            this.groupBoxEncryptFile.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxDecryptFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtxtKeyDe;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Button btnKeyDe;
        private System.Windows.Forms.Button btnTargetDe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKeyDe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTargetDe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSourceDe;
        private System.Windows.Forms.TextBox txtSourceDe;
        private System.Windows.Forms.GroupBox groupBoxEncryptFile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboRSAEn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtxtKeyEn;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Button btnKeyEn;
        private System.Windows.Forms.Button btnTargetEn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtKeyEn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTargetEn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSourceEn;
        private System.Windows.Forms.TextBox txtSouceEn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumBit;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtPrivateKey;
        private System.Windows.Forms.RichTextBox rtxtPublicKey;
        private System.Windows.Forms.Button btnSavePrivateKey;
        private System.Windows.Forms.Button btnSavePublicKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkUppercase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboRSAMode;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.RichTextBox rtxtDecryptedText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxtEncryptedText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxtPlainText;
        private System.Windows.Forms.CheckBox checkCompress;
    }
}