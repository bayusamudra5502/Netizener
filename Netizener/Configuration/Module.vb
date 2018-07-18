Imports System.IO
Imports System.Drawing

Module Foreign
	<Runtime.InteropServices.DllImport("gdi32.dll")>
	Public Function DeleteObject(ByVal hObj As IntPtr) As Boolean
	End Function
End Module

Module Imaging
	Public Function BitmapImageConverter(bitmap As Bitmap) As BitmapImage
		Dim hBitmap As IntPtr = bitmap.GetHbitmap
		Dim result As BitmapImage = Nothing

		Try
			result = CType(Interop.Imaging.CreateBitmapSourceFromHBitmap(
				hBitmap,
				IntPtr.Zero,
				Int32Rect.Empty,
				BitmapSizeOptions.FromEmptyOptions()
				), BitmapImage)

		Finally
			DeleteObject(hBitmap)
		End Try

		Return result
	End Function
End Module

Module Config
	ReadOnly Property Application As Configuration
	ReadOnly Property SearchEngines As List(Of SearchEngine)
	ReadOnly Property DefaultSearchEngine As SearchEngine
	ReadOnly Property FileExtension As List(Of Extension)
	ReadOnly Property AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

	Public Sub InitAll()
		InitConfig()
		InitSearchEngine()
		InitExtension()
	End Sub

	Public Sub InitConfig()
		Try
			Dim Path As String = IO.Path.Combine(AppData, "Netizener", "Config", "Netizener.conf")
			Dim Stream As FileStream = File.Open(Path, FileMode.Open)
			Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

			_Application = CType(formatter.Deserialize(Stream), Configuration)

			Stream.Close()
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while loading config. Read log file for futher information.", vbCritical, "System Error", True)

			End
		End Try
	End Sub

	Public Sub InitSearchEngine()
		Try
			_SearchEngines = New List(Of SearchEngine)
			For Each SearchEngineFile As String In Application.SearchEngines
				Dim Path As String = IO.Path.Combine(Application.SearchEnginePath, SearchEngineFile)

				Dim Stream As FileStream = File.Open(Path, FileMode.Open)
				Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

				Dim SearchEngineConfig As SearchEngine = CType(formatter.Deserialize(Stream), SearchEngine)

				Stream.Close()

				_SearchEngines.Add(SearchEngineConfig)
			Next

			'SET DEFAULT SC
			Dim DefaultSearchEngineAppConfig As String = Application.DefaultSearchEngine

			_DefaultSearchEngine = (From sc As SearchEngine In SearchEngines
									Where sc.Name = DefaultSearchEngineAppConfig
									Select sc).First
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while loading config. Read log file for futher information.", vbCritical, "System Error", True)

			End
		End Try
	End Sub

	Public Sub InitExtension()
		Try
			Dim Path As String = IO.Path.Combine(AppData, "Netizener", "Theme", "Default.thm")
			Dim Stream As FileStream = File.Open(Path, FileMode.Open)
			Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

			_FileExtension = CType(formatter.Deserialize(Stream), List(Of Extension))

			Stream.Close()
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while loading config. Read log file for futher information.", vbCritical, "System Error", True)

			End
		End Try
	End Sub

	Public Sub MakeConfigDefault()
		Try
			Dim Searchs As New List(Of String)
			Searchs.Add("Google.scx")
			Searchs.Add("Bing.scx")
			Searchs.Add("Yahoo.scx")
			Searchs.Add("Ask.scx")
			Searchs.Add("Aol.scx")

			Dim Conf As New Configuration() With {
				.InstallPath = AppDomain.CurrentDomain.BaseDirectory,
				.ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Netizener", "Config"),
				.LogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Netizener", "Log"),
				.SearchEnginePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Netizener", "Search"),
				.LibraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Netizener", "Library"),
				.ActiveLibrary = Nothing,
				.ConnectionString = String.Format("Data Source={0};Version=3;", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database", "database.db")),
				.StartPage = "https://www.google.com/",
				.SearchEngines = Searchs,
				.DefaultSearchEngine = "Google",
				.AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
			}

			'MAKE!!
			Dim Stream As FileStream = File.Create(Path.Combine(Path.Combine(AppData, "Netizener", "Config"), "Netizener.conf"))
			Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

			formatter.Serialize(Stream, Conf)

			Stream.Close()
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while making config. Read log file for futher information.", vbCritical, "System Error", True)
			End
		End Try
	End Sub

	Public Sub MakeSearchEngineDefault()
		Try
			Dim data As New List(Of SearchEngine)

			data.Add(New SearchEngine() With {
			.ID = 1,
			.Name = "Google",
			.URL = "https://www.google.com/search?q={0}"
		})

			data.Add(New SearchEngine() With {
			.ID = 1,
			.Name = "Bing",
			.URL = "https://www.bing.com/search?q={0}"
		})

			data.Add(New SearchEngine() With {
			.ID = 1,
			.Name = "Yahoo",
			.URL = "https://search.yahoo.com/search?p={0}"
		})

			data.Add(New SearchEngine() With {
			.ID = 1,
			.Name = "Ask",
			.URL = "https://www.ask.com/web?q={0}"
		})

			data.Add(New SearchEngine() With {
			.ID = 1,
			.Name = "Aol",
			.URL = "https://search.aol.com/aol/search?q={0}"
		})

			For Each conf As SearchEngine In data
				Dim Stream As FileStream = File.Create(Path.Combine(Path.Combine(AppData, "Netizener", "Search"), String.Format("{0}.scx", conf.Name)))
				Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

				formatter.Serialize(Stream, conf)

				Stream.Close()
			Next
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while making config. Read log file for futher information.", vbCritical, "System Error", True)

			End
		End Try
	End Sub

	Public Sub MakeDefaultTheme()
		Try
			Dim path As String = IO.Path.Combine(IO.Path.Combine(AppData, "Netizener", "Theme"), "Default.thm")

			File.WriteAllBytes(path, My.Resources.DefaultTheme)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while making config. Read log file for futher information.", vbCritical, "System Error", True)

			End
		End Try
	End Sub

	Public Sub FirstInstall()
		CreateDir()
		MakeConfigDefault()
		MakeSearchEngineDefault()
		MakeDefaultTheme()
		MakeDatabase()
	End Sub

	Public Sub CreateDir()
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener"))
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener", "Config"))
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener", "Database"))
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener", "Library"))
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener", "Log"))
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener", "Search"))
		Directory.CreateDirectory(Path.Combine(AppData, "Netizener", "Theme"))
	End Sub

	Public Sub MakeDatabase()
		Try
			Dim path As String = IO.Path.Combine(IO.Path.Combine(AppData, "Netizener", "Database"), "database.db")

			File.WriteAllBytes(path, My.Resources.Database)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
			err.ShowErrorAsDialogCustom("Error while making config. Read log file for futher information.", vbCritical, "System Error", True)

			End
		End Try
	End Sub
End Module

#Region "Config Class"
<Serializable>
Class Configuration
	Property InstallPath As String
	Property ConfigPath As String
	Property LogPath As String
	Property LibraryPath As String
	Property SearchEnginePath As String
	Property ActiveLibrary As List(Of Library)
	Property ConnectionString As String
	Property StartPage As String
	Property SearchEngines As List(Of String)
	Property DefaultSearchEngine As String
	Property AppData As String

End Class

<Serializable>
Class Library
	Property Name As String
	Property DllFiles As String
	Property Run As Runner

	<Serializable>
	Class Runner
		Dim Name As String
		Dim Path As String
		Dim Argument As String
	End Class
End Class

<Serializable>
Class SearchEngine
	Property ID As Integer
	Property Name As String
	Property URL As String 'SET {0} as file name to execute
End Class

Module Theme
	<Serializable>
	Class Extension
		Property Extention As String
		Property ExtentionName As String
		Property Type As FileTypes
		Property IsExecutable As Boolean
		Property Icon As Bitmap
		Property Theme As Themes
		Property OpenText As String
		Property AdvancedDll As String

		<Serializable>
		Enum FileTypes
			Document
			Audio
			Video
			Program
			System
			Picture
			Archive
			Font
			Other
		End Enum

		<Serializable>
		Structure Themes
			Dim Name As String
			Dim DesignBy As String
			Dim Developer As String
			Dim InputDate As Date
		End Structure
	End Class
End Module
#End Region