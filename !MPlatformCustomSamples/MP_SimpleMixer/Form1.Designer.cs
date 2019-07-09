namespace MP_SimpleMixer
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
            this.panelPrev = new System.Windows.Forms.Panel();
            this.openFile_btn = new System.Windows.Forms.Button();
            this.listOfStreams_ltb = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // panelPrev
            // 
            this.panelPrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrev.Location = new System.Drawing.Point(62, 12);
            this.panelPrev.Name = "panelPrev";
            this.panelPrev.Size = new System.Drawing.Size(517, 284);
            this.panelPrev.TabIndex = 0;
            // 
            // openFile_btn
            // 
            this.openFile_btn.Location = new System.Drawing.Point(62, 319);
            this.openFile_btn.Name = "openFile_btn";
            this.openFile_btn.Size = new System.Drawing.Size(517, 23);
            this.openFile_btn.TabIndex = 1;
            this.openFile_btn.Text = "Open File";
            this.openFile_btn.UseVisualStyleBackColor = true;
            this.openFile_btn.Click += new System.EventHandler(this.openFile_btn_Click);
            // 
            // listOfStreams_ltb
            // 
            this.listOfStreams_ltb.FormattingEnabled = true;
            this.listOfStreams_ltb.Location = new System.Drawing.Point(604, 28);
            this.listOfStreams_ltb.Name = "listOfStreams_ltb";
            this.listOfStreams_ltb.Size = new System.Drawing.Size(283, 108);
            this.listOfStreams_ltb.TabIndex = 2;
            this.listOfStreams_ltb.SelectedIndexChanged += new System.EventHandler(this.listOfStreams_ltb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "list of streams";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listOfStreams_ltb);
            this.Controls.Add(this.openFile_btn);
            this.Controls.Add(this.panelPrev);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPrev;
        private System.Windows.Forms.Button openFile_btn;
        private System.Windows.Forms.ListBox listOfStreams_ltb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

