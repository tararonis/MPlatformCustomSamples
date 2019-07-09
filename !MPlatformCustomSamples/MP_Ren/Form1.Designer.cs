namespace MPRen
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
            this.panelFile = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.openFile_btn = new System.Windows.Forms.Button();
            this.renList_lsb = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.updateVideoFormats_btn = new System.Windows.Forms.Button();
            this.formats_lsb = new System.Windows.Forms.ListBox();
            this.changeRenFormat_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelFile
            // 
            this.panelFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelFile.Location = new System.Drawing.Point(47, 40);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(320, 213);
            this.panelFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File";
            // 
            // openFile_btn
            // 
            this.openFile_btn.Location = new System.Drawing.Point(47, 274);
            this.openFile_btn.Name = "openFile_btn";
            this.openFile_btn.Size = new System.Drawing.Size(320, 23);
            this.openFile_btn.TabIndex = 4;
            this.openFile_btn.Text = "Open";
            this.openFile_btn.UseVisualStyleBackColor = true;
            this.openFile_btn.Click += new System.EventHandler(this.openFile_btn_Click);
            // 
            // renList_lsb
            // 
            this.renList_lsb.FormattingEnabled = true;
            this.renList_lsb.Location = new System.Drawing.Point(47, 314);
            this.renList_lsb.Name = "renList_lsb";
            this.renList_lsb.Size = new System.Drawing.Size(320, 95);
            this.renList_lsb.TabIndex = 6;
            this.renList_lsb.SelectedIndexChanged += new System.EventHandler(this.renList_lsb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "FormatRen";
            // 
            // updateVideoFormats_btn
            // 
            this.updateVideoFormats_btn.Location = new System.Drawing.Point(12, 427);
            this.updateVideoFormats_btn.Name = "updateVideoFormats_btn";
            this.updateVideoFormats_btn.Size = new System.Drawing.Size(13, 23);
            this.updateVideoFormats_btn.TabIndex = 11;
            this.updateVideoFormats_btn.Text = "U";
            this.updateVideoFormats_btn.UseVisualStyleBackColor = true;
            this.updateVideoFormats_btn.Click += new System.EventHandler(this.updateVideoFormats_btn_Click);
            // 
            // formats_lsb
            // 
            this.formats_lsb.FormattingEnabled = true;
            this.formats_lsb.Location = new System.Drawing.Point(47, 427);
            this.formats_lsb.Name = "formats_lsb";
            this.formats_lsb.Size = new System.Drawing.Size(320, 95);
            this.formats_lsb.TabIndex = 7;
            this.formats_lsb.SelectedIndexChanged += new System.EventHandler(this.formats_lsb_SelectedIndexChanged);
            // 
            // changeRenFormat_btn
            // 
            this.changeRenFormat_btn.Location = new System.Drawing.Point(47, 529);
            this.changeRenFormat_btn.Name = "changeRenFormat_btn";
            this.changeRenFormat_btn.Size = new System.Drawing.Size(320, 23);
            this.changeRenFormat_btn.TabIndex = 12;
            this.changeRenFormat_btn.Text = "Change";
            this.changeRenFormat_btn.UseVisualStyleBackColor = true;
            this.changeRenFormat_btn.Click += new System.EventHandler(this.changeRenFormat_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 569);
            this.Controls.Add(this.changeRenFormat_btn);
            this.Controls.Add(this.updateVideoFormats_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.formats_lsb);
            this.Controls.Add(this.renList_lsb);
            this.Controls.Add(this.openFile_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openFile_btn;
        private System.Windows.Forms.ListBox renList_lsb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button updateVideoFormats_btn;
        private System.Windows.Forms.ListBox formats_lsb;
        private System.Windows.Forms.Button changeRenFormat_btn;
    }
}

