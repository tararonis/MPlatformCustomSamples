Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports MPLATFORMLib

Namespace MControls
	Public Partial Class FormAttributes
		Inherits Form
		Public m_pAttributes As IMAttributes

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property FixedItems() As Boolean
			Get
				Return mAttributesList1.FixedItems
			End Get
			Set
				mAttributesList1.FixedItems = value
			End Set
		End Property

		Private Sub FormAttributes_Load(sender As Object, e As EventArgs)
			' Temp fix (TODO: make default via default values)
			'mAttributesList1.strDefaultTypes = null;
			'mAttributesList1.strDefaultAttributes = null;
			'mAttributesList1.bShowDefaultAttributes = false;
			'mAttributesList1.BShowDefaultTypes = false;

			mAttributesList1.SetControlledObject(m_pAttributes)
		End Sub

		Private Sub mAttributesList1_SelectedIndexChanged(sender As Object, e As EventArgs)
			' Update help
			If mAttributesList1.SelectedIndices.Count > 0 Then
				Dim strName As String = mAttributesList1.SelectedItems(0).SubItems(0).Text

				Dim strHelp As String
				m_pAttributes.AttributesInfoGet(strName, MPLATFORMLib.eMInfoType.eMIT_Help, strHelp)
				textBoxHelp.Text = strHelp
			End If
		End Sub
	End Class
End Namespace
