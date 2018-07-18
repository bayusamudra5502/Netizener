Imports System.Data
Imports System.Text
Imports CryptSharp
Imports Netizeners

Public Class Register
	Implements IRegister

#Region "Constructors"
	Public Sub New(AdminUser As String, AdminPass As String)
		Me.AdminUser = AdminUser
		Me.AdminPass = AdminPass
	End Sub

	Public Sub New(AdminUser As String, AdminPass As String, ConnectionString As String)
		Me.AdminUser = AdminUser
		Me.AdminPass = AdminPass
		Me.ConnectionString = ConnectionString
	End Sub
#End Region

#Region "Properties"
	Public ReadOnly Property AdminUser As String Implements IRegister.AdminUser
	Public ReadOnly Property AdminPass As String Implements IRegister.AdminPass
	'DEPRECATED
	Public ReadOnly Property ConnectionString As String Implements IRegister.ConnectionString
#End Region

#Region "Private Function"
	Private Function GeneratePassword(ByVal Password As String) As String
		Dim result As String = ""

		result = Crypter.Blowfish.Crypt(Encoding.ASCII.GetBytes(Password),
										Crypter.Blowfish.GenerateSalt())
		Return result
	End Function
#End Region

#Region "Public Function"
	Public Async Function RegisterUser(Username As String, Password As String, AccessCode As Integer) As Task(Of Boolean) Implements IRegister.RegisterUser
		Dim db As New Database(Of Object)
		Await db.Connect()

		If Await IsUserAvailable(Username) Then
			Dim err As New ErrorHandler()
			err.ShowErrorAsDialogCustom("Pengguna sudah terdaftar.", MsgBoxStyle.Critical, "Pemberitahuan", False)
			Return False
		End If

		Dim Uid, Pwd, Acc, Name, Picture As Value

		'##### SET Username #####
		Uid.ColumnName = "Username"
		Uid.Value = Username

		'##### SET Password #####
		Pwd.ColumnName = "Password"
		Pwd.Value = GeneratePassword(Password)

		'##### SET Access Code #####
		Acc.ColumnName = "Akses"
		Acc.Value = AccessCode

		'##### SET Name ####
		Name.ColumnName = "Name"
		Name.Value = Username

		'##### SET PICTURE ####
		Picture.ColumnName = "Foto"
		Picture.Value = "../Resources/boy.png"

		Return Await db.InsertData("Pengguna", Uid, Pwd, Acc, Name, Picture)
	End Function

	Public Async Function RegisterUser(Username As String, Password As String, AccessCode As Integer, Name As String, PictureURI As String) As Task(Of Boolean)
		Dim db As New Database(Of Object)
		Await db.Connect()

		If Await IsUserAvailable(Username) Then
			Dim err As New ErrorHandler()
			err.ShowErrorAsDialogCustom("Pengguna sudah terdaftar.", MsgBoxStyle.Critical, "Pemberitahuan", False)
			Return False
		End If

		Dim Uid, Pwd, Acc, Nama, Picture As Value

		'##### SET Username #####
		Uid.ColumnName = "Username"
		Uid.Value = Username

		'##### SET Password #####
		Pwd.ColumnName = "Password"
		Pwd.Value = GeneratePassword(Password)

		'##### SET Access Code #####
		Acc.ColumnName = "Akses"
		Acc.Value = AccessCode

		'##### SET Name ####
		Nama.ColumnName = "Name"
		Nama.Value = Name

		'##### SET PICTURE ####
		Picture.ColumnName = "Foto"
		Picture.Value = PictureURI

		Return Await db.InsertData("Pengguna", Uid, Pwd, Acc, Nama, Picture)
	End Function

	Public Async Function IsUserAvailable(Username As String) As Task(Of Boolean) Implements IRegister.IsUserAvailable
		Dim hasil As Boolean = False

		Dim db As New Database(Of Object)
		Await db.Connect()

		Try
			Dim Criteria As Criteria
			Criteria.ColumnName = "Username"
			Criteria.Value = Username

			If Await db.IsRowAvailable("Pengguna", Criteria) Then
				hasil = True
			End If
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return hasil
	End Function

	Public Async Function FindColumn(SearchWithColumn As String, ValueToSearch As String, Column As String) As Task(Of DataSet) Implements IRegister.FindColumn
		Dim db As New Database(Of Object)
		Try
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = SearchWithColumn
			Criteria.Value = ValueToSearch

			Return Await db.FindColumn("Pengguna", Column, Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function FindColums(SearchWithColumn As String, ValueToSearch As String, ParamArray Columns() As String) As Task(Of DataSet) Implements IRegister.FindColums
		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Dim Criteria As Criteria
			Criteria.ColumnName = SearchWithColumn
			Criteria.Value = ValueToSearch

			Return Await db.FindColumns("Pengguna", Columns, Criteria)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function

	Public Async Function UnRegister(Username As String) As Task(Of Boolean) Implements IRegister.UnRegister
		Dim db As New Database(Of Object)

		Try
			Await db.Connect()
			Dim Condition As Criteria
			Condition.ColumnName = "Username"
			Condition.Value = Username

			Return Await db.DeleteData("Pengguna", Condition)
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return Nothing
	End Function
#End Region

End Class
