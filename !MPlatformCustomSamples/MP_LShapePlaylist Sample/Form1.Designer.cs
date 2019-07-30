namespace PlaylistSample
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mBreaksControl1 = new MControls.MBreaksList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mPersistControl1 = new MControls.MPersistControl();
            this.mPlaylistBackground1 = new MControls.MPlaylistBackground();
            this.label3 = new System.Windows.Forms.Label();
            this.mFormatControl1 = new MControls.MFormatControl();
            this.checkBoxListSeek = new System.Windows.Forms.CheckBox();
            this.mFileStateControl1 = new MControls.MFileState();
            this.mPlaylistControl1 = new MControls.MPlaylistList();
            this.checkBoxCG = new System.Windows.Forms.CheckBox();
            this.buttonCG_Props = new System.Windows.Forms.Button();
            this.checkBoxVSource = new System.Windows.Forms.CheckBox();
            this.buttonStatistic = new System.Windows.Forms.Button();
            this.CgEditorButton = new System.Windows.Forms.Button();
            this.checkBoxCC = new System.Windows.Forms.CheckBox();
            this.timerReleaseEvents = new System.Windows.Forms.Timer(this.components);
            this.mPlaylistTimeline1 = new MControls.MPlaylistTimeline();
            this.mAudioMeter1 = new MControls.MAudioMeter();
            this.mPlaylistStatus1 = new MControls.MPlaylistStatus();
            this.mRateControl1 = new MControls.MFileRate();
            this.mRendererCheckList1 = new MControls.MRenderersList();
            this.mSeekControl1 = new MControls.MFileSeeking();
            this.mPreviewControl1 = new MControls.MPreviewControl();
            this.checkBoxHTML = new System.Windows.Forms.CheckBox();
            this.textBoxHTMLURL = new System.Windows.Forms.TextBox();
            this.buttonHTMLProps = new System.Windows.Forms.Button();
            this.Lshape_chb = new System.Windows.Forms.CheckBox();
            this.LShapePath_txb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Breaks:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mBreaksControl1);
            this.panel1.Location = new System.Drawing.Point(5, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 163);
            this.panel1.TabIndex = 6;
            // 
            // mBreaksControl1
            // 
            this.mBreaksControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBreaksControl1.Enabled = false;
            this.mBreaksControl1.Location = new System.Drawing.Point(4, 18);
            this.mBreaksControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mBreaksControl1.Name = "mBreaksControl1";
            this.mBreaksControl1.Size = new System.Drawing.Size(444, 143);
            this.mBreaksControl1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.mPersistControl1);
            this.panel2.Controls.Add(this.mPlaylistBackground1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.mFormatControl1);
            this.panel2.Controls.Add(this.checkBoxListSeek);
            this.panel2.Controls.Add(this.mFileStateControl1);
            this.panel2.Controls.Add(this.mPlaylistControl1);
            this.panel2.Location = new System.Drawing.Point(5, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 321);
            this.panel2.TabIndex = 7;
            // 
            // mPersistControl1
            // 
            this.mPersistControl1.DefaultExt = ".xml";
            this.mPersistControl1.Filter = "MPlaylist Files (*.mpl, *.xml)|*.mpl;*.xml;*.mlp|All Files|*.*";
            this.mPersistControl1.Location = new System.Drawing.Point(6, 4);
            this.mPersistControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mPersistControl1.Name = "mPersistControl1";
            this.mPersistControl1.Size = new System.Drawing.Size(90, 23);
            this.mPersistControl1.TabIndex = 10;
            // 
            // mPlaylistBackground1
            // 
            this.mPlaylistBackground1.Location = new System.Drawing.Point(124, 5);
            this.mPlaylistBackground1.Margin = new System.Windows.Forms.Padding(4);
            this.mPlaylistBackground1.Name = "mPlaylistBackground1";
            this.mPlaylistBackground1.Size = new System.Drawing.Size(232, 21);
            this.mPlaylistBackground1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "BG:";
            // 
            // mFormatControl1
            // 
            this.mFormatControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mFormatControl1.Location = new System.Drawing.Point(220, 273);
            this.mFormatControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mFormatControl1.MInputFormat = false;
            this.mFormatControl1.MTextFormatDescription = false;
            this.mFormatControl1.Name = "mFormatControl1";
            this.mFormatControl1.Size = new System.Drawing.Size(227, 44);
            this.mFormatControl1.TabIndex = 7;
            // 
            // checkBoxListSeek
            // 
            this.checkBoxListSeek.AutoSize = true;
            this.checkBoxListSeek.Checked = true;
            this.checkBoxListSeek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxListSeek.Location = new System.Drawing.Point(361, 8);
            this.checkBoxListSeek.Name = "checkBoxListSeek";
            this.checkBoxListSeek.Size = new System.Drawing.Size(86, 17);
            this.checkBoxListSeek.TabIndex = 2;
            this.checkBoxListSeek.Text = "Playlist Seek";
            this.checkBoxListSeek.UseVisualStyleBackColor = true;
            this.checkBoxListSeek.CheckedChanged += new System.EventHandler(this.checkBoxListSeek_CheckedChanged);
            // 
            // mFileStateControl1
            // 
            this.mFileStateControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mFileStateControl1.Location = new System.Drawing.Point(7, 276);
            this.mFileStateControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mFileStateControl1.Name = "mFileStateControl1";
            this.mFileStateControl1.Size = new System.Drawing.Size(209, 38);
            this.mFileStateControl1.TabIndex = 1;
            // 
            // mPlaylistControl1
            // 
            this.mPlaylistControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlaylistControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPlaylistControl1.Location = new System.Drawing.Point(5, 29);
            this.mPlaylistControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mPlaylistControl1.Name = "mPlaylistControl1";
            this.mPlaylistControl1.Size = new System.Drawing.Size(442, 238);
            this.mPlaylistControl1.TabIndex = 2;
            // 
            // checkBoxCG
            // 
            this.checkBoxCG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCG.Location = new System.Drawing.Point(898, 581);
            this.checkBoxCG.Name = "checkBoxCG";
            this.checkBoxCG.Size = new System.Drawing.Size(62, 16);
            this.checkBoxCG.TabIndex = 13;
            this.checkBoxCG.Text = "CG";
            this.checkBoxCG.UseVisualStyleBackColor = true;
            this.checkBoxCG.CheckedChanged += new System.EventHandler(this.checkBoxCG_CheckedChanged);
            // 
            // buttonCG_Props
            // 
            this.buttonCG_Props.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCG_Props.Enabled = false;
            this.buttonCG_Props.Location = new System.Drawing.Point(898, 602);
            this.buttonCG_Props.Name = "buttonCG_Props";
            this.buttonCG_Props.Size = new System.Drawing.Size(62, 23);
            this.buttonCG_Props.TabIndex = 14;
            this.buttonCG_Props.Text = "CG Props";
            this.buttonCG_Props.UseVisualStyleBackColor = true;
            this.buttonCG_Props.Click += new System.EventHandler(this.buttonCG_Props_Click);
            // 
            // checkBoxVSource
            // 
            this.checkBoxVSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxVSource.Location = new System.Drawing.Point(955, 581);
            this.checkBoxVSource.Name = "checkBoxVSource";
            this.checkBoxVSource.Size = new System.Drawing.Size(92, 17);
            this.checkBoxVSource.TabIndex = 15;
            this.checkBoxVSource.Text = "Virtual Source";
            this.checkBoxVSource.UseVisualStyleBackColor = true;
            this.checkBoxVSource.CheckedChanged += new System.EventHandler(this.checkBoxVSource_CheckedChanged);
            // 
            // buttonStatistic
            // 
            this.buttonStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStatistic.Location = new System.Drawing.Point(1037, 602);
            this.buttonStatistic.Name = "buttonStatistic";
            this.buttonStatistic.Size = new System.Drawing.Size(66, 23);
            this.buttonStatistic.TabIndex = 17;
            this.buttonStatistic.Text = "Statistic";
            this.buttonStatistic.UseVisualStyleBackColor = true;
            this.buttonStatistic.Click += new System.EventHandler(this.buttonStatistic_Click);
            // 
            // CgEditorButton
            // 
            this.CgEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CgEditorButton.Enabled = false;
            this.CgEditorButton.Location = new System.Drawing.Point(966, 602);
            this.CgEditorButton.Name = "CgEditorButton";
            this.CgEditorButton.Size = new System.Drawing.Size(65, 23);
            this.CgEditorButton.TabIndex = 18;
            this.CgEditorButton.Text = "CG Editor";
            this.CgEditorButton.UseVisualStyleBackColor = true;
            this.CgEditorButton.Click += new System.EventHandler(this.CgEditorButton_Click);
            // 
            // checkBoxCC
            // 
            this.checkBoxCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCC.Location = new System.Drawing.Point(1058, 581);
            this.checkBoxCC.Name = "checkBoxCC";
            this.checkBoxCC.Size = new System.Drawing.Size(42, 17);
            this.checkBoxCC.TabIndex = 19;
            this.checkBoxCC.Text = "CC";
            this.checkBoxCC.UseVisualStyleBackColor = true;
            this.checkBoxCC.CheckedChanged += new System.EventHandler(this.checkBoxCC_CheckedChanged);
            // 
            // timerReleaseEvents
            // 
            this.timerReleaseEvents.Enabled = true;
            this.timerReleaseEvents.Interval = 1000;
            this.timerReleaseEvents.Tick += new System.EventHandler(this.timerReleaseEvents_Tick);
            // 
            // mPlaylistTimeline1
            // 
            this.mPlaylistTimeline1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlaylistTimeline1.BackColor = System.Drawing.Color.White;
            this.mPlaylistTimeline1.BackColorHi = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.mPlaylistTimeline1.BlockColorHi = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.mPlaylistTimeline1.BlockColorLo = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(144)))));
            this.mPlaylistTimeline1.BreakColorHi = System.Drawing.Color.Red;
            this.mPlaylistTimeline1.BreakColorLo = System.Drawing.Color.Maroon;
            this.mPlaylistTimeline1.CmdColorHi = System.Drawing.Color.LightGray;
            this.mPlaylistTimeline1.CmdColorLo = System.Drawing.Color.Gray;
            this.mPlaylistTimeline1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mPlaylistTimeline1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(104)))));
            this.mPlaylistTimeline1.Location = new System.Drawing.Point(5, 636);
            this.mPlaylistTimeline1.Name = "mPlaylistTimeline1";
            this.mPlaylistTimeline1.NowPos = 0.33F;
            this.mPlaylistTimeline1.ShowFrames = true;
            this.mPlaylistTimeline1.Size = new System.Drawing.Size(1098, 124);
            this.mPlaylistTimeline1.TabIndex = 11;
            // 
            // mAudioMeter1
            // 
            this.mAudioMeter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mAudioMeter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.mAudioMeter1.BackColorHi = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.mAudioMeter1.ColorGainSlider = System.Drawing.Color.Red;
            this.mAudioMeter1.ColorLevelBack = System.Drawing.Color.DarkGray;
            this.mAudioMeter1.ColorLevelHi = System.Drawing.Color.Red;
            this.mAudioMeter1.ColorLevelLo = System.Drawing.Color.DarkBlue;
            this.mAudioMeter1.ColorLevelMid = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(144)))));
            this.mAudioMeter1.ColorLevelOrg = System.Drawing.Color.Silver;
            this.mAudioMeter1.ColorOutline = System.Drawing.Color.Black;
            this.mAudioMeter1.Location = new System.Drawing.Point(463, 46);
            this.mAudioMeter1.Margin = new System.Windows.Forms.Padding(4);
            this.mAudioMeter1.Name = "mAudioMeter1";
            this.mAudioMeter1.Size = new System.Drawing.Size(66, 323);
            this.mAudioMeter1.TabIndex = 12;
            // 
            // mPlaylistStatus1
            // 
            this.mPlaylistStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlaylistStatus1.Location = new System.Drawing.Point(463, 377);
            this.mPlaylistStatus1.Margin = new System.Windows.Forms.Padding(4);
            this.mPlaylistStatus1.Name = "mPlaylistStatus1";
            this.mPlaylistStatus1.OnAir = false;
            this.mPlaylistStatus1.Size = new System.Drawing.Size(640, 152);
            this.mPlaylistStatus1.TabIndex = 10;
            // 
            // mRateControl1
            // 
            this.mRateControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mRateControl1.BackColor = System.Drawing.SystemColors.Control;
            this.mRateControl1.Location = new System.Drawing.Point(463, 548);
            this.mRateControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mRateControl1.Name = "mRateControl1";
            this.mRateControl1.Size = new System.Drawing.Size(432, 80);
            this.mRateControl1.TabIndex = 9;
            // 
            // mRendererCheckList1
            // 
            this.mRendererCheckList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mRendererCheckList1.CheckBoxes = true;
            this.mRendererCheckList1.FullRowSelect = true;
            this.mRendererCheckList1.GridLines = true;
            this.mRendererCheckList1.Location = new System.Drawing.Point(5, 503);
            this.mRendererCheckList1.Name = "mRendererCheckList1";
            this.mRendererCheckList1.Size = new System.Drawing.Size(452, 127);
            this.mRendererCheckList1.TabIndex = 8;
            this.mRendererCheckList1.UseCompatibleStateImageBehavior = false;
            this.mRendererCheckList1.View = System.Windows.Forms.View.Details;
            // 
            // mSeekControl1
            // 
            this.mSeekControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mSeekControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mSeekControl1.Location = new System.Drawing.Point(463, 6);
            this.mSeekControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mSeekControl1.Name = "mSeekControl1";
            this.mSeekControl1.Size = new System.Drawing.Size(640, 36);
            this.mSeekControl1.TabIndex = 3;
            // 
            // mPreviewControl1
            // 
            this.mPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPreviewControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPreviewControl1.Location = new System.Drawing.Point(537, 46);
            this.mPreviewControl1.Margin = new System.Windows.Forms.Padding(4);
            this.mPreviewControl1.Name = "mPreviewControl1";
            this.mPreviewControl1.Size = new System.Drawing.Size(566, 323);
            this.mPreviewControl1.TabIndex = 3;
            // 
            // checkBoxHTML
            // 
            this.checkBoxHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHTML.AutoSize = true;
            this.checkBoxHTML.Location = new System.Drawing.Point(898, 535);
            this.checkBoxHTML.Name = "checkBoxHTML";
            this.checkBoxHTML.Size = new System.Drawing.Size(93, 17);
            this.checkBoxHTML.TabIndex = 188;
            this.checkBoxHTML.Text = "HTML overlay";
            this.checkBoxHTML.UseVisualStyleBackColor = true;
            this.checkBoxHTML.CheckedChanged += new System.EventHandler(this.checkBoxHTML_CheckedChanged);
            // 
            // textBoxHTMLURL
            // 
            this.textBoxHTMLURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHTMLURL.Location = new System.Drawing.Point(898, 557);
            this.textBoxHTMLURL.Name = "textBoxHTMLURL";
            this.textBoxHTMLURL.Size = new System.Drawing.Size(205, 20);
            this.textBoxHTMLURL.TabIndex = 189;
            this.textBoxHTMLURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHTMLURL_KeyDown);
            // 
            // buttonHTMLProps
            // 
            this.buttonHTMLProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHTMLProps.Enabled = false;
            this.buttonHTMLProps.Location = new System.Drawing.Point(1028, 531);
            this.buttonHTMLProps.Name = "buttonHTMLProps";
            this.buttonHTMLProps.Size = new System.Drawing.Size(75, 23);
            this.buttonHTMLProps.TabIndex = 190;
            this.buttonHTMLProps.Text = "Props";
            this.buttonHTMLProps.UseVisualStyleBackColor = true;
            this.buttonHTMLProps.Click += new System.EventHandler(this.buttonHTMLProps_Click);
            // 
            // Lshape_chb
            // 
            this.Lshape_chb.AutoSize = true;
            this.Lshape_chb.Location = new System.Drawing.Point(860, 535);
            this.Lshape_chb.Name = "Lshape_chb";
            this.Lshape_chb.Size = new System.Drawing.Size(32, 17);
            this.Lshape_chb.TabIndex = 191;
            this.Lshape_chb.Text = "L";
            this.Lshape_chb.UseVisualStyleBackColor = true;
            this.Lshape_chb.CheckedChanged += new System.EventHandler(this.Lshape_chb_CheckedChanged);
            // 
            // LShapePath_txb
            // 
            this.LShapePath_txb.Location = new System.Drawing.Point(477, 535);
            this.LShapePath_txb.Name = "LShapePath_txb";
            this.LShapePath_txb.Size = new System.Drawing.Size(377, 20);
            this.LShapePath_txb.TabIndex = 192;
            this.LShapePath_txb.Text = "E:\\!temp\\etere pte ltd_1024x576_L Shape-12.png";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1109, 765);
            this.Controls.Add(this.LShapePath_txb);
            this.Controls.Add(this.Lshape_chb);
            this.Controls.Add(this.buttonHTMLProps);
            this.Controls.Add(this.textBoxHTMLURL);
            this.Controls.Add(this.checkBoxHTML);
            this.Controls.Add(this.checkBoxCC);
            this.Controls.Add(this.CgEditorButton);
            this.Controls.Add(this.buttonStatistic);
            this.Controls.Add(this.checkBoxVSource);
            this.Controls.Add(this.mPlaylistTimeline1);
            this.Controls.Add(this.buttonCG_Props);
            this.Controls.Add(this.checkBoxCG);
            this.Controls.Add(this.mAudioMeter1);
            this.Controls.Add(this.mPlaylistStatus1);
            this.Controls.Add(this.mRateControl1);
            this.Controls.Add(this.mRendererCheckList1);
            this.Controls.Add(this.mSeekControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mPreviewControl1);
            this.MinimumSize = new System.Drawing.Size(1125, 728);
            this.Name = "Form1";
            this.Text = "Playlist Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MControls.MFileState mFileStateControl1;
        private MControls.MPlaylistList mPlaylistControl1;
        private MControls.MPreviewControl mPreviewControl1;
        private MControls.MBreaksList mBreaksControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxListSeek;
        private MControls.MFileSeeking mSeekControl1;
        private MControls.MFormatControl mFormatControl1;
        private MControls.MRenderersList mRendererCheckList1;
        private MControls.MFileRate mRateControl1;
        private MControls.MPlaylistStatus mPlaylistStatus1;
        private MControls.MPlaylistTimeline mPlaylistTimeline1;
        private MControls.MAudioMeter mAudioMeter1;
        private System.Windows.Forms.CheckBox checkBoxCG;
        private System.Windows.Forms.Button buttonCG_Props;
        private MControls.MPlaylistBackground mPlaylistBackground1;
        private System.Windows.Forms.Label label3;
        private MControls.MPersistControl mPersistControl1;
        private System.Windows.Forms.CheckBox checkBoxVSource;
        private System.Windows.Forms.Button buttonStatistic;
        private System.Windows.Forms.Button CgEditorButton;
        private System.Windows.Forms.CheckBox checkBoxCC;
        private System.Windows.Forms.Timer timerReleaseEvents;
        private System.Windows.Forms.CheckBox checkBoxHTML;
        private System.Windows.Forms.TextBox textBoxHTMLURL;
        private System.Windows.Forms.Button buttonHTMLProps;
        private System.Windows.Forms.CheckBox Lshape_chb;
        private System.Windows.Forms.TextBox LShapePath_txb;
    }
}

