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
	''' Mendapatkan hak akses user. Harus jalanin dulu fungsi login.
	''' </summary>
	''' <returns>Mendapatkan kolom 'Akses'</returns>
	Function GetAccess() As Task(Of Integer)

	''' <summary>
	''' Punya akses ga untuk ngakses aksi yang ditunjukan nomor. Tanya ke Bayu nanti.
	''' </summary>
	''' <param name="Code">Kode pada list</param>
	''' <returns>Menghasilkan keadaan bisa akses ga</returns>
	Function HasAccess(ByVal Code As Integer) As Task(Of Boolean)
End Interface