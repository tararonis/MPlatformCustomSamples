namespace MixerSample
{
    partial class LiveForm
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
            this.panelPreview = new System.Windows.Forms.Panel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.checkBoxAudio = new System.Windows.Forms.CheckBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxVFOut = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonVF = new System.Windows.Forms.Button();
            this.buttonV = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.comboBoxAF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxExtAudio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxAudio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVF = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxVL = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVideo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNDIRefresh = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(143)))));
            this.panelPreview.Location = new System.Drawing.Point(376, 11);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(640, 360);
            this.panelPreview.TabIndex = 125;
            this.panelPreview.Resize += new System.EventHandler(this.panelPreview_Resize);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 33;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.checkBoxVideo);
            this.panel2.Controls.Add(this.checkBoxAudio);
            this.panel2.Controls.Add(this.trackBarVolume);
            this.panel2.Location = new System.Drawing.Point(376, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(640, 36);
            this.panel2.TabIndex = 176;
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.Checked = true;
            this.checkBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVideo.Location = new System.Drawing.Point(8, 9);
            this.checkBoxVideo.Name = "checkBoxVideo";
            this.checkBoxVideo.Size = new System.Drawing.Size(94, 17);
            this.checkBoxVideo.TabIndex = 126;
            this.checkBoxVideo.Text = "Video Preview";
            this.checkBoxVideo.UseVisualStyleBackColor = true;
            this.checkBoxVideo.CheckedChanged += new System.EventHandler(this.checkBoxVideo_CheckedChanged);
            // 
            // checkBoxAudio
            // 
            this.checkBoxAudio.AutoSize = true;
            this.checkBoxAudio.Location = new System.Drawing.Point(110, 10);
            this.checkBoxAudio.Name = "checkBoxAudio";
            this.checkBoxAudio.Size = new System.Drawing.Size(94, 17);
            this.checkBoxAudio.TabIndex = 127;
            this.checkBoxAudio.Text = "Audio Preview";
            this.checkBoxAudio.UseVisualStyleBackColor = true;
            this.checkBoxAudio.CheckedChanged += new System.EventHandler(this.checkBoxAudio_CheckedChanged);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(207, 9);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(429, 17);
            this.trackBarVolume.TabIndex = 148;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.buttonNDIRefresh);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.comboBoxVFOut);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.buttonVF);
            this.panel1.Controls.Add(this.buttonV);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonInit);
            this.panel1.Controls.Add(this.comboBoxAF);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxExtAudio);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxAudio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxVF);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxVL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxVideo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 403);
            this.panel1.TabIndex = 177;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 201;
            this.label10.Text = "Conversion";
            // 
            // comboBoxVFOut
            // 
            this.comboBoxVFOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVFOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVFOut.DropDownWidth = 300;
            this.comboBoxVFOut.FormattingEnabled = true;
            this.comboBoxVFOut.Location = new System.Drawing.Point(112, 282);
            this.comboBoxVFOut.Name = "comboBoxVFOut";
            this.comboBoxVFOut.Size = new System.Drawing.Size(239, 21);
            this.comboBoxVFOut.TabIndex = 200;
            this.comboBoxVFOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxVFOut_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 199;
            this.label9.Text = "Output video format:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 193;
            this.label8.Text = "Audio device";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 192;
            this.label7.Text = "Video device";
            // 
            // buttonVF
            // 
            this.buttonVF.Location = new System.Drawing.Point(276, 100);
            this.buttonVF.Name = "buttonVF";
            this.buttonVF.Size = new System.Drawing.Size(75, 23);
            this.buttonVF.TabIndex = 189;
            this.buttonVF.Text = "Props";
            this.buttonVF.UseVisualStyleBackColor = true;
            this.buttonVF.Click += new System.EventHandler(this.buttonVF_Click);
            // 
            // buttonV
            // 
            this.buttonV.Location = new System.Drawing.Point(276, 40);
            this.buttonV.Name = "buttonV";
            this.buttonV.Size = new System.Drawing.Size(75, 23);
            this.buttonV.TabIndex = 188;
            this.buttonV.Text = "Props";
            this.buttonV.UseVisualStyleBackColor = true;
            this.buttonV.Click += new System.EventHandler(this.buttonV_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(187, 325);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 35);
            this.buttonClose.TabIndex = 187;
            this.buttonClose.Text = "Close Device";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(10, 325);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(164, 35);
            this.buttonInit.TabIndex = 186;
            this.buttonInit.Text = "Init Device";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // comboBoxAF
            // 
            this.comboBoxAF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAF.FormattingEnabled = true;
            this.comboBoxAF.Location = new System.Drawing.Point(55, 226);
            this.comboBoxAF.Name = "comboBoxAF";
            this.comboBoxAF.Size = new System.Drawing.Size(296, 21);
            this.comboBoxAF.TabIndex = 185;
            this.comboBoxAF.SelectedIndexChanged += new System.EventHandler(this.comboBoxAVF_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "Format:";
            // 
            // comboBoxExtAudio
            // 
            this.comboBoxExtAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExtAudio.FormattingEnabled = true;
            this.comboBoxExtAudio.Location = new System.Drawing.Point(55, 199);
            this.comboBoxExtAudio.Name = "comboBoxExtAudio";
            this.comboBoxExtAudio.Size = new System.Drawing.Size(296, 21);
            this.comboBoxExtAudio.TabIndex = 181;
            this.comboBoxExtAudio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 180;
            this.label5.Text = "External:";
            // 
            // comboBoxAudio
            // 
            this.comboBoxAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudio.FormattingEnabled = true;
            this.comboBoxAudio.Location = new System.Drawing.Point(55, 173);
            this.comboBoxAudio.Name = "comboBoxAudio";
            this.comboBoxAudio.Size = new System.Drawing.Size(296, 21);
            this.comboBoxAudio.TabIndex = 181;
            this.comboBoxAudio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 180;
            this.label6.Text = "Audio:";
            // 
            // comboBoxVF
            // 
            this.comboBoxVF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVF.FormattingEnabled = true;
            this.comboBoxVF.Location = new System.Drawing.Point(55, 101);
            this.comboBoxVF.Name = "comboBoxVF";
            this.comboBoxVF.Size = new System.Drawing.Size(215, 21);
            this.comboBoxVF.TabIndex = 179;
            this.comboBoxVF.SelectedIndexChanged += new System.EventHandler(this.comboBoxAVF_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 178;
            this.label3.Text = "Format:";
            // 
            // comboBoxVL
            // 
            this.comboBoxVL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVL.FormattingEnabled = true;
            this.comboBoxVL.Location = new System.Drawing.Point(55, 71);
            this.comboBoxVL.Name = "comboBoxVL";
            this.comboBoxVL.Size = new System.Drawing.Size(215, 21);
            this.comboBoxVL.TabIndex = 177;
            this.comboBoxVL.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 176;
            this.label2.Text = "Line:";
            // 
            // comboBoxVideo
            // 
            this.comboBoxVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideo.FormattingEnabled = true;
            this.comboBoxVideo.Location = new System.Drawing.Point(55, 41);
            this.comboBoxVideo.Name = "comboBoxVideo";
            this.comboBoxVideo.Size = new System.Drawing.Size(215, 21);
            this.comboBoxVideo.TabIndex = 175;
            this.comboBoxVideo.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Video:";
            // 
            // buttonNDIRefresh
            // 
            this.buttonNDIRefresh.Location = new System.Drawing.Point(276, 69);
            this.buttonNDIRefresh.Name = "buttonNDIRefresh";
            this.buttonNDIRefresh.Size = new System.Drawing.Size(23, 23);
            this.buttonNDIRefresh.TabIndex = 202;
            this.buttonNDIRefresh.Text = "R";
            this.buttonNDIRefresh.UseVisualStyleBackColor = true;
            this.buttonNDIRefresh.Click += new System.EventHandler(this.buttonNDIRefresh_Click);
            // 
            // LiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelPreview);
            this.Name = "LiveForm";
            this.Text = "Configure live source";
            this.Load += new System.EventHandler(this.FormLive_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxVideo;
        private System.Windows.Forms.CheckBox checkBoxAudio;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonVF;
        private System.Windows.Forms.Button buttonV;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.ComboBox comboBoxAF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAudio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxVF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxVL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxVFOut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxExtAudio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonNDIRefresh;
    }
}

