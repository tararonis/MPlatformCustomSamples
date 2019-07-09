namespace MP_liveExternal
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
            this.test_btn = new System.Windows.Forms.Button();
            this.panelPrev = new System.Windows.Forms.Panel();
            this.deviceList_lsb = new System.Windows.Forms.ListBox();
            this.EXdeviceList_lsb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // test_btn
            // 
            this.test_btn.Location = new System.Drawing.Point(12, 318);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(583, 23);
            this.test_btn.TabIndex = 0;
            this.test_btn.Text = "Start";
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // panelPrev
            // 
            this.panelPrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrev.Location = new System.Drawing.Point(13, 13);
            this.panelPrev.Name = "panelPrev";
            this.panelPrev.Size = new System.Drawing.Size(582, 290);
            this.panelPrev.TabIndex = 1;
            // 
            // deviceList_lsb
            // 
            this.deviceList_lsb.FormattingEnabled = true;
            this.deviceList_lsb.Location = new System.Drawing.Point(601, 13);
            this.deviceList_lsb.Name = "deviceList_lsb";
            this.deviceList_lsb.Size = new System.Drawing.Size(174, 173);
            this.deviceList_lsb.TabIndex = 2;
            this.deviceList_lsb.SelectedIndexChanged += new System.EventHandler(this.deviceList_lsb_SelectedIndexChanged);
            // 
            // EXdeviceList_lsb
            // 
            this.EXdeviceList_lsb.FormattingEnabled = true;
            this.EXdeviceList_lsb.Location = new System.Drawing.Point(602, 193);
            this.EXdeviceList_lsb.Name = "EXdeviceList_lsb";
            this.EXdeviceList_lsb.Size = new System.Drawing.Size(173, 173);
            this.EXdeviceList_lsb.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EXdeviceList_lsb);
            this.Controls.Add(this.deviceList_lsb);
            this.Controls.Add(this.panelPrev);
            this.Controls.Add(this.test_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button test_btn;
        private System.Windows.Forms.Panel panelPrev;
        private System.Windows.Forms.ListBox deviceList_lsb;
        private System.Windows.Forms.ListBox EXdeviceList_lsb;
    }
}

