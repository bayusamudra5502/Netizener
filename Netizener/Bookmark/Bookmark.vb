Imports System.Data
Imports Netizeners

Public Class Bookmark
	Implements IBookmark

#Region "Constructors"
	Public Sub New()
	End Sub

	Public Sub New(URL As String, Name As String)
		Me.URL = URL
		BookmarkName = Name
	End Sub

	Public Sub New(ConnectionString As String)
		Me.ConnectionString = ConnectionString
	End Sub

	Public Sub New(URL As String, Name As String, ConnectionString As String)
		Me.URL = URL
		BookmarkName = Name
		Me.ConnectionString = ConnectionString
	End Sub
#End Region

#Region "Properties"
	Public Property URL As String Implements IBookmark.URL
	Public Property BookmarkName As String Implements IBookmark.BookmarkName
	Public ReadOnly Property ConnectionString As String Implements IBookmark.ConnectionString
#End Region

	Public Async Function Save() As Task(Of Boolean) Implements IBookmark.Save
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim URL, Name As Value

			'##### SET URL VALUE #####
			URL.ColumnName = "Alamat"
			URL.Value = Me.URL

			'##### SET Name #####
			Name.ColumnName = "Nama"
			Name.Value = BookmarkName

			Return Await db.InsertData("Bookmark", URL, Name)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function


	Public Async Function GetBookmarkDataSet() As Task(Of DataSet) Implements IBookmark.GetBookmarkDataSet
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Return Await db.GetDataSet("SELECT Nama,Alamat FROM Bookmark;")
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function DeleteAll() As Task(Of Boolean) Implements IBookmark.DeleteAll
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Return Await db.DeleteData("Bookmark")
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function DeleteByURL(URL As String) As Task(Of Boolean) Implements IBookmark.DeleteByURL
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = "Alamat"
			Criteria.Value = URL

			Return Await db.DeleteData("Bookmark", Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function DeleteByName(Name As String) As Task(Of Boolean) Implements IBookmark.DeleteByName
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = "Nama"
			Criteria.Value = Name

			Return Await db.DeleteData("Bookmark", Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function DeleteByID(ID As Integer) As Task(Of Boolean) Implements IBookmark.DeleteByID
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = "ID"
			Criteria.Value = ID

			Return Await db.DeleteData("Bookmark", Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function FindColumn(SearchWithColumn As String, ValueToSearch As String, Column As String) As Task(Of DataSet) Implements IBookmark.FindColumn
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = SearchWithColumn
			Criteria.Value = ValueToSearch

			Return Await db.FindColumn("Bookmark", Column, Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function FindColums(SearchWithColumn As String, ValueToSearch As String, ParamArray Columns() As String) As Task(Of DataSet) Implements IBookmark.FindColums
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = SearchWithColumn
			Criteria.Value = ValueToSearch

			Return Await db.FindColumns("Bookmark", Columns, Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function
End Class
