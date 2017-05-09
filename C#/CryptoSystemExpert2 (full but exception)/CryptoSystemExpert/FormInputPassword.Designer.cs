namespace CryptoSystem
{
    partial class FormInputPassword
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
            this.btnOK = new System.Windows.Forms.Button();
            this.labelInputPass = new System.Windows.Forms.Label();
            this.txtInputPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(197, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelInputPass
            // 
            this.labelInputPass.AutoSize = true;
            this.labelInputPass.Location = new System.Drawing.Point(12, 22);
            this.labelInputPass.Name = "labelInputPass";
            this.labelInputPass.Size = new System.Drawing.Size(102, 13);
            this.labelInputPass.TabIndex = 7;
            this.labelInputPass.Text = "Input your password";
            // 
            // txtInputPass
            // 
            this.txtInputPass.Location = new System.Drawing.Point(130, 19);
            this.txtInputPass.Name = "txtInputPass";
            this.txtInputPass.Size = new System.Drawing.Size(142, 20);
            this.txtInputPass.TabIndex = 1;
            this.txtInputPass.UseSystemPasswordChar = true;
            // 
            // FormInputPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelInputPass);
            this.Controls.Add(this.txtInputPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInputPassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input your password";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormInputPassword_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelInputPass;
        private System.Windows.Forms.TextBox txtInputPass;
    }
}