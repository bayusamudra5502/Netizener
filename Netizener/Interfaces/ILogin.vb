Imports Netizeners
''' <summary>
''' Interface yang menangani proses login
''' </summary>
Public Interface ILogin
	''' <summary>
	''' Menyimpan data Username untuk proses login. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan Username</returns>
	ReadOnly Property Username As String

	''' <summary>
	''' Buat nyimpen Password. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan Password</returns>
	ReadOnly Property Password As String

	''' <summary>
	''' Menyimpan koneksi string yang digunakan database nanti. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan connectionString</returns>
	ReadOnly Property ConnectionString As String

	''' <summary>
	''' Indikator apakah udah login belom?
	''' </summary>
	''' <returns>Menghasilkan keadaan login</returns>
	ReadOnly Property IsLogged As Boolean

	''' <summary>
	''' Menyimpan data Username untuk proses login. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan Sukses tidak login</returns>
	Function Login() As Task(Of Boolean)

	''' <summary>
	''' Mendapatkan apakah memiliki akses atau tidak.
	''' </summary>
	''' <param name="Access">Nomor Akses</param>
	''' <returns>Keputusan kepemilikan akses.</returns>
	Function HasAccess(Access As Access) As Task(Of Boolean)

	''' <summary>
	''' Mendapatkan apakah memiliki akses atau tidak.
	''' </summary>
	''' <remarks>HANYA UNTUK LEBIH DARI 1 AKSES SAJA</remarks>
	''' <param name="Access">Untuk Nomor akses lebih dari 1</param>
	''' <returns>Keputusan kepemilikan akses.</returns>
	Function HasAccess(ParamArray Access() As Access) As Task(Of Boolean)

	''' <summary>
	''' Mendapatkan keputusan apakah memiliki akses atau tidak.
	''' </summary>
	''' <param name="Access">Nomor Akses dimulai dari 1</param>
	''' <returns>Keputusan kepemilikan akses.</returns>
	Function HasAccess(Access As Integer) As Task(Of Boolean)

	''' <summary>
	''' Mendapatkan hak akses user. Harus jalanin dulu fungsi login.
	''' </summary>
	''' <returns>Mendapatkan kolom 'Akses'</returns>
	Function GetAccess() As Task(Of Integer)
End Interface