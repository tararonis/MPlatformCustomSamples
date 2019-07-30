Namespace MControls
	Partial Class FormAttributes
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
			Me.textBoxHelp = New System.Windows.Forms.TextBox()
			Me.mAttributesList1 = New MControls.MAttributesList()
			Me.SuspendLayout()
			' 
			' textBoxHelp
			' 
			Me.textBoxHelp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.textBoxHelp.ForeColor = System.Drawing.Color.Black
			Me.textBoxHelp.Location = New System.Drawing.Point(0, 350)
			Me.textBoxHelp.Multiline = True
			Me.textBoxHelp.Name = "textBoxHelp"
			Me.textBoxHelp.[ReadOnly] = True
			Me.textBoxHelp.Size = New System.Drawing.Size(284, 94)
			Me.textBoxHelp.TabIndex = 1
			' 
			' mAttributesList1
			' 
			Me.mAttributesList1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.mAttributesList1.FixedItems = False
			Me.mAttributesList1.FullRowSelect = True
			Me.mAttributesList1.GridLines = True
			Me.mAttributesList1.Location = New System.Drawing.Point(0, 0)
			Me.mAttributesList1.Name = "mAttributesList1"
			Me.mAttributesList1.Size = New System.Drawing.Size(284, 344)
			Me.mAttributesList1.TabIndex = 0
			Me.mAttributesList1.TimeForChange = 2
			Me.mAttributesList1.UseCompatibleStateImageBehavior = False
			Me.mAttributesList1.View = System.Windows.Forms.View.Details
			AddHandler Me.mAttributesList1.SelectedIndexChanged, New System.EventHandler(AddressOf Me.mAttributesList1_SelectedIndexChanged)
			' 
			' FormAttributes
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 444)
			Me.Controls.Add(Me.textBoxHelp)
			Me.Controls.Add(Me.mAttributesList1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
			Me.Name = "FormAttributes"
			Me.Text = "FormAttributes"
			AddHandler Me.Load, New System.EventHandler(AddressOf Me.FormAttributes_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private mAttributesList1 As MAttributesList
		Private textBoxHelp As System.Windows.Forms.TextBox
	End Class
End Namespace
