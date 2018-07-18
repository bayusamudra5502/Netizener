Imports Netizeners

Public Class Session
	Implements ISession

	Public ReadOnly Property Username As String Implements ISession.Username
	Public ReadOnly Property Access As Integer Implements ISession.Access
	Public ReadOnly Property Name As String Implements ISession.Name
	Public ReadOnly Property Picture As BitmapImage Implements ISession.Picture

	Dim User As Login

	Public Sub New(ByVal sender As Login)
		User = sender

		Try
			Make()
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
		End Try
	End Sub

	Private Async Sub Make()
		If Not User.IsLogged Then
			Throw New UserExeption("User should be logged in when making a session.")
		End If

		_Username = User.Username
		_Access = Await GetAccess()
		_Name = Await GetName()
		_Picture = Await GetPicture()
	End Sub

	Private Async Function GetAccess() As Task(Of Integer)
		Return Await User.GetAccess()
	End Function

	Private Async Function GetName() As Task(Of String)
		Dim db As New Database(Of Object)
		Await db.Connect()
		Return Convert.ToString(Await db.GetDataScalarSafe(
								String.Format("SELECT Nama FROM Pengguna WHERE Username='{0}'",
											  User.Username)))
	End Function

	Private Async Function GetPicture() As Task(Of BitmapImage)
		Dim db As New Database(Of Object)
		Await db.Connect()
		Dim location As String = Convert.ToString(Await db.GetDataScalarSafe(
								String.Format("SELECT Foto FROM Pengguna WHERE Username='{0}'",
											  User.Username)))
		Dim hasil As New BitmapImage

		Try
			hasil.BeginInit()
			hasil.UriSource = New Uri(location)
			hasil.EndInit()
		Catch ex As Exception
			Dim Handle As IErrorHandler = New ErrorHandler(ex)
			Handle.SaveErrorToFileAuto()
		End Try

		Return hasil
	End Function
End Class
