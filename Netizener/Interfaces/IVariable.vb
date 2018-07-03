' Interface IVariable
''' <summary>
''' Interface yang menangani penyimpanan variabel.
''' </summary>
Public Interface IVariable
	'Inimah isinya variabel semua

	''' <summary>
	''' Digunakan untuk menyimpan connectionString.
	''' Contoh : "Data Source=database.db;Version=3;"
	''' </summary>
	''' <returns>String : Koneksi string.</returns>
	ReadOnly Property connectionString As String

	''' <summary>
	''' Digunakan untuk menyimpan username saat login.
	''' </summary>
	''' <returns></returns>
	ReadOnly Property Username As String
End Interface