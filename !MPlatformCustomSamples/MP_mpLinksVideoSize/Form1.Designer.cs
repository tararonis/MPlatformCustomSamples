namespace MP_mpLinksVideoSize
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
            this.panelPub = new System.Windows.Forms.Panel();
            this.panelRec = new System.Windows.Forms.Panel();
            this.senders_lsb = new System.Windows.Forms.ListBox();
            this.data_lsb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // panelPub
            // 
            this.panelPub.Location = new System.Drawing.Point(59, 36);
            this.panelPub.Name = "panelPub";
            this.panelPub.Size = new System.Drawing.Size(275, 198);
            this.panelPub.TabIndex = 0;
            // 
            // panelRec
            // 
            this.panelRec.Location = new System.Drawing.Point(369, 36);
            this.panelRec.Name = "panelRec";
            this.panelRec.Size = new System.Drawing.Size(275, 198);
            this.panelRec.TabIndex = 1;
            // 
            // senders_lsb
            // 
            this.senders_lsb.FormattingEnabled = true;
            this.senders_lsb.Location = new System.Drawing.Point(369, 260);
            this.senders_lsb.Name = "senders_lsb";
            this.senders_lsb.Size = new System.Drawing.Size(275, 108);
            this.senders_lsb.TabIndex = 2;
            this.senders_lsb.SelectedIndexChanged += new System.EventHandler(this.Senders_lsb_SelectedIndexChanged);
            // 
            // data_lsb
            // 
            this.data_lsb.FormattingEnabled = true;
            this.data_lsb.Location = new System.Drawing.Point(59, 260);
            this.data_lsb.Name = "data_lsb";
            this.data_lsb.Size = new System.Drawing.Size(275, 108);
            this.data_lsb.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.data_lsb);
            this.Controls.Add(this.senders_lsb);
            this.Controls.Add(this.panelRec);
            this.Controls.Add(this.panelPub);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPub;
        private System.Windows.Forms.Panel panelRec;
        private System.Windows.Forms.ListBox senders_lsb;
        private System.Windows.Forms.ListBox data_lsb;
    }
}

