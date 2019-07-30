Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Specialized
Imports MPLATFORMLib


Namespace MControls
	Public Partial Class MAttributesList
		Inherits ListViewEx
		Private m_pAttributes As IMAttributes
		Private m_pElement As IMElement
		' Optionally
		Private m_ElementDescriptors As List(Of MElemementDescriptor)

		Public Property ElementDescriptors() As List(Of MElemementDescriptor)
			Get
				Return m_ElementDescriptors
			End Get
			Set
				m_ElementDescriptors = value
			End Set
		End Property

		Public Sub New()
			InitializeComponent()

			Columns(0).Tag = New TextBox()
			Columns(1).Tag = New TextBox()

			AddHandler Me.ListSubItemChanged, New EventHandler(AddressOf MAttributesList_ListSubItemChanged)
			AddHandler Me.ListSubItemOnStartChange, New EventHandler(AddressOf MAttributesList_ListSubItemOnStartChange)
			AddHandler Me.KeyDown, New KeyEventHandler(AddressOf MAttributesList_KeyDown)

			Me.ShowItemToolTips = True
		End Sub

		Private Sub MAttributesList_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyData = Keys.Delete AndAlso Me.SelectedItems IsNot Nothing AndAlso Me.SelectedItems.Count > 0 AndAlso Me.SelectedItems(0).Tag IsNot Nothing Then
				Dim lvItem As ListViewItem = Me.SelectedItems(0)
				Dim strFullName As String = lvItem.Tag.ToString() & lvItem.Text
				Try
					' Use try as attribute could be displayed as default
					m_pAttributes.AttributesRemove(strFullName)
				Catch generatedExceptionName As System.Exception
				End Try


				UpdateList()
			End If
		End Sub

		Public Function SetControlledObject(pObject As [Object]) As [Object]
			Dim pOld As [Object] = DirectCast(m_pAttributes, [Object])
			Try
				m_pAttributes = DirectCast(pObject, IMAttributes)
				m_pElement = Nothing
				Try
					m_pElement = DirectCast(pObject, IMElement)
				Catch generatedExceptionName As System.Exception
				End Try

				UpdateList()
			Catch generatedExceptionName As System.Exception
			End Try

			Return pOld
		End Function

		Private m_dblTimeForChange As Double = 2.0
		Public Property TimeForChange() As Double
			Get
				Return m_dblTimeForChange
			End Get
			Set
				m_dblTimeForChange = value
			End Set
		End Property

		' Allow to show only fixed (items present in info list)
		Private m_bFixedItems As Boolean = False
		Public Property FixedItems() As Boolean
			Get
				Return m_bFixedItems
			End Get
			Set
				m_bFixedItems = value
			End Set
		End Property

		Public Sub UpdateList()
			'Remember selection and scroll position
			EndEdit()

			Dim nTopItemIndex As Integer = -1
			If Me.TopItem IsNot Nothing AndAlso Me.TopItem.Index >= 0 Then
				nTopItemIndex = Me.TopItem.Index
			End If

			Dim nSelectedIndex As Integer = -1
			If Me.SelectedIndices IsNot Nothing AndAlso Me.SelectedIndices.Count > 0 Then
				nSelectedIndex = Me.SelectedIndices(0)
			End If

			Items.Clear()

			Dim mapTypesPos As New HybridDictionary()
			Dim mapAttributes As New ListDictionary()

			mapTypesPos.Clear()
			mapTypesPos.Add("", AddDelimer(""))

			Dim nCount As Integer = 0

			' Get nodes info
			Dim strNodes As String = Nothing, strDescription As String = Nothing
			Try
				' Try element
				Dim pElement As IMElement = DirectCast(m_pAttributes, IMElement)
				pElement.ElementInfoGet("", strDescription)
				pElement.ElementInfoGet("show_nodes", strNodes)
			Catch generatedExceptionName As System.Exception
			End Try
			If strNodes Is Nothing Then
				Try
					' Try node
					Dim pNode As IMNode = DirectCast(m_pAttributes, IMNode)
					pNode.NodeInfoGet("", strDescription)
					pNode.NodeInfoGet("show_nodes", strNodes)
				Catch generatedExceptionName As System.Exception
				End Try
			End If

			If strNodes IsNot Nothing Then
				Dim arrNodes As String() = strNodes.Split(New Char() {","C, " "C}, StringSplitOptions.RemoveEmptyEntries)
				For i As Integer = 0 To arrNodes.Length - 1
					mapTypesPos.Add(arrNodes(i), AddDelimer(arrNodes(i)))
				Next
			End If

			' Default attributes 
			m_pAttributes.AttributesInfoGetCount(nCount)
			For i As Integer = 0 To nCount - 1
				Dim strName As String
				m_pAttributes.AttributesInfoGetByIndex(i, strName)

				If Not mapAttributes.Contains(strName) Then
					mapAttributes.Add(strName, Nothing)
				End If
			Next

			' Custom attributes
			If Not m_bFixedItems Then
				m_pAttributes.AttributesGetCount(nCount)
				For i As Integer = 0 To nCount - 1
					Dim strName As String, strValue As String
					m_pAttributes.AttributesGetByIndex(i, strName, strValue)
					If Not mapAttributes.Contains(strName) Then
						mapAttributes.Add(strName, Nothing)
					End If
				Next
			End If

			' Insert names and attributes into list
			For Each entry As DictionaryEntry In mapAttributes
				Dim strFullName As String = DirectCast(entry.Key, String)
				Dim strName As String = strFullName
				Dim strPrefix As String = GetPrefix(strName)

				If Not mapTypesPos.Contains(strPrefix) Then
					mapTypesPos.Add(strPrefix, AddDelimer(strPrefix))
				End If

				Dim nPos As Integer = Items.IndexOf(DirectCast(mapTypesPos(strPrefix), ListViewItem))

				Dim bHaveValue As Integer = 0

				Dim strValue As String
				m_pAttributes.AttributesHave(strFullName, bHaveValue, strValue)

				Dim strHelp As String
				m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Help, strHelp)

				Dim strType As String
				m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Type, strType)

				Dim strDefault As String
				m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Default, strDefault)

				Dim strValues As String = ""
				m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Values, strValues)

				If bHaveValue = 0 Then
					strValue = strDefault
				End If

				Dim strHelpString As String = ""
				m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Help, strHelpString)

				Dim lvItem As ListViewItem = If(nPos >= 0, Items.Insert(nPos, strName), Items.Add(strName))
				If strHelpString <> String.Empty AndAlso strHelpString <> "null" Then
					lvItem.ToolTipText = strHelpString
				End If
				Dim lvSubItem As ListViewItem.ListViewSubItem = lvItem.SubItems.Add(strValue)
				If (strType = "option" OrElse strType = "option_fixed") AndAlso strValues IsNot Nothing AndAlso strValues <> "" Then
					' The option values may be divided by commas or by '|' if values contain commas
					Dim arrValues As String() = If(strValues.Contains("|"), strValues.Split("|"C), strValues.Split(","C))
					If arrValues.Length > 1 Then
						Dim pCombo As ComboBox = SubItem_SetCombo(lvSubItem, Nothing, If(strType = "option_fixed", ComboBoxStyle.DropDownList, ComboBoxStyle.DropDown))
						For k As Integer = 0 To arrValues.Length - 1
							pCombo.Items.Add(arrValues(k).Trim())
						Next
					End If
				ElseIf strType = "bool" Then
					Dim pCombo As ComboBox = SubItem_SetCombo(lvSubItem, Nothing, ComboBoxStyle.DropDownList)
					pCombo.Items.Add("true")
					pCombo.Items.Add("false")
				ElseIf strType = "path" Then
					Dim pDialog As New OpenFileDialog()
					pDialog.Title = strHelp
					Dim textWithDialog As New TextBox()
					textWithDialog.Tag = pDialog
					SubItem_SetControl(lvSubItem, textWithDialog)
				End If

				If strPrefix <> "" Then
					strPrefix += "::"
				End If
				lvItem.Tag = strPrefix
				lvItem.UseItemStyleForSubItems = False
				lvItem.BackColor = Color.White
				If strValue <> strDefault Then
					' User modified values select by black
					lvSubItem.ForeColor = Color.Black
				Else
					lvSubItem.ForeColor = Color.Gray
				End If
			Next


			Columns(0).Width = -2
			Columns(1).Width = -2

			'Restore selection and scroll
			If nSelectedIndex > 0 AndAlso Me.Items.Count - 1 >= nSelectedIndex Then
				Me.Items(nSelectedIndex).Selected = True
			End If
			If nTopItemIndex > 0 AndAlso Me.Items.Count - 1 >= nTopItemIndex Then
				Me.TopItem = Me.Items(nTopItemIndex)
			End If

		End Sub

		Private Function AddDelimer(strName As String) As ListViewItem
			Dim strPrefix As String = ""
			Dim lvItem As ListViewItem = Nothing
			If strName <> "" Then
				strPrefix = strName & "::"

				' Add delimer
				lvItem = Items.Add(strName)
				lvItem.UseItemStyleForSubItems = True
				lvItem.BackColor = Color.FromArgb(222, 232, 254)
				lvItem.SubItems.Add("")
			End If

			If Not m_bFixedItems Then
				lvItem = Items.Add("<Add new>")
				lvItem.Tag = strPrefix
				lvItem.BackColor = Color.White
				lvItem.UseItemStyleForSubItems = True
			End If

			Return lvItem
		End Function

		Private Function GetPrefix(ByRef strName As String) As String
			Dim strPrefix As String = ""
			Dim nDelimer As Integer = strName.IndexOf("::")
			If nDelimer >= 0 Then
				strPrefix = strName.Substring(0, nDelimer)
				strName = strName.Substring(nDelimer + 2)
			End If

			Return strPrefix
		End Function


		Private Sub MAttributesList_ListSubItemOnStartChange(sender As Object, e As EventArgs)
			Dim lvArg As ListViewEx_EventArgs = DirectCast(e, ListViewEx_EventArgs)

			' Check for separator
			If lvArg.lvItem.Tag Is Nothing Then
				lvArg.Cancel = True
			End If

			' Check for property name (edit only if <new name> - one subitem)
			If lvArg.nSubItem = 0 AndAlso lvArg.lvItem.SubItems.Count > 1 Then
				lvArg.Cancel = True
			End If
		End Sub

		Private Sub MAttributesList_ListSubItemChanged(sender As Object, e As EventArgs)
			Dim lvArg As ListViewEx_EventArgs = DirectCast(e, ListViewEx_EventArgs)

			If lvArg.nSubItem = 0 Then
				' Add subitem for value
					'BeginEdit(lvArg.nItem, 1);
				lvArg.lvItem.SubItems.Add("")
			Else
				' Update attribute
				Dim sPrefix As String = DirectCast(lvArg.lvItem.Tag, String)
				Dim sName As String = sPrefix & lvArg.lvItem.SubItems(0).Text
				Dim sValue As String = lvArg.lvItem.SubItems(1).Text


				' Check for new element
				Dim bHave As Integer = 0
				Dim sOldValue As String
				m_pAttributes.AttributesHave(sName, bHave, sOldValue)

				Dim sDefValue As String
				m_pAttributes.AttributesInfoGet(sName, eMInfoType.eMIT_Default, sDefValue)

				' Check for remove attributes
				If sValue = "" AndAlso bHave = 1 Then
					m_pAttributes.AttributesRemove(sName)

					lvArg.lvItem.SubItems(1).Text = sDefValue
					lvArg.lvItem.SubItems(1).ForeColor = Color.Gray
				Else
					If m_pElement IsNot Nothing Then
						'm_pElement.ElementMultipleSet( sName+"="+sValue, m_dblTimeForChange);
						m_pElement.ElementStringSet(sName, sValue, m_dblTimeForChange)
					Else
						m_pAttributes.AttributesStringSet(sName, sValue)
					End If

					' TODO: Compare with defaults
					lvArg.lvItem.SubItems(1).ForeColor = Color.Black

					If bHave = 0 AndAlso Not m_bFixedItems Then
						UpdateList()
					ElseIf sValue = "" OrElse sValue = sDefValue Then
						lvArg.lvItem.SubItems(1).Text = sDefValue
						lvArg.lvItem.SubItems(1).ForeColor = Color.Gray
					End If


				End If
			End If
		End Sub

	End Class
End Namespace
