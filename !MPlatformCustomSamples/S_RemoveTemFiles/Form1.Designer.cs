namespace S_RemoveTemFiles
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
            this.RemoveFiles_btn = new System.Windows.Forms.Button();
            this.path_txb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Log_lsb = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listOfKeyWords = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddKey_txb = new System.Windows.Forms.TextBox();
            this.AddKey_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // RemoveFiles_btn
            // 
            this.RemoveFiles_btn.Location = new System.Drawing.Point(30, 58);
            this.RemoveFiles_btn.Name = "RemoveFiles_btn";
            this.RemoveFiles_btn.Size = new System.Drawing.Size(103, 23);
            this.RemoveFiles_btn.TabIndex = 0;
            this.RemoveFiles_btn.Text = "RemoveFiles";
            this.RemoveFiles_btn.UseVisualStyleBackColor = true;
            this.RemoveFiles_btn.Click += new System.EventHandler(this.RemoveFiles_btn_Click);
            // 
            // path_txb
            // 
            this.path_txb.Location = new System.Drawing.Point(30, 32);
            this.path_txb.Name = "path_txb";
            this.path_txb.Size = new System.Drawing.Size(415, 20);
            this.path_txb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "path";
            // 
            // Log_lsb
            // 
            this.Log_lsb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_lsb.FormattingEnabled = true;
            this.Log_lsb.Location = new System.Drawing.Point(465, 32);
            this.Log_lsb.Name = "Log_lsb";
            this.Log_lsb.Size = new System.Drawing.Size(583, 381);
            this.Log_lsb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "listOfRemovedFiles";
            // 
            // listOfKeyWords
            // 
            this.listOfKeyWords.FormattingEnabled = true;
            this.listOfKeyWords.Location = new System.Drawing.Point(33, 141);
            this.listOfKeyWords.Name = "listOfKeyWords";
            this.listOfKeyWords.Size = new System.Drawing.Size(412, 160);
            this.listOfKeyWords.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "removed files and folders";
            // 
            // AddKey_txb
            // 
            this.AddKey_txb.Location = new System.Drawing.Point(33, 343);
            this.AddKey_txb.Name = "AddKey_txb";
            this.AddKey_txb.Size = new System.Drawing.Size(100, 20);
            this.AddKey_txb.TabIndex = 7;
            // 
            // AddKey_btn
            // 
            this.AddKey_btn.Location = new System.Drawing.Point(30, 378);
            this.AddKey_btn.Name = "AddKey_btn";
            this.AddKey_btn.Size = new System.Drawing.Size(75, 23);
            this.AddKey_btn.TabIndex = 8;
            this.AddKey_btn.Text = "AddKey_btn";
            this.AddKey_btn.UseVisualStyleBackColor = true;
            this.AddKey_btn.Click += new System.EventHandler(this.AddKey_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 450);
            this.Controls.Add(this.AddKey_btn);
            this.Controls.Add(this.AddKey_txb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listOfKeyWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Log_lsb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.path_txb);
            this.Controls.Add(this.RemoveFiles_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RemoveFiles_btn;
        private System.Windows.Forms.TextBox path_txb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Log_lsb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listOfKeyWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AddKey_txb;
        private System.Windows.Forms.Button AddKey_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

