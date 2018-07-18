Imports CefSharp
Imports Netizeners

Public Class Downloader
	Implements IDownloader

	Public Property OnDownload As Boolean Implements IDownloader.OnDownload

	Public Event OnBeforeDownloadFired As EventHandler(Of DownloadItem) Implements IDownloader.OnBeforeDownloadFired
	Public Event OnDownloadUpdateFired As EventHandler(Of DownloadItem) Implements IDownloader.OnDownloadUpdateFired

	Public Sub OnBeforeDownload(browser As IBrowser, downloadItem As DownloadItem, callback As IBeforeDownloadCallback) Implements IDownloadHandler.OnBeforeDownload
		RaiseEvent OnBeforeDownloadFired(Me, downloadItem)

		If Not callback.IsDisposed Then
			'Download Using CEFSharp Browser... (TODO : Gunakan Downloader Sendiri)
			callback.Continue(downloadItem.SuggestedFileName, True)
		End If
	End Sub

	Public Sub OnDownloadUpdated(browser As IBrowser, downloadItem As DownloadItem, callback As IDownloadItemCallback) Implements IDownloadHandler.OnDownloadUpdated
		RaiseEvent OnDownloadUpdateFired(Me, downloadItem)
	End Sub
End Class
