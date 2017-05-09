namespace CryptoSystemExpert
{
    partial class FormEncrypt
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkCompress = new System.Windows.Forms.CheckBox();
            this.checkRanAll = new System.Windows.Forms.CheckBox();
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
            this.txtSouceEn = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkCompress);
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
            this.groupBox3.Controls.Add(this.txtSouceEn);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(513, 327);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encrypt File";
            // 
            // checkCompress
            // 
            this.checkCompress.AutoSize = true;
            this.checkCompress.Checked = true;
            this.checkCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCompress.Location = new System.Drawing.Point(216, 282);
            this.checkCompress.Name = "checkCompress";
            this.checkCompress.Size = new System.Drawing.Size(157, 17);
            this.checkCompress.TabIndex = 12;
            this.checkCompress.Text = "Compress before encryption";
            this.checkCompress.UseVisualStyleBackColor = true;
            // 
            // checkRanAll
            // 
            this.checkRanAll.AutoSize = true;
            this.checkRanAll.Location = new System.Drawing.Point(216, 167);
            this.checkRanAll.Name = "checkRanAll";
            this.checkRanAll.Size = new System.Drawing.Size(259, 17);
            this.checkRanAll.TabIndex = 7;
            this.checkRanAll.Text = "Random (Algorithm, Padding Mode, Cipher Mode)";
            this.checkRanAll.UseVisualStyleBackColor = true;
            this.checkRanAll.CheckedChanged += new System.EventHandler(this.checkRanAll_CheckedChanged);
            // 
            // comboRecipient
            // 
            this.comboRecipient.FormattingEnabled = true;
            this.comboRecipient.Location = new System.Drawing.Point(97, 116);
            this.comboRecipient.Name = "comboRecipient";
            this.comboRecipient.Size = new System.Drawing.Size(363, 21);
            this.comboRecipient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Cipher Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Padding Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Algorithm";
            // 
            // comboCiMode
            // 
            this.comboCiMode.FormattingEnabled = true;
            this.comboCiMode.Location = new System.Drawing.Point(97, 250);
            this.comboCiMode.Name = "comboCiMode";
            this.comboCiMode.Size = new System.Drawing.Size(90, 21);
            this.comboCiMode.TabIndex = 6;
            // 
            // comboPadMode
            // 
            this.comboPadMode.FormattingEnabled = true;
            this.comboPadMode.Location = new System.Drawing.Point(97, 209);
            this.comboPadMode.Name = "comboPadMode";
            this.comboPadMode.Size = new System.Drawing.Size(90, 21);
            this.comboPadMode.TabIndex = 5;
            // 
            // comboAlgo
            // 
            this.comboAlgo.FormattingEnabled = true;
            this.comboAlgo.Location = new System.Drawing.Point(97, 168);
            this.comboAlgo.Name = "comboAlgo";
            this.comboAlgo.Size = new System.Drawing.Size(90, 21);
            this.comboAlgo.TabIndex = 4;
            // 
            // checkShowAlgo
            // 
            this.checkShowAlgo.AutoSize = true;
            this.checkShowAlgo.Checked = true;
            this.checkShowAlgo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAlgo.Location = new System.Drawing.Point(216, 213);
            this.checkShowAlgo.Name = "checkShowAlgo";
            this.checkShowAlgo.Size = new System.Drawing.Size(174, 17);
            this.checkShowAlgo.TabIndex = 9;
            this.checkShowAlgo.Text = "Show running random algorithm";
            this.checkShowAlgo.UseVisualStyleBackColor = true;
            // 
            // checkFP
            // 
            this.checkFP.AutoSize = true;
            this.checkFP.Location = new System.Drawing.Point(216, 259);
            this.checkFP.Name = "checkFP";
            this.checkFP.Size = new System.Drawing.Size(189, 17);
            this.checkFP.TabIndex = 11;
            this.checkFP.Text = "Force recipient input secret key Ks";
            this.checkFP.UseVisualStyleBackColor = true;
            // 
            // checkSP
            // 
            this.checkSP.AutoSize = true;
            this.checkSP.Location = new System.Drawing.Point(216, 236);
            this.checkSP.Name = "checkSP";
            this.checkSP.Size = new System.Drawing.Size(178, 17);
            this.checkSP.TabIndex = 10;
            this.checkSP.Text = "Show secret key Ks for recipient";
            this.checkSP.UseVisualStyleBackColor = true;
            // 
            // checkRP
            // 
            this.checkRP.AutoSize = true;
            this.checkRP.Checked = true;
            this.checkRP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRP.Location = new System.Drawing.Point(216, 190);
            this.checkRP.Name = "checkRP";
            this.checkRP.Size = new System.Drawing.Size(133, 17);
            this.checkRP.TabIndex = 8;
            this.checkRP.Text = "Random secret key Ks";
            this.checkRP.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Location = new System.Drawing.Point(415, 298);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 13;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnTargetEn
            // 
            this.btnTargetEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTargetEn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTargetEn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetEn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTargetEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTargetEn.Location = new System.Drawing.Point(466, 73);
            this.btnTargetEn.Name = "btnTargetEn";
            this.btnTargetEn.Size = new System.Drawing.Size(41, 23);
            this.btnTargetEn.TabIndex = 2;
            this.btnTargetEn.Text = "...";
            this.btnTargetEn.UseVisualStyleBackColor = false;
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
            this.txtTargetEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTargetEn.Location = new System.Drawing.Point(97, 75);
            this.txtTargetEn.Name = "txtTargetEn";
            this.txtTargetEn.ReadOnly = true;
            this.txtTargetEn.Size = new System.Drawing.Size(363, 20);
            this.txtTargetEn.TabIndex = 11;
            this.txtTargetEn.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Source files";
            // 
            // txtSouceEn
            // 
            this.txtSouceEn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSouceEn.Location = new System.Drawing.Point(97, 36);
            this.txtSouceEn.Name = "txtSouceEn";
            this.txtSouceEn.ReadOnly = true;
            this.txtSouceEn.Size = new System.Drawing.Size(363, 20);
            this.txtSouceEn.TabIndex = 0;
            this.txtSouceEn.TabStop = false;
            // 
            // FormEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(538, 348);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEncrypt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypt File";
            this.Load += new System.EventHandler(this.FormEncrypt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEncrypt_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkCompress;
        private System.Windows.Forms.CheckBox checkRanAll;
        private System.Windows.Forms.ComboBox comboRecipient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCiMode;
        private System.Windows.Forms.ComboBox comboPadMode;
        private System.Windows.Forms.ComboBox comboAlgo;
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
        private System.Windows.Forms.TextBox txtSouceEn;
    }
}