namespace MP_MixerWithMFileAsMpLinksWithCEF
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.MFileN_lbl = new System.Windows.Forms.Label();
            this.CEFN_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelPr
            // 
            this.panelPr.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPr.Location = new System.Drawing.Point(75, 44);
            this.panelPr.Name = "panelPr";
            this.panelPr.Size = new System.Drawing.Size(444, 258);
            this.panelPr.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(75, 411);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // MFileN_lbl
            // 
            this.MFileN_lbl.AutoSize = true;
            this.MFileN_lbl.Location = new System.Drawing.Point(557, 81);
            this.MFileN_lbl.Name = "MFileN_lbl";
            this.MFileN_lbl.Size = new System.Drawing.Size(35, 13);
            this.MFileN_lbl.TabIndex = 2;
            this.MFileN_lbl.Text = "label1";
            // 
            // CEFN_lbl
            // 
            this.CEFN_lbl.AutoSize = true;
            this.CEFN_lbl.Location = new System.Drawing.Point(557, 126);
            this.CEFN_lbl.Name = "CEFN_lbl";
            this.CEFN_lbl.Size = new System.Drawing.Size(35, 13);
            this.CEFN_lbl.TabIndex = 3;
            this.CEFN_lbl.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 450);
            this.Controls.Add(this.CEFN_lbl);
            this.Controls.Add(this.MFileN_lbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panelPr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPr;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label MFileN_lbl;
        private System.Windows.Forms.Label CEFN_lbl;
    }
}

