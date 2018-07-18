' Interface IVariable
''' <summary>
''' Interface yang menangani penyimpanan variabel.
''' </summary>
Public Interface ISession
	'Inimah isinya variabel semua

	''' <summary>
	''' Digunakan untuk menyimpan username saat login.
	''' </summary>
	''' <returns>String : Username</returns>
	ReadOnly Property Username As String

	'Security Reason
	'''' <summary>
	'''' Properti untuk menyimpan Password user
	'''' </summary>
	'''' <returns>String : Password</returns>
	'ReadOnly Property Password As String

	''' <summary>
	''' Kode Akses Pengguna
	''' </summary>
	''' <returns>Access Number</returns>
	ReadOnly Property Access As Integer

	''' <summary>
	''' Properti nama pengguna.
	''' </summary>
	''' <returns>Nama pengguna aktif.</returns>
	ReadOnly Property Name As String

	''' <summary>
	''' Foto pengguna.
	''' </summary>
	''' <returns>Picture Image</returns>
	ReadOnly Property Picture As BitmapImage
End Interface

Public Enum Access
	OnlyExploreWithoutDownloads = 0
	CanDownloadsExceptExecutable = 1
	CanDownloadsExecutable = 2
	CanBlockWebsite = 3
	CanCreateOrDeleteUser = 4
End Enum
