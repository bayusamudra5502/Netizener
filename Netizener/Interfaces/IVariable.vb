' Interface IVariable
''' <summary>
''' Interface yang menangani penyimpanan variabel.
''' </summary>
Public Interface IVariable
	'Inimah isinya variabel semua

	''' <summary>
	''' Digunakan untuk menyimpan connectionString.
	''' Contoh : "Data Source=database.db;"
	''' </summary>
	''' <returns>String : Koneksi string.</returns>
	ReadOnly Property ConnectionString As String

	''' <summary>
	''' Digunakan untuk menyimpan username saat login.
	''' </summary>
	''' <returns>Username</returns>
	ReadOnly Property Username As String

	''' <summary>
	''' Properti Lokasi penyimpanan Database
	''' </summary>
	''' <returns>Lokasi Database</returns>
	ReadOnly Property DatabaseLocation As String
End Interface