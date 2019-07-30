namespace MP_NewMDelaySample
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
            this.panelPreview = new System.Windows.Forms.Panel();
            this.OpenFile_btn = new System.Windows.Forms.Button();
            this.MDelay_chb = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericPos = new System.Windows.Forms.NumericUpDown();
            this.numericDelayQuiality = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayQuiality)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPreview
            // 
            this.panelPreview.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPreview.Location = new System.Drawing.Point(13, 13);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(720, 576);
            this.panelPreview.TabIndex = 0;
            // 
            // OpenFile_btn
            // 
            this.OpenFile_btn.Location = new System.Drawing.Point(13, 605);
            this.OpenFile_btn.Name = "OpenFile_btn";
            this.OpenFile_btn.Size = new System.Drawing.Size(75, 23);
            this.OpenFile_btn.TabIndex = 1;
            this.OpenFile_btn.Text = "Open File";
            this.OpenFile_btn.UseVisualStyleBackColor = true;
            this.OpenFile_btn.Click += new System.EventHandler(this.OpenFile_btn_Click);
            // 
            // MDelay_chb
            // 
            this.MDelay_chb.AutoSize = true;
            this.MDelay_chb.Location = new System.Drawing.Point(110, 610);
            this.MDelay_chb.Name = "MDelay_chb";
            this.MDelay_chb.Size = new System.Drawing.Size(104, 17);
            this.MDelay_chb.TabIndex = 2;
            this.MDelay_chb.Text = "MDelay Enabled";
            this.MDelay_chb.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(13, 634);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(534, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 610);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buffered (sec):";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(322, 605);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 5;
            // 
            // numericPos
            // 
            this.numericPos.Location = new System.Drawing.Point(568, 634);
            this.numericPos.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericPos.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericPos.Name = "numericPos";
            this.numericPos.Size = new System.Drawing.Size(41, 20);
            this.numericPos.TabIndex = 6;
            // 
            // numericDelayQuiality
            // 
            this.numericDelayQuiality.Location = new System.Drawing.Point(448, 605);
            this.numericDelayQuiality.Name = "numericDelayQuiality";
            this.numericDelayQuiality.Size = new System.Drawing.Size(48, 20);
            this.numericDelayQuiality.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 609);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quality:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 685);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericDelayQuiality);
            this.Controls.Add(this.numericPos);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.MDelay_chb);
            this.Controls.Add(this.OpenFile_btn);
            this.Controls.Add(this.panelPreview);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayQuiality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Button OpenFile_btn;
        private System.Windows.Forms.CheckBox MDelay_chb;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericPos;
        private System.Windows.Forms.NumericUpDown numericDelayQuiality;
        private System.Windows.Forms.Label label2;
    }
}

