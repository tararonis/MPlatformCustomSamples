namespace MP_fastTranscoding
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
            this.panelPrev = new System.Windows.Forms.Panel();
            this.Start_btn = new System.Windows.Forms.Button();
            this.openFile_txb = new System.Windows.Forms.TextBox();
            this.savePath_txb = new System.Windows.Forms.TextBox();
            this.maxDur_txb = new System.Windows.Forms.TextBox();
            this.maxDuration_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelPrev
            // 
            this.panelPrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrev.Location = new System.Drawing.Point(24, 12);
            this.panelPrev.Name = "panelPrev";
            this.panelPrev.Size = new System.Drawing.Size(335, 251);
            this.panelPrev.TabIndex = 0;
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(24, 363);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(335, 23);
            this.Start_btn.TabIndex = 1;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // openFile_txb
            // 
            this.openFile_txb.Location = new System.Drawing.Point(24, 269);
            this.openFile_txb.Name = "openFile_txb";
            this.openFile_txb.Size = new System.Drawing.Size(335, 20);
            this.openFile_txb.TabIndex = 3;
            this.openFile_txb.Text = "\\\\MLDiskStation\\MLFiles\\MediaTest\\MP4\\!1080p 60fpsOri and the Will of the Wisps.m" +
    "p4";
            // 
            // savePath_txb
            // 
            this.savePath_txb.Location = new System.Drawing.Point(24, 295);
            this.savePath_txb.Name = "savePath_txb";
            this.savePath_txb.Size = new System.Drawing.Size(335, 20);
            this.savePath_txb.TabIndex = 4;
            this.savePath_txb.Text = "M:\\TempVideo\\1.mp4";
            // 
            // maxDur_txb
            // 
            this.maxDur_txb.Location = new System.Drawing.Point(24, 321);
            this.maxDur_txb.Name = "maxDur_txb";
            this.maxDur_txb.Size = new System.Drawing.Size(48, 20);
            this.maxDur_txb.TabIndex = 5;
            this.maxDur_txb.Text = "10";
            // 
            // maxDuration_btn
            // 
            this.maxDuration_btn.Location = new System.Drawing.Point(78, 321);
            this.maxDuration_btn.Name = "maxDuration_btn";
            this.maxDuration_btn.Size = new System.Drawing.Size(281, 20);
            this.maxDuration_btn.TabIndex = 6;
            this.maxDuration_btn.Text = "Max Duration Set";
            this.maxDuration_btn.UseVisualStyleBackColor = true;
            this.maxDuration_btn.Click += new System.EventHandler(this.maxDuration_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maxDuration_btn);
            this.Controls.Add(this.maxDur_txb);
            this.Controls.Add(this.savePath_txb);
            this.Controls.Add(this.openFile_txb);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.panelPrev);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPrev;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.TextBox openFile_txb;
        private System.Windows.Forms.TextBox savePath_txb;
        private System.Windows.Forms.TextBox maxDur_txb;
        private System.Windows.Forms.Button maxDuration_btn;
        private System.Windows.Forms.Button button1;
    }
}

