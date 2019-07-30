Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.Win32

Class CheckVersionClass
	Public Shared Function GetVersion() As String
		Dim sVersion As String = SearchIstalledVersion(32)

		Return If(String.IsNullOrEmpty(sVersion), SearchIstalledVersion(64), sVersion)
	End Function

	Private Shared Function SearchIstalledVersion(bit As Integer) As String
		Dim subKey As String = String.Empty
		Dim m__ReadKey As RegistryKey
		Dim m_ReadSubKey As RegistryKey

		Select Case bit
			Case 64
				subKey = "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\"
				Exit Select
			Case 32
				subKey = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\"
				Exit Select
		End Select

		m__ReadKey = Registry.LocalMachine.OpenSubKey(subKey)
		Dim subKeyNames As String() = m__ReadKey.GetSubKeyNames()

		For Each subKeyName As String In subKeyNames
			m_ReadSubKey = Registry.LocalMachine.OpenSubKey(subKey & subKeyName)

			Dim subValuesNames As String() = m_ReadSubKey.GetValueNames()
			For Each subname As String In subValuesNames
				If subname = "DisplayName" Then
					Try
						Dim displayNameValue As String = DirectCast(m_ReadSubKey.GetValue(subname), String)
						If displayNameValue.Contains("MPlatform") Then
							Return DirectCast(m_ReadSubKey.GetValue("DisplayVersion"), String)
						End If
					Catch
					End Try
				End If
			Next
		Next

		Return String.Empty
	End Function
End Class
