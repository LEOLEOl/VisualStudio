namespace DoAnThucHanh
{
    partial class FormEncryptDecrypt
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnTargetDe = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTargetDe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSourceDe = new System.Windows.Forms.Button();
            this.txtSouceDe = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboRecipient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCiMode = new System.Windows.Forms.ComboBox();
            this.comboPadMode = new System.Windows.Forms.ComboBox();
            this.comboAlgo = new System.Windows.Forms.ComboBox();
            this.checkShowAlgo = new System.Windows.Forms.CheckBox();
            this.checkFP = new System.Windows.Forms.CheckBox();
            this.checkSP = new System.Windows.Forms.CheckBox();
            this.checkRP = new System.Windows.Forms.CheckBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnTargetEn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTargetEn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSourceEn = new System.Windows.Forms.Button();
            this.txtSouceEn = new System.Windows.Forms.TextBox();
            this.checkRanAll = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDecrypt);
            this.groupBox2.Controls.Add(this.btnTargetDe);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTargetDe);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnSourceDe);
            this.groupBox2.Controls.Add(this.txtSouceDe);
            this.groupBox2.Location = new System.Drawing.Point(12, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 186);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decrypt File";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(551, 151);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 16;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnTargetDe
            // 
            this.btnTargetDe.Location = new System.Drawing.Point(602, 73);
            this.btnTargetDe.Name = "btnTargetDe";
            this.btnTargetDe.Size = new System.Drawing.Size(24, 23);
            this.btnTargetDe.TabIndex = 14;
            this.btnTargetDe.Text = "...";
            this.btnTargetDe.UseVisualStyleBackColor = true;
            this.btnTargetDe.Click += new System.EventHandler(this.btnTargetDe_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(139, 116);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(425, 20);
            this.txtPassword.TabIndex = 15;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Target file";
            // 
            // txtTargetDe
            // 
            this.txtTargetDe.Location = new System.Drawing.Point(139, 75);
            this.txtTargetDe.Name = "txtTargetDe";
            this.txtTargetDe.ReadOnly = true;
            this.txtTargetDe.Size = new System.Drawing.Size(425, 20);
            this.txtTargetDe.TabIndex = 11;
            this.txtTargetDe.TabStop = false;
            this.txtTargetDe.Text = "E:\\de.jpg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Source file";
            // 
            // btnSourceDe
            // 
            this.btnSourceDe.Location = new System.Drawing.Point(602, 34);
            this.btnSourceDe.Name = "btnSourceDe";
            this.btnSourceDe.Size = new System.Drawing.Size(24, 23);
            this.btnSourceDe.TabIndex = 13;
            this.btnSourceDe.Text = "...";
            this.btnSourceDe.UseVisualStyleBackColor = true;
            this.btnSourceDe.Click += new System.EventHandler(this.btnSourceDe_Click);
            // 
            // txtSouceDe
            // 
            this.txtSouceDe.Location = new System.Drawing.Point(139, 36);
            this.txtSouceDe.Name = "txtSouceDe";
            this.txtSouceDe.ReadOnly = true;
            this.txtSouceDe.Size = new System.Drawing.Size(425, 20);
            this.txtSouceDe.TabIndex = 0;
            this.txtSouceDe.TabStop = false;
            this.txtSouceDe.Text = "E:\\en";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkRanAll);
            this.groupBox3.Controls.Add(this.comboRecipient);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboCiMode);
            this.groupBox3.Controls.Add(this.comboPadMode);
            this.groupBox3.Controls.Add(this.comboAlgo);
            this.groupBox3.Controls.Add(this.checkShowAlgo);
            this.groupBox3.Controls.Add(this.checkFP);
            this.groupBox3.Controls.Add(this.checkSP);
            this.groupBox3.Controls.Add(this.checkRP);
            this.groupBox3.Controls.Add(this.btnEncrypt);
            this.groupBox3.Controls.Add(this.btnTargetEn);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtTargetEn);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnSourceEn);
            this.groupBox3.Controls.Add(this.txtSouceEn);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(653, 277);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encrypt File";
            // 
            // comboRecipient
            // 
            this.comboRecipient.FormattingEnabled = true;
            this.comboRecipient.Location = new System.Drawing.Point(139, 116);
            this.comboRecipient.Name = "comboRecipient";
            this.comboRecipient.Size = new System.Drawing.Size(425, 21);
            this.comboRecipient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Cipher Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Padding Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Algorithm";
            // 
            // comboCiMode
            // 
            this.comboCiMode.FormattingEnabled = true;
            this.comboCiMode.Location = new System.Drawing.Point(139, 230);
            this.comboCiMode.Name = "comboCiMode";
            this.comboCiMode.Size = new System.Drawing.Size(90, 21);
            this.comboCiMode.TabIndex = 6;
            // 
            // comboPadMode
            // 
            this.comboPadMode.FormattingEnabled = true;
            this.comboPadMode.Location = new System.Drawing.Point(139, 193);
            this.comboPadMode.Name = "comboPadMode";
            this.comboPadMode.Size = new System.Drawing.Size(90, 21);
            this.comboPadMode.TabIndex = 5;
            // 
            // comboAlgo
            // 
            this.comboAlgo.FormattingEnabled = true;
            this.comboAlgo.Location = new System.Drawing.Point(139, 156);
            this.comboAlgo.Name = "comboAlgo";
            this.comboAlgo.Size = new System.Drawing.Size(90, 21);
            this.comboAlgo.TabIndex = 4;
            // 
            // checkShowAlgo
            // 
            this.checkShowAlgo.AutoSize = true;
            this.checkShowAlgo.Checked = true;
            this.checkShowAlgo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAlgo.Location = new System.Drawing.Point(515, 179);
            this.checkShowAlgo.Name = "checkShowAlgo";
            this.checkShowAlgo.Size = new System.Drawing.Size(136, 17);
            this.checkShowAlgo.TabIndex = 9;
            this.checkShowAlgo.Text = "Show random algorithm";
            this.checkShowAlgo.UseVisualStyleBackColor = true;
            // 
            // checkFP
            // 
            this.checkFP.AutoSize = true;
            this.checkFP.Location = new System.Drawing.Point(515, 225);
            this.checkFP.Name = "checkFP";
            this.checkFP.Size = new System.Drawing.Size(137, 17);
            this.checkFP.TabIndex = 11;
            this.checkFP.Text = "Force recipient input Ks";
            this.checkFP.UseVisualStyleBackColor = true;
            // 
            // checkSP
            // 
            this.checkSP.AutoSize = true;
            this.checkSP.Location = new System.Drawing.Point(515, 202);
            this.checkSP.Name = "checkSP";
            this.checkSP.Size = new System.Drawing.Size(126, 17);
            this.checkSP.TabIndex = 10;
            this.checkSP.Text = "Show Ks for recipient";
            this.checkSP.UseVisualStyleBackColor = true;
            // 
            // checkRP
            // 
            this.checkRP.AutoSize = true;
            this.checkRP.Checked = true;
            this.checkRP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRP.Location = new System.Drawing.Point(515, 156);
            this.checkRP.Name = "checkRP";
            this.checkRP.Size = new System.Drawing.Size(81, 17);
            this.checkRP.TabIndex = 8;
            this.checkRP.Text = "Random Ks";
            this.checkRP.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(551, 248);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 12;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnTargetEn
            // 
            this.btnTargetEn.Location = new System.Drawing.Point(602, 73);
            this.btnTargetEn.Name = "btnTargetEn";
            this.btnTargetEn.Size = new System.Drawing.Size(24, 23);
            this.btnTargetEn.TabIndex = 2;
            this.btnTargetEn.Text = "...";
            this.btnTargetEn.UseVisualStyleBackColor = true;
            this.btnTargetEn.Click += new System.EventHandler(this.btnTargetEn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Recipient";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Target file";
            // 
            // txtTargetEn
            // 
            this.txtTargetEn.Location = new System.Drawing.Point(139, 75);
            this.txtTargetEn.Name = "txtTargetEn";
            this.txtTargetEn.ReadOnly = true;
            this.txtTargetEn.Size = new System.Drawing.Size(425, 20);
            this.txtTargetEn.TabIndex = 11;
            this.txtTargetEn.TabStop = false;
            this.txtTargetEn.Text = "E:\\en";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Source file";
            // 
            // btnSourceEn
            // 
            this.btnSourceEn.Location = new System.Drawing.Point(602, 34);
            this.btnSourceEn.Name = "btnSourceEn";
            this.btnSourceEn.Size = new System.Drawing.Size(24, 23);
            this.btnSourceEn.TabIndex = 1;
            this.btnSourceEn.Text = "...";
            this.btnSourceEn.UseVisualStyleBackColor = true;
            this.btnSourceEn.Click += new System.EventHandler(this.btnSourceEn_Click);
            // 
            // txtSouceEn
            // 
            this.txtSouceEn.Location = new System.Drawing.Point(139, 36);
            this.txtSouceEn.Name = "txtSouceEn";
            this.txtSouceEn.ReadOnly = true;
            this.txtSouceEn.Size = new System.Drawing.Size(425, 20);
            this.txtSouceEn.TabIndex = 0;
            this.txtSouceEn.TabStop = false;
            this.txtSouceEn.Text = "E:\\1.jpg";
            // 
            // checkRanAll
            // 
            this.checkRanAll.AutoSize = true;
            this.checkRanAll.Location = new System.Drawing.Point(252, 158);
            this.checkRanAll.Name = "checkRanAll";
            this.checkRanAll.Size = new System.Drawing.Size(259, 17);
            this.checkRanAll.TabIndex = 7;
            this.checkRanAll.Text = "Random (Algorithm, Padding Mode, Cipher Mode)";
            this.checkRanAll.UseVisualStyleBackColor = true;
            this.checkRanAll.CheckedChanged += new System.EventHandler(this.checkRanAll_CheckedChanged);
            // 
            // FormEncryptDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEncryptDecrypt";
            this.ShowInTaskbar = false;
            this.Text = "Encrypt and Decrypt file";
            this.Load += new System.EventHandler(this.FormEncryptDecrypt_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnTargetDe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTargetDe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSourceDe;
        private System.Windows.Forms.TextBox txtSouceDe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkShowAlgo;
        private System.Windows.Forms.CheckBox checkFP;
        private System.Windows.Forms.CheckBox checkSP;
        private System.Windows.Forms.CheckBox checkRP;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnTargetEn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTargetEn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSourceEn;
        private System.Windows.Forms.TextBox txtSouceEn;
        private System.Windows.Forms.ComboBox comboCiMode;
        private System.Windows.Forms.ComboBox comboPadMode;
        private System.Windows.Forms.ComboBox comboAlgo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRecipient;
        private System.Windows.Forms.CheckBox checkRanAll;
    }
}