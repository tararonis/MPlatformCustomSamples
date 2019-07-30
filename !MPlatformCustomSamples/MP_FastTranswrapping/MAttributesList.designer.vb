Namespace MControls
	Partial Class MAttributesList
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.columnName = New System.Windows.Forms.ColumnHeader()
			Me.columnValue = New System.Windows.Forms.ColumnHeader()
			Me.SuspendLayout()
			' 
			' columnName
			' 
			Me.columnName.Text = "Name"
			' 
			' columnValue
			' 
			Me.columnValue.Text = "Value"
			Me.columnValue.Width = 120
			' 
			' MAttributesList
			' 
			Me.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnName, Me.columnValue})
			Me.Size = New System.Drawing.Size(210, 214)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private columnName As System.Windows.Forms.ColumnHeader
		Private columnValue As System.Windows.Forms.ColumnHeader
	End Class
End Namespace
