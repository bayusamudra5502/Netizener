Imports System.Linq
Imports System.IO
Imports System.Drawing

Module ConfigurationExample

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
			Dim Argument As String 'SET {0} as file name to execute
		End Class
	End Class

	<Serializable>
	Class SearchEngine
		ReadOnly Property ID As Integer
		ReadOnly Property Name As String
		ReadOnly Property URL As String 'SET {0} as file name to execute
	End Class
	Function GetBitmap(Name As String) As Bitmap
		Dim path As String = IO.Path.Combine("C:\Users\Bayu\Downloads\FILE EXTENSION\File", Name & ".png")
		Return New Bitmap(path)
	End Function

	Sub Main()
		Dim Searchs As New List(Of String)
		Searchs.Add("Google.scr")
		Searchs.Add("Bing.scr")
		Searchs.Add("Yahoo.scr")
		Searchs.Add("Ask.scr")
		Searchs.Add("Aol.scr")

		Dim Conf As New Configuration() With {
		.InstallPath = "C:\Users\Bayu\source\repos\Netizener\Netizener\bin\x86\Debug",
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
		Dim Stream As FileStream = File.Create(Path.Combine("C:\Users\Bayu\Desktop", "Netizener.conf"))
		Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

		formatter.Serialize(Stream, Conf)

		Stream.Close()
	End Sub

	'Public Sub main()
	'Dim Stream As FileStream = File.Open(Path.Combine("C:\Users\Bayu\Desktop", "Extention.conf"), FileMode.Open)
	'Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
	'
	'Dim Conf As List(Of Extension) = CType(formatter.Deserialize(Stream), List(Of Extension))

	'Dim resulte As IEnumerable(Of Extension) = From data In Conf
	'											   Where data.Extention = ".fbx"
	'Select Case data
	'
	'Dim result As Extension = resulte.First()

	'	Console.WriteLine(result.ExtentionName)
	'	Console.WriteLine(result.Icon)
	'	Console.WriteLine(result.IsExecutable)
	'	Console.ReadKey()
	'End Sub


End Module
