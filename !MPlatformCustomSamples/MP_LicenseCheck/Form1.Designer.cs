namespace MP_LicenseCheck
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
            this.panelPrSource = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Stop_btn = new System.Windows.Forms.Button();
            this.panelPrRecordFile = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelPrSource
            // 
            this.panelPrSource.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrSource.Location = new System.Drawing.Point(66, 27);
            this.panelPrSource.Name = "panelPrSource";
            this.panelPrSource.Size = new System.Drawing.Size(321, 233);
            this.panelPrSource.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(642, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Stop_btn
            // 
            this.Stop_btn.Location = new System.Drawing.Point(66, 340);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(642, 23);
            this.Stop_btn.TabIndex = 2;
            this.Stop_btn.Text = "Stop";
            this.Stop_btn.UseVisualStyleBackColor = true;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // panelPrRecordFile
            // 
            this.panelPrRecordFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrRecordFile.Location = new System.Drawing.Point(416, 27);
            this.panelPrRecordFile.Name = "panelPrRecordFile";
            this.panelPrRecordFile.Size = new System.Drawing.Size(292, 233);
            this.panelPrRecordFile.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPrRecordFile);
            this.Controls.Add(this.Stop_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelPrSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Stop_btn;
        private System.Windows.Forms.Panel panelPrRecordFile;
    }
}

