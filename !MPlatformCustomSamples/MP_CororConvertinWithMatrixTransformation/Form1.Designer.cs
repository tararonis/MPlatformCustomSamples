namespace MP_CororConvertinWithMatrixTransformation
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
            this.panelPr = new System.Windows.Forms.Panel();
            this.OpenFile_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.GpuPipilineOn_btn = new System.Windows.Forms.Button();
            this.PredifinedMatrix_txb = new System.Windows.Forms.ComboBox();
            this.Red_trb = new System.Windows.Forms.TrackBar();
            this.Green_trb = new System.Windows.Forms.TrackBar();
            this.Blue_trb = new System.Windows.Forms.TrackBar();
            this.ColorLevel_cmb = new System.Windows.Forms.ComboBox();
            this.Constant_trb = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Reset_btn = new System.Windows.Forms.Button();
            this.CurrentMatrix_txb = new System.Windows.Forms.TextBox();
            this.RedChannel_txb = new System.Windows.Forms.TextBox();
            this.GreenChannel_txb = new System.Windows.Forms.TextBox();
            this.BlueChannel_txb = new System.Windows.Forms.TextBox();
            this.ConstantChannel_txb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Red_trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green_trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Constant_trb)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPr
            // 
            this.panelPr.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPr.BackgroundImage = global::MP_CororConvertinWithMatrixTransformation.Properties.Resources.turn_on;
            this.panelPr.Location = new System.Drawing.Point(54, 48);
            this.panelPr.Name = "panelPr";
            this.panelPr.Size = new System.Drawing.Size(720, 576);
            this.panelPr.TabIndex = 0;
            // 
            // OpenFile_btn
            // 
            this.OpenFile_btn.Location = new System.Drawing.Point(54, 630);
            this.OpenFile_btn.Name = "OpenFile_btn";
            this.OpenFile_btn.Size = new System.Drawing.Size(720, 23);
            this.OpenFile_btn.TabIndex = 1;
            this.OpenFile_btn.Text = "Open File";
            this.OpenFile_btn.UseVisualStyleBackColor = true;
            this.OpenFile_btn.Click += new System.EventHandler(this.OpenFile_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GpuPipilineOn_btn
            // 
            this.GpuPipilineOn_btn.BackColor = System.Drawing.Color.Red;
            this.GpuPipilineOn_btn.Location = new System.Drawing.Point(805, 12);
            this.GpuPipilineOn_btn.Name = "GpuPipilineOn_btn";
            this.GpuPipilineOn_btn.Size = new System.Drawing.Size(223, 21);
            this.GpuPipilineOn_btn.TabIndex = 2;
            this.GpuPipilineOn_btn.Text = "GPU PIPELINE = OFF";
            this.GpuPipilineOn_btn.UseVisualStyleBackColor = false;
            this.GpuPipilineOn_btn.Click += new System.EventHandler(this.GpuPipilineOn_btn_Click);
            // 
            // PredifinedMatrix_txb
            // 
            this.PredifinedMatrix_txb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PredifinedMatrix_txb.Enabled = false;
            this.PredifinedMatrix_txb.FormattingEnabled = true;
            this.PredifinedMatrix_txb.Location = new System.Drawing.Point(805, 103);
            this.PredifinedMatrix_txb.Name = "PredifinedMatrix_txb";
            this.PredifinedMatrix_txb.Size = new System.Drawing.Size(223, 21);
            this.PredifinedMatrix_txb.TabIndex = 4;
            this.PredifinedMatrix_txb.SelectedIndexChanged += new System.EventHandler(this.PredifinedMatrix_txb_SelectedIndexChanged);
            // 
            // Red_trb
            // 
            this.Red_trb.Enabled = false;
            this.Red_trb.LargeChange = 20;
            this.Red_trb.Location = new System.Drawing.Point(805, 218);
            this.Red_trb.Maximum = 250;
            this.Red_trb.Minimum = -250;
            this.Red_trb.Name = "Red_trb";
            this.Red_trb.Size = new System.Drawing.Size(223, 45);
            this.Red_trb.SmallChange = 10;
            this.Red_trb.TabIndex = 5;
            this.Red_trb.Scroll += new System.EventHandler(this.R_trb_Scroll);
            // 
            // Green_trb
            // 
            this.Green_trb.Enabled = false;
            this.Green_trb.LargeChange = 20;
            this.Green_trb.Location = new System.Drawing.Point(805, 284);
            this.Green_trb.Maximum = 250;
            this.Green_trb.Minimum = -250;
            this.Green_trb.Name = "Green_trb";
            this.Green_trb.Size = new System.Drawing.Size(223, 45);
            this.Green_trb.SmallChange = 10;
            this.Green_trb.TabIndex = 6;
            this.Green_trb.Scroll += new System.EventHandler(this.G_trb_Scroll);
            // 
            // Blue_trb
            // 
            this.Blue_trb.Enabled = false;
            this.Blue_trb.LargeChange = 20;
            this.Blue_trb.Location = new System.Drawing.Point(805, 352);
            this.Blue_trb.Maximum = 250;
            this.Blue_trb.Minimum = -250;
            this.Blue_trb.Name = "Blue_trb";
            this.Blue_trb.Size = new System.Drawing.Size(223, 45);
            this.Blue_trb.SmallChange = 10;
            this.Blue_trb.TabIndex = 7;
            this.Blue_trb.Scroll += new System.EventHandler(this.B_trb_Scroll);
            // 
            // ColorLevel_cmb
            // 
            this.ColorLevel_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorLevel_cmb.Enabled = false;
            this.ColorLevel_cmb.FormattingEnabled = true;
            this.ColorLevel_cmb.Location = new System.Drawing.Point(805, 163);
            this.ColorLevel_cmb.Name = "ColorLevel_cmb";
            this.ColorLevel_cmb.Size = new System.Drawing.Size(223, 21);
            this.ColorLevel_cmb.TabIndex = 8;
            this.ColorLevel_cmb.SelectedIndexChanged += new System.EventHandler(this.ColorLevel_cmb_SelectedIndexChanged);
            // 
            // Constant_trb
            // 
            this.Constant_trb.Enabled = false;
            this.Constant_trb.LargeChange = 20;
            this.Constant_trb.Location = new System.Drawing.Point(805, 437);
            this.Constant_trb.Maximum = 250;
            this.Constant_trb.Minimum = -250;
            this.Constant_trb.Name = "Constant_trb";
            this.Constant_trb.Size = new System.Drawing.Size(223, 45);
            this.Constant_trb.SmallChange = 10;
            this.Constant_trb.TabIndex = 9;
            this.Constant_trb.Scroll += new System.EventHandler(this.Level_trb_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(802, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Channel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(802, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Red:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(802, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Green:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(802, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Blue:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(806, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Constant:";
            // 
            // Reset_btn
            // 
            this.Reset_btn.Location = new System.Drawing.Point(805, 60);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(223, 23);
            this.Reset_btn.TabIndex = 14;
            this.Reset_btn.Text = "Reset";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // CurrentMatrix_txb
            // 
            this.CurrentMatrix_txb.Location = new System.Drawing.Point(54, 13);
            this.CurrentMatrix_txb.Name = "CurrentMatrix_txb";
            this.CurrentMatrix_txb.ReadOnly = true;
            this.CurrentMatrix_txb.Size = new System.Drawing.Size(720, 20);
            this.CurrentMatrix_txb.TabIndex = 15;
            // 
            // RedChannel_txb
            // 
            this.RedChannel_txb.Enabled = false;
            this.RedChannel_txb.Location = new System.Drawing.Point(976, 195);
            this.RedChannel_txb.Name = "RedChannel_txb";
            this.RedChannel_txb.ReadOnly = true;
            this.RedChannel_txb.Size = new System.Drawing.Size(52, 20);
            this.RedChannel_txb.TabIndex = 16;
            this.RedChannel_txb.Text = "0";
            this.RedChannel_txb.TextChanged += new System.EventHandler(this.RedChannel_txb_TextChanged);
            // 
            // GreenChannel_txb
            // 
            this.GreenChannel_txb.Enabled = false;
            this.GreenChannel_txb.Location = new System.Drawing.Point(976, 261);
            this.GreenChannel_txb.Name = "GreenChannel_txb";
            this.GreenChannel_txb.ReadOnly = true;
            this.GreenChannel_txb.Size = new System.Drawing.Size(52, 20);
            this.GreenChannel_txb.TabIndex = 17;
            this.GreenChannel_txb.Text = "0";
            this.GreenChannel_txb.TextChanged += new System.EventHandler(this.GreenChannel_txb_TextChanged);
            // 
            // BlueChannel_txb
            // 
            this.BlueChannel_txb.Enabled = false;
            this.BlueChannel_txb.Location = new System.Drawing.Point(976, 329);
            this.BlueChannel_txb.Name = "BlueChannel_txb";
            this.BlueChannel_txb.ReadOnly = true;
            this.BlueChannel_txb.Size = new System.Drawing.Size(52, 20);
            this.BlueChannel_txb.TabIndex = 18;
            this.BlueChannel_txb.Text = "0";
            this.BlueChannel_txb.TextChanged += new System.EventHandler(this.BlueChannel_txb_TextChanged);
            // 
            // ConstantChannel_txb
            // 
            this.ConstantChannel_txb.Enabled = false;
            this.ConstantChannel_txb.Location = new System.Drawing.Point(976, 414);
            this.ConstantChannel_txb.Name = "ConstantChannel_txb";
            this.ConstantChannel_txb.ReadOnly = true;
            this.ConstantChannel_txb.Size = new System.Drawing.Size(52, 20);
            this.ConstantChannel_txb.TabIndex = 19;
            this.ConstantChannel_txb.Text = "0";
            this.ConstantChannel_txb.TextChanged += new System.EventHandler(this.ConstantChannel_txb_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.label6.Location = new System.Drawing.Point(1034, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.label7.Location = new System.Drawing.Point(1034, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.label8.Location = new System.Drawing.Point(1034, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.label9.Location = new System.Drawing.Point(1034, 417);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 665);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ConstantChannel_txb);
            this.Controls.Add(this.BlueChannel_txb);
            this.Controls.Add(this.GreenChannel_txb);
            this.Controls.Add(this.RedChannel_txb);
            this.Controls.Add(this.CurrentMatrix_txb);
            this.Controls.Add(this.Reset_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Constant_trb);
            this.Controls.Add(this.ColorLevel_cmb);
            this.Controls.Add(this.Blue_trb);
            this.Controls.Add(this.Green_trb);
            this.Controls.Add(this.Red_trb);
            this.Controls.Add(this.PredifinedMatrix_txb);
            this.Controls.Add(this.GpuPipilineOn_btn);
            this.Controls.Add(this.OpenFile_btn);
            this.Controls.Add(this.panelPr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Red_trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green_trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Constant_trb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPr;
        private System.Windows.Forms.Button OpenFile_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button GpuPipilineOn_btn;
        private System.Windows.Forms.ComboBox PredifinedMatrix_txb;
        private System.Windows.Forms.TrackBar Red_trb;
        private System.Windows.Forms.TrackBar Green_trb;
        private System.Windows.Forms.TrackBar Blue_trb;
        private System.Windows.Forms.ComboBox ColorLevel_cmb;
        private System.Windows.Forms.TrackBar Constant_trb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.TextBox CurrentMatrix_txb;
        private System.Windows.Forms.TextBox RedChannel_txb;
        private System.Windows.Forms.TextBox GreenChannel_txb;
        private System.Windows.Forms.TextBox BlueChannel_txb;
        private System.Windows.Forms.TextBox ConstantChannel_txb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

