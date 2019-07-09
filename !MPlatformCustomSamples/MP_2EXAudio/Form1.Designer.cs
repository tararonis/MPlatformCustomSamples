namespace MP_2EXAudio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListOfExAudio = new System.Windows.Forms.ListBox();
            this.ListOfVideo = new System.Windows.Forms.ListBox();
            this.GetVU_btn = new System.Windows.Forms.CheckBox();
            this.ListVU_lst = new System.Windows.Forms.ListBox();
            this.CountOfTracks_lbl = new System.Windows.Forms.Label();
            this.Gain_lst = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 209);
            this.panel1.TabIndex = 0;
            // 
            // ListOfExAudio
            // 
            this.ListOfExAudio.FormattingEnabled = true;
            this.ListOfExAudio.Location = new System.Drawing.Point(12, 356);
            this.ListOfExAudio.Name = "ListOfExAudio";
            this.ListOfExAudio.Size = new System.Drawing.Size(236, 95);
            this.ListOfExAudio.TabIndex = 2;
            this.ListOfExAudio.SelectedIndexChanged += new System.EventHandler(this.ListOfExAudio_SelectedIndexChanged);
            // 
            // ListOfVideo
            // 
            this.ListOfVideo.FormattingEnabled = true;
            this.ListOfVideo.Location = new System.Drawing.Point(12, 255);
            this.ListOfVideo.Name = "ListOfVideo";
            this.ListOfVideo.Size = new System.Drawing.Size(236, 95);
            this.ListOfVideo.TabIndex = 3;
            this.ListOfVideo.SelectedIndexChanged += new System.EventHandler(this.ListOfVideo_SelectedIndexChanged);
            // 
            // GetVU_btn
            // 
            this.GetVU_btn.AutoSize = true;
            this.GetVU_btn.Location = new System.Drawing.Point(255, 13);
            this.GetVU_btn.Name = "GetVU_btn";
            this.GetVU_btn.Size = new System.Drawing.Size(58, 17);
            this.GetVU_btn.TabIndex = 4;
            this.GetVU_btn.Text = "GetVU";
            this.GetVU_btn.UseVisualStyleBackColor = true;
            // 
            // ListVU_lst
            // 
            this.ListVU_lst.FormattingEnabled = true;
            this.ListVU_lst.Location = new System.Drawing.Point(254, 36);
            this.ListVU_lst.Name = "ListVU_lst";
            this.ListVU_lst.Size = new System.Drawing.Size(183, 316);
            this.ListVU_lst.TabIndex = 5;
            // 
            // CountOfTracks_lbl
            // 
            this.CountOfTracks_lbl.AutoSize = true;
            this.CountOfTracks_lbl.Location = new System.Drawing.Point(339, 12);
            this.CountOfTracks_lbl.Name = "CountOfTracks_lbl";
            this.CountOfTracks_lbl.Size = new System.Drawing.Size(13, 13);
            this.CountOfTracks_lbl.TabIndex = 6;
            this.CountOfTracks_lbl.Text = "0";
            // 
            // Gain_lst
            // 
            this.Gain_lst.FormattingEnabled = true;
            this.Gain_lst.Location = new System.Drawing.Point(443, 36);
            this.Gain_lst.Name = "Gain_lst";
            this.Gain_lst.Size = new System.Drawing.Size(183, 316);
            this.Gain_lst.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 476);
            this.Controls.Add(this.Gain_lst);
            this.Controls.Add(this.CountOfTracks_lbl);
            this.Controls.Add(this.ListVU_lst);
            this.Controls.Add(this.GetVU_btn);
            this.Controls.Add(this.ListOfVideo);
            this.Controls.Add(this.ListOfExAudio);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListOfExAudio;
        private System.Windows.Forms.ListBox ListOfVideo;
        private System.Windows.Forms.CheckBox GetVU_btn;
        private System.Windows.Forms.ListBox ListVU_lst;
        private System.Windows.Forms.Label CountOfTracks_lbl;
        private System.Windows.Forms.ListBox Gain_lst;
    }
}

