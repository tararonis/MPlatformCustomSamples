Namespace MControls
	Partial Class ListViewEx
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
			Me.SuspendLayout()
			' 
			' ListViewEx
			' 
			Me.FullRowSelect = True
			Me.GridLines = True
			Me.View = System.Windows.Forms.View.Details
			AddHandler Me.MouseDoubleClick, New System.Windows.Forms.MouseEventHandler(AddressOf Me.ListViewEx_MouseDoubleClick)
			AddHandler Me.MouseClick, New System.Windows.Forms.MouseEventHandler(AddressOf Me.ListViewEx_MouseClick)
			Me.ResumeLayout(False)

		End Sub

		#End Region
	End Class
End Namespace
