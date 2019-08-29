namespace MP_CheckTheNameSetSpeed
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
            this.OpenFileMFile_btn = new System.Windows.Forms.Button();
            this.Stat_lsb = new System.Windows.Forms.ListBox();
            this.panelpr = new System.Windows.Forms.Panel();
            this.OpenFileMPlaylist_btn = new System.Windows.Forms.Button();
            this.OpenFileMMixer_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.addParams = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenFileMFile_btn
            // 
            this.OpenFileMFile_btn.Location = new System.Drawing.Point(295, 176);
            this.OpenFileMFile_btn.Name = "OpenFileMFile_btn";
            this.OpenFileMFile_btn.Size = new System.Drawing.Size(222, 38);
            this.OpenFileMFile_btn.TabIndex = 0;
            this.OpenFileMFile_btn.Text = "OpenFileMFile";
            this.OpenFileMFile_btn.UseVisualStyleBackColor = true;
            this.OpenFileMFile_btn.Click += new System.EventHandler(this.OpenFileMFile_btn_Click);
            // 
            // Stat_lsb
            // 
            this.Stat_lsb.FormattingEnabled = true;
            this.Stat_lsb.Location = new System.Drawing.Point(12, 12);
            this.Stat_lsb.Name = "Stat_lsb";
            this.Stat_lsb.Size = new System.Drawing.Size(261, 290);
            this.Stat_lsb.TabIndex = 2;
            // 
            // panelpr
            // 
            this.panelpr.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelpr.Location = new System.Drawing.Point(295, 12);
            this.panelpr.Name = "panelpr";
            this.panelpr.Size = new System.Drawing.Size(222, 152);
            this.panelpr.TabIndex = 3;
            // 
            // OpenFileMPlaylist_btn
            // 
            this.OpenFileMPlaylist_btn.Location = new System.Drawing.Point(295, 220);
            this.OpenFileMPlaylist_btn.Name = "OpenFileMPlaylist_btn";
            this.OpenFileMPlaylist_btn.Size = new System.Drawing.Size(222, 38);
            this.OpenFileMPlaylist_btn.TabIndex = 4;
            this.OpenFileMPlaylist_btn.Text = "OpenFileMPlaylist";
            this.OpenFileMPlaylist_btn.UseVisualStyleBackColor = true;
            this.OpenFileMPlaylist_btn.Click += new System.EventHandler(this.OpenFileMPlaylist_btn_Click);
            // 
            // OpenFileMMixer_btn
            // 
            this.OpenFileMMixer_btn.Location = new System.Drawing.Point(295, 264);
            this.OpenFileMMixer_btn.Name = "OpenFileMMixer_btn";
            this.OpenFileMMixer_btn.Size = new System.Drawing.Size(222, 38);
            this.OpenFileMMixer_btn.TabIndex = 5;
            this.OpenFileMMixer_btn.Text = "OpenFileMMixer";
            this.OpenFileMMixer_btn.UseVisualStyleBackColor = true;
            this.OpenFileMMixer_btn.Click += new System.EventHandler(this.OpenFileMMixer_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // addParams
            // 
            this.addParams.Location = new System.Drawing.Point(78, 322);
            this.addParams.Name = "addParams";
            this.addParams.Size = new System.Drawing.Size(439, 20);
            this.addParams.TabIndex = 6;
            this.addParams.Text = "loop=true mxf.force_ffmpeg=true";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "addParams";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addParams);
            this.Controls.Add(this.OpenFileMMixer_btn);
            this.Controls.Add(this.OpenFileMPlaylist_btn);
            this.Controls.Add(this.panelpr);
            this.Controls.Add(this.Stat_lsb);
            this.Controls.Add(this.OpenFileMFile_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFileMFile_btn;
        private System.Windows.Forms.ListBox Stat_lsb;
        private System.Windows.Forms.Panel panelpr;
        private System.Windows.Forms.Button OpenFileMPlaylist_btn;
        private System.Windows.Forms.Button OpenFileMMixer_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox addParams;
        private System.Windows.Forms.Label label1;
    }
}

