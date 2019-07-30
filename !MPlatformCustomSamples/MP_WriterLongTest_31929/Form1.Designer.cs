namespace MP_WriterLongTest_31929
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
            this.StartTest_btn = new System.Windows.Forms.Button();
            this.panelPR = new System.Windows.Forms.Panel();
            this.Stop_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartTest_btn
            // 
            this.StartTest_btn.Location = new System.Drawing.Point(189, 349);
            this.StartTest_btn.Name = "StartTest_btn";
            this.StartTest_btn.Size = new System.Drawing.Size(230, 64);
            this.StartTest_btn.TabIndex = 0;
            this.StartTest_btn.Text = "Start";
            this.StartTest_btn.UseVisualStyleBackColor = true;
            this.StartTest_btn.Click += new System.EventHandler(this.StartTest_btn_Click);
            // 
            // panelPR
            // 
            this.panelPR.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPR.Location = new System.Drawing.Point(189, 12);
            this.panelPR.Name = "panelPR";
            this.panelPR.Size = new System.Drawing.Size(455, 321);
            this.panelPR.TabIndex = 1;
            // 
            // Stop_btn
            // 
            this.Stop_btn.Location = new System.Drawing.Point(435, 349);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(209, 64);
            this.Stop_btn.TabIndex = 2;
            this.Stop_btn.Text = "Stop";
            this.Stop_btn.UseVisualStyleBackColor = true;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Stop_btn);
            this.Controls.Add(this.panelPR);
            this.Controls.Add(this.StartTest_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartTest_btn;
        private System.Windows.Forms.Panel panelPR;
        private System.Windows.Forms.Button Stop_btn;
    }
}

