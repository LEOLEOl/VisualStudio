namespace ConvertCurrency
{
    partial class Form1
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
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtV1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtV2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtV22 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRate2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtV12 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtV23 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRate3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtV13 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtV24 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRate4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtV14 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(22, 51);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(141, 20);
            this.txtRate.TabIndex = 0;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exchange rate k (1V1 = kV2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Value 1";
            // 
            // txtV1
            // 
            this.txtV1.Location = new System.Drawing.Point(269, 33);
            this.txtV1.Name = "txtV1";
            this.txtV1.Size = new System.Drawing.Size(200, 20);
            this.txtV1.TabIndex = 2;
            this.txtV1.TextChanged += new System.EventHandler(this.txtV1_TextChanged);
            this.txtV1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value 2";
            // 
            // txtV2
            // 
            this.txtV2.Location = new System.Drawing.Point(269, 78);
            this.txtV2.Name = "txtV2";
            this.txtV2.Size = new System.Drawing.Size(200, 20);
            this.txtV2.TabIndex = 4;
            this.txtV2.TextChanged += new System.EventHandler(this.txtV2_TextChanged);
            this.txtV2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV2_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtV2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtV1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 124);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtV22);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtRate2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtV12);
            this.groupBox2.Location = new System.Drawing.Point(10, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 124);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // txtV22
            // 
            this.txtV22.Location = new System.Drawing.Point(269, 78);
            this.txtV22.Name = "txtV22";
            this.txtV22.Size = new System.Drawing.Size(200, 20);
            this.txtV22.TabIndex = 4;
            this.txtV22.TextChanged += new System.EventHandler(this.txtV22_TextChanged);
            this.txtV22.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV22_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Value 2";
            // 
            // txtRate2
            // 
            this.txtRate2.Location = new System.Drawing.Point(22, 51);
            this.txtRate2.Name = "txtRate2";
            this.txtRate2.Size = new System.Drawing.Size(141, 20);
            this.txtRate2.TabIndex = 0;
            this.txtRate2.TextChanged += new System.EventHandler(this.txtRate2_TextChanged);
            this.txtRate2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Exchange rate k (1V1 = kV2)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Value 1";
            // 
            // txtV12
            // 
            this.txtV12.Location = new System.Drawing.Point(269, 33);
            this.txtV12.Name = "txtV12";
            this.txtV12.Size = new System.Drawing.Size(200, 20);
            this.txtV12.TabIndex = 2;
            this.txtV12.TextChanged += new System.EventHandler(this.txtV12_TextChanged);
            this.txtV12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV12_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtV23);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtRate3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtV13);
            this.groupBox3.Location = new System.Drawing.Point(524, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 124);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // txtV23
            // 
            this.txtV23.Location = new System.Drawing.Point(269, 78);
            this.txtV23.Name = "txtV23";
            this.txtV23.Size = new System.Drawing.Size(200, 20);
            this.txtV23.TabIndex = 4;
            this.txtV23.TextChanged += new System.EventHandler(this.txtV23_TextChanged);
            this.txtV23.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV23_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Value 2";
            // 
            // txtRate3
            // 
            this.txtRate3.Location = new System.Drawing.Point(22, 51);
            this.txtRate3.Name = "txtRate3";
            this.txtRate3.Size = new System.Drawing.Size(141, 20);
            this.txtRate3.TabIndex = 0;
            this.txtRate3.TextChanged += new System.EventHandler(this.txtRate3_TextChanged);
            this.txtRate3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate3_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Exchange rate k (1V1 = kV2)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Value 1";
            // 
            // txtV13
            // 
            this.txtV13.Location = new System.Drawing.Point(269, 33);
            this.txtV13.Name = "txtV13";
            this.txtV13.Size = new System.Drawing.Size(200, 20);
            this.txtV13.TabIndex = 2;
            this.txtV13.TextChanged += new System.EventHandler(this.txtV13_TextChanged);
            this.txtV13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV13_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtV24);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtRate4);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtV14);
            this.groupBox4.Location = new System.Drawing.Point(524, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(495, 124);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // txtV24
            // 
            this.txtV24.Location = new System.Drawing.Point(269, 78);
            this.txtV24.Name = "txtV24";
            this.txtV24.Size = new System.Drawing.Size(200, 20);
            this.txtV24.TabIndex = 4;
            this.txtV24.TextChanged += new System.EventHandler(this.txtV24_TextChanged);
            this.txtV24.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV24_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(208, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Value 2";
            // 
            // txtRate4
            // 
            this.txtRate4.Location = new System.Drawing.Point(22, 51);
            this.txtRate4.Name = "txtRate4";
            this.txtRate4.Size = new System.Drawing.Size(141, 20);
            this.txtRate4.TabIndex = 0;
            this.txtRate4.TextChanged += new System.EventHandler(this.txtRate4_TextChanged);
            this.txtRate4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate4_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Exchange rate k (1V1 = kV2)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(208, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Value 1";
            // 
            // txtV14
            // 
            this.txtV14.Location = new System.Drawing.Point(269, 33);
            this.txtV14.Name = "txtV14";
            this.txtV14.Size = new System.Drawing.Size(200, 20);
            this.txtV14.TabIndex = 2;
            this.txtV14.TextChanged += new System.EventHandler(this.txtV14_TextChanged);
            this.txtV14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV14_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 277);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convertor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtV1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtV2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtV22;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRate2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtV12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtV23;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRate3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtV13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtV24;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRate4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtV14;
    }
}

