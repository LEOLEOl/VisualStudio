namespace DoAnThucHanh
{
    partial class FormSignCheck
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
            this.label12 = new System.Windows.Forms.Label();
            this.btnSourceSign = new System.Windows.Forms.Button();
            this.txtSourceSign = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSignCheck = new System.Windows.Forms.Button();
            this.txtSignCheck = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSourceCheck = new System.Windows.Forms.Button();
            this.txtSourceCheck = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Source file";
            // 
            // btnSourceSign
            // 
            this.btnSourceSign.Location = new System.Drawing.Point(290, 28);
            this.btnSourceSign.Name = "btnSourceSign";
            this.btnSourceSign.Size = new System.Drawing.Size(24, 23);
            this.btnSourceSign.TabIndex = 1;
            this.btnSourceSign.Text = "...";
            this.btnSourceSign.UseVisualStyleBackColor = true;
            this.btnSourceSign.Click += new System.EventHandler(this.btnSourceSign_Click);
            // 
            // txtSourceSign
            // 
            this.txtSourceSign.Location = new System.Drawing.Point(69, 30);
            this.txtSourceSign.Name = "txtSourceSign";
            this.txtSourceSign.ReadOnly = true;
            this.txtSourceSign.Size = new System.Drawing.Size(214, 20);
            this.txtSourceSign.TabIndex = 24;
            this.txtSourceSign.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPassword);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnSign);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnSourceSign);
            this.groupBox4.Controls.Add(this.txtSourceSign);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(425, 114);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sign";
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(333, 28);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 3;
            this.btnSign.Text = "SIGN";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCheck);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.btnSignCheck);
            this.groupBox5.Controls.Add(this.txtSignCheck);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.btnSourceCheck);
            this.groupBox5.Controls.Add(this.txtSourceCheck);
            this.groupBox5.Location = new System.Drawing.Point(12, 141);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(425, 110);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Check signature";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(333, 29);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "CHECK";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Sign file";
            // 
            // btnSignCheck
            // 
            this.btnSignCheck.Location = new System.Drawing.Point(290, 71);
            this.btnSignCheck.Name = "btnSignCheck";
            this.btnSignCheck.Size = new System.Drawing.Size(24, 23);
            this.btnSignCheck.TabIndex = 5;
            this.btnSignCheck.Text = "...";
            this.btnSignCheck.UseVisualStyleBackColor = true;
            this.btnSignCheck.Click += new System.EventHandler(this.btnSignCheck_Click);
            // 
            // txtSignCheck
            // 
            this.txtSignCheck.Location = new System.Drawing.Point(69, 73);
            this.txtSignCheck.Name = "txtSignCheck";
            this.txtSignCheck.ReadOnly = true;
            this.txtSignCheck.Size = new System.Drawing.Size(214, 20);
            this.txtSignCheck.TabIndex = 27;
            this.txtSignCheck.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Source file";
            // 
            // btnSourceCheck
            // 
            this.btnSourceCheck.Location = new System.Drawing.Point(290, 28);
            this.btnSourceCheck.Name = "btnSourceCheck";
            this.btnSourceCheck.Size = new System.Drawing.Size(24, 23);
            this.btnSourceCheck.TabIndex = 4;
            this.btnSourceCheck.Text = "...";
            this.btnSourceCheck.UseVisualStyleBackColor = true;
            this.btnSourceCheck.Click += new System.EventHandler(this.btnSourceCheck_Click);
            // 
            // txtSourceCheck
            // 
            this.txtSourceCheck.Location = new System.Drawing.Point(69, 30);
            this.txtSourceCheck.Name = "txtSourceCheck";
            this.txtSourceCheck.ReadOnly = true;
            this.txtSourceCheck.Size = new System.Drawing.Size(214, 20);
            this.txtSourceCheck.TabIndex = 24;
            this.txtSourceCheck.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(69, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // FormSignCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 265);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSignCheck";
            this.ShowInTaskbar = false;
            this.Text = "Create Signature and Check Signature";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSourceSign;
        private System.Windows.Forms.TextBox txtSourceSign;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSignCheck;
        private System.Windows.Forms.TextBox txtSignCheck;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSourceCheck;
        private System.Windows.Forms.TextBox txtSourceCheck;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
    }
}