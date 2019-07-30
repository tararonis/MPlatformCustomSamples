namespace InternalPlaylistSample
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.openMediaFile = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxAF = new System.Windows.Forms.ComboBox();
            this.comboBoxVF = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPos = new System.Windows.Forms.Label();
            this.trackBarSeek = new System.Windows.Forms.TrackBar();
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.checkBoxAudio = new System.Windows.Forms.CheckBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNDIWebRTCName = new System.Windows.Forms.TextBox();
            this.checkBoxVDev = new System.Windows.Forms.CheckBox();
            this.comboBoxRenderer = new System.Windows.Forms.ComboBox();
            this.checkBoxOutput = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.CGProps = new System.Windows.Forms.Button();
            this.checkBoxCG = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 33;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // openMediaFile
            // 
            this.openMediaFile.Multiselect = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.comboBoxAF);
            this.panel2.Controls.Add(this.comboBoxVF);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelPos);
            this.panel2.Controls.Add(this.trackBarSeek);
            this.panel2.Controls.Add(this.checkBoxVideo);
            this.panel2.Controls.Add(this.checkBoxAudio);
            this.panel2.Controls.Add(this.buttonPause);
            this.panel2.Controls.Add(this.trackBarVolume);
            this.panel2.Controls.Add(this.buttonPlay);
            this.panel2.Controls.Add(this.buttonStop);
            this.panel2.Controls.Add(this.buttonRewind);
            this.panel2.Location = new System.Drawing.Point(416, 634);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(561, 101);
            this.panel2.TabIndex = 172;
            // 
            // comboBoxAF
            // 
            this.comboBoxAF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAF.DropDownWidth = 300;
            this.comboBoxAF.FormattingEnabled = true;
            this.comboBoxAF.Location = new System.Drawing.Point(400, 74);
            this.comboBoxAF.Name = "comboBoxAF";
            this.comboBoxAF.Size = new System.Drawing.Size(150, 21);
            this.comboBoxAF.TabIndex = 168;
            this.comboBoxAF.SelectedIndexChanged += new System.EventHandler(this.comboBoxAF_SelectedIndexChanged);
            // 
            // comboBoxVF
            // 
            this.comboBoxVF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVF.DropDownWidth = 300;
            this.comboBoxVF.FormattingEnabled = true;
            this.comboBoxVF.Location = new System.Drawing.Point(400, 49);
            this.comboBoxVF.Name = "comboBoxVF";
            this.comboBoxVF.Size = new System.Drawing.Size(150, 21);
            this.comboBoxVF.TabIndex = 167;
            this.comboBoxVF.SelectedIndexChanged += new System.EventHandler(this.comboBoxVF_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 166;
            this.label2.Text = "Audio format:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 165;
            this.label1.Text = "Video format:";
            // 
            // labelPos
            // 
            this.labelPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPos.BackColor = System.Drawing.Color.Lime;
            this.labelPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPos.ForeColor = System.Drawing.Color.Lime;
            this.labelPos.Location = new System.Drawing.Point(10, 36);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(540, 5);
            this.labelPos.TabIndex = 150;
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSeek.AutoSize = false;
            this.trackBarSeek.LargeChange = 10;
            this.trackBarSeek.Location = new System.Drawing.Point(4, 4);
            this.trackBarSeek.Maximum = 1000;
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(556, 33);
            this.trackBarSeek.TabIndex = 132;
            this.trackBarSeek.TickFrequency = 50;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.Checked = true;
            this.checkBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVideo.Location = new System.Drawing.Point(10, 78);
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
            this.checkBoxAudio.Location = new System.Drawing.Point(104, 79);
            this.checkBoxAudio.Name = "checkBoxAudio";
            this.checkBoxAudio.Size = new System.Drawing.Size(94, 17);
            this.checkBoxAudio.TabIndex = 127;
            this.checkBoxAudio.Text = "Audio Preview";
            this.checkBoxAudio.UseVisualStyleBackColor = true;
            this.checkBoxAudio.CheckedChanged += new System.EventHandler(this.checkBoxAudio_CheckedChanged);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(85, 51);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(69, 21);
            this.buttonPause.TabIndex = 138;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(200, 78);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(104, 17);
            this.trackBarVolume.TabIndex = 148;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(10, 51);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(69, 21);
            this.buttonPlay.TabIndex = 155;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(235, 51);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(69, 21);
            this.buttonStop.TabIndex = 154;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRewind
            // 
            this.buttonRewind.Location = new System.Drawing.Point(160, 51);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(69, 21);
            this.buttonRewind.TabIndex = 153;
            this.buttonRewind.Text = "Rewind";
            this.buttonRewind.UseVisualStyleBackColor = true;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(202, 10);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(208, 50);
            this.labelInfo.TabIndex = 170;
            this.labelInfo.Text = "Internal playlist shows MPlaylist class features like seamless playback and seeki" +
    "ng through entire playlist.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureLogo.InitialImage")));
            this.pictureLogo.Location = new System.Drawing.Point(7, 10);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(193, 50);
            this.pictureLogo.TabIndex = 169;
            this.pictureLogo.TabStop = false;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowDrop = true;
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToResizeRows = false;
            this.dataGridViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.dataGridViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNum,
            this.ColumnFileDest,
            this.ColumnIn,
            this.ColumnOut,
            this.ColumnLoc});
            this.dataGridViewFiles.Location = new System.Drawing.Point(7, 336);
            this.dataGridViewFiles.MultiSelect = false;
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewFiles.RowHeadersWidth = 21;
            this.dataGridViewFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFiles.RowTemplate.Height = 24;
            this.dataGridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFiles.Size = new System.Drawing.Size(403, 292);
            this.dataGridViewFiles.TabIndex = 168;
            this.dataGridViewFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFiles_CellDoubleClick);
            this.dataGridViewFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFiles_CellValueChanged);
            this.dataGridViewFiles.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewFiles_RowsRemoved);
            this.dataGridViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewFiles_DragDrop);
            this.dataGridViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewFiles_DragEnter);
            // 
            // ColumnNum
            // 
            this.ColumnNum.FillWeight = 20F;
            this.ColumnNum.HeaderText = "#";
            this.ColumnNum.Name = "ColumnNum";
            this.ColumnNum.ReadOnly = true;
            this.ColumnNum.Width = 20;
            // 
            // ColumnFileDest
            // 
            this.ColumnFileDest.FillWeight = 80F;
            this.ColumnFileDest.HeaderText = "File";
            this.ColumnFileDest.Name = "ColumnFileDest";
            this.ColumnFileDest.ReadOnly = true;
            this.ColumnFileDest.Width = 280;
            // 
            // ColumnIn
            // 
            this.ColumnIn.HeaderText = "In";
            this.ColumnIn.Name = "ColumnIn";
            this.ColumnIn.Width = 50;
            // 
            // ColumnOut
            // 
            this.ColumnOut.HeaderText = "Out";
            this.ColumnOut.Name = "ColumnOut";
            this.ColumnOut.Width = 50;
            // 
            // ColumnLoc
            // 
            this.ColumnLoc.HeaderText = "Props";
            this.ColumnLoc.Name = "ColumnLoc";
            this.ColumnLoc.Width = 200;
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(143)))));
            this.panelPreview.Location = new System.Drawing.Point(7, 66);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(403, 257);
            this.panelPreview.TabIndex = 166;
            this.panelPreview.SizeChanged += new System.EventHandler(this.panelPreview_SizeChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.ForeColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(520, 7);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(5);
            this.labelStatus.Size = new System.Drawing.Size(457, 53);
            this.labelStatus.TabIndex = 167;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(9, 8);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(186, 25);
            this.buttonAdd.TabIndex = 165;
            this.buttonAdd.Text = "Add files to playlist";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.textBoxNDIWebRTCName);
            this.panel1.Controls.Add(this.checkBoxVDev);
            this.panel1.Controls.Add(this.comboBoxRenderer);
            this.panel1.Controls.Add(this.checkBoxOutput);
            this.panel1.Location = new System.Drawing.Point(7, 681);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 54);
            this.panel1.TabIndex = 166;
            // 
            // textBoxNDIWebRTCName
            // 
            this.textBoxNDIWebRTCName.Enabled = false;
            this.textBoxNDIWebRTCName.Location = new System.Drawing.Point(279, 7);
            this.textBoxNDIWebRTCName.Name = "textBoxNDIWebRTCName";
            this.textBoxNDIWebRTCName.Size = new System.Drawing.Size(113, 20);
            this.textBoxNDIWebRTCName.TabIndex = 169;
            this.textBoxNDIWebRTCName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNDIWebRTCName_KeyPress);
            // 
            // checkBoxVDev
            // 
            this.checkBoxVDev.AutoSize = true;
            this.checkBoxVDev.Location = new System.Drawing.Point(9, 30);
            this.checkBoxVDev.Name = "checkBoxVDev";
            this.checkBoxVDev.Size = new System.Drawing.Size(101, 17);
            this.checkBoxVDev.TabIndex = 168;
            this.checkBoxVDev.Text = "Create virt. dev.";
            this.checkBoxVDev.UseVisualStyleBackColor = true;
            this.checkBoxVDev.CheckedChanged += new System.EventHandler(this.checkBoxVDev_CheckedChanged);
            // 
            // comboBoxRenderer
            // 
            this.comboBoxRenderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRenderer.FormattingEnabled = true;
            this.comboBoxRenderer.Location = new System.Drawing.Point(124, 6);
            this.comboBoxRenderer.Name = "comboBoxRenderer";
            this.comboBoxRenderer.Size = new System.Drawing.Size(149, 21);
            this.comboBoxRenderer.TabIndex = 167;
            this.comboBoxRenderer.SelectedIndexChanged += new System.EventHandler(this.comboBoxRenderer_SelectedIndexChanged);
            // 
            // checkBoxOutput
            // 
            this.checkBoxOutput.AutoSize = true;
            this.checkBoxOutput.Enabled = false;
            this.checkBoxOutput.Location = new System.Drawing.Point(9, 8);
            this.checkBoxOutput.Name = "checkBoxOutput";
            this.checkBoxOutput.Size = new System.Drawing.Size(105, 17);
            this.checkBoxOutput.TabIndex = 161;
            this.checkBoxOutput.Text = "Output to device";
            this.checkBoxOutput.UseVisualStyleBackColor = true;
            this.checkBoxOutput.CheckedChanged += new System.EventHandler(this.checkBoxOutput_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel3.Controls.Add(this.buttonRemove);
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Location = new System.Drawing.Point(7, 634);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 40);
            this.panel3.TabIndex = 173;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(206, 8);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(186, 25);
            this.buttonRemove.TabIndex = 166;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // CGProps
            // 
            this.CGProps.Location = new System.Drawing.Point(426, 37);
            this.CGProps.Name = "CGProps";
            this.CGProps.Size = new System.Drawing.Size(75, 23);
            this.CGProps.TabIndex = 174;
            this.CGProps.Text = "CG Props";
            this.CGProps.UseVisualStyleBackColor = true;
            this.CGProps.Click += new System.EventHandler(this.CGProps_Click);
            // 
            // checkBoxCG
            // 
            this.checkBoxCG.AutoSize = true;
            this.checkBoxCG.Location = new System.Drawing.Point(426, 14);
            this.checkBoxCG.Name = "checkBoxCG";
            this.checkBoxCG.Size = new System.Drawing.Size(80, 17);
            this.checkBoxCG.TabIndex = 175;
            this.checkBoxCG.Text = "CG Enabler";
            this.checkBoxCG.UseVisualStyleBackColor = true;
            this.checkBoxCG.CheckedChanged += new System.EventHandler(this.checkBoxCG_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 176;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(576, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(400, 21);
            this.comboBox1.TabIndex = 177;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(426, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 178;
            this.checkBox1.Text = "Insert each frame";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(426, 180);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(550, 448);
            this.richTextBox1.TabIndex = 179;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(576, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 20);
            this.textBox1.TabIndex = 180;
            this.textBox1.Text = "udp://225.0.0.1:5000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 181;
            this.label3.Text = "URL";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 182;
            this.button2.Text = "Start DVB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 757);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxCG);
            this.Controls.Add(this.CGProps);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.dataGridViewFiles);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.labelStatus);
            this.MinimumSize = new System.Drawing.Size(998, 550);
            this.Name = "MainForm";
            this.Text = "Internal Playlist Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.OpenFileDialog openMediaFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.CheckBox checkBoxVideo;
        private System.Windows.Forms.CheckBox checkBoxAudio;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxOutput;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ComboBox comboBoxAF;
        private System.Windows.Forms.ComboBox comboBoxVF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRenderer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLoc;
        private System.Windows.Forms.CheckBox checkBoxVDev;
        private System.Windows.Forms.Button CGProps;
        private System.Windows.Forms.CheckBox checkBoxCG;
        private System.Windows.Forms.TextBox textBoxNDIWebRTCName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}

