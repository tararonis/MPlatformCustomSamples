Partial Class LiveForm
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
		Me.panelPreview = New System.Windows.Forms.Panel()
		Me.timerStatus = New System.Windows.Forms.Timer(Me.components)
		Me.panel2 = New System.Windows.Forms.Panel()
		Me.checkBoxVideo = New System.Windows.Forms.CheckBox()
		Me.checkBoxAudio = New System.Windows.Forms.CheckBox()
		Me.trackBarVolume = New System.Windows.Forms.TrackBar()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.label10 = New System.Windows.Forms.Label()
		Me.comboBoxVFOut = New System.Windows.Forms.ComboBox()
		Me.label9 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.buttonAF = New System.Windows.Forms.Button()
		Me.buttonA = New System.Windows.Forms.Button()
		Me.buttonVF = New System.Windows.Forms.Button()
		Me.buttonV = New System.Windows.Forms.Button()
		Me.buttonClose = New System.Windows.Forms.Button()
		Me.buttonInit = New System.Windows.Forms.Button()
		Me.comboBoxAF = New System.Windows.Forms.ComboBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.comboBoxAL = New System.Windows.Forms.ComboBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.comboBoxExtAudio = New System.Windows.Forms.ComboBox()
		Me.label11 = New System.Windows.Forms.Label()
		Me.comboBoxAudio = New System.Windows.Forms.ComboBox()
		Me.label6 = New System.Windows.Forms.Label()
		Me.comboBoxVF = New System.Windows.Forms.ComboBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.comboBoxVL = New System.Windows.Forms.ComboBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.comboBoxVideo = New System.Windows.Forms.ComboBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.buttonNDIRefresh = New System.Windows.Forms.Button()
		Me.panel2.SuspendLayout()
		DirectCast(Me.trackBarVolume, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panel1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' panelPreview
		' 
		Me.panelPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panelPreview.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(0)), CInt(CByte(88)), CInt(CByte(143)))
		Me.panelPreview.Location = New System.Drawing.Point(376, 11)
		Me.panelPreview.Name = "panelPreview"
		Me.panelPreview.Size = New System.Drawing.Size(640, 360)
		Me.panelPreview.TabIndex = 125
		AddHandler Me.panelPreview.Resize, New System.EventHandler(AddressOf Me.panelPreview_Resize)
		' 
		' timerStatus
		' 
		Me.timerStatus.Enabled = True
		Me.timerStatus.Interval = 33
		AddHandler Me.timerStatus.Tick, New System.EventHandler(AddressOf Me.timerStatus_Tick)
		' 
		' panel2
		' 
		Me.panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.panel2.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(222)), CInt(CByte(232)), CInt(CByte(254)))
		Me.panel2.Controls.Add(Me.checkBoxVideo)
		Me.panel2.Controls.Add(Me.checkBoxAudio)
		Me.panel2.Controls.Add(Me.trackBarVolume)
		Me.panel2.Location = New System.Drawing.Point(376, 377)
		Me.panel2.Name = "panel2"
		Me.panel2.Size = New System.Drawing.Size(640, 36)
		Me.panel2.TabIndex = 176
		' 
		' checkBoxVideo
		' 
		Me.checkBoxVideo.AutoSize = True
		Me.checkBoxVideo.Checked = True
		Me.checkBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxVideo.Location = New System.Drawing.Point(8, 9)
		Me.checkBoxVideo.Name = "checkBoxVideo"
		Me.checkBoxVideo.Size = New System.Drawing.Size(94, 17)
		Me.checkBoxVideo.TabIndex = 126
		Me.checkBoxVideo.Text = "Video Preview"
		Me.checkBoxVideo.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxVideo.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxVideo_CheckedChanged)
		' 
		' checkBoxAudio
		' 
		Me.checkBoxAudio.AutoSize = True
		Me.checkBoxAudio.Location = New System.Drawing.Point(110, 10)
		Me.checkBoxAudio.Name = "checkBoxAudio"
		Me.checkBoxAudio.Size = New System.Drawing.Size(94, 17)
		Me.checkBoxAudio.TabIndex = 127
		Me.checkBoxAudio.Text = "Audio Preview"
		Me.checkBoxAudio.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxAudio.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxAudio_CheckedChanged)
		' 
		' trackBarVolume
		' 
		Me.trackBarVolume.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.trackBarVolume.AutoSize = False
		Me.trackBarVolume.LargeChange = 10
		Me.trackBarVolume.Location = New System.Drawing.Point(207, 9)
		Me.trackBarVolume.Maximum = 100
		Me.trackBarVolume.Name = "trackBarVolume"
		Me.trackBarVolume.Size = New System.Drawing.Size(429, 17)
		Me.trackBarVolume.TabIndex = 148
		Me.trackBarVolume.TickFrequency = 10
		Me.trackBarVolume.Value = 50
		AddHandler Me.trackBarVolume.Scroll, New System.EventHandler(AddressOf Me.trackBar1_Scroll)
		' 
		' panel1
		' 
		Me.panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.panel1.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(222)), CInt(CByte(232)), CInt(CByte(254)))
		Me.panel1.Controls.Add(Me.buttonNDIRefresh)
		Me.panel1.Controls.Add(Me.label10)
		Me.panel1.Controls.Add(Me.comboBoxVFOut)
		Me.panel1.Controls.Add(Me.label9)
		Me.panel1.Controls.Add(Me.label8)
		Me.panel1.Controls.Add(Me.label7)
		Me.panel1.Controls.Add(Me.buttonAF)
		Me.panel1.Controls.Add(Me.buttonA)
		Me.panel1.Controls.Add(Me.buttonVF)
		Me.panel1.Controls.Add(Me.buttonV)
		Me.panel1.Controls.Add(Me.buttonClose)
		Me.panel1.Controls.Add(Me.buttonInit)
		Me.panel1.Controls.Add(Me.comboBoxAF)
		Me.panel1.Controls.Add(Me.label4)
		Me.panel1.Controls.Add(Me.comboBoxAL)
		Me.panel1.Controls.Add(Me.label5)
		Me.panel1.Controls.Add(Me.comboBoxExtAudio)
		Me.panel1.Controls.Add(Me.label11)
		Me.panel1.Controls.Add(Me.comboBoxAudio)
		Me.panel1.Controls.Add(Me.label6)
		Me.panel1.Controls.Add(Me.comboBoxVF)
		Me.panel1.Controls.Add(Me.label3)
		Me.panel1.Controls.Add(Me.comboBoxVL)
		Me.panel1.Controls.Add(Me.label2)
		Me.panel1.Controls.Add(Me.comboBoxVideo)
		Me.panel1.Controls.Add(Me.label1)
		Me.panel1.Location = New System.Drawing.Point(10, 11)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(361, 403)
		Me.panel1.TabIndex = 177
		' 
		' label10
		' 
		Me.label10.AutoSize = True
		Me.label10.Location = New System.Drawing.Point(7, 289)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(60, 13)
		Me.label10.TabIndex = 201
		Me.label10.Text = "Conversion"
		' 
		' comboBoxVFOut
		' 
		Me.comboBoxVFOut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.comboBoxVFOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxVFOut.DropDownWidth = 300
		Me.comboBoxVFOut.FormattingEnabled = True
		Me.comboBoxVFOut.Location = New System.Drawing.Point(112, 313)
		Me.comboBoxVFOut.Name = "comboBoxVFOut"
		Me.comboBoxVFOut.Size = New System.Drawing.Size(239, 21)
		Me.comboBoxVFOut.TabIndex = 200
		AddHandler Me.comboBoxVFOut.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxVFOut_SelectedIndexChanged)
		' 
		' label9
		' 
		Me.label9.AutoSize = True
		Me.label9.Location = New System.Drawing.Point(7, 316)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(103, 13)
		Me.label9.TabIndex = 199
		Me.label9.Text = "Output video format:"
		' 
		' label8
		' 
		Me.label8.AutoSize = True
		Me.label8.Location = New System.Drawing.Point(7, 147)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(69, 13)
		Me.label8.TabIndex = 193
		Me.label8.Text = "Audio device"
		' 
		' label7
		' 
		Me.label7.AutoSize = True
		Me.label7.Location = New System.Drawing.Point(7, 17)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(69, 13)
		Me.label7.TabIndex = 192
		Me.label7.Text = "Video device"
		' 
		' buttonAF
		' 
		Me.buttonAF.Location = New System.Drawing.Point(276, 249)
		Me.buttonAF.Name = "buttonAF"
		Me.buttonAF.Size = New System.Drawing.Size(75, 23)
		Me.buttonAF.TabIndex = 191
		Me.buttonAF.Text = "Props"
		Me.buttonAF.UseVisualStyleBackColor = True
		AddHandler Me.buttonAF.Click, New System.EventHandler(AddressOf Me.buttonAF_Click)
		' 
		' buttonA
		' 
		Me.buttonA.Location = New System.Drawing.Point(276, 170)
		Me.buttonA.Name = "buttonA"
		Me.buttonA.Size = New System.Drawing.Size(75, 23)
		Me.buttonA.TabIndex = 190
		Me.buttonA.Text = "Props"
		Me.buttonA.UseVisualStyleBackColor = True
		AddHandler Me.buttonA.Click, New System.EventHandler(AddressOf Me.buttonA_Click)
		' 
		' buttonVF
		' 
		Me.buttonVF.Location = New System.Drawing.Point(276, 100)
		Me.buttonVF.Name = "buttonVF"
		Me.buttonVF.Size = New System.Drawing.Size(75, 23)
		Me.buttonVF.TabIndex = 189
		Me.buttonVF.Text = "Props"
		Me.buttonVF.UseVisualStyleBackColor = True
		AddHandler Me.buttonVF.Click, New System.EventHandler(AddressOf Me.buttonVF_Click)
		' 
		' buttonV
		' 
		Me.buttonV.Location = New System.Drawing.Point(276, 40)
		Me.buttonV.Name = "buttonV"
		Me.buttonV.Size = New System.Drawing.Size(75, 23)
		Me.buttonV.TabIndex = 188
		Me.buttonV.Text = "Props"
		Me.buttonV.UseVisualStyleBackColor = True
		AddHandler Me.buttonV.Click, New System.EventHandler(AddressOf Me.buttonV_Click)
		' 
		' buttonClose
		' 
		Me.buttonClose.Location = New System.Drawing.Point(187, 356)
		Me.buttonClose.Name = "buttonClose"
		Me.buttonClose.Size = New System.Drawing.Size(164, 35)
		Me.buttonClose.TabIndex = 187
		Me.buttonClose.Text = "Close Device"
		Me.buttonClose.UseVisualStyleBackColor = True
		AddHandler Me.buttonClose.Click, New System.EventHandler(AddressOf Me.buttonClose_Click)
		' 
		' buttonInit
		' 
		Me.buttonInit.Location = New System.Drawing.Point(10, 356)
		Me.buttonInit.Name = "buttonInit"
		Me.buttonInit.Size = New System.Drawing.Size(164, 35)
		Me.buttonInit.TabIndex = 186
		Me.buttonInit.Text = "Init Device"
		Me.buttonInit.UseVisualStyleBackColor = True
		AddHandler Me.buttonInit.Click, New System.EventHandler(AddressOf Me.buttonInit_Click)
		' 
		' comboBoxAF
		' 
		Me.comboBoxAF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxAF.FormattingEnabled = True
		Me.comboBoxAF.Location = New System.Drawing.Point(50, 250)
		Me.comboBoxAF.Name = "comboBoxAF"
		Me.comboBoxAF.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxAF.TabIndex = 185
		AddHandler Me.comboBoxAF.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAVF_SelectedIndexChanged)
		' 
		' label4
		' 
		Me.label4.AutoSize = True
		Me.label4.Location = New System.Drawing.Point(7, 254)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(42, 13)
		Me.label4.TabIndex = 184
		Me.label4.Text = "Format:"
		' 
		' comboBoxAL
		' 
		Me.comboBoxAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxAL.FormattingEnabled = True
		Me.comboBoxAL.Location = New System.Drawing.Point(50, 221)
		Me.comboBoxAL.Name = "comboBoxAL"
		Me.comboBoxAL.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxAL.TabIndex = 183
		AddHandler Me.comboBoxAL.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAV_SelectedIndexChanged)
		' 
		' label5
		' 
		Me.label5.AutoSize = True
		Me.label5.Location = New System.Drawing.Point(7, 225)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(30, 13)
		Me.label5.TabIndex = 182
		Me.label5.Text = "Line:"
		' 
		' comboBoxExtAudio
		' 
		Me.comboBoxExtAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxExtAudio.FormattingEnabled = True
		Me.comboBoxExtAudio.Location = New System.Drawing.Point(50, 196)
		Me.comboBoxExtAudio.Name = "comboBoxExtAudio"
		Me.comboBoxExtAudio.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxExtAudio.TabIndex = 181
		AddHandler Me.comboBoxExtAudio.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAV_SelectedIndexChanged)
		' 
		' label11
		' 
		Me.label11.AutoSize = True
		Me.label11.Location = New System.Drawing.Point(7, 200)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(45, 13)
		Me.label11.TabIndex = 180
		Me.label11.Text = "Exernal:"
		' 
		' comboBoxAudio
		' 
		Me.comboBoxAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxAudio.FormattingEnabled = True
		Me.comboBoxAudio.Location = New System.Drawing.Point(50, 171)
		Me.comboBoxAudio.Name = "comboBoxAudio"
		Me.comboBoxAudio.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxAudio.TabIndex = 181
		AddHandler Me.comboBoxAudio.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAV_SelectedIndexChanged)
		' 
		' label6
		' 
		Me.label6.AutoSize = True
		Me.label6.Location = New System.Drawing.Point(7, 175)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(37, 13)
		Me.label6.TabIndex = 180
		Me.label6.Text = "Audio:"
		' 
		' comboBoxVF
		' 
		Me.comboBoxVF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxVF.FormattingEnabled = True
		Me.comboBoxVF.Location = New System.Drawing.Point(50, 101)
		Me.comboBoxVF.Name = "comboBoxVF"
		Me.comboBoxVF.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxVF.TabIndex = 179
		AddHandler Me.comboBoxVF.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAVF_SelectedIndexChanged)
		' 
		' label3
		' 
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(7, 105)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(42, 13)
		Me.label3.TabIndex = 178
		Me.label3.Text = "Format:"
		' 
		' comboBoxVL
		' 
		Me.comboBoxVL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxVL.FormattingEnabled = True
		Me.comboBoxVL.Location = New System.Drawing.Point(50, 71)
		Me.comboBoxVL.Name = "comboBoxVL"
		Me.comboBoxVL.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxVL.TabIndex = 177
		AddHandler Me.comboBoxVL.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAV_SelectedIndexChanged)
		' 
		' label2
		' 
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(7, 75)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(30, 13)
		Me.label2.TabIndex = 176
		Me.label2.Text = "Line:"
		' 
		' comboBoxVideo
		' 
		Me.comboBoxVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBoxVideo.FormattingEnabled = True
		Me.comboBoxVideo.Location = New System.Drawing.Point(50, 41)
		Me.comboBoxVideo.Name = "comboBoxVideo"
		Me.comboBoxVideo.Size = New System.Drawing.Size(220, 21)
		Me.comboBoxVideo.TabIndex = 175
		AddHandler Me.comboBoxVideo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.comboBoxAV_SelectedIndexChanged)
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(7, 45)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(37, 13)
		Me.label1.TabIndex = 174
		Me.label1.Text = "Video:"
		' 
		' buttonNDIRefresh
		' 
		Me.buttonNDIRefresh.Location = New System.Drawing.Point(276, 69)
		Me.buttonNDIRefresh.Name = "buttonNDIRefresh"
		Me.buttonNDIRefresh.Size = New System.Drawing.Size(23, 23)
		Me.buttonNDIRefresh.TabIndex = 202
		Me.buttonNDIRefresh.Text = "R"
		Me.buttonNDIRefresh.UseVisualStyleBackColor = True
		AddHandler Me.buttonNDIRefresh.Click, New System.EventHandler(AddressOf Me.buttonNDIRefresh_Click)
		' 
		' LiveForm
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(1023, 422)
		Me.Controls.Add(Me.panel1)
		Me.Controls.Add(Me.panel2)
		Me.Controls.Add(Me.panelPreview)
		Me.Name = "LiveForm"
		Me.Text = "Configure live source"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.LiveForm_FormClosed)
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.FormLive_Load)
		Me.panel2.ResumeLayout(False)
		Me.panel2.PerformLayout()
		DirectCast(Me.trackBarVolume, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panel1.ResumeLayout(False)
		Me.panel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private panelPreview As System.Windows.Forms.Panel
	Private timerStatus As System.Windows.Forms.Timer
	Private panel2 As System.Windows.Forms.Panel
	Private checkBoxVideo As System.Windows.Forms.CheckBox
	Private checkBoxAudio As System.Windows.Forms.CheckBox
	Private trackBarVolume As System.Windows.Forms.TrackBar
	Private panel1 As System.Windows.Forms.Panel
	Private label7 As System.Windows.Forms.Label
	Private buttonAF As System.Windows.Forms.Button
	Private buttonA As System.Windows.Forms.Button
	Private buttonVF As System.Windows.Forms.Button
	Private buttonV As System.Windows.Forms.Button
	Private buttonClose As System.Windows.Forms.Button
	Private buttonInit As System.Windows.Forms.Button
	Private comboBoxAF As System.Windows.Forms.ComboBox
	Private label4 As System.Windows.Forms.Label
	Private comboBoxAL As System.Windows.Forms.ComboBox
	Private label5 As System.Windows.Forms.Label
	Private comboBoxAudio As System.Windows.Forms.ComboBox
	Private label6 As System.Windows.Forms.Label
	Private comboBoxVF As System.Windows.Forms.ComboBox
	Private label3 As System.Windows.Forms.Label
	Private comboBoxVL As System.Windows.Forms.ComboBox
	Private label2 As System.Windows.Forms.Label
	Private comboBoxVideo As System.Windows.Forms.ComboBox
	Private label1 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private comboBoxVFOut As System.Windows.Forms.ComboBox
	Private label9 As System.Windows.Forms.Label
	Private comboBoxExtAudio As System.Windows.Forms.ComboBox
	Private label11 As System.Windows.Forms.Label
	Private buttonNDIRefresh As System.Windows.Forms.Button
End Class

