Imports System.Data

''' <summary>
''' Interface yang menangani semua masalah database.
''' </summary>
Public Interface IDatabase(Of T)
	''' <summary>
	''' Properti yang menjadi tanda apakah sudah tersambung ke database.
	''' </summary>
	''' <returns>Menghasilkan True jika sudah terkoneksi</returns>
	ReadOnly Property IsConnected As Boolean

	''' <summary>
	''' Properti string koneksi database SQLite. Diisi saat New()
	''' </summary>
	''' <returns>Koneksi String</returns>
	ReadOnly Property ConnectionString As String

	''' <summary>
	''' Fungsi untuk menyambungkan ke database.
	''' </summary>
	''' <returns>Menghasilkan True Bila berhasil tersambung</returns>
	Function Connect() As Task(Of Boolean)

	''' <summary>
	''' Fungsi untuk mendapatkan data tabel kolom pertama dan baris pertama dari
	''' Query database yang dijalankan. Keunggulannya tipe data bisa yang kita inginkan
	''' Tetapi berhati-hatilah karena bisa timbul error saat konversi.
	''' </summary>
	''' <param name="Query">Perintah SQL yang dimaksud</param>
	''' <returns>Data yang didapatkan setelah menjalankan Query</returns>
	Function GetDataScalar(ByVal Query As String) As Task(Of T) 'Obat Generik :v

	''' <summary>
	''' Versi yang lebih aman dari GetDataScalar(...) As Task(Of T) yang membiarkan
	''' konversi secara manual
	''' </summary>
	''' <param name="Query">Perintah SQL yang dimaksud</param>
	''' <returns>Data yang didapatkan setelah menjalankan Query</returns>
	Function GetDataScalarSafe(ByVal Query As String) As Task(Of Object)

	''' <summary>
	''' Mendapatkan Dataset dari database sesuai dengan Perintah SQL yang dimaksud.
	''' </summary>
	''' <param name="Query">Perintah SQL yang dimaksud</param>
	''' <returns>DataSet yang didapatkan setelah menjalankan Query</returns>
	Function GetDataSet(ByVal Query As String) As Task(Of DataSet)

	''' <summary>
	''' Menjalankan Perintah SQL tanpa memperhatikan hasilnya.
	''' </summary>
	''' <param name="Query">Perintah SQL yang dimaksud</param>
	''' <returns>Menghasilkan True jika berhasil.</returns>
	Function RunQuery(ByVal Query As String) As Task(Of Boolean)
End Interface