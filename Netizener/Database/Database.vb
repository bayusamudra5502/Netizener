Imports System.Data
Imports System.Data.SQLite
Imports System.Threading
Imports Netizeners

Public Class Database(Of T)
	Implements IDatabase(Of T)

#Region "Local Variables"
	Dim sekering As New CancellationTokenSource(10000)
	Dim Connection As SQLiteConnection
#End Region

#Region "Constructor"
	Public Sub New(ByVal ConnectionString As String)
		Connection = New SQLiteConnection(ConnectionString)
		Me.ConnectionString = ConnectionString
		IsConnected = False
	End Sub
#End Region

#Region "Properties"
	Public ReadOnly Property IsConnected As Boolean Implements IDatabase(Of T).IsConnected
	Public ReadOnly Property ConnectionString As String Implements IDatabase(Of T).ConnectionString
#End Region

#Region "Procedures"
	Public Async Function Connect() As Task(Of Boolean) Implements IDatabase(Of T).Connect
		Dim hasil As Boolean = False
		Try
			Await Connection.OpenAsync(sekering.Token)

			If Connection.State = ConnectionState.Closed Then
				Throw New Exception("Gagal menyambungkan ke database. Koneksi masih tertutup.")
			Else
				hasil = True
			End If
		Catch Err As TaskCanceledException
			Dim Handle As IErrorHandler = New ErrorHandler()
			Handle.ShowErrorAsDialogCustom("Penyambungan ke Database dibatalkan karena melebihi batas waktu.", vbCritical, "Kesalahan")
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
			Handle.ShowErrorAsDialogCustom("Terjadi masalah saat menyambungkan ke Database.", vbCritical, "Kesalahan")
		End Try

		Return hasil
	End Function

	Public Async Function GetDataScalar(Query As String) As Task(Of T) Implements IDatabase(Of T).GetDataScalar
		Dim hasil As T = Nothing
		Try
			If Not Connection.State = ConnectionState.Closed Then
				Dim cmd As New SQLiteCommand(Query, Connection)
				hasil = CType(Await cmd.ExecuteScalarAsync(sekering.Token), T)
			Else
				Throw New Exception("Koneksi masih tertutup.")
			End If
		Catch Err As TaskCanceledException
			Dim Handle As IErrorHandler = New ErrorHandler()
			Handle.ShowErrorAsDialogCustom("Penyambungan ke Database dibatalkan karena melebihi batas waktu.", vbCritical, "Kesalahan")
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
			Handle.ShowErrorAsDialogCustom("Terjadi masalah saat menyambungkan ke Database.", vbCritical, "Kesalahan")
		End Try

		Return hasil
	End Function

	Public Async Function GetDataScalarSafe(Query As String) As Task(Of Object) Implements IDatabase(Of T).GetDataScalarSafe
		Dim hasil As Object = Nothing
		Try
			If Not Connection.State = ConnectionState.Closed Then
				Dim cmd As New SQLiteCommand(Query, Connection)
				hasil = CType(Await cmd.ExecuteScalarAsync(sekering.Token), Object)
			Else
				Throw New Exception("Koneksi masih tertutup.")
			End If
		Catch Err As TaskCanceledException
			Dim Handle As IErrorHandler = New ErrorHandler()
			Handle.ShowErrorAsDialogCustom("Penyambungan ke Database dibatalkan karena melebihi batas waktu.", vbCritical, "Kesalahan")
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
			Handle.ShowErrorAsDialogCustom("Terjadi masalah saat menyambungkan ke Database.", vbCritical, "Kesalahan")
		End Try

		Return hasil
	End Function

	Public Async Function GetDataSet(Query As String) As Task(Of DataSet) Implements IDatabase(Of T).GetDataSet
		Dim hasil As DataSet = Nothing
		Try
			If Not Connection.State = ConnectionState.Closed Then
				Dim DA As New SQLiteDataAdapter(Query, Connection)
				Await Task.Run(Sub()
								   hasil = New DataSet()
							   End Sub, sekering.Token)

				DA.Fill(hasil)
			Else
				Throw New Exception("Koneksi masih tertutup.")
			End If
		Catch Err As TaskCanceledException
			Dim Handle As IErrorHandler = New ErrorHandler(Err)
			Handle.ShowErrorAsDialogCustom("Penyambungan ke Database dibatalkan karena melebihi batas waktu.", vbCritical, "Kesalahan")
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
			Handle.ShowErrorAsDialogCustom("Terjadi masalah saat menyambungkan ke Database.", vbCritical, "Kesalahan")
		End Try

		Return hasil
	End Function

	Public Async Function RunQuery(Query As String) As Task(Of Boolean) Implements IDatabase(Of T).RunQuery
		Dim hasil As Boolean = False
		Try
			If Not Connection.State = ConnectionState.Closed Then
				Dim cmd As New SQLiteCommand(Query, Connection)
				Await cmd.ExecuteNonQueryAsync(sekering.Token)

				hasil = True
			Else
				Throw New Exception("Koneksi masih tertutup.")
			End If
		Catch Err As TaskCanceledException
			Dim Handle As IErrorHandler = New ErrorHandler()
			Handle.ShowErrorAsDialogCustom("Penyambungan ke Database dibatalkan karena melebihi batas waktu.", vbCritical, "Kesalahan")
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
			Handle.ShowErrorAsDialogCustom("Terjadi masalah saat menyambungkan ke Database.", vbCritical, "Kesalahan")
		End Try

		Return hasil
	End Function
#End Region
End Class
