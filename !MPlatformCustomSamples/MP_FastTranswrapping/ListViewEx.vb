Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace MControls
	Public Partial Class ListViewEx
		Inherits ListView
		Public Event ListSubItemChanged As EventHandler
		Public Event ListSubItemOnStartChange As EventHandler

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Const WM_HSCROLL As Integer = &H114
		Private Const WM_VSCROLL As Integer = &H115
		Private Const MOUSEWHEEL As Integer = &H20a
		Private Const KEYDOWN As Integer = &H100
		Private pEditControl As Control = Nothing

		Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
			If pEditControl IsNot Nothing AndAlso (m.Msg = MOUSEWHEEL OrElse m.Msg = WM_VSCROLL OrElse m.Msg = WM_HSCROLL) Then
				' Trap WM_VSCROLL 

				If m.Msg = WM_VSCROLL OrElse m.Msg = WM_HSCROLL Then
					pEditControl.Visible = False
					pEditControl = Nothing

					MyBase.WndProc(m)
				End If
			Else
				MyBase.WndProc(m)
			End If
		End Sub

		Public Function AddNewItem(sText As String, imageIndex As Integer) As ListViewItem
			Dim pCombo As ComboBox
			Return AddNewItem_Combo(sText, imageIndex, pCombo)
		End Function

		Public Sub SetRowBGColor(nRow As Integer, color As Color)
			Dim lvItem As ListViewItem = Items(nRow)
			lvItem.BackColor = color
			For i As Integer = 0 To lvItem.SubItems.Count - 1
				lvItem.SubItems(i).BackColor = color
			Next
		End Sub

		Public Function AddNewItem_Combo(sText As String, imageIndex As Integer, ByRef pCombo As ComboBox) As ListViewItem
			pCombo = Nothing

			Dim lvItem As ListViewItem = Items.Add(sText, imageIndex)
			For i As Integer = 1 To Columns.Count - 1
				Dim lvSubItem As ListViewItem.ListViewSubItem = lvItem.SubItems.Add("")
				If Columns(i).Tag IsNot Nothing Then
					Dim sType As String = Columns(i).Tag.[GetType]().Name
					If sType = "ComboBox" Then
						pCombo = SubItem_SetCombo(lvSubItem, DirectCast(Columns(i).Tag, ComboBox))
							' TODO: Copy props/def items from column ComboBox
							'                         pCombo = new ComboBox();
							' 
							'                         pCombo.Visible = false;
							'                         pCombo.Parent = this;
							'                         pCombo.FlatStyle = FlatStyle.Flat;
							'                         pCombo.Tag = new ListViewEx_EventArgs(lvItem, lvSubItem, Items.Count - 1, i);
							'                         pCombo.DropDownStyle = ComboBoxStyle.DropDownList;
							'                         pCombo.SelectedIndexChanged += new EventHandler(pCombo_EditDone);
							'                         pCombo.DropDownClosed += new EventHandler(pCombo_DropDownClosed);
							'                         lvSubItem.Tag = pCombo;
						pCombo.Tag = New ListViewEx_EventArgs(lvItem, lvSubItem, Items.Count - 1, i)
					End If
				End If
			Next

			Return lvItem
		End Function

		Public Function SubItem_SetCombo(lvSubItem As ListViewItem.ListViewSubItem, pDefault As ComboBox) As ComboBox
			Return SubItem_SetCombo(lvSubItem, pDefault, ComboBoxStyle.DropDownList)
		End Function
		Public Function SubItem_SetCombo(lvSubItem As ListViewItem.ListViewSubItem, pDefault As ComboBox, cbxStyle As ComboBoxStyle) As ComboBox
			' TODO: Copy props/def items from column ComboBox
			Dim pCombo As New ComboBox()

			pCombo.Visible = False
			pCombo.Parent = Me
			pCombo.FlatStyle = FlatStyle.Flat
			pCombo.DropDownStyle = cbxStyle
			AddHandler pCombo.SelectedIndexChanged, New EventHandler(AddressOf pCombo_EditDone)
			AddHandler pCombo.DropDownClosed, New EventHandler(AddressOf pCombo_DropDownClosed)
			If cbxStyle <> ComboBoxStyle.DropDownList Then
				AddHandler pCombo.Leave, New EventHandler(AddressOf pControl_Leave)
				AddHandler pCombo.KeyDown, New KeyEventHandler(AddressOf pControl_KeyDown)
			End If
			lvSubItem.Tag = pCombo

			Return pCombo
		End Function

		Public Sub SubItem_SetControl(lvSubItem As ListViewItem.ListViewSubItem, pControl As Control)
			pControl.Visible = False
			pControl.Parent = Me
			AddHandler pControl.Leave, New EventHandler(AddressOf pControl_Leave)
			AddHandler pControl.KeyDown, New KeyEventHandler(AddressOf pControl_KeyDown)
			AddHandler pControl.DoubleClick, New EventHandler(AddressOf pControl_DoubleClick)
			lvSubItem.Tag = pControl
		End Sub

		Public Function SubItem_SetDTPicker(lvSubItem As ListViewItem.ListViewSubItem) As DateTimePicker
			' TODO: Copy props/def items from column ComboBox
			Dim pPicker As New DateTimePicker()

			pPicker.Visible = False
			pPicker.Parent = Me
			pPicker.Format = DateTimePickerFormat.[Custom]
			AddHandler pPicker.KeyDown, New KeyEventHandler(AddressOf pPicker_KeyDown)
			AddHandler pPicker.DropDown, New EventHandler(AddressOf pPicker_DropDown)
			AddHandler pPicker.Leave, New EventHandler(AddressOf pPicker_Leave)
			lvSubItem.Tag = pPicker


			Return pPicker
		End Function

		Private Sub pPicker_Leave(sender As Object, e As EventArgs)
			Dim dtPicker As DateTimePicker = DirectCast(sender, DateTimePicker)
			If dtPicker.CustomFormat = "HH':'mm':'ss" Then
				dtPicker.Text = [String].Format("{0,0:00}:{1,0:00}:{2,0:00}", dtPicker.Value.Hour, dtPicker.Value.Minute, dtPicker.Value.Second)
			End If
			ListTextChange(dtPicker)
			dtPicker.Visible = False
			dtPicker.Parent.Focus()
			pEditControl = Nothing
		End Sub

		Private Sub pPicker_DropDown(sender As Object, e As EventArgs)
			DirectCast(sender, DateTimePicker).CustomFormat = "dd'.'MM'.'yyyy HH':'mm':'ss"
		End Sub

		Private Sub pPicker_KeyDown(sender As Object, e As KeyEventArgs)
			Dim dtPicker As DateTimePicker = DirectCast(sender, DateTimePicker)
			If e.KeyCode = Keys.[Return] Then
				If dtPicker.CustomFormat = "HH':'mm':'ss" Then
					dtPicker.Text = [String].Format("{0,0:00}:{1,0:00}:{2,0:00}", dtPicker.Value.Hour, dtPicker.Value.Minute, dtPicker.Value.Second)
				End If
				ListTextChange(dtPicker)
				dtPicker.Visible = False
				dtPicker.Parent.Focus()
				pEditControl = Nothing
			End If
			If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then

				dtPicker.Format = DateTimePickerFormat.[Custom]
				dtPicker.CustomFormat = " "

				dtPicker.Visible = False
				dtPicker.Parent.Focus()
				pEditControl = Nothing
			End If
		End Sub

		Public Function GetClickedColumn(ptClick As Point, ByRef rcItem As Rectangle) As Integer
			' Get column number
			rcItem = New Rectangle()
			If SelectedItems.Count > 0 AndAlso SelectedItems(0).SubItems.Count > 0 Then
				Dim rcBounds As Rectangle = SelectedItems(0).SubItems(0).Bounds
				If SelectedItems(0).SubItems.Count > 1 Then
					rcBounds.Width = SelectedItems(0).SubItems(1).Bounds.Left
				End If

				If rcBounds.Contains(ptClick) Then
					rcItem = rcBounds
					Return 0
				End If

				For i As Integer = 1 To SelectedItems(0).SubItems.Count - 1
					If SelectedItems(0).SubItems(i).Bounds.Contains(ptClick) Then
						rcItem = SelectedItems(0).SubItems(i).Bounds
						Return i
					End If
				Next
			End If

			Return -1
		End Function
		Public Sub EndEdit()
			If pEditControl IsNot Nothing Then
				pEditControl.Visible = False
				If pEditControl IsNot Nothing AndAlso pEditControl.Parent IsNot Nothing Then
					pEditControl.Parent.Focus()
				End If
				pEditControl = Nothing
			End If
		End Sub
		Public Function BeginEdit(nRow As Integer, nCol As Integer) As Boolean
			If nRow < 0 OrElse nRow >= Items.Count OrElse nCol < 0 OrElse nCol >= Items(nRow).SubItems.Count Then
				Return False
			End If

			Dim lvItem As ListViewItem = Items(nRow)

			EnsureVisible(nRow)

			Dim rcBounds As Rectangle = lvItem.SubItems(nCol).Bounds
			If nCol = 0 AndAlso lvItem.SubItems.Count > 1 Then
				' Special fix for first column -> all item width returned
				rcBounds.Width = lvItem.SubItems(1).Bounds.Left - 1
			End If

			Dim pArg As New ListViewEx_EventArgs(lvItem, lvItem.SubItems(nCol), nRow, nCol)

			' Event for cancel
			If True Then
                Dim handler As EventHandler = Me.ListSubItemOnStartChangeEvent
				If handler IsNot Nothing Then
					handler(Me, pArg)
					If pArg.Cancel Then
						Return False
					End If
				End If
			End If

			' Check object type
			'             if (Columns[nCol].Tag != null && Columns[nCol].Tag.GetType().Name == "ComboBox")
			'             {
			'                 try
			'                 {
			'                     ComboBox pCombo = (ComboBox)lvItem.SubItems[nCol].Tag;
			' 
			'                     if (pCombo.Items.Count > 1)
			'                     {
			'                         pCombo.Bounds = rcBounds;
			'                         pCombo.Visible = true;
			'                        // pCombo.Focus(); // Some flickering in ListView if Focused() TODO: Fix
			'                         pCombo.DroppedDown = true;
			'                     }
			' 
			'                     pEditControl = pCombo;
			'                 }
			'                 catch (System.Exception) { }
			'             }
			'             else 
			If True Then
				Try
					Dim pControl As Control = Nothing
					If lvItem.SubItems(nCol).Tag IsNot Nothing Then
						Try
							pControl = DirectCast(lvItem.SubItems(nCol).Tag, Control)
						Catch generatedExceptionName As System.Exception
						End Try
					End If

					If pControl Is Nothing AndAlso Columns(nCol).Tag IsNot Nothing Then
						pControl = DirectCast(Columns(nCol).Tag, Control)
					End If

					If pControl Is Nothing OrElse Not pControl.Enabled Then
						Return False
					End If

					If pControl.Tag Is Nothing AndAlso pControl.[GetType]().Name <> "DateTimePicker" Then
						AddHandler pControl.Leave, New EventHandler(AddressOf pControl_Leave)
						AddHandler pControl.KeyDown, New KeyEventHandler(AddressOf pControl_KeyDown)
						AddHandler pControl.DoubleClick, New EventHandler(AddressOf pControl_DoubleClick)
					End If

					pControl.Parent = Me
					pControl.Bounds = rcBounds
					If pControl.[GetType]().Name <> "DateTimePicker" Then
						pControl.Text = lvItem.SubItems(nCol).Text
					End If

					If pControl.Tag IsNot Nothing Then
						If pControl.Tag.[GetType]().Name <> "ListViewEx_EventArgs" Then
							pArg.Tag = pControl.Tag
						Else
							pArg.Tag = DirectCast(pControl.Tag, ListViewEx_EventArgs).Tag
						End If
					End If
					pControl.Tag = pArg
					pControl.Visible = True
					If pControl.[GetType]().Name = "ComboBox" Then
						DirectCast(pControl, ComboBox).DroppedDown = True
					Else
						pControl.Focus()
					End If

					pEditControl = pControl
				Catch generatedExceptionName As System.Exception
				End Try
			End If

			Return True
		End Function


		Private Function OnListClick(ptLocation As Point) As Boolean
			Dim rcBounds As Rectangle
			Dim nCol As Integer = GetClickedColumn(ptLocation, rcBounds)
			If nCol >= 0 AndAlso nCol < Columns.Count AndAlso (Columns(nCol).Tag IsNot Nothing OrElse SelectedItems(0).SubItems(nCol).Tag IsNot Nothing) Then
				Return BeginEdit(SelectedIndices(0), nCol)
			End If

			Return False
		End Function

		' List events
		Private Sub ListViewEx_MouseClick(sender As Object, e As MouseEventArgs)
			OnListClick(e.Location)
		End Sub

		Private Sub ListViewEx_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			OnListClick(e.Location)
		End Sub



		' Items events
		Private Sub pCombo_EditDone(sender As Object, e As EventArgs)
			Dim pCombo As ComboBox = DirectCast(sender, ComboBox)
			Dim evArg As ListViewEx_EventArgs = DirectCast(pCombo.Tag, ListViewEx_EventArgs)
			If evArg IsNot Nothing Then
				evArg.strPrevValue = evArg.lvSubItem.Text
				evArg.lvSubItem.Text = pCombo.Text
				' For handler
                Dim handler As EventHandler = Me.ListSubItemChangedEvent
				If handler IsNot Nothing Then
					handler(Me, evArg)
					If evArg.Cancel Then
						evArg.lvSubItem.Text = evArg.strPrevValue
					End If
				End If

				pCombo.Visible = False
				pCombo.Parent.Focus()
				pEditControl = Nothing
			End If
		End Sub

		Private Sub pCombo_DropDownClosed(sender As Object, e As EventArgs)
			Dim pCombo As ComboBox = DirectCast(sender, ComboBox)
			If pCombo.DropDownStyle <> ComboBoxStyle.DropDown Then
				pCombo.Visible = False
				pCombo.Parent.Focus()
				pEditControl = Nothing
			End If
		End Sub

		Private Sub pControl_DoubleClick(sender As Object, e As EventArgs)
			Dim pControl As Control = DirectCast(sender, Control)
			If pControl.Tag IsNot Nothing Then
				' e.g. Browse for file
				Try
					Dim pArg As ListViewEx_EventArgs = DirectCast(pControl.Tag, ListViewEx_EventArgs)
					Dim pDialog As FileDialog = DirectCast(pArg.Tag, FileDialog)
					If pDialog.ShowDialog() = DialogResult.OK Then
						If pDialog.FileName IsNot Nothing Then
							pControl.Text = pDialog.FileName
							pControl_Leave(sender, e)
						End If
					End If
				Catch generatedExceptionName As System.Exception
				End Try
			End If
		End Sub

		Private Sub pControl_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] OrElse e.KeyCode = Keys.Escape Then
				Dim pText As Control = DirectCast(sender, Control)
				If e.KeyCode = Keys.[Return] Then
					ListTextChange(pText)
				End If

				'pText.Text = "";
				pText.Visible = False
				pText.Parent.Focus()
				pEditControl = Nothing
			End If
		End Sub

		Private Sub pControl_Leave(sender As Object, e As EventArgs)
			Dim pText As Control = DirectCast(sender, Control)
			If pText.Text <> "" Then
				ListTextChange(pText)
			End If
			pText.Visible = False
			pText.Parent.Focus()
			pEditControl = Nothing
		End Sub

		Private Sub ListNumChange(pNumeric As NumericUpDown)
			Dim evArg As ListViewEx_EventArgs = DirectCast(pNumeric.Tag, ListViewEx_EventArgs)
			evArg.strPrevValue = evArg.lvSubItem.Text
			evArg.lvSubItem.Text = pNumeric.Value.ToString()

			' For handler
            Dim handler As EventHandler = Me.ListSubItemChangedEvent
			If handler IsNot Nothing Then
				handler(Me, evArg)
				If evArg.Cancel Then
					evArg.lvSubItem.Text = evArg.strPrevValue
				End If
			End If
		End Sub

		Private Sub ListTextChange(pText As Control)
			Dim evArg As ListViewEx_EventArgs = DirectCast(pText.Tag, ListViewEx_EventArgs)
			If evArg.lvSubItem.Text <> pText.Text Then
				evArg.strPrevValue = evArg.lvSubItem.Text
				evArg.lvSubItem.Text = pText.Text

				' For handler
                Dim handler As EventHandler = Me.ListSubItemChangedEvent
				If handler IsNot Nothing Then
					handler(Me, evArg)
					If evArg.Cancel Then
						evArg.lvSubItem.Text = evArg.strPrevValue
					End If
				End If
			End If
		End Sub
	End Class

	Public Class ListViewEx_EventArgs
		Inherits CancelEventArgs
		Public lvItem As ListViewItem
		Public lvSubItem As ListViewItem.ListViewSubItem
		Public nSubItem As Integer
		Public nItem As Integer
		Public Tag As [Object]
		Public strPrevValue As String

		Public Sub New(_lvItem As ListViewItem, _lvSubItem As ListViewItem.ListViewSubItem, _nItem As Integer, _nSubItem As Integer)
			lvItem = _lvItem
			lvSubItem = _lvSubItem
			nItem = _nItem
			nSubItem = _nSubItem
		End Sub
	End Class
End Namespace

