namespace DShow_GetDevicesAndFormats
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
            this.button1 = new System.Windows.Forms.Button();
            this.listOfDevices_lsb = new System.Windows.Forms.ListBox();
            this.supportedformats = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "GetDevices";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listOfDevices_lsb
            // 
            this.listOfDevices_lsb.FormattingEnabled = true;
            this.listOfDevices_lsb.Location = new System.Drawing.Point(45, 38);
            this.listOfDevices_lsb.Name = "listOfDevices_lsb";
            this.listOfDevices_lsb.Size = new System.Drawing.Size(171, 173);
            this.listOfDevices_lsb.TabIndex = 1;
            // 
            // supportedformats
            // 
            this.supportedformats.FormattingEnabled = true;
            this.supportedformats.Location = new System.Drawing.Point(239, 132);
            this.supportedformats.Name = "supportedformats";
            this.supportedformats.Size = new System.Drawing.Size(171, 199);
            this.supportedformats.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "devices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "supported formats";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supportedformats);
            this.Controls.Add(this.listOfDevices_lsb);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listOfDevices_lsb;
        private System.Windows.Forms.ListBox supportedformats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

