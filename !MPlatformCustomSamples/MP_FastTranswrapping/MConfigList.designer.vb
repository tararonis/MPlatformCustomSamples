Namespace MControls
	Partial Class MConfigList
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
			Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
			Me.SuspendLayout()
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "Type"
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "Selected Option"
			Me.columnHeader2.Width = 82
			' 
			' MConfigList
			' 
			Me.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
			Me.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.Size = New System.Drawing.Size(120, 60)
			AddHandler Me.MouseDoubleClick, New System.Windows.Forms.MouseEventHandler(AddressOf Me.MConfigList_MouseDoubleClick)
			AddHandler Me.ListSubItemChanged, New System.EventHandler(AddressOf Me.MConfigList_ListSubItemChanged)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
	End Class
End Namespace
