namespace CryptoSystemExpert
{
    partial class FormHash
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
            this.checkUppercase = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioFMurmur2_64 = new System.Windows.Forms.RadioButton();
            this.radioFMD2 = new System.Windows.Forms.RadioButton();
            this.radioFWhirlpool = new System.Windows.Forms.RadioButton();
            this.radioFMD4 = new System.Windows.Forms.RadioButton();
            this.radioFAdler32 = new System.Windows.Forms.RadioButton();
            this.radioFCRC64 = new System.Windows.Forms.RadioButton();
            this.radioFTIGER1923 = new System.Windows.Forms.RadioButton();
            this.radioFCRC32 = new System.Windows.Forms.RadioButton();
            this.radioFRIPEMD160 = new System.Windows.Forms.RadioButton();
            this.btnCopyFile = new System.Windows.Forms.Button();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelRB = new System.Windows.Forms.Label();
            this.rtxtCompare = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtxtFileHash = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioFSHA512 = new System.Windows.Forms.RadioButton();
            this.radioFSHA384 = new System.Windows.Forms.RadioButton();
            this.radioFSHA256 = new System.Windows.Forms.RadioButton();
            this.radioFSHA1 = new System.Windows.Forms.RadioButton();
            this.radioFMD5 = new System.Windows.Forms.RadioButton();
            this.btnCopyString = new System.Windows.Forms.Button();
            this.txtString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtStringHash = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioSHA512 = new System.Windows.Forms.RadioButton();
            this.radioSHA384 = new System.Windows.Forms.RadioButton();
            this.radioSHA256 = new System.Windows.Forms.RadioButton();
            this.radioSHA1 = new System.Windows.Forms.RadioButton();
            this.radioMD5 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRBString = new System.Windows.Forms.Label();
            this.radioMurmur2_64 = new System.Windows.Forms.RadioButton();
            this.rtxtCompareString = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.radioMD2 = new System.Windows.Forms.RadioButton();
            this.radioWhirlpool = new System.Windows.Forms.RadioButton();
            this.radioMD4 = new System.Windows.Forms.RadioButton();
            this.radioAdler32 = new System.Windows.Forms.RadioButton();
            this.radioCRC64 = new System.Windows.Forms.RadioButton();
            this.radioTIGER1923 = new System.Windows.Forms.RadioButton();
            this.radioCRC32 = new System.Windows.Forms.RadioButton();
            this.radioRIPEMD160 = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkUppercase
            // 
            this.checkUppercase.AutoSize = true;
            this.checkUppercase.Checked = true;
            this.checkUppercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUppercase.Location = new System.Drawing.Point(642, 0);
            this.checkUppercase.Name = "checkUppercase";
            this.checkUppercase.Size = new System.Drawing.Size(78, 17);
            this.checkUppercase.TabIndex = 14;
            this.checkUppercase.Text = "Uppercase";
            this.checkUppercase.UseVisualStyleBackColor = true;
            this.checkUppercase.CheckedChanged += new System.EventHandler(this.checkUppercase_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.radioFMurmur2_64);
            this.groupBox2.Controls.Add(this.radioFMD2);
            this.groupBox2.Controls.Add(this.radioFWhirlpool);
            this.groupBox2.Controls.Add(this.radioFMD4);
            this.groupBox2.Controls.Add(this.radioFAdler32);
            this.groupBox2.Controls.Add(this.radioFCRC64);
            this.groupBox2.Controls.Add(this.radioFTIGER1923);
            this.groupBox2.Controls.Add(this.radioFCRC32);
            this.groupBox2.Controls.Add(this.radioFRIPEMD160);
            this.groupBox2.Controls.Add(this.btnCopyFile);
            this.groupBox2.Controls.Add(this.labelFileSize);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labelRB);
            this.groupBox2.Controls.Add(this.rtxtCompare);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnBrowseFile);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rtxtFileHash);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.radioFSHA512);
            this.groupBox2.Controls.Add(this.radioFSHA384);
            this.groupBox2.Controls.Add(this.radioFSHA256);
            this.groupBox2.Controls.Add(this.radioFSHA1);
            this.groupBox2.Controls.Add(this.radioFMD5);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(3, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 238);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hash File";
            // 
            // radioFMurmur2_64
            // 
            this.radioFMurmur2_64.AutoSize = true;
            this.radioFMurmur2_64.Location = new System.Drawing.Point(556, 99);
            this.radioFMurmur2_64.Name = "radioFMurmur2_64";
            this.radioFMurmur2_64.Size = new System.Drawing.Size(81, 17);
            this.radioFMurmur2_64.TabIndex = 20;
            this.radioFMurmur2_64.TabStop = true;
            this.radioFMurmur2_64.Text = "Murmur2-64";
            this.radioFMurmur2_64.UseVisualStyleBackColor = true;
            this.radioFMurmur2_64.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFMD2
            // 
            this.radioFMD2.AutoSize = true;
            this.radioFMD2.Location = new System.Drawing.Point(119, 76);
            this.radioFMD2.Name = "radioFMD2";
            this.radioFMD2.Size = new System.Drawing.Size(48, 17);
            this.radioFMD2.TabIndex = 19;
            this.radioFMD2.TabStop = true;
            this.radioFMD2.Text = "MD2";
            this.radioFMD2.UseVisualStyleBackColor = true;
            this.radioFMD2.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFWhirlpool
            // 
            this.radioFWhirlpool.AutoSize = true;
            this.radioFWhirlpool.Location = new System.Drawing.Point(481, 99);
            this.radioFWhirlpool.Name = "radioFWhirlpool";
            this.radioFWhirlpool.Size = new System.Drawing.Size(69, 17);
            this.radioFWhirlpool.TabIndex = 18;
            this.radioFWhirlpool.TabStop = true;
            this.radioFWhirlpool.Text = "Whirlpool";
            this.radioFWhirlpool.UseVisualStyleBackColor = true;
            this.radioFWhirlpool.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFMD4
            // 
            this.radioFMD4.AutoSize = true;
            this.radioFMD4.Location = new System.Drawing.Point(178, 76);
            this.radioFMD4.Name = "radioFMD4";
            this.radioFMD4.Size = new System.Drawing.Size(48, 17);
            this.radioFMD4.TabIndex = 17;
            this.radioFMD4.TabStop = true;
            this.radioFMD4.Text = "MD4";
            this.radioFMD4.UseVisualStyleBackColor = true;
            this.radioFMD4.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFAdler32
            // 
            this.radioFAdler32.AutoSize = true;
            this.radioFAdler32.Location = new System.Drawing.Point(320, 76);
            this.radioFAdler32.Name = "radioFAdler32";
            this.radioFAdler32.Size = new System.Drawing.Size(61, 17);
            this.radioFAdler32.TabIndex = 16;
            this.radioFAdler32.TabStop = true;
            this.radioFAdler32.Text = "Adler32";
            this.radioFAdler32.UseVisualStyleBackColor = true;
            this.radioFAdler32.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFCRC64
            // 
            this.radioFCRC64.AutoSize = true;
            this.radioFCRC64.Location = new System.Drawing.Point(481, 76);
            this.radioFCRC64.Name = "radioFCRC64";
            this.radioFCRC64.Size = new System.Drawing.Size(59, 17);
            this.radioFCRC64.TabIndex = 15;
            this.radioFCRC64.TabStop = true;
            this.radioFCRC64.Text = "CRC64";
            this.radioFCRC64.UseVisualStyleBackColor = true;
            this.radioFCRC64.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFTIGER1923
            // 
            this.radioFTIGER1923.AutoSize = true;
            this.radioFTIGER1923.Location = new System.Drawing.Point(556, 76);
            this.radioFTIGER1923.Name = "radioFTIGER1923";
            this.radioFTIGER1923.Size = new System.Drawing.Size(85, 17);
            this.radioFTIGER1923.TabIndex = 14;
            this.radioFTIGER1923.TabStop = true;
            this.radioFTIGER1923.Text = "TIGER192-3";
            this.radioFTIGER1923.UseVisualStyleBackColor = true;
            this.radioFTIGER1923.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFCRC32
            // 
            this.radioFCRC32.AutoSize = true;
            this.radioFCRC32.Location = new System.Drawing.Point(387, 76);
            this.radioFCRC32.Name = "radioFCRC32";
            this.radioFCRC32.Size = new System.Drawing.Size(59, 17);
            this.radioFCRC32.TabIndex = 13;
            this.radioFCRC32.TabStop = true;
            this.radioFCRC32.Text = "CRC32";
            this.radioFCRC32.UseVisualStyleBackColor = true;
            this.radioFCRC32.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFRIPEMD160
            // 
            this.radioFRIPEMD160.AutoSize = true;
            this.radioFRIPEMD160.Location = new System.Drawing.Point(387, 99);
            this.radioFRIPEMD160.Name = "radioFRIPEMD160";
            this.radioFRIPEMD160.Size = new System.Drawing.Size(88, 17);
            this.radioFRIPEMD160.TabIndex = 12;
            this.radioFRIPEMD160.TabStop = true;
            this.radioFRIPEMD160.Text = "RIPEMD-160";
            this.radioFRIPEMD160.UseVisualStyleBackColor = true;
            this.radioFRIPEMD160.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCopyFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCopyFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCopyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFile.Location = new System.Drawing.Point(647, 140);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(45, 25);
            this.btnCopyFile.TabIndex = 11;
            this.btnCopyFile.Text = "Copy";
            this.btnCopyFile.UseVisualStyleBackColor = true;
            this.btnCopyFile.Click += new System.EventHandler(this.buttonCopyFile_Click);
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(116, 51);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(36, 13);
            this.labelFileSize.TabIndex = 15;
            this.labelFileSize.Text = "0 byte";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "File size";
            // 
            // labelRB
            // 
            this.labelRB.AutoSize = true;
            this.labelRB.Location = new System.Drawing.Point(653, 201);
            this.labelRB.Name = "labelRB";
            this.labelRB.Size = new System.Drawing.Size(39, 13);
            this.labelRB.TabIndex = 13;
            this.labelRB.Text = "Wrong";
            // 
            // rtxtCompare
            // 
            this.rtxtCompare.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtCompare.Location = new System.Drawing.Point(119, 186);
            this.rtxtCompare.Name = "rtxtCompare";
            this.rtxtCompare.Size = new System.Drawing.Size(522, 45);
            this.rtxtCompare.TabIndex = 12;
            this.rtxtCompare.Text = "";
            this.rtxtCompare.TextChanged += new System.EventHandler(this.rtxtCompare_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Compare with";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBrowseFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBrowseFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFile.Location = new System.Drawing.Point(647, 16);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(45, 25);
            this.btnBrowseFile.TabIndex = 2;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPath.Location = new System.Drawing.Point(119, 19);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(522, 20);
            this.txtPath.TabIndex = 9;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "File path";
            // 
            // rtxtFileHash
            // 
            this.rtxtFileHash.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtFileHash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFileHash.Location = new System.Drawing.Point(119, 132);
            this.rtxtFileHash.Name = "rtxtFileHash";
            this.rtxtFileHash.ReadOnly = true;
            this.rtxtFileHash.Size = new System.Drawing.Size(522, 45);
            this.rtxtFileHash.TabIndex = 7;
            this.rtxtFileHash.Text = "";
            this.rtxtFileHash.TextChanged += new System.EventHandler(this.rtxtFileHash_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Checksum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Checksum type";
            // 
            // radioFSHA512
            // 
            this.radioFSHA512.AutoSize = true;
            this.radioFSHA512.Location = new System.Drawing.Point(320, 99);
            this.radioFSHA512.Name = "radioFSHA512";
            this.radioFSHA512.Size = new System.Drawing.Size(65, 17);
            this.radioFSHA512.TabIndex = 4;
            this.radioFSHA512.TabStop = true;
            this.radioFSHA512.Text = "SHA512";
            this.radioFSHA512.UseVisualStyleBackColor = true;
            this.radioFSHA512.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFSHA384
            // 
            this.radioFSHA384.AutoSize = true;
            this.radioFSHA384.Location = new System.Drawing.Point(249, 99);
            this.radioFSHA384.Name = "radioFSHA384";
            this.radioFSHA384.Size = new System.Drawing.Size(65, 17);
            this.radioFSHA384.TabIndex = 3;
            this.radioFSHA384.TabStop = true;
            this.radioFSHA384.Text = "SHA384";
            this.radioFSHA384.UseVisualStyleBackColor = true;
            this.radioFSHA384.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFSHA256
            // 
            this.radioFSHA256.AutoSize = true;
            this.radioFSHA256.Location = new System.Drawing.Point(178, 99);
            this.radioFSHA256.Name = "radioFSHA256";
            this.radioFSHA256.Size = new System.Drawing.Size(65, 17);
            this.radioFSHA256.TabIndex = 2;
            this.radioFSHA256.TabStop = true;
            this.radioFSHA256.Text = "SHA256";
            this.radioFSHA256.UseVisualStyleBackColor = true;
            this.radioFSHA256.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFSHA1
            // 
            this.radioFSHA1.AutoSize = true;
            this.radioFSHA1.Location = new System.Drawing.Point(119, 99);
            this.radioFSHA1.Name = "radioFSHA1";
            this.radioFSHA1.Size = new System.Drawing.Size(53, 17);
            this.radioFSHA1.TabIndex = 1;
            this.radioFSHA1.TabStop = true;
            this.radioFSHA1.Text = "SHA1";
            this.radioFSHA1.UseVisualStyleBackColor = true;
            this.radioFSHA1.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // radioFMD5
            // 
            this.radioFMD5.AutoSize = true;
            this.radioFMD5.Checked = true;
            this.radioFMD5.Location = new System.Drawing.Point(249, 76);
            this.radioFMD5.Name = "radioFMD5";
            this.radioFMD5.Size = new System.Drawing.Size(48, 17);
            this.radioFMD5.TabIndex = 0;
            this.radioFMD5.TabStop = true;
            this.radioFMD5.Text = "MD5";
            this.radioFMD5.UseVisualStyleBackColor = true;
            this.radioFMD5.CheckedChanged += new System.EventHandler(this.radioButtonsFile_CheckedChanged);
            // 
            // btnCopyString
            // 
            this.btnCopyString.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCopyString.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCopyString.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCopyString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyString.Location = new System.Drawing.Point(647, 114);
            this.btnCopyString.Name = "btnCopyString";
            this.btnCopyString.Size = new System.Drawing.Size(45, 25);
            this.btnCopyString.TabIndex = 10;
            this.btnCopyString.Text = "Copy";
            this.btnCopyString.UseVisualStyleBackColor = true;
            this.btnCopyString.Click += new System.EventHandler(this.btnCopyString_Click);
            // 
            // txtString
            // 
            this.txtString.BackColor = System.Drawing.SystemColors.Window;
            this.txtString.Location = new System.Drawing.Point(119, 19);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(522, 20);
            this.txtString.TabIndex = 1;
            this.txtString.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "String";
            // 
            // rtxtStringHash
            // 
            this.rtxtStringHash.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtStringHash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtStringHash.Location = new System.Drawing.Point(119, 105);
            this.rtxtStringHash.Name = "rtxtStringHash";
            this.rtxtStringHash.ReadOnly = true;
            this.rtxtStringHash.Size = new System.Drawing.Size(522, 45);
            this.rtxtStringHash.TabIndex = 7;
            this.rtxtStringHash.Text = "";
            this.rtxtStringHash.TextChanged += new System.EventHandler(this.rtxtStringHash_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Checksum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Checksum type";
            // 
            // radioSHA512
            // 
            this.radioSHA512.AutoSize = true;
            this.radioSHA512.Location = new System.Drawing.Point(320, 73);
            this.radioSHA512.Name = "radioSHA512";
            this.radioSHA512.Size = new System.Drawing.Size(65, 17);
            this.radioSHA512.TabIndex = 4;
            this.radioSHA512.TabStop = true;
            this.radioSHA512.Text = "SHA512";
            this.radioSHA512.UseVisualStyleBackColor = true;
            this.radioSHA512.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioSHA384
            // 
            this.radioSHA384.AutoSize = true;
            this.radioSHA384.Location = new System.Drawing.Point(249, 73);
            this.radioSHA384.Name = "radioSHA384";
            this.radioSHA384.Size = new System.Drawing.Size(65, 17);
            this.radioSHA384.TabIndex = 3;
            this.radioSHA384.TabStop = true;
            this.radioSHA384.Text = "SHA384";
            this.radioSHA384.UseVisualStyleBackColor = true;
            this.radioSHA384.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioSHA256
            // 
            this.radioSHA256.AutoSize = true;
            this.radioSHA256.Location = new System.Drawing.Point(178, 73);
            this.radioSHA256.Name = "radioSHA256";
            this.radioSHA256.Size = new System.Drawing.Size(65, 17);
            this.radioSHA256.TabIndex = 2;
            this.radioSHA256.TabStop = true;
            this.radioSHA256.Text = "SHA256";
            this.radioSHA256.UseVisualStyleBackColor = true;
            this.radioSHA256.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioSHA1
            // 
            this.radioSHA1.AutoSize = true;
            this.radioSHA1.Location = new System.Drawing.Point(119, 73);
            this.radioSHA1.Name = "radioSHA1";
            this.radioSHA1.Size = new System.Drawing.Size(53, 17);
            this.radioSHA1.TabIndex = 1;
            this.radioSHA1.TabStop = true;
            this.radioSHA1.Text = "SHA1";
            this.radioSHA1.UseVisualStyleBackColor = true;
            this.radioSHA1.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioMD5
            // 
            this.radioMD5.AutoSize = true;
            this.radioMD5.Location = new System.Drawing.Point(249, 50);
            this.radioMD5.Name = "radioMD5";
            this.radioMD5.Size = new System.Drawing.Size(48, 17);
            this.radioMD5.TabIndex = 0;
            this.radioMD5.TabStop = true;
            this.radioMD5.Text = "MD5";
            this.radioMD5.UseVisualStyleBackColor = true;
            this.radioMD5.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRBString);
            this.groupBox1.Controls.Add(this.radioMurmur2_64);
            this.groupBox1.Controls.Add(this.rtxtCompareString);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.radioMD2);
            this.groupBox1.Controls.Add(this.radioWhirlpool);
            this.groupBox1.Controls.Add(this.radioMD4);
            this.groupBox1.Controls.Add(this.radioAdler32);
            this.groupBox1.Controls.Add(this.radioCRC64);
            this.groupBox1.Controls.Add(this.radioTIGER1923);
            this.groupBox1.Controls.Add(this.radioCRC32);
            this.groupBox1.Controls.Add(this.radioRIPEMD160);
            this.groupBox1.Controls.Add(this.btnCopyString);
            this.groupBox1.Controls.Add(this.txtString);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rtxtStringHash);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioSHA512);
            this.groupBox1.Controls.Add(this.radioSHA384);
            this.groupBox1.Controls.Add(this.radioSHA256);
            this.groupBox1.Controls.Add(this.radioSHA1);
            this.groupBox1.Controls.Add(this.radioMD5);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 208);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hash String";
            // 
            // labelRBString
            // 
            this.labelRBString.AutoSize = true;
            this.labelRBString.Location = new System.Drawing.Point(653, 171);
            this.labelRBString.Name = "labelRBString";
            this.labelRBString.Size = new System.Drawing.Size(39, 13);
            this.labelRBString.TabIndex = 23;
            this.labelRBString.Text = "Wrong";
            // 
            // radioMurmur2_64
            // 
            this.radioMurmur2_64.AutoSize = true;
            this.radioMurmur2_64.Location = new System.Drawing.Point(556, 73);
            this.radioMurmur2_64.Name = "radioMurmur2_64";
            this.radioMurmur2_64.Size = new System.Drawing.Size(81, 17);
            this.radioMurmur2_64.TabIndex = 19;
            this.radioMurmur2_64.TabStop = true;
            this.radioMurmur2_64.Text = "Murmur2-64";
            this.radioMurmur2_64.UseVisualStyleBackColor = true;
            this.radioMurmur2_64.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rtxtCompareString
            // 
            this.rtxtCompareString.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtCompareString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtCompareString.Location = new System.Drawing.Point(119, 156);
            this.rtxtCompareString.Name = "rtxtCompareString";
            this.rtxtCompareString.Size = new System.Drawing.Size(522, 45);
            this.rtxtCompareString.TabIndex = 22;
            this.rtxtCompareString.Text = "";
            this.rtxtCompareString.TextChanged += new System.EventHandler(this.rtxtCompareString_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Compare with";
            // 
            // radioMD2
            // 
            this.radioMD2.AutoSize = true;
            this.radioMD2.Location = new System.Drawing.Point(119, 50);
            this.radioMD2.Name = "radioMD2";
            this.radioMD2.Size = new System.Drawing.Size(48, 17);
            this.radioMD2.TabIndex = 18;
            this.radioMD2.TabStop = true;
            this.radioMD2.Text = "MD2";
            this.radioMD2.UseVisualStyleBackColor = true;
            this.radioMD2.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioWhirlpool
            // 
            this.radioWhirlpool.AutoSize = true;
            this.radioWhirlpool.Location = new System.Drawing.Point(481, 73);
            this.radioWhirlpool.Name = "radioWhirlpool";
            this.radioWhirlpool.Size = new System.Drawing.Size(69, 17);
            this.radioWhirlpool.TabIndex = 17;
            this.radioWhirlpool.TabStop = true;
            this.radioWhirlpool.Text = "Whirlpool";
            this.radioWhirlpool.UseVisualStyleBackColor = true;
            this.radioWhirlpool.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioMD4
            // 
            this.radioMD4.AutoSize = true;
            this.radioMD4.Location = new System.Drawing.Point(178, 50);
            this.radioMD4.Name = "radioMD4";
            this.radioMD4.Size = new System.Drawing.Size(48, 17);
            this.radioMD4.TabIndex = 16;
            this.radioMD4.TabStop = true;
            this.radioMD4.Text = "MD4";
            this.radioMD4.UseVisualStyleBackColor = true;
            this.radioMD4.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioAdler32
            // 
            this.radioAdler32.AutoSize = true;
            this.radioAdler32.Location = new System.Drawing.Point(320, 50);
            this.radioAdler32.Name = "radioAdler32";
            this.radioAdler32.Size = new System.Drawing.Size(61, 17);
            this.radioAdler32.TabIndex = 15;
            this.radioAdler32.TabStop = true;
            this.radioAdler32.Text = "Adler32";
            this.radioAdler32.UseVisualStyleBackColor = true;
            this.radioAdler32.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioCRC64
            // 
            this.radioCRC64.AutoSize = true;
            this.radioCRC64.Location = new System.Drawing.Point(481, 50);
            this.radioCRC64.Name = "radioCRC64";
            this.radioCRC64.Size = new System.Drawing.Size(59, 17);
            this.radioCRC64.TabIndex = 14;
            this.radioCRC64.TabStop = true;
            this.radioCRC64.Text = "CRC64";
            this.radioCRC64.UseVisualStyleBackColor = true;
            this.radioCRC64.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioTIGER1923
            // 
            this.radioTIGER1923.AutoSize = true;
            this.radioTIGER1923.Location = new System.Drawing.Point(556, 50);
            this.radioTIGER1923.Name = "radioTIGER1923";
            this.radioTIGER1923.Size = new System.Drawing.Size(85, 17);
            this.radioTIGER1923.TabIndex = 13;
            this.radioTIGER1923.TabStop = true;
            this.radioTIGER1923.Text = "TIGER192-3";
            this.radioTIGER1923.UseVisualStyleBackColor = true;
            this.radioTIGER1923.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioCRC32
            // 
            this.radioCRC32.AutoSize = true;
            this.radioCRC32.Location = new System.Drawing.Point(387, 50);
            this.radioCRC32.Name = "radioCRC32";
            this.radioCRC32.Size = new System.Drawing.Size(59, 17);
            this.radioCRC32.TabIndex = 12;
            this.radioCRC32.TabStop = true;
            this.radioCRC32.Text = "CRC32";
            this.radioCRC32.UseVisualStyleBackColor = true;
            this.radioCRC32.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioRIPEMD160
            // 
            this.radioRIPEMD160.AutoSize = true;
            this.radioRIPEMD160.Location = new System.Drawing.Point(387, 73);
            this.radioRIPEMD160.Name = "radioRIPEMD160";
            this.radioRIPEMD160.Size = new System.Drawing.Size(88, 17);
            this.radioRIPEMD160.TabIndex = 11;
            this.radioRIPEMD160.TabStop = true;
            this.radioRIPEMD160.Text = "RIPEMD-160";
            this.radioRIPEMD160.UseVisualStyleBackColor = true;
            this.radioRIPEMD160.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // FormHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(723, 471);
            this.Controls.Add(this.checkUppercase);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hash Generator and Check";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkUppercase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioFMurmur2_64;
        private System.Windows.Forms.RadioButton radioFMD2;
        private System.Windows.Forms.RadioButton radioFWhirlpool;
        private System.Windows.Forms.RadioButton radioFMD4;
        private System.Windows.Forms.RadioButton radioFAdler32;
        private System.Windows.Forms.RadioButton radioFCRC64;
        private System.Windows.Forms.RadioButton radioFTIGER1923;
        private System.Windows.Forms.RadioButton radioFCRC32;
        private System.Windows.Forms.RadioButton radioFRIPEMD160;
        private System.Windows.Forms.Button btnCopyFile;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelRB;
        private System.Windows.Forms.RichTextBox rtxtCompare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtxtFileHash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioFSHA512;
        private System.Windows.Forms.RadioButton radioFSHA384;
        private System.Windows.Forms.RadioButton radioFSHA256;
        private System.Windows.Forms.RadioButton radioFSHA1;
        private System.Windows.Forms.RadioButton radioFMD5;
        private System.Windows.Forms.Button btnCopyString;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtStringHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioSHA512;
        private System.Windows.Forms.RadioButton radioSHA384;
        private System.Windows.Forms.RadioButton radioSHA256;
        private System.Windows.Forms.RadioButton radioSHA1;
        private System.Windows.Forms.RadioButton radioMD5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRBString;
        private System.Windows.Forms.RadioButton radioMurmur2_64;
        private System.Windows.Forms.RichTextBox rtxtCompareString;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioMD2;
        private System.Windows.Forms.RadioButton radioWhirlpool;
        private System.Windows.Forms.RadioButton radioMD4;
        private System.Windows.Forms.RadioButton radioAdler32;
        private System.Windows.Forms.RadioButton radioCRC64;
        private System.Windows.Forms.RadioButton radioTIGER1923;
        private System.Windows.Forms.RadioButton radioCRC32;
        private System.Windows.Forms.RadioButton radioRIPEMD160;

    }
}