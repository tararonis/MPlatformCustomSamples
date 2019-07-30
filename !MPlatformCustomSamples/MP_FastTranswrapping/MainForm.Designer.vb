Partial Class MainForm
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.timerStatus = New System.Windows.Forms.Timer(Me.components)
        Me.openMediaFile = New System.Windows.Forms.OpenFileDialog()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.buttonCG_Props = New System.Windows.Forms.Button()
        Me.trackBarVolume = New System.Windows.Forms.TrackBar()
        Me.checkBoxCG = New System.Windows.Forms.CheckBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.checkBoxVideo = New System.Windows.Forms.CheckBox()
        Me.checkBoxAudio = New System.Windows.Forms.CheckBox()
        Me.labelPos = New System.Windows.Forms.Label()
        Me.trackBarSeek = New System.Windows.Forms.TrackBar()
        Me.comboBoxVF = New System.Windows.Forms.ComboBox()
        Me.comboBoxAF = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.buttonPause = New System.Windows.Forms.Button()
        Me.buttonPlay = New System.Windows.Forms.Button()
        Me.buttonStop = New System.Windows.Forms.Button()
        Me.dataGridViewFiles = New System.Windows.Forms.DataGridView()
        Me.ColumnNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnFileDest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelPreview = New System.Windows.Forms.Panel()
        Me.labelStatus = New System.Windows.Forms.Label()
        Me.buttonAddFile = New System.Windows.Forms.Button()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.checkBox1 = New System.Windows.Forms.CheckBox()
        Me.buttonRemove = New System.Windows.Forms.Button()
        Me.buttonAddLive = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.comboBoxURL = New System.Windows.Forms.ComboBox()
        Me.columnProps = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.comboBoxProps = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.numericPause = New System.Windows.Forms.NumericUpDown()
        Me.buttonSetMax = New System.Windows.Forms.Button()
        Me.numericMaxDuration = New System.Windows.Forms.NumericUpDown()
        Me.label6 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.mConfigList1 = New CapturePlaylistSample.MControls.MConfigList()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panel2.SuspendLayout()
        CType(Me.trackBarVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBarSeek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridViewFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel3.SuspendLayout()
        CType(Me.numericPause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericMaxDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timerStatus
        '
        Me.timerStatus.Enabled = True
        Me.timerStatus.Interval = 33
        '
        'openMediaFile
        '
        Me.openMediaFile.Multiselect = True
        '
        'panel2
        '
        Me.panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.panel2.Controls.Add(Me.buttonCG_Props)
        Me.panel2.Controls.Add(Me.trackBarVolume)
        Me.panel2.Controls.Add(Me.checkBoxCG)
        Me.panel2.Controls.Add(Me.label5)
        Me.panel2.Controls.Add(Me.checkBoxVideo)
        Me.panel2.Controls.Add(Me.checkBoxAudio)
        Me.panel2.Controls.Add(Me.labelPos)
        Me.panel2.Controls.Add(Me.trackBarSeek)
        Me.panel2.Location = New System.Drawing.Point(416, 426)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(560, 69)
        Me.panel2.TabIndex = 172
        '
        'buttonCG_Props
        '
        Me.buttonCG_Props.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCG_Props.Location = New System.Drawing.Point(476, 43)
        Me.buttonCG_Props.Name = "buttonCG_Props"
        Me.buttonCG_Props.Size = New System.Drawing.Size(75, 23)
        Me.buttonCG_Props.TabIndex = 183
        Me.buttonCG_Props.Text = "CG Props"
        Me.buttonCG_Props.UseVisualStyleBackColor = True
        '
        'trackBarVolume
        '
        Me.trackBarVolume.AutoSize = False
        Me.trackBarVolume.LargeChange = 10
        Me.trackBarVolume.Location = New System.Drawing.Point(210, 43)
        Me.trackBarVolume.Maximum = 100
        Me.trackBarVolume.Name = "trackBarVolume"
        Me.trackBarVolume.Size = New System.Drawing.Size(152, 17)
        Me.trackBarVolume.TabIndex = 148
        Me.trackBarVolume.TickFrequency = 10
        Me.trackBarVolume.Value = 50
        '
        'checkBoxCG
        '
        Me.checkBoxCG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkBoxCG.Location = New System.Drawing.Point(368, 43)
        Me.checkBoxCG.Name = "checkBoxCG"
        Me.checkBoxCG.Size = New System.Drawing.Size(84, 17)
        Me.checkBoxCG.TabIndex = 182
        Me.checkBoxCG.Text = "CG Enabled"
        Me.checkBoxCG.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(-110, 51)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(87, 13)
        Me.label5.TabIndex = 181
        Me.label5.Text = "Max file duration:"
        '
        'checkBoxVideo
        '
        Me.checkBoxVideo.AutoSize = True
        Me.checkBoxVideo.Checked = True
        Me.checkBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBoxVideo.Location = New System.Drawing.Point(110, 43)
        Me.checkBoxVideo.Name = "checkBoxVideo"
        Me.checkBoxVideo.Size = New System.Drawing.Size(94, 17)
        Me.checkBoxVideo.TabIndex = 126
        Me.checkBoxVideo.Text = "Video Preview"
        Me.checkBoxVideo.UseVisualStyleBackColor = True
        '
        'checkBoxAudio
        '
        Me.checkBoxAudio.AutoSize = True
        Me.checkBoxAudio.Location = New System.Drawing.Point(10, 43)
        Me.checkBoxAudio.Name = "checkBoxAudio"
        Me.checkBoxAudio.Size = New System.Drawing.Size(94, 17)
        Me.checkBoxAudio.TabIndex = 127
        Me.checkBoxAudio.Text = "Audio Preview"
        Me.checkBoxAudio.UseVisualStyleBackColor = True
        '
        'labelPos
        '
        Me.labelPos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelPos.BackColor = System.Drawing.Color.Lime
        Me.labelPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelPos.ForeColor = System.Drawing.Color.Lime
        Me.labelPos.Location = New System.Drawing.Point(22, 35)
        Me.labelPos.Name = "labelPos"
        Me.labelPos.Size = New System.Drawing.Size(529, 5)
        Me.labelPos.TabIndex = 150
        '
        'trackBarSeek
        '
        Me.trackBarSeek.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackBarSeek.AutoSize = False
        Me.trackBarSeek.Enabled = False
        Me.trackBarSeek.LargeChange = 10
        Me.trackBarSeek.Location = New System.Drawing.Point(10, 4)
        Me.trackBarSeek.Maximum = 1000
        Me.trackBarSeek.Name = "trackBarSeek"
        Me.trackBarSeek.Size = New System.Drawing.Size(547, 33)
        Me.trackBarSeek.TabIndex = 132
        Me.trackBarSeek.TickFrequency = 50
        '
        'comboBoxVF
        '
        Me.comboBoxVF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.comboBoxVF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxVF.DropDownWidth = 300
        Me.comboBoxVF.FormattingEnabled = True
        Me.comboBoxVF.Location = New System.Drawing.Point(213, 3)
        Me.comboBoxVF.Name = "comboBoxVF"
        Me.comboBoxVF.Size = New System.Drawing.Size(171, 21)
        Me.comboBoxVF.TabIndex = 175
        '
        'comboBoxAF
        '
        Me.comboBoxAF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.comboBoxAF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxAF.DropDownWidth = 300
        Me.comboBoxAF.FormattingEnabled = True
        Me.comboBoxAF.Location = New System.Drawing.Point(213, 30)
        Me.comboBoxAF.Name = "comboBoxAF"
        Me.comboBoxAF.Size = New System.Drawing.Size(171, 21)
        Me.comboBoxAF.TabIndex = 176
        '
        'label3
        '
        Me.label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(144, 33)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(69, 13)
        Me.label3.TabIndex = 174
        Me.label3.Text = "Audio format:"
        '
        'label4
        '
        Me.label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(144, 8)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(69, 13)
        Me.label4.TabIndex = 173
        Me.label4.Text = "Video format:"
        '
        'buttonPause
        '
        Me.buttonPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonPause.Location = New System.Drawing.Point(93, 452)
        Me.buttonPause.Name = "buttonPause"
        Me.buttonPause.Size = New System.Drawing.Size(64, 41)
        Me.buttonPause.TabIndex = 138
        Me.buttonPause.Text = "Pause Capturing"
        Me.buttonPause.UseVisualStyleBackColor = True
        '
        'buttonPlay
        '
        Me.buttonPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonPlay.Location = New System.Drawing.Point(7, 451)
        Me.buttonPlay.Name = "buttonPlay"
        Me.buttonPlay.Size = New System.Drawing.Size(80, 42)
        Me.buttonPlay.TabIndex = 155
        Me.buttonPlay.Text = "Start Play and  Capture"
        Me.buttonPlay.UseVisualStyleBackColor = True
        '
        'buttonStop
        '
        Me.buttonStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonStop.Location = New System.Drawing.Point(235, 451)
        Me.buttonStop.Name = "buttonStop"
        Me.buttonStop.Size = New System.Drawing.Size(62, 42)
        Me.buttonStop.TabIndex = 154
        Me.buttonStop.Text = "Stop Capturing"
        Me.buttonStop.UseVisualStyleBackColor = True
        '
        'dataGridViewFiles
        '
        Me.dataGridViewFiles.AllowUserToAddRows = False
        Me.dataGridViewFiles.AllowUserToResizeRows = False
        Me.dataGridViewFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dataGridViewFiles.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.dataGridViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dataGridViewFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnNum, Me.ColumnFileDest, Me.ColumnIn, Me.ColumnOut, Me.ColumnLoc})
        Me.dataGridViewFiles.Location = New System.Drawing.Point(7, 7)
        Me.dataGridViewFiles.MultiSelect = False
        Me.dataGridViewFiles.Name = "dataGridViewFiles"
        Me.dataGridViewFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dataGridViewFiles.RowHeadersWidth = 21
        Me.dataGridViewFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dataGridViewFiles.RowTemplate.Height = 24
        Me.dataGridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridViewFiles.Size = New System.Drawing.Size(403, 213)
        Me.dataGridViewFiles.TabIndex = 168
        '
        'ColumnNum
        '
        Me.ColumnNum.FillWeight = 20.0!
        Me.ColumnNum.HeaderText = "#"
        Me.ColumnNum.Name = "ColumnNum"
        Me.ColumnNum.ReadOnly = True
        Me.ColumnNum.Width = 20
        '
        'ColumnFileDest
        '
        Me.ColumnFileDest.FillWeight = 80.0!
        Me.ColumnFileDest.HeaderText = "File"
        Me.ColumnFileDest.Name = "ColumnFileDest"
        Me.ColumnFileDest.ReadOnly = True
        Me.ColumnFileDest.Width = 280
        '
        'ColumnIn
        '
        Me.ColumnIn.HeaderText = "In"
        Me.ColumnIn.Name = "ColumnIn"
        Me.ColumnIn.Width = 50
        '
        'ColumnOut
        '
        Me.ColumnOut.HeaderText = "Out"
        Me.ColumnOut.Name = "ColumnOut"
        Me.ColumnOut.Width = 50
        '
        'ColumnLoc
        '
        Me.ColumnLoc.HeaderText = "Props"
        Me.ColumnLoc.Name = "ColumnLoc"
        Me.ColumnLoc.Width = 200
        '
        'panelPreview
        '
        Me.panelPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.panelPreview.Location = New System.Drawing.Point(416, 86)
        Me.panelPreview.Name = "panelPreview"
        Me.panelPreview.Size = New System.Drawing.Size(560, 338)
        Me.panelPreview.TabIndex = 166
        '
        'labelStatus
        '
        Me.labelStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.labelStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelStatus.ForeColor = System.Drawing.Color.Black
        Me.labelStatus.Location = New System.Drawing.Point(416, 7)
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Padding = New System.Windows.Forms.Padding(5)
        Me.labelStatus.Size = New System.Drawing.Size(561, 76)
        Me.labelStatus.TabIndex = 167
        Me.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'buttonAddFile
        '
        Me.buttonAddFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonAddFile.Location = New System.Drawing.Point(10, 3)
        Me.buttonAddFile.Name = "buttonAddFile"
        Me.buttonAddFile.Size = New System.Drawing.Size(123, 21)
        Me.buttonAddFile.TabIndex = 165
        Me.buttonAddFile.Text = "Add file"
        Me.buttonAddFile.UseVisualStyleBackColor = True
        '
        'panel3
        '
        Me.panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.panel3.Controls.Add(Me.checkBox1)
        Me.panel3.Controls.Add(Me.buttonRemove)
        Me.panel3.Controls.Add(Me.comboBoxVF)
        Me.panel3.Controls.Add(Me.buttonAddLive)
        Me.panel3.Controls.Add(Me.buttonAddFile)
        Me.panel3.Controls.Add(Me.comboBoxAF)
        Me.panel3.Controls.Add(Me.label4)
        Me.panel3.Controls.Add(Me.label3)
        Me.panel3.Location = New System.Drawing.Point(7, 226)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(403, 81)
        Me.panel3.TabIndex = 173
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.Location = New System.Drawing.Point(147, 60)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(157, 17)
        Me.checkBox1.TabIndex = 177
        Me.checkBox1.Text = "Split playlist to separate files"
        Me.checkBox1.UseVisualStyleBackColor = True
        '
        'buttonRemove
        '
        Me.buttonRemove.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonRemove.Location = New System.Drawing.Point(10, 57)
        Me.buttonRemove.Name = "buttonRemove"
        Me.buttonRemove.Size = New System.Drawing.Size(123, 21)
        Me.buttonRemove.TabIndex = 167
        Me.buttonRemove.Text = "Remove"
        Me.buttonRemove.UseVisualStyleBackColor = True
        '
        'buttonAddLive
        '
        Me.buttonAddLive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonAddLive.Location = New System.Drawing.Point(10, 30)
        Me.buttonAddLive.Name = "buttonAddLive"
        Me.buttonAddLive.Size = New System.Drawing.Size(123, 21)
        Me.buttonAddLive.TabIndex = 166
        Me.buttonAddLive.Text = "Add live"
        Me.buttonAddLive.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(5, 430)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(32, 13)
        Me.label1.TabIndex = 178
        Me.label1.Text = "URL:"
        '
        'comboBoxURL
        '
        Me.comboBoxURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.comboBoxURL.Enabled = False
        Me.comboBoxURL.FormattingEnabled = True
        Me.comboBoxURL.Items.AddRange(New Object() {"rtmp://trial:demostream@free.flashwebtown.com/trial/m_stream", "http://localhost:8080", "c:\temp\test.wmv", "c:\temp\test.wmv | http://localhost:8080 | http://User:Stream123@free.streamwebto" & _
                "wn.com/testwmspnt"})
        Me.comboBoxURL.Location = New System.Drawing.Point(43, 426)
        Me.comboBoxURL.Name = "comboBoxURL"
        Me.comboBoxURL.Size = New System.Drawing.Size(368, 21)
        Me.comboBoxURL.TabIndex = 177
        Me.comboBoxURL.Text = "rtmp://trial:demostream@free.flashwebtown.com/trial/m_stream"
        '
        'columnProps
        '
        Me.columnProps.Tag = "b"
        Me.columnProps.Text = "Bitrate"
        '
        'comboBoxProps
        '
        Me.comboBoxProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.comboBoxProps.FormattingEnabled = True
        Me.comboBoxProps.Items.AddRange(New Object() {"audio::b=256K video::b=30M video::codec=mpeg4 gop_size=1 qmin=1 qscale=1 v422=tru" & _
                "e", "audio::b=128K video::b=10M video::codec=mjpeg qscale=1", "audio::b=256K video::b=60M video::codec=libopenjpeg"})
        Me.comboBoxProps.Location = New System.Drawing.Point(7, 399)
        Me.comboBoxProps.Name = "comboBoxProps"
        Me.comboBoxProps.Size = New System.Drawing.Size(404, 21)
        Me.comboBoxProps.TabIndex = 175
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.label2.Location = New System.Drawing.Point(207, 465)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(27, 13)
        Me.label2.TabIndex = 180
        Me.label2.Text = "sec."
        '
        'numericPause
        '
        Me.numericPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numericPause.DecimalPlaces = 2
        Me.numericPause.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numericPause.Location = New System.Drawing.Point(163, 461)
        Me.numericPause.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.numericPause.Name = "numericPause"
        Me.numericPause.Size = New System.Drawing.Size(44, 20)
        Me.numericPause.TabIndex = 179
        Me.numericPause.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'buttonSetMax
        '
        Me.buttonSetMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonSetMax.Location = New System.Drawing.Point(358, 470)
        Me.buttonSetMax.Name = "buttonSetMax"
        Me.buttonSetMax.Size = New System.Drawing.Size(53, 23)
        Me.buttonSetMax.TabIndex = 183
        Me.buttonSetMax.Text = "Set"
        Me.buttonSetMax.UseVisualStyleBackColor = True
        '
        'numericMaxDuration
        '
        Me.numericMaxDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numericMaxDuration.Location = New System.Drawing.Point(303, 472)
        Me.numericMaxDuration.Name = "numericMaxDuration"
        Me.numericMaxDuration.Size = New System.Drawing.Size(49, 20)
        Me.numericMaxDuration.TabIndex = 182
        '
        'label6
        '
        Me.label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.label6.Location = New System.Drawing.Point(304, 452)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(87, 13)
        Me.label6.TabIndex = 184
        Me.label6.Text = "Max file duration:"
        '
        'panel1
        '
        Me.panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.panel1.Location = New System.Drawing.Point(1, 395)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(414, 100)
        Me.panel1.TabIndex = 185
        '
        'mConfigList1
        '
        Me.mConfigList1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.mConfigList1.FullRowSelect = True
        Me.mConfigList1.GridLines = True
        Me.mConfigList1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.mConfigList1.Location = New System.Drawing.Point(7, 313)
        Me.mConfigList1.Name = "mConfigList1"
        Me.mConfigList1.Size = New System.Drawing.Size(403, 76)
        Me.mConfigList1.TabIndex = 186
        Me.mConfigList1.UseCompatibleStateImageBehavior = False
        Me.mConfigList1.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Bitrate"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(984, 497)
        Me.Controls.Add(Me.mConfigList1)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.buttonSetMax)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.numericPause)
        Me.Controls.Add(Me.numericMaxDuration)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.comboBoxURL)
        Me.Controls.Add(Me.comboBoxProps)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.dataGridViewFiles)
        Me.Controls.Add(Me.panelPreview)
        Me.Controls.Add(Me.labelStatus)
        Me.Controls.Add(Me.buttonStop)
        Me.Controls.Add(Me.buttonPause)
        Me.Controls.Add(Me.buttonPlay)
        Me.Controls.Add(Me.panel1)
        Me.MinimumSize = New System.Drawing.Size(1000, 535)
        Me.Name = "MainForm"
        Me.Text = "Capture Playlist Sample"
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.trackBarVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBarSeek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridViewFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        CType(Me.numericPause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericMaxDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

    Friend WithEvents timerStatus As System.Windows.Forms.Timer
    Friend WithEvents openMediaFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents trackBarSeek As System.Windows.Forms.TrackBar
    Friend WithEvents checkBoxVideo As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxAudio As System.Windows.Forms.CheckBox
    Friend WithEvents buttonPause As System.Windows.Forms.Button
    Friend WithEvents trackBarVolume As System.Windows.Forms.TrackBar
    Friend WithEvents buttonPlay As System.Windows.Forms.Button
    Friend WithEvents labelPos As System.Windows.Forms.Label
    Friend WithEvents buttonStop As System.Windows.Forms.Button
    Friend WithEvents dataGridViewFiles As System.Windows.Forms.DataGridView
    Friend WithEvents panelPreview As System.Windows.Forms.Panel
    Friend WithEvents labelStatus As System.Windows.Forms.Label
    Friend WithEvents buttonAddFile As System.Windows.Forms.Button
    Friend WithEvents panel3 As System.Windows.Forms.Panel
    Friend WithEvents buttonAddLive As System.Windows.Forms.Button
    Friend WithEvents buttonRemove As System.Windows.Forms.Button
    Friend WithEvents comboBoxAF As System.Windows.Forms.ComboBox
    Friend WithEvents comboBoxVF As System.Windows.Forms.ComboBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents ColumnNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnFileDest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnIn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buttonSetMax As System.Windows.Forms.Button
    Friend WithEvents numericMaxDuration As System.Windows.Forms.NumericUpDown
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents comboBoxURL As System.Windows.Forms.ComboBox
    '  Friend WithEvents MControls.MConfigList mConfigList1;
    Friend WithEvents columnProps As System.Windows.Forms.ColumnHeader
    Friend WithEvents comboBoxProps As System.Windows.Forms.ComboBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents numericPause As System.Windows.Forms.NumericUpDown
    Friend WithEvents buttonCG_Props As System.Windows.Forms.Button
    Friend WithEvents checkBoxCG As System.Windows.Forms.CheckBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents checkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents mConfigList1 As MControls.MConfigList
    Friend WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
End Class

