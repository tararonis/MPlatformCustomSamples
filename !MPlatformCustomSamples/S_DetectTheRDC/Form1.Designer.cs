namespace S_DetectTheRDC
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
            this.components = new System.ComponentModel.Container();
            this.log_lsb = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log_lsb
            // 
            this.log_lsb.FormattingEnabled = true;
            this.log_lsb.Location = new System.Drawing.Point(90, 12);
            this.log_lsb.Name = "log_lsb";
            this.log_lsb.Size = new System.Drawing.Size(373, 420);
            this.log_lsb.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Timer_btn
            // 
            this.Timer_btn.Location = new System.Drawing.Point(21, 12);
            this.Timer_btn.Name = "Timer_btn";
            this.Timer_btn.Size = new System.Drawing.Size(46, 420);
            this.Timer_btn.TabIndex = 1;
            this.Timer_btn.Text = "Timer Off";
            this.Timer_btn.UseVisualStyleBackColor = true;
            this.Timer_btn.Click += new System.EventHandler(this.Timer_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 450);
            this.Controls.Add(this.Timer_btn);
            this.Controls.Add(this.log_lsb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox log_lsb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Timer_btn;
    }
}

