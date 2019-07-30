namespace MP_FileEventTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ChangePreviewType_btn = new System.Windows.Forms.Button();
            this.SeekToTheEnd_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Repr";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 195);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(263, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChangePreviewType_btn
            // 
            this.ChangePreviewType_btn.Location = new System.Drawing.Point(296, 13);
            this.ChangePreviewType_btn.Name = "ChangePreviewType_btn";
            this.ChangePreviewType_btn.Size = new System.Drawing.Size(75, 194);
            this.ChangePreviewType_btn.TabIndex = 3;
            this.ChangePreviewType_btn.Text = "ChangePreviewType Cur-dx11";
            this.ChangePreviewType_btn.UseVisualStyleBackColor = true;
            this.ChangePreviewType_btn.Click += new System.EventHandler(this.ChangePreviewType_btn_Click);
            // 
            // SeekToTheEnd_btn
            // 
            this.SeekToTheEnd_btn.Location = new System.Drawing.Point(296, 214);
            this.SeekToTheEnd_btn.Name = "SeekToTheEnd_btn";
            this.SeekToTheEnd_btn.Size = new System.Drawing.Size(75, 68);
            this.SeekToTheEnd_btn.TabIndex = 4;
            this.SeekToTheEnd_btn.Text = "SeekToTheEnd";
            this.SeekToTheEnd_btn.UseVisualStyleBackColor = true;
            this.SeekToTheEnd_btn.Click += new System.EventHandler(this.SeekToTheEnd_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 317);
            this.Controls.Add(this.SeekToTheEnd_btn);
            this.Controls.Add(this.ChangePreviewType_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ChangePreviewType_btn;
        private System.Windows.Forms.Button SeekToTheEnd_btn;
    }
}

