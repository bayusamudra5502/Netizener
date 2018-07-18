Imports Netizeners
Imports CryptSharp
Imports System.Text

Public Class Login
	Implements ILogin

#Region "Constructor"
	Public Sub New(ByVal Username As String, ByVal Password As String)
		Me.Username = Username
		Me.Password = Password
		IsLogged = False
	End Sub

	'DEPRECATED. USE FIRST CONSTRUCTOR INSTEAD
	Public Sub New(ByVal Username As String, ByVal Password As String, ByVal ConnectionString As String)
		Me.Username = Username
		Me.Password = Password
		Me.ConnectionString = ConnectionString
		IsLogged = False
	End Sub

	Public Sub New(ByVal Session As ISession)
		Me.Username = Session.Username
		IsLogged = True
	End Sub
#End Region

#Region "Properties"
	Public ReadOnly Property Username As String Implements ILogin.Username
	Public ReadOnly Property Password As String Implements ILogin.Password
	Public ReadOnly Property ConnectionString As String Implements ILogin.ConnectionString
	Public ReadOnly Property IsLogged As Boolean Implements ILogin.IsLogged
	Public ReadOnly Property Session As ISession
#End Region

#Region "Methods"
	Public Async Function GetAccess() As Task(Of Integer) Implements ILogin.GetAccess
		If Not IsLogged Then
			Throw New UserExeption("User was not logged in.", 1)
			Exit Function
		End If

		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			Return Convert.ToInt32(
				Await db.GetDataScalarSafe(
					String.Format("SELECT Akses FROM Pengguna WHERE Username='{0}'", Username)))
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

	End Function

	'RUMUS : (ACC >> NUMACC) AND 1
	Public Async Function HasAccess(Access As Access) As Task(Of Boolean) Implements ILogin.HasAccess
		Dim hasil As Boolean = False
		If Not IsLogged Then
			Throw New UserExeption("User was not logged in.", 1)
			Exit Function
		End If

		Dim AccCode As Integer = Await GetAccess()
		If ((AccCode >> Access) And 1) Then
			hasil = True
		End If

		Return hasil
	End Function

	Public Async Function HasAccess(ParamArray Access() As Access) As Task(Of Boolean) Implements ILogin.HasAccess
		Dim hasil As Boolean = True
		If Not IsLogged Then
			Throw New UserExeption("User was not logged in.", 1)
			Exit Function
		End If

		Dim AccCode As Integer = Await GetAccess()

		For Each Acc As Integer In Access
			If Not ((AccCode >> Acc) And 1) Then
				hasil = False
				Exit For
			End If
		Next

		Return hasil
	End Function

	Public Async Function HasAccess(Access As Integer) As Task(Of Boolean) Implements ILogin.HasAccess
		Dim hasil As Boolean = False
		If Not IsLogged Then
			Throw New UserExeption("User was not logged in.", 1)
			Exit Function
		End If

		Dim AccCode As Integer = Await GetAccess()
		If ((AccCode >> Access) And 1) Then
			hasil = True
		End If

		Return hasil
	End Function

	Public Async Function Login() As Task(Of Boolean) Implements ILogin.Login
		Dim hasil As Boolean = False

		Try
			Dim db As New Database(Of Object)
			Await db.Connect()

			'CHECK AVAIBILITY FIRST!
			Dim IsUserExist As Criteria
			IsUserExist.ColumnName = "Username"
			IsUserExist.Value = Username

			If Not Await db.IsRowAvailable("Pengguna", IsUserExist) Then
				Return False
			End If

			Dim pwd As String = Convert.ToString(Await db.GetDataScalarSafe(
				String.Format("SELECT Password FROM Pengguna WHERE Username='{0}'", Username)))

			If Crypter.CheckPassword(Encoding.ASCII.GetBytes(Password), pwd) Then
				hasil = True
				_IsLogged = True

				Dim Session As New Session(Me)
				_Session = Session
			End If
		Catch ex As Exception
			Dim err As New ErrorHandler(ex)
			err.SaveErrorToFileAuto()
		End Try

		Return hasil
	End Function
#End Region

End Class

Public Class UserExeption
	Inherits Exception
	ReadOnly Property ErrorCode As Integer
	Overrides ReadOnly Property Message As String

	Public Sub New()
		Me.ErrorCode = -2
	End Sub

	Public Sub New(ByVal Message As String)
		Me.Message = Message
		Me.ErrorCode = -1
	End Sub

	Public Sub New(ByVal Message As String, ByVal ErrorCode As Integer)
		Me.Message = Message
		Me.ErrorCode = ErrorCode
	End Sub
End Class