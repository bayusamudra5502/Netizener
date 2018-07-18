Imports Dragablz
Imports Netizeners

Public Class MainWindow
	Dim i As Integer = 1
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Dim TabItemPlus As New TabItem
		TabItemPlus.Header = "+"

		TabControl.Items.Add(TabItemPlus)

		Dim TabItem As New TabItem
		TabItem.Header = "Tab 1"
		Dim Frame As New Frame
		Dim frm As Page = New BrowserTmp
		Frame.Content = frm
		TabItem.Content = Frame

		TabControl.Items.Add(TabItem)
	End Sub

	Private Sub TabData_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

	End Sub
End Class