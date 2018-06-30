Imports MahApps.Metro.Controls

Public Class AboutClass
	Inherits MetroWindow

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

	Private Sub BtnOK_Click(sender As Object, e As RoutedEventArgs) Handles BtnOK.Click
		Me.Close()
	End Sub
End Class
