Imports CefSharp

''' <summary>
''' Interface yang menangani proses download.
''' </summary>
Public Interface IDownloader
	Inherits IDownloadHandler

	''' <summary>
	''' Digunakan untuk menjadi tanda apakah proses download sudah selesai
	''' atau belum. True jika belum selesai dan False jika sudah selesai.
	''' </summary>
	''' <returns>Boolean : Keadaan proses download.</returns>
	Property OnDownload As Boolean

	''' <summary>
	''' Event ini yang akan dipanggil saat Sebelum download.
	''' </summary>
	Event OnBeforeDownloadFired As EventHandler(Of DownloadItem)

	''' <summary>
	''' Event ini yang akan dipanggil saat update.
	''' </summary>
	Event OnDownloadUpdateFired As EventHandler(Of DownloadItem)
End Interface
