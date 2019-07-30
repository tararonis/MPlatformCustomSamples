Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports MPLATFORMLib

Namespace MControls
	Public Partial Class MConfigList
		Inherits ListViewEx
		Private m_pConfigRoot As IMConfig

		Public Event OnConfigChanged As EventHandler

		Public Sub New()
			InitializeComponent()

			Columns(1).Tag = New ComboBox()
		End Sub

		Public Function SetControlledObject(pObject As [Object]) As [Object]
			Dim pOld As [Object] = DirectCast(m_pConfigRoot, [Object])
			Try
				m_pConfigRoot = DirectCast(pObject, IMConfig)

				UpdateList()
			Catch generatedExceptionName As System.Exception
			End Try

			Return pOld
		End Function

		Private Sub UpdateList()
			Items.Clear()
			Focus()

			Dim nCount As Integer = 0
			m_pConfigRoot.ConfigTypesGetCount(nCount)
			For i As Integer = 0 To nCount - 1
				Dim strType As String
				m_pConfigRoot.ConfigTypesGetByIndex(i, strType)

				UpdateType(m_pConfigRoot, strType)
			Next

			For i As Integer = 0 To Columns.Count - 1
				Columns(i).Width = -2
			Next
		End Sub

		Private Sub UpdateType(pConfig As IMConfig, sType As String)
			Dim lvItem As ListViewItem = AddNewItem(sType, 0)
			Dim pCombo As ComboBox = DirectCast(lvItem.SubItems(1).Tag, ComboBox)

			Dim nCount As Integer = 0
			pConfig.ConfigGetCount(sType, nCount)
			For i As Integer = 0 To nCount - 1
				Dim strName As String
				pConfig.ConfigGetByIndex(sType, i, strName)

				pCombo.Items.Add(strName)
			Next

			Dim strNameSel As String
			Dim pConfigProps As IMAttributes
			pConfig.ConfigGet(sType, strNameSel, pConfigProps)
			lvItem.Tag = pConfigProps
			' Used for additional column attibutes
			If pCombo.Items.Count > 0 AndAlso strNameSel IsNot Nothing Then
				Dim nIndex As Integer = pCombo.FindStringExact(strNameSel)
				pCombo.SelectedIndex = If(nIndex >= 0, nIndex, 0)
			End If

			pCombo.Enabled = If(pCombo.Items.Count > 1, True, False)

			If pConfigProps IsNot Nothing Then
				' Update attributes

				For i As Integer = 2 To Columns.Count - 1
					Dim nHave As Integer = 0
					Dim strValue As String = Nothing
					Dim strAttrName As String = Columns(i).Text

					If Columns(i).Tag IsNot Nothing AndAlso Columns(i).Tag.[GetType]().Name = "String" Then
						strAttrName = DirectCast(Columns(i).Tag, String)
					End If

					pConfigProps.AttributesHave(strAttrName, nHave, strValue)
					If strValue IsNot Nothing Then
						While lvItem.SubItems.Count <= i
							lvItem.SubItems.Add("")
						End While

						lvItem.SubItems(i).Text = strValue
						lvItem.SubItems(i).Tag = New TextBox()
					ElseIf lvItem.SubItems.Count > i Then
						' For now allow edit
						lvItem.SubItems(i).Tag = Nothing


					End If
				Next
			End If
		End Sub

		Private Sub MConfigList_ListSubItemChanged(sender As Object, e As EventArgs)
			Dim lvEvent As ListViewEx_EventArgs = DirectCast(e, ListViewEx_EventArgs)

			If lvEvent.nSubItem = 1 Then
				Dim strNameSel As String
				Dim pConfigProps As IMAttributes
				m_pConfigRoot.ConfigGet(lvEvent.lvItem.SubItems(0).Text, strNameSel, pConfigProps)

				If strNameSel <> lvEvent.lvSubItem.Text Then
					m_pConfigRoot.ConfigSet(lvEvent.lvItem.SubItems(0).Text, lvEvent.lvSubItem.Text, pConfigProps)

					' The list could be changed
					' TODO: Keep selection
					UpdateList()

					RaiseEvent OnConfigChanged(Me, e)
				End If
			ElseIf lvEvent.nSubItem > 1 Then
				Dim pConfigProps As IMAttributes = DirectCast(lvEvent.lvItem.Tag, IMAttributes)

				' The attribute name could be column name or tag (for allow to set user-friendly columns names)
				Dim strAttrName As String = Columns(lvEvent.nSubItem).Text
				If Columns(lvEvent.nSubItem).Tag IsNot Nothing AndAlso Columns(lvEvent.nSubItem).Tag.[GetType]().Name = "String" Then
					strAttrName = DirectCast(Columns(lvEvent.nSubItem).Tag, String)
				End If

				pConfigProps.AttributesStringSet(strAttrName, lvEvent.lvSubItem.Text)

				RaiseEvent OnConfigChanged(Me, e)
			End If
		End Sub

		Private Sub MConfigList_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			If SelectedItems.Count > 0 Then
				Dim strNameSel As String
				Dim pConfigProps As IMAttributes
				m_pConfigRoot.ConfigGet(SelectedItems(0).SubItems(0).Text, strNameSel, pConfigProps)

				Try
					Dim attr As IMAttributes = DirectCast(pConfigProps, IMAttributes)
					Dim nCount As Integer
					attr.AttributesInfoGetCount(nCount)

				Catch generatedExceptionName As System.Exception
				End Try


				' We show attributes for selected item 
				Dim formAttributes As New FormAttributes()
				formAttributes.Text = strNameSel
				formAttributes.m_pAttributes = pConfigProps
				formAttributes.FixedItems = True

				formAttributes.ShowDialog()

				RaiseEvent OnConfigChanged(Me, e)


				UpdateList()
			End If
		End Sub

	End Class
End Namespace
