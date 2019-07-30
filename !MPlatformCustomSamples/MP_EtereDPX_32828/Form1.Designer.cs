namespace MP_EtereDPX_32828
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
            this.play_btn = new System.Windows.Forms.Button();
            this.RelocateAllHidenFiles_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelPr
            // 
            this.panelPr.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPr.Location = new System.Drawing.Point(46, 12);
            this.panelPr.Name = "panelPr";
            this.panelPr.Size = new System.Drawing.Size(349, 219);
            this.panelPr.TabIndex = 0;
            // 
            // play_btn
            // 
            this.play_btn.Location = new System.Drawing.Point(46, 253);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(349, 23);
            this.play_btn.TabIndex = 1;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.Play_btn_Click);
            // 
            // RelocateAllHidenFiles_btn
            // 
            this.RelocateAllHidenFiles_btn.Location = new System.Drawing.Point(46, 283);
            this.RelocateAllHidenFiles_btn.Name = "RelocateAllHidenFiles_btn";
            this.RelocateAllHidenFiles_btn.Size = new System.Drawing.Size(349, 23);
            this.RelocateAllHidenFiles_btn.TabIndex = 2;
            this.RelocateAllHidenFiles_btn.Text = "RelocateAllHidenFiles";
            this.RelocateAllHidenFiles_btn.UseVisualStyleBackColor = true;
            this.RelocateAllHidenFiles_btn.Click += new System.EventHandler(this.RelocateAllHidenFiles_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 340);
            this.Controls.Add(this.RelocateAllHidenFiles_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.panelPr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPr;
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Button RelocateAllHidenFiles_btn;
    }
}

