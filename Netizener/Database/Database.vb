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
	Public Sub New()
		Connection = New SQLiteConnection(Config.Application.ConnectionString)
		IsConnected = False
	End Sub

	Public Sub New(ByVal ConnectionString As String)
		Connection = New SQLiteConnection(ConnectionString)
		Me.ConnectionString = ConnectionString
		IsConnected = False
	End Sub
#End Region

#Region "Properties"
	Public ReadOnly Property IsConnected As Boolean Implements IDatabase(Of T).IsConnected
	Public ReadOnly Property ConnectionString As String Implements IDatabase(Of T).ConnectionString 'AUTO
#End Region

#Region "Public Procedures"
	Public Async Function Connect() As Task(Of Boolean) Implements IDatabase(Of T).Connect
		Dim hasil As Boolean = False
		Try
			Await Connection.OpenAsync(sekering.Token)

			If Connection.State = ConnectionState.Closed Then
				Throw New Exception("Gagal menyambungkan ke database. Koneksi masih tertutup.")
			Else
				hasil = True
				_IsConnected = True
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


	''' <summary>
	''' Memeriksa suatu tabel dengan kriteria yang diberi
	''' </summary>
	''' <remarks>HARUS SUDAH TERSAMBUNG KE DATABASE</remarks>
	''' <param name="TableName">Nama Tabel yang dimaksud</param>
	''' <param name="Criteria">Kriteria</param>
	''' <returns></returns>
	Public Async Function IsRowAvailable(ByVal TableName As String, ParamArray Criteria() As Criteria) As Task(Of Boolean)
		Dim hasil As Boolean = False

		If Not IsConnected Then
			Throw New Exception("Database should be connected before do this function.")
			Exit Function
		End If

		Dim CMD As String = String.Format("SELECT CASE WHEN EXISTS(SELECT * FROM {0} WHERE {1}) Then 1 else 0 end;", TableName, MakeQueryForSearch(Criteria))

		If Convert.ToBoolean(Await GetDataScalarSafe(CMD)) Then
			hasil = True
		End If

		Return hasil
	End Function

	Public Async Function FindColumn(TableName As String, ResultColumn As String, ParamArray Criteria() As Criteria) As Task(Of DataSet) Implements IDatabase(Of T).FindColumn
		Dim hasil As New DataSet

		If Not IsConnected Then
			Throw New Exception("Database should be connected before do this function.")
			Exit Function
		End If

		Dim CMD As String = String.Format("SELECT {0} FROM {1} WHERE {2};", ResultColumn, TableName, MakeQueryForSearch(Criteria))
		hasil = Await GetDataSet(CMD)

		Return hasil
	End Function

	Public Async Function FindColumns(TableName As String, ResultColumns() As String, ParamArray Criteria() As Criteria) As Task(Of DataSet) Implements IDatabase(Of T).FindColums
		Dim hasil As New DataSet

		If Not IsConnected Then
			Throw New Exception("Database should be connected before do this function.")
			Exit Function
		End If

		Dim ResultColumnCommand As String = MakeQueryAfterOperator(ResultColumns)

		Dim CMD As String = String.Format("SELECT {0} FROM {1} WHERE {2};", ResultColumnCommand, TableName, MakeQueryForSearch(Criteria))
		hasil = Await GetDataSet(CMD)

		Return hasil
	End Function

	''' <summary>
	''' Memasukan Data ke Database
	''' <param name="TableName">Nama Tabel</param>
	''' <param name="Values">Nilai yang akan dimasukan</param>
	''' <remarks>Nilai Values harus mewakili semua Kolom pada tabel di database dan diisi berurutan</remarks>
	''' <returns>Nilai Keberhasilan</returns>
	''' </summary>
	Public Async Function InsertData(ByVal TableName As String, ParamArray Values() As String) As Task(Of Boolean)
		Dim hasil As Boolean = False
		Dim Query As String = String.Format("INSERT INTO {0} VALUES ({1})",
											TableName, MakeQueryForInput(Values))

		If Not IsConnected Then
			Throw New Exception("Database is not connected in this time.")
			Return False
		End If

		hasil = Await RunQuery(Query)

		Return hasil
	End Function

	''' <summary>
	''' Memasukan Data ke Database
	''' <param name="TableName">Nama Tabel</param>
	''' <param name="Values">Nilai yang akan dimasukan</param>
	''' <remarks>Nilai Values harus mewakili semua Kolom pada tabel di database dan diisi berurutan</remarks>
	''' <returns>Nilai Keberhasilan</returns>
	Public Async Function InsertData(ByVal TableName As String, ParamArray Values() As Value) As Task(Of Boolean)
		Dim hasil As Boolean = False
		Dim Query As String = String.Format("INSERT INTO {0}({1}) VALUES ({2})",
											TableName, MakeQueryAfterOperator(Values), MakeQueryForInput(Values))

		If Not IsConnected Then
			Throw New Exception("Database is not connected in this time.")
			Return False
		End If

		hasil = Await RunQuery(Query)

		Return hasil
	End Function

	''' <summary>
	''' Fungsi untuk menghapus data dari database
	''' </summary>
	''' <param name="TableName">Nama Tabel</param>
	''' <param name="Conditions">Kondisi yang dimaksud</param>
	''' <returns>Keberasilan Proses ini</returns>
	Public Async Function DeleteData(ByVal TableName As String, ParamArray Conditions() As Criteria) As Task(Of Boolean)
		Dim hasil As Boolean = False
		Dim Query As String = String.Format("DELETE FROM {0} WHERE {1};", TableName, MakeQueryForSearch(Conditions))

		If Not IsConnected Then
			Throw New Exception("Database is not connected in this time.")
			Return False
		End If

		hasil = Await RunQuery(Query)

		Return hasil
	End Function

	''' <summary>
	''' Fungsi untuk menghapus semua data pada tabel.
	''' </summary>
	''' <param name="TableName">Nama Tabel</param>
	''' <returns>Keberasilan Proses ini</returns>
	Public Async Function DeleteData(ByVal TableName As String) As Task(Of Boolean)
		Dim hasil As Boolean = False
		Dim Query As String = String.Format("DELETE FROM {0};", TableName)

		If Not IsConnected Then
			Throw New Exception("Database is not connected in this time.")
			Return False
		End If

		hasil = Await RunQuery(Query)

		Return hasil
	End Function

	''' <summary>
	''' Fungsi mengubah data pada database.
	''' </summary>
	''' <param name="TableName">Nama Tabel</param>
	''' <param name="Conditions">Kondisi yang dimaksud</param>
	''' <returns>Keberasilan Proses ini</returns>
	Public Async Function UpdateData(ByVal TableName As String, Conditions() As Criteria, ParamArray Value() As Value) As Task(Of Boolean)
		Dim hasil As Boolean = False
		Dim Query As String = String.Format("UPDATE {0} SET {1} WHERE {2};", TableName, MakeQueryForSearch(Value), MakeQueryForSearch(Conditions))

		If Not IsConnected Then
			Throw New Exception("Database is not connected in this time.")
			Return False
		End If

		hasil = Await RunQuery(Query)

		Return hasil
	End Function
#End Region

#Region "Private Functions"

	Private Function MakeQueryForSearch(ParamArray Input() As Criteria) As String
		Dim hasil As String = ""

		For Each data As Criteria In Input
			If TypeOf data.Value Is Integer Then
				hasil &= String.Format("{0} = {1} AND ", data.ColumnName, data.Value)
			ElseIf TypeOf data.Value Is String Then
				hasil &= String.Format("{0} = '{1}' AND ", data.ColumnName, data.Value)
			ElseIf TypeOf data.Value Is Double Then
				hasil &= String.Format("{0} = {1} AND ", data.ColumnName, data.Value)
			ElseIf TypeOf data.Value Is Boolean Then
				If data.Value = True Then
					hasil &= String.Format("{0} = {1} AND ", data.ColumnName, 1)
				Else
					hasil &= String.Format("{0} = {1} AND ", data.ColumnName, 0)
				End If
			Else
				Throw New Exception(String.Format("{0} is not supported.", data.ColumnName.GetType.ToString))
			End If
		Next

		hasil.Remove(hasil.Length - 5)

		Return hasil
	End Function

	Private Function MakeQueryForSearch(ParamArray Input() As Value) As String
		Dim hasil As String = ""

		For Each data As Value In Input
			If TypeOf data.Value Is Integer Then
				hasil &= String.Format("{0} = {1} AND ", data.ColumnName, data.Value)
			ElseIf TypeOf data.Value Is String Then
				hasil &= String.Format("{0} = '{1}' AND ", data.ColumnName, data.Value)
			ElseIf TypeOf data.Value Is Double Then
				hasil &= String.Format("{0} = {1} AND ", data.ColumnName, data.Value)
			ElseIf TypeOf data.Value Is Boolean Then
				If data.Value = True Then
					hasil &= String.Format("{0} = {1} AND ", data.ColumnName, 1)
				Else
					hasil &= String.Format("{0} = {1} AND ", data.ColumnName, 0)
				End If
			Else
				Throw New Exception(String.Format("{0} is not supported.", data.ColumnName.GetType.ToString))
			End If
		Next

		hasil.Remove(hasil.Length - 5)

		Return hasil
	End Function

	Private Function MakeQueryForInput(ParamArray Input() As String) As String
		Dim Result As String = ""

		For Each Data As String In Input
			Result &= String.Format("'{0}',", Data)
		Next

		Result.Remove(Result.Length - 1)

		Return Result
	End Function

	Private Function MakeQueryForInput(ParamArray Input() As Value) As String
		Dim Result As String = ""
		Dim Data As New List(Of Object)

		For Each Value As Value In Input
			Data.Add(Value.Value)
		Next

		For Each obj As Object In Data
			If TypeOf obj Is Integer Then
				Result &= String.Format("{0},", Data)
			ElseIf TypeOf obj Is String Then
				Result &= String.Format("'{0}',", Data)
			ElseIf TypeOf obj Is Double Then
				Result &= String.Format("{0},", Data)
			ElseIf TypeOf obj Is Boolean Then
				If Result Then
					Result &= String.Format("{0},", 1)
				Else
					Result &= String.Format("{0},", 0)
				End If
			Else
				Throw New Exception(String.Format("{0} is not supported.", Data.GetType.ToString))
			End If
			Result &= String.Format("'{0}',", Data)
		Next

		Result.Remove(Result.Length - 1)

		Return Result
	End Function

	Private Function MakeQueryAfterOperator(ParamArray Columns() As String) As String
		Dim Result As String = ""

		For Each Data As String In Columns
			Result &= Data & ","
		Next

		Result.Remove(Result.Length - 1)

		Return Result
	End Function

	Private Function MakeQueryAfterOperator(ParamArray Columns() As Value) As String
		Dim Result As String = ""
		Dim Columns2 As New List(Of String)

		For Each col As Value In Columns
			Columns2.Add(col.ColumnName)
		Next

		For Each Data As String In Columns2
			Result &= Data & ","
		Next

		Result.Remove(Result.Length - 1)

		Return Result
	End Function

#End Region
End Class

Public Structure Criteria
	Dim ColumnName As String
	Dim Value As Object
End Structure


Public Structure Value
	Dim ColumnName As String
	Dim Value As Object
End Structure

