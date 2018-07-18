Imports CefSharp
Imports System.Text.RegularExpressions

Public Class BrowserTmp

#Region "Variables"
	Dim WithEvents Downloader As New Downloader
	Dim WithEvents BrowserLoad As New BrowserLoad
	Dim ErrorState As Boolean = False
#End Region

#Region "Constructor"
	Public Sub New()
		'Gathering Information
		DefaultPage = Config.Application.StartPage
		SearchEngine = Config.Application.DefaultSearchEngine

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

		' Browser Init() 
		CefSharpSettings.LegacyJavascriptBindingEnabled = True
		Browser.BrowserSettings.FileAccessFromFileUrls = CefState.Enabled
		Browser.BrowserSettings.UniversalAccessFromFileUrls = CefState.Enabled


		Browser.Address = DefaultPage
		Browser.DownloadHandler = Downloader
		Browser.LoadHandler = BrowserLoad
		Back.IsEnabled = False
		Forward.IsEnabled = False

		Browser.RegisterJsObject("NetizenerErrorHandler", New JSErrorHandler(Browser, Me), New BindingOptions() With {.Binder = BindingOptions.DefaultBinder.Binder})
		If DefaultPage = "" AndAlso SearchEngine = "" Then
			Throw New Exception("Settings Error!")
		End If

		IsSecurityActivated = True
		IsSSLSecurityActivated = True
		OnError = False
	End Sub
#End Region

#Region "Variables"
	Dim _ForwardEnabled As Boolean
	Dim _BackEnabled As Boolean
#End Region

#Region "Properties"
	ReadOnly Property DefaultPage As String
	ReadOnly Property SearchEngine As String
	ReadOnly Property OnLoad As Boolean
	ReadOnly Property LastError As String
	Property OnError As Boolean
	Property IsSecurityActivated As Boolean
	Property IsSSLSecurityActivated As Boolean

	Property BackEnabled As Boolean
		Get
			Return _BackEnabled
		End Get
		Set(value As Boolean)
			If value Then
				Back.IsEnabled = True
				_BackEnabled = True

				Dim img As New BitmapImage()
				img.BeginInit()
				img.UriSource = New Uri("pack://application:,,,/Resources/left-arrow-enable.png")
				img.EndInit()

				IconForward.Fill = New ImageBrush(img)
			Else
				Back.IsEnabled = False
				_BackEnabled = False

				Dim img As New BitmapImage()
				img.BeginInit()
				img.UriSource = New Uri("pack://application:,,,/Resources/left-arrow-disable.png")
				img.EndInit()

				IconForward.Fill = New ImageBrush(img)
			End If
		End Set
	End Property

	Property ForwardEnabled As Boolean
		Get
			Return _ForwardEnabled
		End Get
		Set(value As Boolean)
			If value Then
				Forward.IsEnabled = True
				_ForwardEnabled = True

				Dim img As New BitmapImage()
				img.BeginInit()
				img.UriSource = New Uri("pack://application:,,,/Resources/right-arrow-enable.png")
				img.EndInit()

				IconForward.Fill = New ImageBrush(img)
			Else
				Forward.IsEnabled = False
				_ForwardEnabled = False

				Dim img As New BitmapImage()
				img.BeginInit()
				img.UriSource = New Uri("pack://application:,,,/Resources/right-arrow-disable.png")
				img.EndInit()

				IconForward.Fill = New ImageBrush(img)
			End If
		End Set
	End Property
#End Region

	Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
		If Browser.CanGoBack Then
			Browser.Back()
		End If
	End Sub

	Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
		If Browser.CanGoForward Then
			Browser.Forward()
		End If
	End Sub

	Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
		If e.Key = Key.Enter AndAlso Not String.IsNullOrWhiteSpace(URL.Text) Then
			If URLValidator(URL.Text) Then
				Browser.Load(URL.Text)
			Else
				Browser.Load(SearchPage(URL.Text))
			End If
		ElseIf Not String.IsNullOrWhiteSpace(URL.Text) Then
			If URLValidator(URL.Text) Then
				Dim Regex As New Regex("^(https:|ftps:)\/\/")
				If Regex.IsMatch(URL.Text, 0) Then
					Dim img As New BitmapImage()
					img.BeginInit()
					img.UriSource = New Uri("pack://application:,,,/Resources/https.png")
					img.EndInit()

					BarIcon.Source = img
				Else
					Dim img As New BitmapImage()
					img.BeginInit()
					img.UriSource = New Uri("pack://application:,,,/Resources/http.png")
					img.EndInit()

					BarIcon.Source = img
				End If
			Else
				Dim img As New BitmapImage()
				img.BeginInit()
				img.UriSource = New Uri("pack://application:,,,/Resources/search.png")
				img.EndInit()

				BarIcon.Source = img
			End If
		Else
			Dim img As New BitmapImage()
			img.BeginInit()
			img.UriSource = New Uri("pack://application:,,,/Resources/search.png")
			img.EndInit()

			BarIcon.Source = img
		End If
	End Sub

	Private Function URLValidator(ByVal URL As String) As Boolean
		Dim sample As Uri
		Return Uri.TryCreate(URL, UriKind.Absolute, sample)
	End Function

	Private Function SearchPage(ByVal Query As String) As String
		Dim FormattedQuery As String = Query.Replace(" ", "+")
		Dim Hasil As String = ""

		Hasil = String.Format(DefaultSearchEngine.URL, FormattedQuery)

		Return Hasil
	End Function

	Private Sub Browser_FrameLoadEnd(sender As Object, e As FrameLoadEndEventArgs)
		Dispatcher.BeginInvoke(Sub()
								   If ErrorState Then
									   Dim img As New BitmapImage()
									   img.BeginInit()
									   img.UriSource = New Uri("pack://application:,,,/Resources/cancel.png")
									   img.EndInit()

									   BarIcon.Source = img
								   Else
									   URL.Text = e.Url

									   Dim Regex As New Regex("^(https:|ftps:)\/\/")
									   If Regex.IsMatch(URL.Text, 0) Then
										   Dim img As New BitmapImage()
										   img.BeginInit()
										   img.UriSource = New Uri("pack://application:,,,/Resources/https.png")

										   img.EndInit()

										   BarIcon.Source = img
									   Else
										   Dim img As New BitmapImage()
										   img.BeginInit()
										   img.UriSource = New Uri("pack://application:,,,/Resources/http.png")
										   img.EndInit()

										   BarIcon.Source = img
									   End If
								   End If

								   BackEnabled = Browser.CanGoBack
								   ForwardEnabled = Browser.CanGoForward

							   End Sub)
	End Sub

	Private Sub Browser_LoadingStateChanged(sender As Object, e As LoadingStateChangedEventArgs)
		'TODO: Tambahin tanda loading...
		If e.IsLoading Then
			Dispatcher.BeginInvoke(Sub()
									   _OnLoad = True

									   Dim img As New BitmapImage()
									   img.BeginInit()
									   img.UriSource = New Uri("pack://application:,,,/Resources/cancel.png")
									   img.EndInit()

									   RefreshIcon.Fill = New ImageBrush(img)

									   Me.Title = "Loading..."
								   End Sub)
		Else
			Dispatcher.BeginInvoke(Sub()
									   _OnLoad = False

									   Dim img As New BitmapImage()
									   img.BeginInit()
									   img.UriSource = New Uri("pack://application:,,,/Resources/refresh.png")
									   img.EndInit()

									   RefreshIcon.Fill = New ImageBrush(img)

									   Me.Title = If(Browser.Title, "Netizener")

									   IsSSLSecurityActivated = True
									   IsSecurityActivated = True
								   End Sub)
		End If
	End Sub

	Private Sub Refresh_Click(sender As Object, e As RoutedEventArgs)
		If OnLoad Then
			Browser.Stop()
		ElseIf OnError Then
			Browser.Load(LastError)
			OnError = False
		Else
			Browser.Reload()
		End If
	End Sub

	Private Sub Browser_LoadError(sender As Object, e As LoadErrorEventArgs)
		Dim ErrorPage As String = e.FailedUrl
		_LastError = ErrorPage
		OnError = True

		Select Case -e.ErrorCode
			Case 10, 100, 101, 102, 103, 104, 105, 106, 108, 109, 118, 15, 19, 7, 8, 9
				ErrorState = True

				Dim InstallPath As String = Config.Application.InstallPath
				Dim ErrorPath As String = IO.Path.Combine(InstallPath, "Handler", -e.ErrorCode & ".html")

				Browser.Load(ErrorPath)
			Case 6
				Dim FileName As String = IO.Path.GetFileName(ErrorPage)

				ErrorState = True

				Dim InstallPath As String = Config.Application.InstallPath
				Dim ErrorPath As String = IO.Path.Combine(InstallPath, "Handler", -e.ErrorCode & ".html")

				Browser.Load(String.Format("{0}?file={1}", ErrorPath, FileName))
			Case 19
				If IsSecurityActivated Then
					ErrorState = True

					Dim InstallPath As String = Config.Application.InstallPath
					Dim ErrorPath As String = IO.Path.Combine(InstallPath, "Handler", -e.ErrorCode & ".html")

					Browser.Load(ErrorPath)
				End If
			Case 107
				If IsSSLSecurityActivated Then
					ErrorState = True

					Dim InstallPath As String = Config.Application.InstallPath
					Dim ErrorPath As String = IO.Path.Combine(InstallPath, "Handler", -e.ErrorCode & ".html")

					Browser.Load(ErrorPath)
				End If
		End Select
	End Sub

	Private Sub Border_MouseDown(sender As Object, e As MouseButtonEventArgs)
		URL.SelectAll()
	End Sub

	Private Sub Browser_Loaded(sender As Object, e As RoutedEventArgs)
		If ErrorState Then
			URL.Text = LastError

			Dim img As New BitmapImage()
			img.BeginInit()
			img.UriSource = New Uri("pack://application:,,,/Resources/cancel.png")
			img.EndInit()

			BarIcon.Source = img

			ErrorState = False
		End If
	End Sub
End Class

Class JSErrorHandler
	Property LastErrorPage As String
	Private Shared BrowserInstance As Wpf.ChromiumWebBrowser
	Private Shared FormInstance As BrowserTmp

	Public Sub New(browser As Wpf.ChromiumWebBrowser, Form As BrowserTmp)
		BrowserInstance = browser
		FormInstance = Form
	End Sub

	Public Sub Reload()
		BrowserInstance.Load(FormInstance.LastError)
		FormInstance.OnError = False
	End Sub

	Public Sub FindFile()

		Dim ErrorURI As String = FormInstance.LastError
		Dim Path As String = IO.Path.GetDirectoryName(ErrorURI)
		Dim FileName As String = IO.Path.GetFileName(ErrorURI)

		Dim Query As String = String.Format("search:query=filename:{0}{1}{0}&crumb=location:{2}", Chr(34), (FileName.Split(".")).First(), Path)
		Process.Start(New ProcessStartInfo(Query))
	End Sub

	Public Sub Troubleshoot()
		Dim Path As String = IO.Path.Combine(Environment.SystemDirectory, "control.exe")
		Process.Start(Path, "/name Microsoft.Troubleshooting")
	End Sub

	Public Sub Back()
		BrowserInstance.Back()
		FormInstance.OnError = False
	End Sub

	Public Sub RunAnywayVirus()
		If FormInstance.OnError Then
			FormInstance.IsSecurityActivated = False
			Reload()
			FormInstance.OnError = False
		End If
	End Sub

	Public Sub RunAnywayPage()
		If FormInstance.OnError Then
			FormInstance.IsSSLSecurityActivated = False
			Reload()

			FormInstance.OnError = False
		End If
	End Sub
End Class