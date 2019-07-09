namespace MP_WrongTimeCode_Etere31735
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
            this.GetTC_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeCode_lbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelPrPl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeCodePl_lbl = new System.Windows.Forms.Label();
            this.ChangeTC_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.newTC_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelPr
            // 
            this.panelPr.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPr.Location = new System.Drawing.Point(70, 28);
            this.panelPr.Name = "panelPr";
            this.panelPr.Size = new System.Drawing.Size(273, 242);
            this.panelPr.TabIndex = 0;
            // 
            // GetTC_btn
            // 
            this.GetTC_btn.Location = new System.Drawing.Point(70, 294);
            this.GetTC_btn.Name = "GetTC_btn";
            this.GetTC_btn.Size = new System.Drawing.Size(562, 23);
            this.GetTC_btn.TabIndex = 1;
            this.GetTC_btn.Text = "GetTC";
            this.GetTC_btn.UseVisualStyleBackColor = true;
            this.GetTC_btn.Click += new System.EventHandler(this.GetTC_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "TimeCode MFile -";
            // 
            // timeCode_lbl
            // 
            this.timeCode_lbl.AutoSize = true;
            this.timeCode_lbl.Location = new System.Drawing.Point(162, 335);
            this.timeCode_lbl.Name = "timeCode_lbl";
            this.timeCode_lbl.Size = new System.Drawing.Size(55, 13);
            this.timeCode_lbl.TabIndex = 3;
            this.timeCode_lbl.Text = "00:00:000";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelPrPl
            // 
            this.panelPrPl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrPl.Location = new System.Drawing.Point(359, 28);
            this.panelPrPl.Name = "panelPrPl";
            this.panelPrPl.Size = new System.Drawing.Size(273, 242);
            this.panelPrPl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TimeCode MPlaylist -";
            // 
            // TimeCodePl_lbl
            // 
            this.TimeCodePl_lbl.AutoSize = true;
            this.TimeCodePl_lbl.Location = new System.Drawing.Point(467, 335);
            this.TimeCodePl_lbl.Name = "TimeCodePl_lbl";
            this.TimeCodePl_lbl.Size = new System.Drawing.Size(55, 13);
            this.TimeCodePl_lbl.TabIndex = 5;
            this.TimeCodePl_lbl.Text = "00:00:000";
            // 
            // ChangeTC_btn
            // 
            this.ChangeTC_btn.Location = new System.Drawing.Point(70, 367);
            this.ChangeTC_btn.Name = "ChangeTC_btn";
            this.ChangeTC_btn.Size = new System.Drawing.Size(562, 23);
            this.ChangeTC_btn.TabIndex = 6;
            this.ChangeTC_btn.Text = "ChangeTC";
            this.ChangeTC_btn.UseVisualStyleBackColor = true;
            this.ChangeTC_btn.Click += new System.EventHandler(this.ChangeTC_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ChangedTC - ";
            // 
            // newTC_lbl
            // 
            this.newTC_lbl.AutoSize = true;
            this.newTC_lbl.Location = new System.Drawing.Point(165, 406);
            this.newTC_lbl.Name = "newTC_lbl";
            this.newTC_lbl.Size = new System.Drawing.Size(41, 13);
            this.newTC_lbl.TabIndex = 8;
            this.newTC_lbl.Text = "newTC";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
            this.Controls.Add(this.newTC_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChangeTC_btn);
            this.Controls.Add(this.TimeCodePl_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelPrPl);
            this.Controls.Add(this.timeCode_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetTC_btn);
            this.Controls.Add(this.panelPr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPr;
        private System.Windows.Forms.Button GetTC_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeCode_lbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelPrPl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TimeCodePl_lbl;
        private System.Windows.Forms.Button ChangeTC_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label newTC_lbl;
    }
}

