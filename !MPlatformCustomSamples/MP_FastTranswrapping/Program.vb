Imports System.Threading
Imports System.Windows.Forms

NotInheritable Class Program
	Private Sub New()
	End Sub
	''' <summary>
	''' The main entry point for the application.
	''' </summary>
	<STAThread> _
	Friend Shared Sub Main()
		AddHandler Application.ThreadException, AddressOf Application_ThreadException
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
		Application.EnableVisualStyles()
		Application.SetCompatibleTextRenderingDefault(False)
		Application.Run(New MainForm())
	End Sub
	Private Shared Sub Application_ThreadException(sender As Object, e As ThreadExceptionEventArgs)
		' All exceptions thrown by the main thread are handled over this method
		MessageBox.Show("Error occured: " & e.Exception.Message & vbCr & vbLf & e.Exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
	End Sub

	Private Shared Sub CurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
		Try
			Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
			MessageBox.Show("Fatal Error" & ex.Message & vbCr & vbLf & ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
		Finally
			Application.[Exit]()
		End Try
	End Sub
End Class
