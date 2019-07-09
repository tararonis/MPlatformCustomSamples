namespace MP_PlaylistDelayIssue
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
            this.panelPrFile = new System.Windows.Forms.Panel();
            this.AddURL_btn = new System.Windows.Forms.Button();
            this.AddMDelay_btn = new System.Windows.Forms.Button();
            this.panelPrPlaylist = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelPrFile
            // 
            this.panelPrFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrFile.Location = new System.Drawing.Point(59, 13);
            this.panelPrFile.Name = "panelPrFile";
            this.panelPrFile.Size = new System.Drawing.Size(319, 248);
            this.panelPrFile.TabIndex = 0;
            // 
            // AddURL_btn
            // 
            this.AddURL_btn.Location = new System.Drawing.Point(59, 281);
            this.AddURL_btn.Name = "AddURL_btn";
            this.AddURL_btn.Size = new System.Drawing.Size(670, 23);
            this.AddURL_btn.TabIndex = 1;
            this.AddURL_btn.Text = "AddURL";
            this.AddURL_btn.UseVisualStyleBackColor = true;
            this.AddURL_btn.Click += new System.EventHandler(this.AddURL_btn_Click);
            // 
            // AddMDelay_btn
            // 
            this.AddMDelay_btn.Location = new System.Drawing.Point(59, 324);
            this.AddMDelay_btn.Name = "AddMDelay_btn";
            this.AddMDelay_btn.Size = new System.Drawing.Size(670, 23);
            this.AddMDelay_btn.TabIndex = 2;
            this.AddMDelay_btn.Text = "AddMDelay";
            this.AddMDelay_btn.UseVisualStyleBackColor = true;
            this.AddMDelay_btn.Click += new System.EventHandler(this.AddMDelay_btn_Click);
            // 
            // panelPrPlaylist
            // 
            this.panelPrPlaylist.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrPlaylist.Location = new System.Drawing.Point(410, 13);
            this.panelPrPlaylist.Name = "panelPrPlaylist";
            this.panelPrPlaylist.Size = new System.Drawing.Size(319, 248);
            this.panelPrPlaylist.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 395);
            this.Controls.Add(this.panelPrPlaylist);
            this.Controls.Add(this.AddMDelay_btn);
            this.Controls.Add(this.AddURL_btn);
            this.Controls.Add(this.panelPrFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrFile;
        private System.Windows.Forms.Button AddURL_btn;
        private System.Windows.Forms.Button AddMDelay_btn;
        private System.Windows.Forms.Panel panelPrPlaylist;
    }
}

