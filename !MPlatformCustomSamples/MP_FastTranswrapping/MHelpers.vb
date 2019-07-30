Imports System.Collections.Generic
Imports System.Text
Imports MPLATFORMLib
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace MControls
	Public Class MHelpers
		Public Shared ReadOnly Property ColorActive() As Color
			Get
					' Color.FromArgb(255, 72, 0);
				Return Color.Red
			End Get
		End Property

		Public Shared ReadOnly Property ColorReady() As Color
			Get
					' FromArgb(122, 192, 36);
				Return Color.Green
			End Get
		End Property

		Public Shared ReadOnly Property ColorDarkBlue() As Color
			Get
				Return Color.FromArgb(0, 92, 144)
			End Get
		End Property

		Public Shared ReadOnly Property ColorLightBlue() As Color
			Get
				Return Color.FromArgb(52, 152, 212)
			End Get
		End Property

		Public Shared ReadOnly Property ColorBGBlue() As Color
			Get
				Return Color.FromArgb(222, 232, 254)
			End Get
		End Property

		Public Shared Overloads Function ToString(vidProps As M_VID_PROPS) As String
			Return vidProps.nWidth.ToString() & "x" & vidProps.nHeight & "@" & vidProps.dblRate.ToString("00.00") & " " & vidProps.nAspectX.ToString() & ":" & vidProps.nAspectY.ToString() & " " & vidProps.eInterlace.ToString()
		End Function

		Public Shared Overloads Function ToString(audProps As M_AUD_PROPS) As String
			Return (CDbl(audProps.nSamplesPerSec) / 1000).ToString("0.00") & "KHz " & audProps.nChannels.ToString() & "Ch " & audProps.nBitsPerSample.ToString() & "Bits"
		End Function

		Public Shared Overloads Function ToString(mTime As M_DATETIME) As String
			Dim strRes As String = ""
			If mTime.nYear > 0 Then
				strRes = String.Format("{0,0:00}.{1,0:00}.{2,0:0000} {3,0:00}:{4,0:00}:{5,0:00}", mTime.nDay, mTime.nMonth, mTime.nYear, mTime.nHour, mTime.nMinute, _
					mTime.nSecond)
			Else
				strRes = String.Format("{0,0:00}:{1,0:00}:{2,0:00}", mTime.nHour, mTime.nMinute, mTime.nSecond)
			End If
			Return strRes
			'return mTime.nHour.ToString("00") + ":" + mTime.nMinute.ToString("00") + ":" + mTime.nSecond.ToString("00");
		End Function

		Public Shared Overloads Function ToString(mTime As M_DATETIME, _bMSec As Boolean) As String
			Return mTime.nHour.ToString("00") & ":" & mTime.nMinute.ToString("00") & ":" & mTime.nSecond.ToString("00") & "." & mTime.nMilliseconds.ToString("000")
		End Function

		Public Shared Function PosToString(_dblPos As Double) As String
			Return PosToString(_dblPos, -1)
		End Function

		' _nUseMsec = 0 -> No msec
		' _nUseMsec = 1 -> Use msec
		' _nUseMsec = -1 -> Auto
		Public Shared Function PosToString(_dblPos As Double, _nUseMsec As Integer) As String
			Dim bReverse As Boolean = If(_dblPos >= 0, False, True)
			If bReverse Then
				_dblPos *= -1
			End If

			Dim nHour As Integer = CInt(Math.Truncate(_dblPos)) \ 3600
			Dim nMinutes As Integer = (CInt(Math.Truncate(_dblPos)) Mod 3600) \ 60
			Dim nSec As Integer = (CInt(Math.Truncate(_dblPos)) Mod 60)
			_dblPos -= CInt(Math.Truncate(_dblPos))
			Dim nMsec As Integer = CInt(Math.Truncate(_dblPos * 1000 + 0.01))
			' For rounding
			nMsec = If(nMsec >= 1000, 999, nMsec)

			If _nUseMsec < 0 Then
				_nUseMsec = If(nMsec > 0, 1, 0)
			End If

			Dim strRes As String = (If(bReverse, "-", "")) & nHour.ToString("00") & ":" & nMinutes.ToString("00") & ":" & nSec.ToString("00") & (If(_nUseMsec > 0, "." & nMsec.ToString("000"), ""))

			Return strRes
		End Function

		Public Shared Function ParseTime(_strTime As String) As M_DATETIME
			Return ParseTime(_strTime, 25.0)
		End Function

		Public Shared Function ParseTime(_strTime As String, _dblRate As Double) As M_DATETIME
			Return ParseTime(_strTime, _dblRate, False)
		End Function

		Public Shared Function ParseDateTime(_strDateTime As String) As M_DATETIME
			Dim m_dtRes As New M_DATETIME()
			Dim dtParse As DateTime
			Dim valid As Boolean = DateTime.TryParse(_strDateTime, Nothing, System.Globalization.DateTimeStyles.NoCurrentDateDefault, dtParse)
			If valid Then
				m_dtRes.nYear = If(dtParse.Year > 1, dtParse.Year, 0)
				m_dtRes.nMonth = If(dtParse.Month > 1, dtParse.Month, 0)
				m_dtRes.nDay = If(dtParse.Day > 1, dtParse.Day, 0)
				m_dtRes.nHour = dtParse.Hour
				m_dtRes.nMinute = dtParse.Minute
				m_dtRes.nSecond = dtParse.Second
			End If
			Return m_dtRes

		End Function

		Public Shared Function ParseTime(_strTime As String, _dblRate As Double, _bForceSec As Boolean) As M_DATETIME
			Dim mTime As New M_DATETIME()
			' Check for negative time
			_strTime = _strTime.Trim()
			Dim bNegative As Boolean = False
			If _strTime.Length > 0 AndAlso _strTime(0) = "-"C Then
				' Remove -1
				bNegative = True
				_strTime = _strTime.Substring(1)
			End If

			' Get milliseconds
			Dim nMsecPos As Integer = _strTime.LastIndexOf(".")
			If nMsecPos >= 0 Then
				Dim dblMsec As Double = 0
				Double.TryParse(_strTime.Substring(nMsecPos), dblMsec)
				mTime.nMilliseconds = CInt(Math.Truncate(dblMsec * 1000))
				_strTime = _strTime.Substring(0, nMsecPos)
			End If

			' Parse other type
			Dim arrParts As String() = _strTime.Split(":"C)
			If arrParts.Length = 1 Then
				' e.g. 10 or 10.100
				Int32.TryParse(arrParts(0), mTime.nSecond)
			ElseIf arrParts.Length = 2 Then
				If nMsecPos >= 0 OrElse _bForceSec Then
					' e.g. 12:10.100 -> 12 min 10 sec 100 msec
					Int32.TryParse(arrParts(0), mTime.nMinute)
					Int32.TryParse(arrParts(1), mTime.nSecond)
				Else
					' e.g. 12:10 -> 12h 10 min
					Int32.TryParse(arrParts(0), mTime.nHour)
					Int32.TryParse(arrParts(1), mTime.nMinute)
				End If
			ElseIf arrParts.Length >= 3 Then
				' e.g. 12:10:05 -> 12h 10 min 5 sec
				Int32.TryParse(arrParts(0), mTime.nHour)
				Int32.TryParse(arrParts(1), mTime.nMinute)
				Int32.TryParse(arrParts(2), mTime.nSecond)

				If arrParts.Length >= 4 Then
					' 12:10:05:10  -> timecode (ignore .xxx if have e.g. 12:10:05:10.100 -> 12:10:05:10)
					Int32.TryParse(arrParts(3), mTime.nMilliseconds)

					' Update milliseconds according to rate
					_dblRate = If(_dblRate > 0, _dblRate, 25.0)
					mTime.nMilliseconds = CInt(Math.Truncate(mTime.nMilliseconds * 1000 / _dblRate))
				End If
			End If

			If bNegative Then
				mTime.nHour *= -1
				mTime.nMinute *= -1
				mTime.nSecond *= -1
				mTime.nMilliseconds *= -1
			End If

			Return mTime
		End Function

		Public Shared Function ParsePos(_strTime As String) As Double
			Dim mTime As M_DATETIME = ParseTime(_strTime, 25.0, True)
			Return mTime.nHour * 3600 + mTime.nMinute * 60 + mTime.nSecond + CDbl(mTime.nMilliseconds) / 1000.0
		End Function

		' Conversion
		Public Shared Function MTime2DateTime(_mTime As M_DATETIME) As DateTime
			Dim dtTime As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _mTime.nHour, _mTime.nMinute, _mTime.nSecond, _
				_mTime.nMilliseconds)

			Return dtTime
		End Function

		Public Shared Function MTime2Sec(mTime As M_DATETIME) As Double
			Return mTime.nHour * 3600 + mTime.nMinute * 60 + mTime.nSecond + CDbl(mTime.nMilliseconds) / 1000.0
		End Function

		Public Shared Function MTime2FileTime(mTime As M_DATETIME) As Long
			If mTime.nDay > 0 Then
				Dim dtTime As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, mTime.nHour, mTime.nMinute, mTime.nSecond, _
					mTime.nMilliseconds)

				Return dtTime.ToFileTime()
			End If

			Return ((mTime.nHour * 3600 + mTime.nMinute * 60 + mTime.nSecond) * 1000 + mTime.nMilliseconds) * 10000L
		End Function

		' Construct Image from MFrame 
		' WARNING !!! This bitmap valid till valid MFrame
		Public Shared Function FrameGetBitmap(pFrame As MFrame) As Bitmap
			' Get image bytes
			Dim nSize As Integer = 0
			Dim pImage32 As Long = 0
			pFrame.FrameVideoGetBytes(nSize, pImage32)

			' Get A/V props (for image size)
			Dim avProps As M_AV_PROPS
			pFrame.FrameAVPropsGet(avProps)

			' The RGB images is bottom-top if height is positive
			If avProps.vidProps.nHeight > 0 Then
				pImage32 += (avProps.vidProps.nHeight - 1) * avProps.vidProps.nRowBytes
				avProps.vidProps.nRowBytes *= -1
			Else
				avProps.vidProps.nHeight *= -1
			End If

			' Note - this bitmap contain reference to MFrame data
			Dim bmpFrame As New Bitmap(avProps.vidProps.nWidth, avProps.vidProps.nHeight, avProps.vidProps.nRowBytes, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, New IntPtr(pImage32))

			Return bmpFrame
		End Function

		Public Shared Function PictureBoxSetImage(picBox As PictureBox, img As Image) As Boolean
			If img IsNot Nothing AndAlso picBox.Tag IsNot img Then
				picBox.Image = img
				picBox.Tag = img

				Return True
			End If

			Return False
		End Function
		' Graphics basics
		Public Shared Sub DrawRoundImage(g As Graphics, img As Image, rect As RectangleF, radius As Single)
			If img IsNot Nothing Then
				Dim brImage As New TextureBrush(img)
				brImage.ScaleTransform(rect.Width / img.Width, rect.Height / img.Height)
				brImage.TranslateTransform(rect.Left, rect.Top, MatrixOrder.Append)
				FillRoundRect(g, brImage, rect, radius)
			End If
		End Sub

		Public Shared Sub DrawRoundRect(g As Graphics, p As Pen, rect As RectangleF, radius As Single)
			Dim gp As GraphicsPath = GetRoundRectPath(rect.X, rect.Y, rect.Width, rect.Height, radius)
			g.DrawPath(p, gp)
			gp.Dispose()
		End Sub

		Public Shared Sub FillRoundRect(g As Graphics, br As Brush, rect As RectangleF, radius As Single)
			g.SmoothingMode = SmoothingMode.AntiAlias
			Dim gp As GraphicsPath = GetRoundRectPath(rect.X, rect.Y, rect.Width, rect.Height, radius)
			g.FillPath(br, gp)
			gp.Dispose()
		End Sub

		Public Shared Function GetRoundRectPath(x As Single, y As Single, width As Single, height As Single, radius As Single) As GraphicsPath
			Dim gp As New GraphicsPath()

			gp.AddLine(x + radius, y, x + width - (radius * 2), y)
			' Line
			If radius > 0 Then
				gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
			End If
			' Corner
			gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
			' Line
			If radius > 0 Then
				gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
			End If
			' Corner
			gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
			' Line
			If radius > 0 Then
				gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
			End If
			' Corner
			gp.AddLine(x, y + height - (radius * 2), x, y + radius)
			' Line
			If radius > 0 Then
				gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
			End If
			' Corner
			gp.CloseFigure()

			Return gp
		End Function

		Public Shared strDefAttributes As String() = New String() {"show", "alpha", "x", "y", "z", "w", _
			"h", "d", "rv", "rh", "r", "pos", _
			"maintain_ar", "sx", "sy", "sw", "sh", "spos", _
			"audio_gain"}
		Public Shared strDefNodes As String() = New String() {"on_hide", "on_show", "on_select", "add", "vary"}
		Public Shared strDefOptions As String() = New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Remove"}
		Public Shared strDefaultElements As String() = New String() {"video", "text", "block", "group", "img", "crawl", _
			"roll", "matrix", "cloud", "cube", "polygon", "star", _
			"ticker"}

		Public Shared MMixerElementDescriptors As New List(Of MElemementDescriptor)(New MElemementDescriptor() {New MElemementDescriptor("foreground", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker"}), "", ""), New MElemementDescriptor("view", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add View", "Invoke", "Remove"}), "", ""), New MElemementDescriptor("video", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(strDefOptions), "<video stream_idx='0' h='0.5' w='0.5' show='1'/>", "<video stream_idx='0' h='0.5' w='0.5' show='1'/>"), New MElemementDescriptor("block", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(strDefOptions), "<block show='1' h='0.5' w='0.5'>" & vbCr & vbLf & "            </block>", "<block show='1' h='0.5' w='0.5'>" & vbCr & vbLf & "            </block>")})







		' TODO: Add ticker

		Public Shared MComposerElementDescriptors As New List(Of MElemementDescriptor)(New MElemementDescriptor() {New MElemementDescriptor("background", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker"}), "", ""), New MElemementDescriptor("scene_3d", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker"}), "", ""), New MElemementDescriptor("foreground", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker"}), "", ""), New MElemementDescriptor("viewroot", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add View"}), "", ""), New MElemementDescriptor("view", New List(Of String)(), New List(Of String)(), New List(Of String)(New String() {"Add View", "Invoke", "Remove"}), "", ""), New MElemementDescriptor("timeline", New List(Of String)(), New List(Of String)(), New List(Of String)(), "", ""), _
			New MElemementDescriptor("effects", New List(Of String)(), New List(Of String)(), New List(Of String)(), "", ""), New MElemementDescriptor("light", New List(Of String)(), New List(Of String)(), New List(Of String)(), "", ""), New MElemementDescriptor("camera", New List(Of String)(), New List(Of String)(New String() {"add", "vary"}), New List(Of String)(), "", ""), New MElemementDescriptor("ticker_item", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Remove"}), "<ticker_item></ticker_item>", "<ticker_item></ticker_item>"), New MElemementDescriptor("on_ticker_next", New List(Of String)(strDefAttributes), New List(Of String)(New String() {"add", "vary"}), New List(Of String)(New String() {"Remove"}), "<on_ticker_next></on_ticker_next>", "<on_ticker_next></on_ticker_next>"), New MElemementDescriptor("rear_side", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(strDefOptions), "<rear_side> </rear_side>", "<rear_side>" & vbCr & vbLf & vbTab & vbTab & "<text show='true' w='0.8'>Rear side</text>" & vbCr & vbLf & "</rear_side>"), _
			New MElemementDescriptor("cell", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<cell>" & vbCr & vbLf & "</cell>", "<cell>" & vbCr & vbLf & vbTab & "<block show='1' shape='rrect-r05' border='0.01' color='green(200)' d='0.02' h='0.9' w='0.9'>" & vbTab & vbCr & vbLf & vbTab & vbTab & "<text show='true' w='0.8'>Content</text>" & vbCr & vbLf & vbTab & "</block>" & vbCr & vbLf & "</cell>"), New MElemementDescriptor("face", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<face></face>", "<face>" & vbCr & vbLf & vbTab & "<block show='1' shape='rrect-r05' border='0' color='red(100)' d='0' h='0.9' w='0.9'>" & vbCr & vbLf & vbTab & vbTab & "<text show='true' w='0.8'>Content</text>" & vbCr & vbLf & vbTab & "</block>" & vbCr & vbLf & "</face>"), New MElemementDescriptor("top", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<top></top>", "<top></top>"), New MElemementDescriptor("bottom", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<bottom></bottom>", "<bottom></bottom>"), New MElemementDescriptor("left", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<left></left>", "<left></left>"), New MElemementDescriptor("right", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<right></right>", "<right></right>"), _
			New MElemementDescriptor("front", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<front></front>", "<front></front>"), New MElemementDescriptor("back", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Add Video", "Add Text", "Add Block", "Add Group", "Add Image", "Add Crawl", _
			"Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", "Add Star", _
			"Add Ticker", "Remove"}), "<back></back>", "<back></back>"), New MElemementDescriptor("video", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Remove", "Move Up", "Move Down"}), "<video/>", "<video stream_idx='0' border='0.03' shape='trect' d='0.1' h='0.6' x='-0.1' rh='40'/>"), New MElemementDescriptor("text", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Remove", "Move Up", "Move Down"}), "<text>Put text here...</text>", "<text bg_color='black(80)' indent='0.03' bg_shape='rrect-r03' size='1.0' show='true'>" & vbCr & vbLf & vbTab & "<font bg_color='RED'>M</font>Composer support " & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & "    <font bg_shape='rrect-r100' bg_color='red'> Rich </font><font size=1.5 color='yellow' face='Consolas'>text <i>formatting</i></font>" & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "<up>UPPerCase</up> and <lo>LOweRcase</lo>" & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "<font depth='1.0' size=3.0 color='silver' bold=true>3D text</font>" & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "<tab/>Tabbed lines." & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "Images could be added into text:<br/>" & vbCr & vbLf & vbTab & "<img size=3.0 shape='rrect' src='C:\Users\Public\Pictures\Sample Pictures\Koala.jpg'/>" & vbCr & vbLf & vbTab & "<br>" & vbCr & vbLf & vbTab & "And even videos:<br/>" & vbCr & vbLf & vbTab & "<video shape='trect' stream_idx='0' size=4.0/>" & vbCr & vbLf & "</text>"), New MElemementDescriptor("block", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down"}), "<block>" & vbCr & vbLf & vbTab & "<rear_side/>" & vbCr & vbLf & "</block>", "<block show='true' d='0.1' h='0.8' w='0.8' color='white' bg_color='black(80)' shape='box-lr-o' border='0.1'>" & vbCr & vbLf & vbTab & "<text w='1.0'>Front side</text>" & vbCr & vbLf & vbTab & "<rear_side>" & vbCr & vbLf & vbTab & vbTab & "<text w='1.0'>Back side</text>" & vbCr & vbLf & vbTab & "</rear_side>" & vbCr & vbLf & "</block>"), New MElemementDescriptor("group", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down"}), "<group/>", "<group h='1.0' w='1.0' d='1.0'/>"), _
			New MElemementDescriptor("img", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down"}), "<img src='' />", "<img shape='rrect-r05' frame='true' border='0.05' color='silver' src='' h='0.8' x='0.1' rh='-40' d='0.1'/>"), New MElemementDescriptor("crawl", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down"}), "<crawl h='0.1' src=''>Crawl content</crawl>", "<crawl h='0.1' w='1.2' bg_color='blue(80)' bg_shape='rrect-r100' indent='0.05, 0.0' z=0.6 rh='30.0' rv='10.0' r='10.0' speed='1.0'>" & vbCr & vbLf & vbTab & "<text color='Red'>Crawl </text>" & vbCr & vbLf & vbTab & "<b>with </b>" & vbCr & vbLf & vbTab & "<text bg_color='RED' bg_shape='trect'> colored </text>" & vbCr & vbLf & vbTab & "<text> text</text>" & vbCr & vbLf & vbTab & "<pause time=1.0/>" & vbCr & vbLf & vbTab & "<i> &lt;1 second pause&gt; </i>" & vbCr & vbLf & vbTab & "<text src=''>...Loaded content...</text>" & vbCr & vbLf & "</crawl>"), New MElemementDescriptor("roll", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Video", "Add Text", "Add Block", "Add Group", "Add Image", _
			"Add Crawl", "Add Roll", "Add Matrix", "Add Cloud", "Add Cube", "Add Polygon", _
			"Add Star", "Add Ticker", "Add Rear Side", "Remove", "Move Up", "Move Down"}), "<roll src=''>Roll content</roll>", "<roll bg_color='blue(80)' bg_shape='rrect-r05' indent='0.1' show='true' h='1.2' w='0.4' z=0.5 y=0.2 rv=-55 speed='2.0'>" & vbCr & vbLf & vbTab & "<font color=yellow align='center' size='2.0'>A long time ago in a<br/>galaxy far, far away....</font>" & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "<pause time=1.0/>" & vbCr & vbLf & vbTab & "<i> &lt;1 second pause&gt; </i>" & vbCr & vbLf & vbTab & "<br/>" & vbCr & vbLf & vbTab & "<text word_wrap='true' align='justify'>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</text>" & vbCr & vbLf & vbTab & "<br>" & vbCr & vbLf & vbTab & "<text src=''>...Loaded content...</text>" & vbCr & vbLf & vbTab & "<br>" & vbCr & vbLf & vbTab & "<br>" & vbCr & vbLf & "</roll>"), New MElemementDescriptor("matrix", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Cell", "Remove", "Move Up", "Move Down"}), "<matrix items='9'>" & vbCr & vbLf & vbTab & "<cell>" & vbCr & vbLf & vbTab & "</cell>" & vbCr & vbLf & "</matrix>", "<matrix items='9' show='true' h='0.8' w='0.8' d='1' rh=-40 z=0.1 x=-0.1>" & vbCr & vbLf & "    <cell>" & vbCr & vbLf & "        <block show='1' shape='rrect-r05' border='0.0' color='grey(100)' d='0.0' h='0.9' w='0.9'>" & vbCr & vbLf & "            <text show='true' w='0.8'>Default cell</text>" & vbCr & vbLf & "        </block>" & vbCr & vbLf & "    </cell>" & vbCr & vbLf & "    <cell.0.0>" & vbCr & vbLf & "        <video stream_idx='0' shape='rrect-r05' border='0.02' d='0.02' h='0.9' w='0.9'/>" & vbCr & vbLf & "    </cell.0.0>" & vbCr & vbLf & "    <cell.2.1>" & vbCr & vbLf & "        <block show='1' shape='rrect-r05' border='0.0' color='red(200)' d='0.0' h='0.9' w='0.9'>" & vbCr & vbLf & "            <text align='center' show='true' w='0.8'>Selected cell<br>(cell.2.1)</text>" & vbCr & vbLf & "        </block>" & vbCr & vbLf & "    </cell.2.1>" & vbCr & vbLf & "</matrix>"), New MElemementDescriptor("cloud", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Cell", "Remove", "Move Up", "Move Down"}), "<cloud items='12' show='1' h='0.5' w='0.5' d='1' src=''>" & vbCr & vbLf & vbTab & "<cell>" & vbCr & vbLf & vbTab & "</cell>" & vbCr & vbLf & "</cloud>", "<cloud items='12' show='true' h='0.5' w='0.5' d='1' src='C:\Users\Public\Pictures\Sample Pictures\*.*'  rv='-20'>" & vbCr & vbLf & "     <cell>" & vbCr & vbLf & vbTab & "           <loaded_item show='true' frame=true shape='rrect-r05' border='0.02' d='0.02' h='0.9'/>" & vbCr & vbLf & vbTab & " </cell>" & vbCr & vbLf & vbTab & " <cell>" & vbCr & vbLf & vbTab & "           <loaded_item show='true' frame=true color='red' shape='rrect-r05' border='0.02' d='0.02' h='0.9'/>" & vbCr & vbLf & vbTab & " </cell>" & vbCr & vbLf & "</cloud>"), New MElemementDescriptor("cube", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Face", "Remove", "Move Up", "Move Down"}), "<cube show='true' h='0.5'>" & vbCr & vbLf & "    <face>" & vbCr & vbLf & "    </face>" & vbCr & vbLf & "</cube>", "<cube  show='1' h='0.5' rh=-45 >" & vbCr & vbLf & vbTab & "<face>" & vbCr & vbLf & vbTab & vbTab & "<block show='1' d='0.0'color='maroon'>" & vbCr & vbLf & vbTab & vbTab & vbTab & "<text show='true' w='0.9'>Default face</text>" & vbCr & vbLf & vbTab & vbTab & "</block>" & vbCr & vbLf & vbTab & "</face>" & vbCr & vbLf & vbTab & "<right>" & vbCr & vbLf & vbTab & vbTab & "<block z='0.1' show='1' color='white'>" & vbCr & vbLf & vbTab & vbTab & vbTab & "<text size=2.0 color='maroon' show='true' pos=top w='0.9' h=0.2 y=0.1>Right face</text>" & vbCr & vbLf & vbTab & vbTab & vbTab & "<video show='true' shape='rrect-r05' border=0.1 pos=bottom w='0.9' h='0.6' y='0.05'/>" & vbCr & vbLf & vbTab & vbTab & "</block>" & vbCr & vbLf & vbTab & "</right>" & vbCr & vbLf & vbTab & "<add rh='10'/>" & vbCr & vbLf & vbTab & "<vary rv=10 time=20/>" & vbCr & vbLf & "</cube>"), _
			New MElemementDescriptor("polygon", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Add Face", "Remove", "Move Up", "Move Down"}), "<polygon faces='3' show='1' h='0.5' w='0.5' d='0.5'>" & vbCr & vbLf & "    <face>" & vbCr & vbLf & "    </face>" & vbCr & vbLf & "</polygon>", "<polygon faces='3' show='true' h='0.5' w='0.5' d='0.5'>" & vbCr & vbLf & "    <face>" & vbCr & vbLf & "        <block show='1' shape='box-lr' border='0.1' bg_color='red(100)' d='0.1' h='0.9' w='0.9' z='0.2'>" & vbCr & vbLf & "            <text show='true' w='0.8'>Default face</text>" & vbCr & vbLf & "        </block>" & vbCr & vbLf & "    </face>" & vbCr & vbLf & "    <face.0>" & vbCr & vbLf & "            <video stream_idx='0' frame=true border=0.05 shape='rrect-r10' d=0.1 w='0.9' h='0.9' z='0.2'/>" & vbCr & vbLf & "    </face.0>" & vbCr & vbLf & "    <add rh='10'/>" & vbCr & vbLf & "</polygon>"), New MElemementDescriptor("star", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Remove", "Move Up", "Move Down"}), "<star faces='6' show='1' h='0.3' w='0.3' d='0.3'>" & vbCr & vbLf & "    <face>" & vbCr & vbLf & "    </face>" & vbCr & vbLf & "</star>", "<star faces='6' show='true' h='0.3' w='0.3' d='0.3' rv='16.666667'>" & vbCr & vbLf & "<face>" & vbCr & vbLf & vbTab & "<video id='video_000' x='-0.2' back_side='true' frame='true' shape='box-lr-i' border='0.05' d='0.1'/>" & vbCr & vbLf & "</face>" & vbCr & vbLf & "    <face.1>" & vbCr & vbLf & "        <video id='video_001' x='-0.2' img_filter='blue' back_side='true' frame='true' shape='box-lr-i' border='0.05' d='0.1' color='orange'>" & vbCr & vbLf & vbTab & vbTab & vbTab & "<text bg_color=black(100)> Selected Face </text>" & vbCr & vbLf & vbTab & vbTab & "</video>" & vbCr & vbLf & "    </face.1>" & vbCr & vbLf & "    <add rh='10'/>" & vbCr & vbLf & "</star>"), New MElemementDescriptor("ticker", New List(Of String)(strDefAttributes), New List(Of String)(strDefNodes), New List(Of String)(New String() {"Invoke", "Remove", "Move Up", "Move Down"}), "<ticker src=''></ticker>", "<ticker src=''>" & vbCr & vbLf & vbTab & vbTab & vbTab & "</ticker>")})




	End Class

	Public Class MElemementDescriptor
		Public Sub New(_strName As String, _strAttributesToShowAlways As List(Of String), _strNodesToShowAlways As List(Of String), _strAvailableOptions As List(Of String), _strDefaultXML As String, _strDemoXML As String)
			strName = _strName
			strAttributesToShowAlways = _strAttributesToShowAlways
			strNodesToShowAlways = _strNodesToShowAlways
			strAvailableOptions = _strAvailableOptions
			strDefaultXML = _strDefaultXML
			strDemoXML = _strDemoXML
		End Sub
		Public strName As String
		Public strAttributesToShowAlways As List(Of String)
		Public strNodesToShowAlways As List(Of String)
		Public strAvailableOptions As List(Of String)
		Public strDefaultXML As String
		Public strDemoXML As String
	End Class
End Namespace
