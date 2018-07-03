Imports System.Data

''' <summary>
''' Interface yang mengatur segala urusan yang berhubungan dengan bookmark
''' </summary>
Public Interface IBookmark
	''' <summary>
	''' Properti alamat URL yang mau dijadiin bookmark.
	''' </summary>
	''' <returns>URL Bookmark</returns>
	Property URL As String

	''' <summary>
	''' Properti Nama Bookmark yang ingin disimpan.
	''' </summary>
	''' <returns>Namanya</returns>
	Property BookmarkName As String

	''' <summary>
	''' Properti koneksi string yang digunakan database nanti. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan connectionString</returns>
	ReadOnly Property ConnectionString As String

	''' <summary>
	''' Fungsi Async Untuk nyimpen bookmark.
	''' </summary>
	''' <returns>Menghasilkan True Kalo berhasil</returns>
	Function Save() As Task(Of Boolean)

	''' <summary>
	''' Fungsi untuk dapetin semua data dari tabel 'Bookmark'.
	''' </summary>
	''' <returns>Dataset Kelas Bookmark terkini</returns>
	Function GetBookmarkDataSet() As Task(Of DataSet)

	''' <summary>
	''' Fungsi menghapus semua data bookmark
	''' </summary>
	''' <returns>Menghasilkan True Kalo berhasil</returns>
	Function DeleteAll() As Task(Of Boolean)

	''' <summary>
	''' Fungsi menghapus semua data yang memiliki URL yang dimaksud.
	''' </summary>
	''' <param name="URL">Alamat Web yang bakal dihapus</param>
	''' <returns>Menghasilkan True Kalo berhasil</returns>
	Function DeleteByURL(ByVal URL As String) As Task(Of Boolean)

	''' <summary>
	''' Fungsi menghapus semua data yang memiliki nama yang dimaksud.
	''' </summary>
	''' <param name="Name">Nama yang bakal dihapus</param>
	''' <returns>Menghasilkan True Kalo berhasil</returns>
	Function DeleteByName(ByVal Name As String) As Task(Of Boolean)

	''' <summary>
	''' Fungsi menghapus data sesuai ID.
	''' </summary>
	''' <param name="ID">ID yang bakal Dihapus</param>
	''' <returns>Menghasilkan True Kalo berhasil</returns>
	Function DeleteByID(ByVal ID As Integer) As Task(Of Boolean)

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
	''' <returns>Dataset Kolom Hasil</returns>
	Function FindColums(ByVal SearchWithColumn As String, ByVal ValueToSearch As String,
						ParamArray Columns() As String) As Task(Of DataSet)
End Interface
