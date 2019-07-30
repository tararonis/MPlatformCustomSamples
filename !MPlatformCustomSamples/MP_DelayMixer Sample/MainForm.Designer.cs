namespace MixerSample
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
            this.CKProps = new System.Windows.Forms.Button();
            this.chromaEnabler = new System.Windows.Forms.CheckBox();
            this.checkBoxCG = new System.Windows.Forms.CheckBox();
            this.CGProps = new System.Windows.Forms.Button();
            this.checkBoxAR = new System.Windows.Forms.CheckBox();
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
            this.panelPreview = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNDIWebRTCName = new System.Windows.Forms.TextBox();
            this.checkBoxVDev = new System.Windows.Forms.CheckBox();
            this.comboBoxRenderer = new System.Windows.Forms.ComboBox();
            this.checkBoxOutput = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericTimeForChange = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRemoveInputStream = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonRemoveSceneElement = new System.Windows.Forms.Button();
            this.buttonLintWithInputStram = new System.Windows.Forms.Button();
            this.dataGridViewStreams = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddLive = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DelayBar = new System.Windows.Forms.TrackBar();
            this.updateList_btn = new System.Windows.Forms.Button();
            this.externalAudio_list = new System.Windows.Forms.ComboBox();
            this.mElementsTree = new MixerSample.MElementsTree();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeForChange)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStreams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBar)).BeginInit();
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
            this.panel2.Controls.Add(this.CKProps);
            this.panel2.Controls.Add(this.chromaEnabler);
            this.panel2.Controls.Add(this.checkBoxCG);
            this.panel2.Controls.Add(this.CGProps);
            this.panel2.Controls.Add(this.checkBoxAR);
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
            this.panel2.Location = new System.Drawing.Point(493, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 101);
            this.panel2.TabIndex = 172;
            // 
            // CKProps
            // 
            this.CKProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CKProps.Location = new System.Drawing.Point(715, 72);
            this.CKProps.Name = "CKProps";
            this.CKProps.Size = new System.Drawing.Size(83, 23);
            this.CKProps.TabIndex = 178;
            this.CKProps.Text = "CK Props";
            this.CKProps.UseVisualStyleBackColor = true;
            this.CKProps.Click += new System.EventHandler(this.CKProps_Click);
            // 
            // chromaEnabler
            // 
            this.chromaEnabler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chromaEnabler.AutoSize = true;
            this.chromaEnabler.Location = new System.Drawing.Point(715, 49);
            this.chromaEnabler.Name = "chromaEnabler";
            this.chromaEnabler.Size = new System.Drawing.Size(83, 17);
            this.chromaEnabler.TabIndex = 177;
            this.chromaEnabler.Text = "Chroma Key";
            this.chromaEnabler.UseVisualStyleBackColor = true;
            this.chromaEnabler.CheckedChanged += new System.EventHandler(this.chromaEnabler_CheckedChanged);
            // 
            // checkBoxCG
            // 
            this.checkBoxCG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCG.AutoSize = true;
            this.checkBoxCG.Location = new System.Drawing.Point(629, 49);
            this.checkBoxCG.Name = "checkBoxCG";
            this.checkBoxCG.Size = new System.Drawing.Size(80, 17);
            this.checkBoxCG.TabIndex = 176;
            this.checkBoxCG.Text = "CG Enabler";
            this.checkBoxCG.UseVisualStyleBackColor = true;
            this.checkBoxCG.CheckedChanged += new System.EventHandler(this.checkBoxCG_CheckedChanged);
            // 
            // CGProps
            // 
            this.CGProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CGProps.Location = new System.Drawing.Point(629, 73);
            this.CGProps.Name = "CGProps";
            this.CGProps.Size = new System.Drawing.Size(80, 23);
            this.CGProps.TabIndex = 175;
            this.CGProps.Text = "CG Props";
            this.CGProps.UseVisualStyleBackColor = true;
            this.CGProps.Click += new System.EventHandler(this.CGProps_Click);
            // 
            // checkBoxAR
            // 
            this.checkBoxAR.AutoSize = true;
            this.checkBoxAR.Location = new System.Drawing.Point(109, 78);
            this.checkBoxAR.Name = "checkBoxAR";
            this.checkBoxAR.Size = new System.Drawing.Size(41, 17);
            this.checkBoxAR.TabIndex = 169;
            this.checkBoxAR.Text = "AR";
            this.checkBoxAR.UseVisualStyleBackColor = true;
            this.checkBoxAR.CheckedChanged += new System.EventHandler(this.checkBoxAR_CheckedChanged);
            // 
            // comboBoxAF
            // 
            this.comboBoxAF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAF.DropDownWidth = 300;
            this.comboBoxAF.FormattingEnabled = true;
            this.comboBoxAF.Location = new System.Drawing.Point(449, 74);
            this.comboBoxAF.Name = "comboBoxAF";
            this.comboBoxAF.Size = new System.Drawing.Size(174, 21);
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
            this.comboBoxVF.Location = new System.Drawing.Point(449, 49);
            this.comboBoxVF.Name = "comboBoxVF";
            this.comboBoxVF.Size = new System.Drawing.Size(174, 21);
            this.comboBoxVF.TabIndex = 167;
            this.comboBoxVF.SelectedIndexChanged += new System.EventHandler(this.comboBoxVF_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 166;
            this.label2.Text = "Audio format:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 53);
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
            this.labelPos.Size = new System.Drawing.Size(793, 5);
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
            this.trackBarSeek.Size = new System.Drawing.Size(809, 33);
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
            this.checkBoxAudio.Checked = true;
            this.checkBoxAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAudio.Location = new System.Drawing.Point(156, 79);
            this.checkBoxAudio.Name = "checkBoxAudio";
            this.checkBoxAudio.Size = new System.Drawing.Size(94, 17);
            this.checkBoxAudio.TabIndex = 127;
            this.checkBoxAudio.Text = "Audio Preview";
            this.checkBoxAudio.UseVisualStyleBackColor = true;
            this.checkBoxAudio.CheckedChanged += new System.EventHandler(this.checkBoxAudio_CheckedChanged);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(98, 51);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(80, 21);
            this.buttonPause.TabIndex = 138;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(252, 78);
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
            this.buttonPlay.Size = new System.Drawing.Size(80, 21);
            this.buttonPlay.TabIndex = 155;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(274, 51);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 21);
            this.buttonStop.TabIndex = 154;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRewind
            // 
            this.buttonRewind.Location = new System.Drawing.Point(186, 51);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(80, 21);
            this.buttonRewind.TabIndex = 153;
            this.buttonRewind.Text = "Rewind";
            this.buttonRewind.UseVisualStyleBackColor = true;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(202, 10);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(289, 50);
            this.labelInfo.TabIndex = 170;
            this.labelInfo.Text = "Scene config sample shows how to arrange scene in video mixer.  You can drag and " +
    "resize items on the preview.";
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
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(143)))));
            this.panelPreview.Location = new System.Drawing.Point(548, 117);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(758, 437);
            this.panelPreview.TabIndex = 166;
            this.panelPreview.SizeChanged += new System.EventHandler(this.panelPreview_SizeChanged);
            this.panelPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseDown);
            this.panelPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseMove);
            this.panelPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseUp);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.ForeColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(493, 7);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(5);
            this.labelStatus.Size = new System.Drawing.Size(814, 53);
            this.labelStatus.TabIndex = 167;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFile.Location = new System.Drawing.Point(5, 238);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(67, 25);
            this.buttonAddFile.TabIndex = 165;
            this.buttonAddFile.Text = "Add file";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
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
            this.panel1.Location = new System.Drawing.Point(7, 625);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 36);
            this.panel1.TabIndex = 166;
            // 
            // textBoxNDIWebRTCName
            // 
            this.textBoxNDIWebRTCName.Enabled = false;
            this.textBoxNDIWebRTCName.Location = new System.Drawing.Point(245, 8);
            this.textBoxNDIWebRTCName.Name = "textBoxNDIWebRTCName";
            this.textBoxNDIWebRTCName.Size = new System.Drawing.Size(123, 20);
            this.textBoxNDIWebRTCName.TabIndex = 169;
            this.textBoxNDIWebRTCName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNDIWebRTCName_KeyPress);
            // 
            // checkBoxVDev
            // 
            this.checkBoxVDev.AutoSize = true;
            this.checkBoxVDev.Location = new System.Drawing.Point(374, 9);
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
            this.comboBoxRenderer.Location = new System.Drawing.Point(106, 7);
            this.comboBoxRenderer.Name = "comboBoxRenderer";
            this.comboBoxRenderer.Size = new System.Drawing.Size(133, 21);
            this.comboBoxRenderer.TabIndex = 167;
            this.comboBoxRenderer.SelectedIndexChanged += new System.EventHandler(this.comboBoxRenderer_SelectedIndexChanged);
            // 
            // checkBoxOutput
            // 
            this.checkBoxOutput.AutoSize = true;
            this.checkBoxOutput.Enabled = false;
            this.checkBoxOutput.Location = new System.Drawing.Point(5, 11);
            this.checkBoxOutput.Name = "checkBoxOutput";
            this.checkBoxOutput.Size = new System.Drawing.Size(105, 17);
            this.checkBoxOutput.TabIndex = 161;
            this.checkBoxOutput.Text = "Output to device";
            this.checkBoxOutput.UseVisualStyleBackColor = true;
            this.checkBoxOutput.CheckedChanged += new System.EventHandler(this.checkBoxOutput_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel3.Controls.Add(this.dataGridViewAttributes);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.numericTimeForChange);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(236, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 552);
            this.panel3.TabIndex = 173;
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.AllowUserToResizeRows = false;
            this.dataGridViewAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewAttributes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAttributes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
            this.dataGridViewAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewAttributes.Location = new System.Drawing.Point(5, 25);
            this.dataGridViewAttributes.MultiSelect = false;
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAttributes.RowHeadersWidth = 15;
            this.dataGridViewAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAttributes.RowTemplate.Height = 24;
            this.dataGridViewAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(241, 493);
            this.dataGridViewAttributes.TabIndex = 173;
            this.dataGridViewAttributes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttributes_CellValueChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.FillWeight = 50F;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnValue.FillWeight = 50F;
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 528);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 172;
            this.label6.Text = "seconds";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 528);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 170;
            this.label5.Text = "Change time:";
            // 
            // numericTimeForChange
            // 
            this.numericTimeForChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericTimeForChange.DecimalPlaces = 2;
            this.numericTimeForChange.Increment = new decimal(new int[] {
            500,
            0,
            0,
            196608});
            this.numericTimeForChange.Location = new System.Drawing.Point(102, 524);
            this.numericTimeForChange.Name = "numericTimeForChange";
            this.numericTimeForChange.Size = new System.Drawing.Size(78, 20);
            this.numericTimeForChange.TabIndex = 171;
            this.numericTimeForChange.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Selected element attributes";
            // 
            // buttonRemoveInputStream
            // 
            this.buttonRemoveInputStream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveInputStream.Location = new System.Drawing.Point(154, 238);
            this.buttonRemoveInputStream.Name = "buttonRemoveInputStream";
            this.buttonRemoveInputStream.Size = new System.Drawing.Size(67, 25);
            this.buttonRemoveInputStream.TabIndex = 166;
            this.buttonRemoveInputStream.Text = "Remove";
            this.buttonRemoveInputStream.UseVisualStyleBackColor = true;
            this.buttonRemoveInputStream.Click += new System.EventHandler(this.buttonRemoveInputStream_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel4.Controls.Add(this.buttonRemoveSceneElement);
            this.panel4.Controls.Add(this.buttonLintWithInputStram);
            this.panel4.Controls.Add(this.dataGridViewStreams);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.buttonAddLive);
            this.panel4.Controls.Add(this.buttonRemoveInputStream);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.buttonAddFile);
            this.panel4.Controls.Add(this.mElementsTree);
            this.panel4.Location = new System.Drawing.Point(7, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 552);
            this.panel4.TabIndex = 174;
            // 
            // buttonRemoveSceneElement
            // 
            this.buttonRemoveSceneElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveSceneElement.Location = new System.Drawing.Point(154, 522);
            this.buttonRemoveSceneElement.Name = "buttonRemoveSceneElement";
            this.buttonRemoveSceneElement.Size = new System.Drawing.Size(67, 25);
            this.buttonRemoveSceneElement.TabIndex = 174;
            this.buttonRemoveSceneElement.Text = "Remove";
            this.buttonRemoveSceneElement.UseVisualStyleBackColor = true;
            this.buttonRemoveSceneElement.Click += new System.EventHandler(this.buttonRemoveSceneElement_Click);
            // 
            // buttonLintWithInputStram
            // 
            this.buttonLintWithInputStram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLintWithInputStram.Enabled = false;
            this.buttonLintWithInputStram.Location = new System.Drawing.Point(5, 522);
            this.buttonLintWithInputStram.Name = "buttonLintWithInputStram";
            this.buttonLintWithInputStram.Size = new System.Drawing.Size(143, 25);
            this.buttonLintWithInputStram.TabIndex = 173;
            this.buttonLintWithInputStram.Text = "Link with input stream";
            this.buttonLintWithInputStram.UseVisualStyleBackColor = true;
            this.buttonLintWithInputStram.Click += new System.EventHandler(this.buttonLinkWithInputStram_Click);
            // 
            // dataGridViewStreams
            // 
            this.dataGridViewStreams.AllowUserToAddRows = false;
            this.dataGridViewStreams.AllowUserToResizeRows = false;
            this.dataGridViewStreams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewStreams.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStreams.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewStreams.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewStreams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStreams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ColumnFile,
            this.ColumnIn,
            this.ColumnOut,
            this.ColumnState});
            this.dataGridViewStreams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewStreams.Location = new System.Drawing.Point(5, 25);
            this.dataGridViewStreams.MultiSelect = false;
            this.dataGridViewStreams.Name = "dataGridViewStreams";
            this.dataGridViewStreams.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewStreams.RowHeadersWidth = 15;
            this.dataGridViewStreams.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewStreams.RowTemplate.Height = 24;
            this.dataGridViewStreams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStreams.Size = new System.Drawing.Size(216, 207);
            this.dataGridViewStreams.TabIndex = 172;
            this.dataGridViewStreams.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewStreams_RowsRemoved);
            this.dataGridViewStreams.SelectionChanged += new System.EventHandler(this.dataGridViewStreams_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 20F;
            this.dataGridViewTextBoxColumn1.HeaderText = "StreamId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // ColumnFile
            // 
            this.ColumnFile.FillWeight = 80F;
            this.ColumnFile.HeaderText = "File";
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.ReadOnly = true;
            this.ColumnFile.Width = 150;
            // 
            // ColumnIn
            // 
            this.ColumnIn.HeaderText = "In";
            this.ColumnIn.Name = "ColumnIn";
            this.ColumnIn.Width = 30;
            // 
            // ColumnOut
            // 
            this.ColumnOut.HeaderText = "Out";
            this.ColumnOut.Name = "ColumnOut";
            this.ColumnOut.Width = 30;
            // 
            // ColumnState
            // 
            this.ColumnState.HeaderText = "State";
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 171;
            this.label7.Text = "Input streams (Add input sources here)";
            // 
            // buttonAddLive
            // 
            this.buttonAddLive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddLive.Location = new System.Drawing.Point(80, 238);
            this.buttonAddLive.Name = "buttonAddLive";
            this.buttonAddLive.Size = new System.Drawing.Size(67, 25);
            this.buttonAddLive.TabIndex = 167;
            this.buttonAddLive.Text = "Add live";
            this.buttonAddLive.UseVisualStyleBackColor = true;
            this.buttonAddLive.Click += new System.EventHandler(this.buttonAddLive_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(6, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scene tree (links scene elements with input streams)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 44);
            this.button1.TabIndex = 175;
            this.button1.Text = "AddMixer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 49);
            this.button2.TabIndex = 176;
            this.button2.Text = "AddDelay";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // DelayBar
            // 
            this.DelayBar.Location = new System.Drawing.Point(548, 67);
            this.DelayBar.Maximum = 20;
            this.DelayBar.Name = "DelayBar";
            this.DelayBar.Size = new System.Drawing.Size(227, 45);
            this.DelayBar.TabIndex = 177;
            // 
            // updateList_btn
            // 
            this.updateList_btn.Location = new System.Drawing.Point(815, 62);
            this.updateList_btn.Name = "updateList_btn";
            this.updateList_btn.Size = new System.Drawing.Size(52, 54);
            this.updateList_btn.TabIndex = 178;
            this.updateList_btn.Text = "Update";
            this.updateList_btn.UseVisualStyleBackColor = true;
            this.updateList_btn.Click += new System.EventHandler(this.Button3_Click);
            // 
            // externalAudio_list
            // 
            this.externalAudio_list.FormattingEnabled = true;
            this.externalAudio_list.Location = new System.Drawing.Point(873, 62);
            this.externalAudio_list.Name = "externalAudio_list";
            this.externalAudio_list.Size = new System.Drawing.Size(121, 21);
            this.externalAudio_list.TabIndex = 179;
            this.externalAudio_list.SelectedIndexChanged += new System.EventHandler(this.ExternalAudio_list_SelectedIndexChanged);
            // 
            // mElementsTree
            // 
            this.mElementsTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mElementsTree.CheckBoxes = true;
            this.mElementsTree.HideSelection = false;
            this.mElementsTree.Location = new System.Drawing.Point(5, 313);
            this.mElementsTree.Name = "mElementsTree";
            this.mElementsTree.SelectedElement = null;
            this.mElementsTree.Size = new System.Drawing.Size(216, 203);
            this.mElementsTree.TabIndex = 0;
            this.mElementsTree.TimeForChange = 2D;
            this.mElementsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mElementsTree_AfterSelect);
            this.mElementsTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mElementsTree_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1314, 669);
            this.Controls.Add(this.externalAudio_list);
            this.Controls.Add(this.updateList_btn);
            this.Controls.Add(this.DelayBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.labelStatus);
            this.MinimumSize = new System.Drawing.Size(1314, 669);
            this.Name = "MainForm";
            this.Text = "Mixer Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeForChange)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStreams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBar)).EndInit();
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
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxOutput;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonRemoveInputStream;
        private System.Windows.Forms.ComboBox comboBoxAF;
        private System.Windows.Forms.ComboBox comboBoxVF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRenderer;
        private System.Windows.Forms.CheckBox checkBoxVDev;
        private System.Windows.Forms.Panel panel4;
        private MElementsTree mElementsTree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddLive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericTimeForChange;
        private System.Windows.Forms.CheckBox checkBoxAR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewStreams;
        private System.Windows.Forms.Button buttonRemoveSceneElement;
        private System.Windows.Forms.Button buttonLintWithInputStram;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnState;
        private System.Windows.Forms.DataGridView dataGridViewAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.Button CGProps;
        private System.Windows.Forms.CheckBox checkBoxCG;
        private System.Windows.Forms.Button CKProps;
        private System.Windows.Forms.CheckBox chromaEnabler;
        private System.Windows.Forms.TextBox textBoxNDIWebRTCName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar DelayBar;
        private System.Windows.Forms.Button updateList_btn;
        private System.Windows.Forms.ComboBox externalAudio_list;
    }
}

