Imports System.IO
Imports Netizeners

Public Class ErrorHandler
	Implements IErrorHandler

#Region "Constructors"
	Public Sub New()
		ErrorSource = New Exception()

		Dim APPDATA As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
		Directory.CreateDirectory(Path.Combine(APPDATA, "Netizener"))
		SavePathInAppData = Path.Combine(APPDATA, "Netizener", Now() & ".log")
	End Sub

	Public Sub New(Exception As Exception)
		ErrorSource = Exception


		Dim APPDATA As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
		Directory.CreateDirectory(Path.Combine(APPDATA, "Netizener"))
		SavePathInAppData = Path.Combine(APPDATA, "Netizener", Now() & ".log")
	End Sub
#End Region

#Region "Properties"
	Public ReadOnly Property ErrorSource As Exception Implements IErrorHandler.ErrorSource
	Public ReadOnly Property SavePathInAppData As String Implements IErrorHandler.SavePathInAppData
#End Region

#Region "Procedures"

	Public Function SaveErrorToFileAs(Path As String) As Boolean Implements IErrorHandler.SaveErrorToFile
		Dim hasil As Boolean = False
		Dim Format As String = My.Resources.ErrorFormat
		Dim ErrorMessage As String = String.Format(Format, Now.ToString("MMMM dd, yyyy"), Now.ToString("HH:mm:ss"), ErrorSource.Message, ErrorSource.ToString)

		Try
			File.WriteAllText(Path, ErrorMessage)

			Dim Err As New ErrorHandler(ErrorSource)
			Err.SaveErrorToFileAuto()

			hasil = True
		Catch ex As Exception
			Dim Err As New ErrorHandler(ex)
			Err.SaveErrorToFileAuto()

			Dim Err2 As New ErrorHandler(ErrorSource)
			Err.SaveErrorToFileAuto()
		End Try

		Return hasil
	End Function

	Public Function SaveErrorToFileAuto() As Boolean Implements IErrorHandler.SaveErrorToFileAuto
		Dim hasil As Boolean = False
		Dim Format As String = My.Resources.ErrorFormat
		Dim ErrorMessage As String = String.Format(Format, Now.ToString("MMMM dd, yyyy"), Now.ToString("HH:mm:ss"), ErrorSource.Message, ErrorSource.ToString)

		Try
			File.WriteAllText(SavePathInAppData, ErrorMessage)
			hasil = True
		Catch ex As Exception
		End Try

		Return hasil
	End Function

	Public Function ShowErrorAsDialog() As Boolean Implements IErrorHandler.ShowErrorAsDialog
		Dim hasil As Boolean = False

		Try
			MsgBox(String.Format(My.Resources.ErrorFormatDialog, ErrorSource.Message), vbCritical + vbOKOnly, "Kesalahan")
			hasil = True
		Catch ex As Exception
		End Try

		Return hasil
	End Function

	'ONLY APPDATA
	Public Function ShowErrorAsDialogCustom(Message As String, Type As MsgBoxStyle, Title As String, Optional ShowErrorSaveLocation As Boolean = True, Optional ShowErrorMessage As Boolean = False) As Boolean Implements IErrorHandler.ShowErrorAsDialogCustom
		Dim hasil As Boolean = False

		Try
			Dim DialogMessage As String = Message

			If ShowErrorSaveLocation Then
				DialogMessage &= vbNewLine & String.Format(My.Resources.LocationFormat, SavePathInAppData)
			End If

			If ShowErrorMessage Then
				DialogMessage &= vbNewLine & String.Format(My.Resources.MessageFormat, ErrorSource.Message)
			End If

			MsgBox(Message, Type, Title)
			hasil = True
		Catch ex As Exception
		End Try

		Return hasil
	End Function
#End Region
End Class
