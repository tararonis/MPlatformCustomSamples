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
            this.SetColorConvertion_btn = new System.Windows.Forms.Button();
            this.PredifinedMatrix_txb = new System.Windows.Forms.ComboBox();
            this.R_trb = new System.Windows.Forms.TrackBar();
            this.G_trb = new System.Windows.Forms.TrackBar();
            this.B_trb = new System.Windows.Forms.TrackBar();
            this.ColorLevel_cmb = new System.Windows.Forms.ComboBox();
            this.Level_trb = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.R_trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Level_trb)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPr
            // 
            this.panelPr.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPr.Location = new System.Drawing.Point(54, 24);
            this.panelPr.Name = "panelPr";
            this.panelPr.Size = new System.Drawing.Size(720, 576);
            this.panelPr.TabIndex = 0;
            // 
            // OpenFile_btn
            // 
            this.OpenFile_btn.Location = new System.Drawing.Point(54, 617);
            this.OpenFile_btn.Name = "OpenFile_btn";
            this.OpenFile_btn.Size = new System.Drawing.Size(720, 23);
            this.OpenFile_btn.TabIndex = 1;
            this.OpenFile_btn.Text = "OpenFile";
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
            this.GpuPipilineOn_btn.Location = new System.Drawing.Point(793, 24);
            this.GpuPipilineOn_btn.Name = "GpuPipilineOn_btn";
            this.GpuPipilineOn_btn.Size = new System.Drawing.Size(223, 23);
            this.GpuPipilineOn_btn.TabIndex = 2;
            this.GpuPipilineOn_btn.Text = "GPU PIPELINE = OFF";
            this.GpuPipilineOn_btn.UseVisualStyleBackColor = false;
            this.GpuPipilineOn_btn.Click += new System.EventHandler(this.GpuPipilineOn_btn_Click);
            // 
            // SetColorConvertion_btn
            // 
            this.SetColorConvertion_btn.Enabled = false;
            this.SetColorConvertion_btn.Location = new System.Drawing.Point(793, 70);
            this.SetColorConvertion_btn.Name = "SetColorConvertion_btn";
            this.SetColorConvertion_btn.Size = new System.Drawing.Size(223, 23);
            this.SetColorConvertion_btn.TabIndex = 3;
            this.SetColorConvertion_btn.Text = "SetColorConvertion";
            this.SetColorConvertion_btn.UseVisualStyleBackColor = true;
            this.SetColorConvertion_btn.Click += new System.EventHandler(this.SetColorConvertion_btn_Click);
            // 
            // PredifinedMatrix_txb
            // 
            this.PredifinedMatrix_txb.Enabled = false;
            this.PredifinedMatrix_txb.FormattingEnabled = true;
            this.PredifinedMatrix_txb.Location = new System.Drawing.Point(793, 114);
            this.PredifinedMatrix_txb.Name = "PredifinedMatrix_txb";
            this.PredifinedMatrix_txb.Size = new System.Drawing.Size(223, 21);
            this.PredifinedMatrix_txb.TabIndex = 4;
            // 
            // R_trb
            // 
            this.R_trb.Enabled = false;
            this.R_trb.LargeChange = 50;
            this.R_trb.Location = new System.Drawing.Point(793, 229);
            this.R_trb.Maximum = 200;
            this.R_trb.Minimum = -200;
            this.R_trb.Name = "R_trb";
            this.R_trb.Size = new System.Drawing.Size(223, 45);
            this.R_trb.SmallChange = 20;
            this.R_trb.TabIndex = 5;
            // 
            // G_trb
            // 
            this.G_trb.Enabled = false;
            this.G_trb.LargeChange = 50;
            this.G_trb.Location = new System.Drawing.Point(793, 295);
            this.G_trb.Maximum = 200;
            this.G_trb.Minimum = -200;
            this.G_trb.Name = "G_trb";
            this.G_trb.Size = new System.Drawing.Size(223, 45);
            this.G_trb.SmallChange = 20;
            this.G_trb.TabIndex = 6;
            // 
            // B_trb
            // 
            this.B_trb.Enabled = false;
            this.B_trb.LargeChange = 50;
            this.B_trb.Location = new System.Drawing.Point(793, 363);
            this.B_trb.Maximum = 200;
            this.B_trb.Minimum = -200;
            this.B_trb.Name = "B_trb";
            this.B_trb.Size = new System.Drawing.Size(223, 45);
            this.B_trb.SmallChange = 20;
            this.B_trb.TabIndex = 7;
            // 
            // ColorLevel_cmb
            // 
            this.ColorLevel_cmb.Enabled = false;
            this.ColorLevel_cmb.FormattingEnabled = true;
            this.ColorLevel_cmb.Location = new System.Drawing.Point(793, 174);
            this.ColorLevel_cmb.Name = "ColorLevel_cmb";
            this.ColorLevel_cmb.Size = new System.Drawing.Size(223, 21);
            this.ColorLevel_cmb.TabIndex = 8;
            // 
            // Level_trb
            // 
            this.Level_trb.Enabled = false;
            this.Level_trb.LargeChange = 50;
            this.Level_trb.Location = new System.Drawing.Point(793, 448);
            this.Level_trb.Maximum = 200;
            this.Level_trb.Minimum = -200;
            this.Level_trb.Name = "Level_trb";
            this.Level_trb.Size = new System.Drawing.Size(223, 45);
            this.Level_trb.SmallChange = 20;
            this.Level_trb.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(870, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(870, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(870, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(870, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(870, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 665);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Level_trb);
            this.Controls.Add(this.ColorLevel_cmb);
            this.Controls.Add(this.B_trb);
            this.Controls.Add(this.G_trb);
            this.Controls.Add(this.R_trb);
            this.Controls.Add(this.PredifinedMatrix_txb);
            this.Controls.Add(this.SetColorConvertion_btn);
            this.Controls.Add(this.GpuPipilineOn_btn);
            this.Controls.Add(this.OpenFile_btn);
            this.Controls.Add(this.panelPr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.R_trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Level_trb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPr;
        private System.Windows.Forms.Button OpenFile_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button GpuPipilineOn_btn;
        private System.Windows.Forms.Button SetColorConvertion_btn;
        private System.Windows.Forms.ComboBox PredifinedMatrix_txb;
        private System.Windows.Forms.TrackBar R_trb;
        private System.Windows.Forms.TrackBar G_trb;
        private System.Windows.Forms.TrackBar B_trb;
        private System.Windows.Forms.ComboBox ColorLevel_cmb;
        private System.Windows.Forms.TrackBar Level_trb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

