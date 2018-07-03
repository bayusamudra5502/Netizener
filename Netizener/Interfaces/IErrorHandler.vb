''' <summary>
''' Interface penanganan error.
''' </summary>
Public Interface IErrorHandler
	''' <summary>
	''' Properti Pesan Error. Diisi saat New()
	''' </summary>
	''' <returns></returns>
	ReadOnly Property ErrorSource As Exception

	''' <summary>
	''' Letak Penyimpanan Error di AppData. Diisi Otomatis saat New()
	''' </summary>
	''' <returns></returns>
	ReadOnly Property SavePathInAppData As String

	''' <summary>
	''' Prosedur menyimpan pesan error sesuai format ke suatu tempat yang ditentukan.
	''' </summary>
	''' <param name="Path">Letak Penyimpanan File</param>
	''' <returns>Menghasilkan True bila berhasil</returns>
	Function SaveErrorToFile(ByVal Path As String) As Boolean

	''' <summary>
	''' Prosedur menyimpan pesan error sesuai format di Appdata/Netizener.
	''' </summary>
	''' <returns>Menghasilkan True bila berhasil</returns>
	Function SaveErrorToFileAuto() As Boolean

	''' <summary>
	''' Prosedur menampilkan Pesan Error sebagai dialog.
	''' </summary>
	''' <returns>Menghasilkan True bila berhasil.</returns>
	Function ShowErrorAsDialog() As Boolean

	''' <summary>
	''' Prosedur menanpilkan Pesan Error secara kustom.
	''' </summary>
	''' <param name="Message">Pesan yang ingin disampaikan</param>
	''' <param name="Type">Mengatur Tipe Pesan</param>
	''' <param name="Title">Judul</param>
	''' <param name="ShowErrorSaveLocation">Tampilkan Lokasi penyimpanan pesan error?</param>
	''' <param name="ShowErrorMessage">Tampilkan Pesan Error?</param>
	''' <returns>Menghasilkan true jika berhasil</returns>
	Function ShowErrorAsDialogCustom(ByVal Message As String,
									 ByVal Type As MsgBoxStyle,
									 ByVal Title As String,
									 Optional ByVal ShowErrorSaveLocation As Boolean = True,
									 Optional ByVal ShowErrorMessage As Boolean = False) As Boolean
End Interface

Class x
	Function a()

	End Function
End Class