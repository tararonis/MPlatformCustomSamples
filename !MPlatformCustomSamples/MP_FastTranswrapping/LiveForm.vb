Imports System.Threading
Imports System.Windows.Forms
Imports MPLATFORMLib

Public Partial Class LiveForm
	Inherits Form
	Private m_objLive As IMDevice
	'Live source class. Intednded for receiving data from capture cards, cams and other devices
	Public Sub New()
		InitializeComponent()
	End Sub

	Public Sub New(pDevice As IMDevice)
		CheckForIllegalCrossThreadCalls = False

		Try
			InitializeComponent()
			m_objLive = DirectCast(pDevice, IMDevice)

			'Fill Video Device List
			FillCombo("video", comboBoxVideo)

			FillCombo("ext_audio", comboBoxExtAudio)

			'Initialize preview
			DirectCast(m_objLive, IMPreview).PreviewEnable("", 0, 0)
			DirectCast(m_objLive, IMPreview).PreviewWindowSet("", panelPreview.Handle.ToInt32())
			DirectCast(m_objLive, IMPreview).PreviewEnable("", If(checkBoxAudio.Checked, 1, 0), If(checkBoxVideo.Checked, 1, 0))

			'Fill output formats
			FillOutputVideoFormats()
		Catch ex As Exception
			MessageBox.Show("Live source object isn't valid: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
			Close()

		End Try
	End Sub

	''' <summary>
	''' Initialization of Medialooks objects and form controls
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub FormLive_Load(sender As Object, e As EventArgs)

	End Sub

	''' <summary>
	''' Fill video output formats list
	''' </summary>
	Private Sub FillOutputVideoFormats()
		comboBoxVFOut.Items.Clear()
		comboBoxVFOut.Items.Add("<Auto>")
		comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_NTSC)
		comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_PAL)
		comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_HD720_50p)
		comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_HD1080_50p)
		comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_HD1080_50i)
		comboBoxVFOut.SelectedIndex = 0
	End Sub

	''' <summary>
	''' Fill combo boxes (Audio/Video device and Audio/Video input line (if avilable))
	''' </summary>
	''' <param name="pDevice"></param>
	''' <param name="strType"></param>
	''' <param name="cbxType"></param>
	Private Sub FillCombo(strType As String, cbxType As ComboBox)
		SyncLock Me
			cbxType.Items.Clear()
			cbxType.Tag = strType
			Dim nCount As Integer = 0
			'Get device count / input line count
			m_objLive.DeviceGetCount(0, strType, nCount)
			cbxType.Enabled = nCount > 0
			If nCount > 0 Then
				For i As Integer = 0 To nCount - 1
					Dim strName As String
					Dim strDesc As String
					'Get deveice / input line
					m_objLive.DeviceGetByIndex(0, strType, i, strName, strDesc)
					cbxType.Items.Add(strName)
				Next
				Dim strCur As String = ""
				Dim strParam As String = ""
				Dim nIndex As Integer = 0
				Try
					'Check if there is already selected device / input line
					m_objLive.DeviceGet(strType, strCur, strParam, nIndex)
					If strCur <> "" Then
						cbxType.SelectedIndex = cbxType.FindStringExact(strCur)
					Else
						cbxType.SelectedIndex = 0
					End If
				Catch
					cbxType.SelectedIndex = 0
				End Try
			End If
		End SyncLock
	End Sub

	''' <summary>
	''' Fill combo boxes (Audio / Video format)
	''' </summary>
	''' <param name="pDevice"></param>
	''' <param name="strType"></param>
	''' <param name="cbxTarget"></param>
	Private Sub FillComboFomat(pDevice As IMDevice, strType As String, cbxTarget As ComboBox)
		If strType = "video" Then
			Dim nCount As Integer = 0
			Dim nIndex As Integer
			Dim strFormat As String
			Dim vidProps As M_VID_PROPS
			cbxTarget.Items.Clear()
			'Get video format count
			DirectCast(m_objLive, IMFormat).FormatVideoGetCount(eMFormatType.eMFT_Input, nCount)
			cbxTarget.Enabled = nCount > 0
			If nCount > 0 Then
				For i As Integer = 0 To nCount - 1
					'Get format by index
					DirectCast(m_objLive, IMFormat).FormatVideoGetByIndex(eMFormatType.eMFT_Input, i, vidProps, strFormat)
					'                        cbxTarget.Items.Add(vidProps.eVideoFormat);

					cbxTarget.Items.Add(strFormat)
				Next
				'Check if there is selected format
				DirectCast(m_objLive, IMFormat).FormatVideoGet(eMFormatType.eMFT_Input, vidProps, nIndex, strFormat)
				If nIndex > 0 Then
					cbxTarget.SelectedIndex = nIndex
				Else
					cbxTarget.SelectedIndex = 0
				End If

			End If
		ElseIf strType = "audio" Then
			Dim nCount As Integer = 0
			Dim nIndex As Integer
			Dim strFormat As String
			Dim audProps As M_AUD_PROPS
			cbxTarget.Items.Clear()
			'Get video format count
			DirectCast(m_objLive, IMFormat).FormatAudioGetCount(eMFormatType.eMFT_Input, nCount)
			cbxTarget.Enabled = nCount > 0
			If nCount > 0 Then
				For i As Integer = 0 To nCount - 1
					'Get audio format
					DirectCast(m_objLive, IMFormat).FormatAudioGetByIndex(eMFormatType.eMFT_Input, i, audProps, strFormat)
					cbxTarget.Items.Add(strFormat)
				Next
				'Check if there is selected format
				DirectCast(m_objLive, IMFormat).FormatAudioGet(eMFormatType.eMFT_Input, audProps, nIndex, strFormat)
				If nIndex > 0 Then
					cbxTarget.SelectedIndex = nIndex
				Else
					cbxTarget.SelectedIndex = 0
				End If
			End If
		End If
		cbxTarget.Tag = strType
	End Sub

	''' <summary>
	''' Device / input line changed
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub comboBoxAV_SelectedIndexChanged(sender As Object, e As EventArgs)
		Dim cbxChanged As ComboBox = DirectCast(sender, ComboBox)
		Dim strType As String = DirectCast(cbxChanged.Tag, String)
		'Set device
		m_objLive.DeviceSet(strType, DirectCast(cbxChanged.SelectedItem, String), "")
		If strType = "video" Then
			buttonNDIRefresh.Enabled = cbxChanged.SelectedItem.ToString().Contains("NDI")

			' Update audio
			FillCombo("audio", comboBoxAudio)
			' Update input lines
			FillCombo(strType & "::line-in", comboBoxVL)
			'Update Formats
			FillComboFomat(m_objLive, strType, comboBoxVF)
		ElseIf strType = "audio" Then
			' Update Lines
			FillCombo(strType & "::line-in", comboBoxAL)
			'Update Formats
			FillComboFomat(m_objLive, strType, comboBoxAF)
		End If
	End Sub

	''' <summary>
	''' Format changed
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub comboBoxAVF_SelectedIndexChanged(sender As Object, e As EventArgs)
		Dim cbxChanged As ComboBox = DirectCast(sender, ComboBox)
		Dim strType As String = DirectCast(cbxChanged.Tag, String)

		If strType = "video" Then
			Dim vidProps As New M_VID_PROPS()
			Dim strFormat As String
			DirectCast(m_objLive, IMFormat).FormatVideoGetByIndex(eMFormatType.eMFT_Input, cbxChanged.SelectedIndex, vidProps, strFormat)
			'Set new video format
			DirectCast(m_objLive, IMFormat).FormatVideoSet(0, vidProps)
		ElseIf strType = "audio" Then
			Dim audProps As New M_AUD_PROPS()
			Dim strFormat As String
			DirectCast(m_objLive, IMFormat).FormatAudioGetByIndex(eMFormatType.eMFT_Input, cbxChanged.SelectedIndex, audProps, strFormat)
			'Set new audio format
			DirectCast(m_objLive, IMFormat).FormatAudioSet(0, audProps)
		End If
	End Sub

	''' <summary>
	''' Close current live source
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub buttonClose_Click(sender As Object, e As EventArgs)
		DirectCast(m_objLive, IMObject).ObjectClose()
	End Sub

	''' <summary>
	''' Show video device properties (if available)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub buttonV_Click(sender As Object, e As EventArgs)
		Try
			m_objLive.DeviceShowProps("video", "device", Me.Handle.ToInt32())
		Catch
		End Try
	End Sub

	''' <summary>
	''' Show audio device properties (if available)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub buttonA_Click(sender As Object, e As EventArgs)
		Try
			m_objLive.DeviceShowProps("audio", "device", Me.Handle.ToInt32())
		Catch
		End Try
	End Sub

	''' <summary>
	''' Show video format properties (if available)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub buttonVF_Click(sender As Object, e As EventArgs)
		Try
			m_objLive.DeviceShowProps("video", "stream", Me.Handle.ToInt32())
		Catch
		End Try
	End Sub

	''' <summary>
	''' Show audio format properties(if available)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub buttonAF_Click(sender As Object, e As EventArgs)
		Try
			m_objLive.DeviceShowProps("audio", "stream", Me.Handle.ToInt32())
		Catch
		End Try
	End Sub

	Private Sub buttonInit_Click(sender As Object, e As EventArgs)
		DirectCast(m_objLive, IMObject).ObjectStart(Nothing)
	End Sub

	''' <summary>
	''' Enable/desable the video preview
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub checkBoxVideo_CheckedChanged(sender As Object, e As EventArgs)
		If m_objLive IsNot Nothing Then
			DirectCast(m_objLive, IMPreview).PreviewEnable("", If(checkBoxAudio.Checked, 1, 0), If(checkBoxVideo.Checked, 1, 0))
		End If
	End Sub

	''' <summary>
	''' Enable/desable the audio preview
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub checkBoxAudio_CheckedChanged(sender As Object, e As EventArgs)
		If m_objLive IsNot Nothing Then
			DirectCast(m_objLive, IMPreview).PreviewEnable("", If(checkBoxAudio.Checked, 1, 0), If(checkBoxVideo.Checked, 1, 0))
		End If
	End Sub

	''' <summary>
	''' Set audio volume
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub trackBar1_Scroll(sender As Object, e As EventArgs)
		' Volume in dB
		' 0 - full volume, -100 silence
		Dim dblPos As Double = CDbl(trackBarVolume.Value) / trackBarVolume.Maximum
		DirectCast(m_objLive, IMPreview).PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos))
	End Sub

	''' <summary>
	''' Statistics routine
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub timerStatus_Tick(sender As Object, e As EventArgs)

	End Sub

	''' <summary>
	''' Refresh preview after resizing
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub panelPreview_Resize(sender As Object, e As EventArgs)
		If m_objLive IsNot Nothing Then
			Try
				DirectCast(m_objLive, IMPreview).PreviewWindowSet("", panelPreview.Handle.ToInt32())
			Catch
			End Try
		End If
	End Sub

	''' <summary>
	''' Set video format
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub comboBoxVFOut_SelectedIndexChanged(sender As Object, e As EventArgs)
		Try
			If comboBoxVFOut.SelectedIndex <> 0 Then
				' Set video format
				Dim vidProps As New M_VID_PROPS()
				vidProps.eVideoFormat = CType(comboBoxVFOut.SelectedItem, eMVideoFormat)
				DirectCast(m_objLive, IMFormat).FormatVideoSet(eMFormatType.eMFT_Convert, vidProps)
			End If
		Catch
		End Try
	End Sub

	Private Sub LiveForm_FormClosed(sender As Object, e As FormClosedEventArgs)
		Dim preview As IMPreview = TryCast(m_objLive, IMPreview)
		If preview IsNot Nothing Then
			preview.PreviewEnable("", 0, 0)
		End If
	End Sub

	Private Sub buttonNDIRefresh_Click(sender As Object, e As EventArgs)
		FillCombo("video::line-in", comboBoxVL)
	End Sub
End Class
