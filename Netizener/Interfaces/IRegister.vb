Imports System.Data

''' <summary>
''' Interface yang mengatur segala Register
''' </summary>
Public Interface IRegister
	''' <summary>
	''' Properti untuk nyimpen Username Admin. Diisi saat New()
	''' </summary>
	''' <returns>Username Admin</returns>
	ReadOnly Property AdminUser As String

	''' <summary>
	''' Properti buat nyimpen Password si Admin. Diisi saat New()
	''' </summary>
	''' <returns>Password Admin</returns>
	ReadOnly Property AdminPass As String

	''' <summary>
	''' Properti koneksi string yang digunakan database nanti. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan connectionString</returns>
	ReadOnly Property ConnectionString As String

	''' <summary>
	''' Fungsi untuk nambahin User
	''' </summary>
	''' <param name="Username">Username pengguna yang mau ditambahin</param>
	''' <param name="Password">Password pengguna yang mau ditambahin</param>
	''' <param name="AccessCode">Apa aja yang bisa dia lakukan? Diatur pake kode akses.</param>
	''' <returns>Berhasil kagak? Kalo berhasil ngasilin True.</returns>
	Function RegisterUser(ByVal Username As String, ByVal Password As String,
						  ByVal AccessCode As Integer) As Task(Of Boolean)

	''' <summary>
	''' Fungsi untuk ngecek ada ga pengguna yang usernamenya sama?
	''' </summary>
	''' <param name="username">Nama Username yang mau di cek.</param>
	''' <returns>True kalo ada.</returns>
	Function IsUserAvailable(ByVal username As String) As Task(Of Boolean)

	''' <summary>
	''' Fungsi mencari kolom yang dimaksud.
	''' </summary>
	''' <param name="SearchWithColumn">Kolom apa yang jadi pacuan?</param>
	''' <param name="ValueToSearch">Apa nilai pada kolom yang dimaksud yang ingin dicari?</param>
	''' <param name="Column">Kolom keluaran yang diinginkan</param>
	''' <returns>Dataset Kolom Hasil</returns>
	Function FindColumn(ByVal SearchWithColumn As String,
						ByVal ValueToSearch As String, ByVal Column As String) As Task(Of DataSet)

	''' <summary>
	''' Fungsi mencari kolom yang memenuhi kriteria.
	''' </summary>
	''' <param name = "SearchWithColumn" > Kolom apa yang jadi pacuan?</param>
	''' <param name="ValueToSearch">Apa nilai pada kolom yang dimaksud yang ingin dicari?</param>
	''' <param name="Columns">Kolom keluaran yang diinginkan</param>
	''' <returns>Dataset Kolom Hasi</returns>
	Function FindColums(ByVal SearchWithColumn As String, ByVal ValueToSearch As String,
						ParamArray Columns() As String) As Task(Of DataSet)

	''' <summary>
	''' Fungsi Untuk Menghapus Pengguna.
	''' </summary>
	''' <param name="Username">Username yang akan dihapus</param>
	''' <returns>Menghasilkan True jika berhasil.</returns>
	Function UnRegister(ByVal Username As String) As Task(Of Boolean)
End Interface
