Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports MPLATFORMLib

Public Partial Class MainForm
	Inherits Form
	Private m_objPlaylist As MPlaylistClass
	Private m_objWriter As MWriterClass
	Private m_nStartVideoFormat As Integer
	Private m_nStartAudioFormat As Integer


	Public Sub New()
		InitializeComponent()
	End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text += " - MPlatform SDK " & CheckVersionClass.GetVersion()
        Catch
        End Try

        Try
            m_objPlaylist = New MPlaylistClass()
            m_objWriter = New MWriterClass()
        Catch ex As Exception
            MessageBox.Show("Error creating MPlatform objects, please check tha libraries are registered correctly: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Application.[Exit]()
            Return
        End Try
        Dim myBack As MItem
        mConfigList1.SetControlledObject(m_objWriter)
        AddHandler mConfigList1.OnConfigChanged, AddressOf mConfigList1_OnConfigChanged
        mConfigList1_OnConfigChanged(Nothing, Nothing)
        AddHandler m_objPlaylist.OnEventSafe, AddressOf m_objFile_OnEventSafe
        m_objPlaylist.PreviewWindowSet("", panelPreview.Handle.ToInt32())
        m_objPlaylist.PreviewEnable("", If(checkBoxAudio.Checked, 1, 0), If(checkBoxVideo.Checked, 1, 0))

        m_objPlaylist.ObjectStart(New Object())
        m_objPlaylist.PlaylistBackgroundSet(Nothing, "", "", myBack)

        If myBack IsNot Nothing Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myBack)
            GC.Collect()
        End If

        m_objPlaylist.PropsSet("loop", "false")
        m_objPlaylist.PropsSet("active_frc", "false")
        m_objPlaylist.PropsSet("preview.drop_frames", "true")
        FillVideoFormats()
        FillAudioFormats()
        comboBoxVF.SelectedIndex = m_nStartVideoFormat
        comboBoxAF.SelectedIndex = m_nStartAudioFormat
        m_objWriter.PropsSet("rate_control", "true")
        m_objWriter.PropsSet("pull_mode", "false")
    End Sub

	Private Sub mConfigList1_OnConfigChanged(sender As Object, e As EventArgs)
		Dim strConfig As String
		m_objWriter.ConfigGetAll(1, strConfig)
		comboBoxProps.Text = strConfig
		Dim strFormat As String
		Dim pFormatConfig As IMAttributes
		m_objWriter.ConfigGet("format", strFormat, pFormatConfig)
		Dim bNetwork As Integer = 0
		Try
			pFormatConfig.AttributesBoolGet("network", bNetwork)
		Catch
		End Try
		comboBoxURL.Enabled = (bNetwork <> 0)
	End Sub

	Private Sub m_objFile_OnEventSafe(bsChannelID As String, bsEventName As String, bsEventParam As String, pEventObject As Object)
		If bsEventName <> "EOL" Then
			Return
		End If
		Try
			checkBox1.Enabled = True
			m_objWriter.ObjectClose()
			buttonPlay.Text = "Start Play and Capture"
		Catch
		End Try
	End Sub

	Private Sub FillVideoFormats()
		Dim nCount As Integer
		Dim nIndex As Integer
		Dim strFormat As String
		Dim vidProps As M_VID_PROPS
		comboBoxVF.Items.Clear()
		m_objPlaylist.FormatVideoGetCount(eMFormatType.eMFT_Convert, nCount)
		comboBoxVF.Enabled = nCount > 0
		If nCount <= 0 Then
			Return
		End If
		For i As Integer = 0 To nCount - 1
			m_objPlaylist.FormatVideoGetByIndex(eMFormatType.eMFT_Convert, i, vidProps, strFormat)
			If vidProps.eVideoFormat = eMVideoFormat.eMVF_HD1080_5994i Then
				m_nStartVideoFormat = i
			End If

			comboBoxVF.Items.Add(strFormat)
		Next
		m_objPlaylist.FormatVideoGet(eMFormatType.eMFT_Convert, vidProps, nIndex, strFormat)
		comboBoxVF.SelectedIndex = If(nIndex > 0, nIndex, 0)
	End Sub

	Private Sub FillAudioFormats()
		Dim nCount As Integer
		comboBoxAF.Items.Clear()
		m_objPlaylist.FormatAudioGetCount(eMFormatType.eMFT_Convert, nCount)
		comboBoxAF.Enabled = nCount > 0
		If nCount <= 0 Then
			Return
		End If
		Dim audProps As M_AUD_PROPS
		Dim strFormat As String
		For i As Integer = 0 To nCount - 1
			m_objPlaylist.FormatAudioGetByIndex(eMFormatType.eMFT_Convert, i, audProps, strFormat)
			If audProps.nBitsPerSample = 16 AndAlso audProps.nChannels = 16 AndAlso audProps.nSamplesPerSec = 48000 Then
				m_nStartAudioFormat = i
			End If

			comboBoxAF.Items.Add(strFormat)
		Next
		Dim nIndex As Integer
		m_objPlaylist.FormatAudioGet(eMFormatType.eMFT_Convert, audProps, nIndex, strFormat)
		comboBoxAF.SelectedIndex = If(nIndex > 0, nIndex, 0)
	End Sub

    Private Sub buttonAdd_Click(sender As Object, e As EventArgs) Handles buttonAddFile.Click
        If openMediaFile.ShowDialog() = DialogResult.OK AndAlso openMediaFile.FileNames.Length <> 0 Then
            For i As Integer = 0 To openMediaFile.FileNames.Length - 1
                Dim nIndex As Integer = -1
                Dim pFile As MItem
                m_objPlaylist.PlaylistAdd(Nothing, openMediaFile.FileNames(i), "external_process=false experimental.mfcodecs=true experimental.out_video_packets=true", nIndex, pFile)

                If pFile Is Nothing Then
                    Continue For
                End If
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFile)
                GC.Collect()
            Next
            UpdateList()
        End If
    End Sub

    Private Sub buttonAddLive_Click(sender As Object, e As EventArgs) Handles buttonAddLive.Click
        Dim nIndex As Integer = -1
        Dim pFile As MItem
        m_objPlaylist.PlaylistAdd(Nothing, "my_live", "live", nIndex, pFile)

        If pFile IsNot Nothing Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFile)
            GC.Collect()
        End If
        UpdateList()
    End Sub

	Private Sub UpdateList()
		RemoveHandler dataGridViewFiles.RowsRemoved, AddressOf dataGridViewFiles_RowsRemoved
		dataGridViewFiles.Rows.Clear()
		AddHandler dataGridViewFiles.RowsRemoved, AddressOf dataGridViewFiles_RowsRemoved
		Dim nFiles As Integer
		Dim dblDuration As Double
		m_objPlaylist.PlaylistGetCount(nFiles, dblDuration)
		For i As Integer = 0 To nFiles - 1
			Dim strPathOrCommand As String
			Dim pItem As MItem
			Dim dblPos As Double
			m_objPlaylist.PlaylistGetByIndex(i, dblPos, strPathOrCommand, pItem)
			strPathOrCommand = strPathOrCommand.Substring(strPathOrCommand.LastIndexOf("\"C) + 1)
			Dim dblIn As Double
			Dim dblOut As Double
			Dim dblFileDuration As Double
			pItem.FileInOutGet(dblIn, dblOut, dblFileDuration)
			Dim strIn As String = [String].Format("{0:0.00}", dblIn)
			Dim strOut As String = [String].Format("{0:0.00}", dblOut)
			Dim nrow As Integer = dataGridViewFiles.Rows.Add(dataGridViewFiles.Rows.Count + 1, strPathOrCommand, strIn, strOut)
			dataGridViewFiles.Rows(nrow).Tag = pItem
		Next
	End Sub

    Private Sub buttonPlay_Click(sender As Object, e As EventArgs) Handles buttonPlay.Click
        If dataGridViewFiles.Rows.Count <= 0 OrElse dataGridViewFiles.SelectedRows.Count = 0 Then
            Return
        End If

        m_objPlaylist.PlaylistPosSet(0, 0, 0)
        Dim mvid As M_VID_PROPS
        Dim maud As M_AUD_PROPS
        Dim fmtind As Integer
        Dim fmtname As String
        m_objPlaylist.FormatVideoGet(eMFormatType.eMFT_Output, mvid, fmtind, fmtname)
        m_objPlaylist.FormatAudioGet(eMFormatType.eMFT_Output, maud, fmtind, fmtname)
        m_objPlaylist.FormatVideoSet(eMFormatType.eMFT_Convert, mvid)
        m_objPlaylist.FormatAudioSet(eMFormatType.eMFT_Convert, maud)
        Dim eState As eMState
        m_objWriter.PropsSet("external_process", "false")
        m_objWriter.ObjectStateGet(eState)
        If eState = eMState.eMS_Paused Then
            m_objWriter.ObjectStart(m_objPlaylist)
            checkBox1.Enabled = False
        End If
        If eState = eMState.eMS_Running Then
            m_objWriter.WriterNameSet("", "")
        Else

            Dim strCapturePathOrUrl As String
            Dim strFormat As String
            Dim pFormatConfig As IMAttributes
            m_objWriter.ConfigGet("format", strFormat, pFormatConfig)

            Dim bNetwork As Integer = 0
            Try
                pFormatConfig.AttributesBoolGet("network", bNetwork)
            Catch generatedExceptionName As Exception
            End Try

            If bNetwork = 0 OrElse comboBoxURL.Text = "" Then
                Dim fileOpen As New SaveFileDialog()
                Dim bHave As Integer
                Dim strExtensions As String
                pFormatConfig.AttributesHave("extensions", bHave, strExtensions)
                If strExtensions Is Nothing Then
                    fileOpen.Filter = "MPEG-4 Files (*.mp4)|*.mp4|" & "MOV Files (*.mov)|*.mov|" & "MXF Files (*.mxf)|*.mxf|" & "MPEG-2 Files (*.mpg)|*.mpg|" & "MPEG-2 TS Files (*.ts)|*.ts|" & "MKV Files (*.mkv)|*.mkv|" & "WebM Files (*.webm)|*.webm|" & "AVI Files (*.avi)|*.avi|" & "All Files (*.*)|*.*"
                Else
                    Dim arrExt As String() = strExtensions.Split(","c)
                    Dim strFilterExt As String = ""
                    For i As Integer = 0 To arrExt.Length - 1
                        If strFilterExt.Length > 0 Then
                            strFilterExt += ";*." & arrExt(i)
                        Else
                            strFilterExt = "*." & arrExt(i)
                        End If
                    Next

                    fileOpen.Filter = strFormat & " Files (" & strFilterExt & ")|" & strFilterExt & "|All Files (*.*)|*.*"
                End If

                If fileOpen.ShowDialog() <> DialogResult.OK Then
                    Return
                End If

                strCapturePathOrUrl = fileOpen.FileName
            Else
                strCapturePathOrUrl = comboBoxURL.Text
            End If
            Try
                m_objWriter.WriterNameSet(strCapturePathOrUrl, "format='mp4' video::codec='packets' audio::codec='audio_packets'")
                m_objWriter.ObjectStart(m_objPlaylist)
                checkBox1.Enabled = False
            Catch ex As Exception
                MessageBox.Show("Error start capture to '" & strCapturePathOrUrl & "' file." & vbCr & vbLf & "File Format: " & strFormat & vbCr & vbLf & vbCr & vbLf & ex.Message)
                Return
            End Try
        End If
        _mNFrame = 0
        m_objPlaylist.FilePlayStart()
    End Sub
	Private _mNFrame As Integer

    Private Sub dataGridViewFiles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewFiles.CellDoubleClick
        If dataGridViewFiles.RowCount > 0 Then
            Dim strPath As String
            Dim dblListPos As Double
            Dim pItem As MItem
            m_objPlaylist.PlaylistGetByIndex(dataGridViewFiles.SelectedRows(0).Index, dblListPos, strPath, pItem)
            Dim pType As eMItemType
            pItem.ItemTypeGet(pType)
            If pType = eMItemType.eMPIT_Live Then
                Dim pDev As IMDevice = TryCast(dataGridViewFiles.SelectedRows(0).Tag, IMDevice)
                Dim liveForm As New LiveForm(pDev)
                liveForm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub checkBoxVideo_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxVideo.CheckedChanged
        If m_objPlaylist IsNot Nothing Then
            m_objPlaylist.PreviewEnable("", If(checkBoxAudio.Checked, 1, 0), If(checkBoxVideo.Checked, 1, 0))
        End If
    End Sub

    Private Sub checkBoxAudio_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxAudio.CheckedChanged
        If m_objPlaylist IsNot Nothing Then
            m_objPlaylist.PreviewEnable("", If(checkBoxAudio.Checked, 1, 0), If(checkBoxVideo.Checked, 1, 0))
        End If
    End Sub

    Private Sub trackBar1_Scroll(sender As Object, e As EventArgs) Handles trackBarVolume.Scroll
        Dim dblPos As Double = CDbl(trackBarVolume.Value) / trackBarVolume.Maximum
        m_objPlaylist.PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos))
    End Sub

    Private Sub buttonPause_Click(sender As Object, e As EventArgs) Handles buttonPause.Click
        m_objWriter.WriterSkip(CDbl(numericPause.Value))
    End Sub

    Private Sub buttonStop_Click(sender As Object, e As EventArgs) Handles buttonStop.Click
        m_objWriter.ObjectClose()
        buttonPlay.Text = "Start Play and Capture"
        checkBox1.Enabled = True
        m_objPlaylist.FilePlayStop(0)
    End Sub

    Private Sub timerStatus_Tick(sender As Object, e As EventArgs) Handles timerStatus.Tick
        If m_objPlaylist IsNot Nothing Then
            Dim eState As eMState
            m_objPlaylist.ObjectStateGet(eState)
            Dim writerState As eMState
            m_objWriter.ObjectStateGet(writerState)
            Try
                Dim nCount As Integer
                Dim dblListLen As Double
                m_objPlaylist.PlaylistGetCount(nCount, dblListLen)

                If nCount > 0 Then
                    Dim nCurFile As Integer, nNextFile As Integer
                    Dim dblFilePos As Double, dblListPos As Double
                    m_objPlaylist.PlaylistPosGet(nCurFile, nNextFile, dblFilePos, dblListPos)

                    Dim strPath As String
                    Dim pItem As MItem
                    Dim dblListOffset As Double
                    nCurFile = If(nCurFile - 1 >= 0, nCurFile, 1)
                    m_objPlaylist.PlaylistGetByIndex(nCurFile - 1, dblListOffset, strPath, pItem)

                    Dim dblIn As Double, dblOut As Double, dblFileLen As Double
                    pItem.FileInOutGet(dblIn, dblOut, dblFileLen)
                    If dblOut > dblIn Then
                        dblFileLen = dblOut
                    End If

                    labelPos.Width = CInt(Math.Truncate((trackBarSeek.Width - 16) * dblListPos / dblListLen))
                    Dim strFile As String = strPath.Substring(strPath.LastIndexOf("\"c) + 1)

                    labelStatus.Text = "Writer state: " & Convert.ToString(writerState) & vbCr & vbLf & Dbl2PosStr(dblFilePos) & "/" & Dbl2PosStr(dblFileLen) & " " & Convert.ToString(eState) & " (" & (nCurFile + 1) & "/" & nCount & ") " & Dbl2PosStr(dblListPos) & "/" & Dbl2PosStr(dblListLen) & " " & vbCr & vbLf & strFile & vbCr & vbLf & strPath

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem)
                End If
                GC.Collect()
            Catch
                labelStatus.Text = eState.ToString()
                labelPos.Width = 0
                Throw
            End Try
        End If
    End Sub

    Private Sub trackBarSeek_Scroll(sender As Object, e As EventArgs) Handles trackBarSeek.Scroll
        Dim nCount As Integer
        Dim dblListLen As Double
        m_objPlaylist.PlaylistGetCount(nCount, dblListLen)
        If nCount <= 0 Then
            Return
        End If
        Dim dblIn As Double
        Dim dblOut As Double
        Dim dblDuration As Double
        m_objPlaylist.FileInOutGet(dblIn, dblOut, dblDuration)
        dblDuration = (If(dblOut > dblIn, dblOut, dblDuration)) - dblIn
        Dim dblPos As Double = dblIn + dblDuration * trackBarSeek.Value / trackBarSeek.Maximum
        m_objPlaylist.FilePosSet(dblPos, 0)
        Dim nIndex As Integer, nNextIndex As Integer
        Dim dblFileTime As Double, dblListTime As Double
        m_objPlaylist.PlaylistPosGet(nIndex, nNextIndex, dblFileTime, dblListTime)
        Try
            dataGridViewFiles.CurrentCell = dataGridViewFiles.Rows(nIndex).Cells(0)
        Catch
        End Try
    End Sub

	Private Function Dbl2PosStr(dblPos As Double) As String
		Dim nHour As Integer = CInt(Math.Truncate(dblPos)) \ 3600
		Dim nMinutes As Integer = (CInt(Math.Truncate(dblPos)) Mod 3600) \ 60
		Dim nSec As Integer = (CInt(Math.Truncate(dblPos)) Mod 60)
		dblPos -= CInt(Math.Truncate(dblPos))
		Dim nMsec As Integer = CInt(Math.Truncate(dblPos * 1000 + 0.5))
		Dim strRes As String = nHour.ToString("00") & ":" & nMinutes.ToString("00") & ":" & nSec.ToString("00") & "." & nMsec.ToString("000")
		Return strRes
	End Function

    Private Sub dataGridViewFiles_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dataGridViewFiles.RowsRemoved
        m_objPlaylist.PlaylistRemoveByIndex(e.RowIndex, 0)
        UpdateList()
    End Sub

    Private Sub panelPreview_SizeChanged(sender As Object, e As EventArgs) Handles panelPreview.SizeChanged
        If m_objPlaylist IsNot Nothing Then
            Try
                m_objPlaylist.PreviewWindowSet("", panelPreview.Handle.ToInt32())
            Catch
            End Try
        End If
    End Sub

    Private Sub buttonRemove_Click(sender As Object, e As EventArgs) Handles buttonRemove.Click
        If dataGridViewFiles.SelectedRows.Count > 0 Then
            m_objPlaylist.PlaylistRemoveByIndex(dataGridViewFiles.SelectedRows(0).Index, 0)
            UpdateList()
        End If
    End Sub

    Private Sub dataGridViewFiles_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewFiles.CellValueChanged
        If dataGridViewFiles.SelectedRows.Count > 0 Then
            For i As Integer = 0 To dataGridViewFiles.SelectedRows(0).Cells.Count - 1
                If dataGridViewFiles.SelectedRows(0).Cells(i).Value Is Nothing Then
                    dataGridViewFiles.SelectedRows(0).Cells(i).Value = String.Empty

                End If
            Next
            If e.ColumnIndex = 2 OrElse e.ColumnIndex = 3 Then
                Dim pItem As IMItem = TryCast(dataGridViewFiles.SelectedRows(0).Tag, IMItem)
                Dim dblIn As Double
                Dim dblOut As Double
                Dim bValidIn As Boolean = Double.TryParse(dataGridViewFiles.SelectedRows(0).Cells(2).Value.ToString(), dblIn)
                Dim bValidOut As Boolean = Double.TryParse(dataGridViewFiles.SelectedRows(0).Cells(3).Value.ToString(), dblOut)
                If bValidIn AndAlso bValidOut Then
                    If pItem IsNot Nothing Then
                        pItem.FileInOutSet(dblIn, dblOut)
                    End If
                End If
                UpdateList()
            End If
        End If
    End Sub

    Private Sub comboBoxVF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxVF.SelectedIndexChanged
        Dim vidProps As M_VID_PROPS
        Dim strFormat As String
        m_objPlaylist.FormatVideoGetByIndex(eMFormatType.eMFT_Convert, comboBoxVF.SelectedIndex, vidProps, strFormat)
        'Set new video format
        m_objPlaylist.FormatVideoSet(eMFormatType.eMFT_Convert, vidProps)
    End Sub

    Private Sub comboBoxAF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxAF.SelectedIndexChanged
        Dim audProps As M_AUD_PROPS
        Dim strFormat As String
        m_objPlaylist.FormatAudioGetByIndex(eMFormatType.eMFT_Convert, comboBoxAF.SelectedIndex, audProps, strFormat)
        m_objPlaylist.FormatAudioSet(eMFormatType.eMFT_Convert, audProps)
    End Sub

    Private Sub buttonSetMax_Click(sender As Object, e As EventArgs) Handles buttonSetMax.Click
        m_objWriter.PropsSet("max_duration", numericMaxDuration.Value.ToString(CultureInfo.InvariantCulture))
    End Sub
	Private _mStrItemId As String
	Public MObjCharGen As MLCHARGENLib.CoMLCharGen
    Private Sub checkBoxCG_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxCG.CheckedChanged
        If checkBoxCG.Checked Then
            MObjCharGen = New MLCHARGENLib.CoMLCharGen()
            m_objPlaylist.PluginsAdd(MObjCharGen, 0)
            MObjCharGen.AddNewItem("<text size=2.0>Crawling String (for control smoothness of playback)</text>", 0.1, 0.1, 1, 1, _mStrItemId)
            MObjCharGen.SetItemProperties(_mStrItemId, "movement::speed-x", "-2", "", 0)
            MObjCharGen.ShowItem(_mStrItemId, 1, 1000)
            Dim strId As String = ""
            MObjCharGen.AddNewItem("<text type=counter size=4.0>XXXXXX</text>", 0.1, 0.2, 1, 1, strId)
        Else
            MObjCharGen.RemoveItem(_mStrItemId, 1000)
            _mStrItemId = ""
            m_objPlaylist.PluginsRemove(MObjCharGen)
            MObjCharGen = Nothing
        End If
    End Sub

    Private Sub buttonCG_Props_Click(sender As Object, e As EventArgs) Handles buttonCG_Props.Click
        If MObjCharGen Is Nothing Then
            MObjCharGen = New MLCHARGENLib.CoMLCharGen()
            m_objPlaylist.PluginsAdd(MObjCharGen, 0)
        End If

        MObjCharGen.ShowPropertiesPage(Handle.ToInt32())
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If m_objWriter IsNot Nothing Then
            m_objWriter.ObjectClose()
        End If
        If m_objPlaylist IsNot Nothing Then
            m_objPlaylist.ObjectClose()
        End If
    End Sub

    Private Sub checkBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckedChanged
        If checkBox1.Checked Then
            m_objWriter.PropsSet("writer.buffers", "0")
            m_objWriter.PropsSet("events.use_window", "false")
            m_objWriter.PropsSet("on_frame.sync", "true")
            AddHandler m_objWriter.OnFrameSafe, AddressOf m_objWriter_OnFrameSafe
        Else
            m_objWriter.PropsSet("writer.buffers", "30")
            m_objWriter.PropsSet("events.use_window", "false")
            m_objWriter.PropsSet("on_frame.sync", "false")
            RemoveHandler m_objWriter.OnFrameSafe, AddressOf m_objWriter_OnFrameSafe
        End If
    End Sub
	Private Sub m_objWriter_OnFrameSafe(bsChannelID As String, pMFrame As Object)
		Dim mTime As M_TIME
		DirectCast(pMFrame, IMFrame).FrameTimeGet(mTime)

		mTime.eFFlags = CType(CInt(mTime.eFFlags) And &Hf, eMFrameFlags)

		If mTime.eFFlags = eMFrameFlags.eMFF_Break AndAlso _mNFrame > 0 Then
			m_objWriter.WriterNameSet("", "")
			_mNFrame = 0
		Else
			_mNFrame += 1
		End If

		Marshal.ReleaseComObject(pMFrame)
	End Sub
End Class
