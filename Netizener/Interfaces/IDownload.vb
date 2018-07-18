Imports System.Data

''' <summary>
''' Interface yang mengatur kalo ada yang didownload, data disimpen ke DB.
''' </summary>
Public Interface IDownload
	'Kalo mau implementasiin ini, bikin dua fungsi new()
	' Yang pertama tanpa parameter, isinya biarin kosong
	' Yang kedua ada parameter ID as Integer.

	''' <summary>
	''' Properti ID Download. Ditampilin kalo udah di Add(). Atau kalo udah kedownload,
	''' Dimasukin di Prosedur New()
	''' </summary>
	''' <returns>ID Download yang ditambahkan</returns>
	ReadOnly Property ID As Integer 'Didapet kalo udah di Add

	''' <summary>
	''' Nama file yang akan, sedang, sudah di download.
	''' </summary>
	''' <returns>Nama file yang didownload</returns>
	ReadOnly Property FileName As String

	''' <summary>
	''' Dari URL manakah file ini diambil?
	''' </summary>
	''' <returns>URL Sumber</returns>
	ReadOnly Property SourcePath As String

	''' <summary>
	''' Dimanakah file yang didownload ini disimpan?
	''' </summary>
	''' <returns>Path File disimpan.</returns>
	ReadOnly Property SavePath As String

	''' <summary>
	''' Status yang dialami oleh file tersebut.
	''' </summary>
	''' <returns>Status</returns>
	ReadOnly Property Status As DownloadStatus

	''' <summary>
	''' Menyimpan koneksi string yang digunakan database nanti. Diisi saat New()
	''' </summary>
	''' <returns>Menghasilkan connectionString</returns>
	ReadOnly Property ConnectionString As String

	''' <summary>
	''' Enum Status. Cara pakenya:
	''' (Objek).DownloadStatus.Downloaded
	''' </summary>
	Enum DownloadStatus
		Downloaded = 0
		IsDownloading = 1
		Failed = 2
		Cancelled = 3
		BeginDownload = 4
	End Enum

	''' <summary>
	''' Fungsi Tambah data
	''' </summary>
	''' <returns>Menghasilkan True Kalo Berhasil</returns>
	Function Add() As Task(Of Boolean)

	''' <summary>
	''' Fungsi Untuk Mengeset Status.
	''' </summary>
	''' <param name="ID">ID yang ingin diganti.</param>
	''' <param name="Status">Nilai statusnya apa?</param>
	''' <returns>Menghasilkan True kalo berhasil</returns>
	Function SetStatus(ByVal ID As Integer, ByVal Status As Integer) As Task(Of Boolean)

	'''' <summary>
	'''' Fungsi untuk ngasilin dataset yang berguna kalo mau tampilin data.
	'''' </summary>
	'''' <returns>Dataset tabel 'Download'</returns>
	'Function GetDownloadedDataSet() As Task(Of DataSet)

	''' <summary>
	''' Fungsi menghapus semua data Download
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
	''' Fungsi menghapus semua data yang memiliki nama file yang dimaksud.
	''' </summary>
	''' <param name="FileName">Nama yang bakal dihapus</param>
	''' <returns>Menghasilkan True Kalo berhasil</returns>
	Function DeleteByFileName(ByVal FileName As String) As Task(Of Boolean)

	''' <summary>
	''' Fungsi menghapus sesuai ID yang dimaksud.
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
	''' <returns>Dataset Kolom Hasi</returns>
	Function FindColums(ByVal SearchWithColumn As String, ByVal ValueToSearch As String,
						ParamArray Columns() As String) As Task(Of DataSet)
End Interface