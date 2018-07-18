

Class Application

	' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
	' can be handled in this file.

	Public Sub New()
		If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Netizener", "IsNotFirstInstall", 0) = 0 Then
			Call FirstInstall()
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Netizener", "IsNotFirstInstall", 1)
			Call InitAll()
		Else
			Call InitAll()
		End If
	End Sub

	'Public Sub New()
	'Call Start()
	'End Sub

End Class

