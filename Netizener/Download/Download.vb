Imports System.Data
Imports Netizeners

Public Class Download
	Implements IDownload

#Region "Variables"
	Dim Data As DownloadData
#End Region

#Region "Constructors"
	Public Sub New(FileName As String, SourcePath As String, SavePath As String)
		'FILL DATA
		Data.FileName = FileName
		Data.SourcePath = SourcePath
		Data.SavePath = SavePath

		'FILL PROPERTIES
		Me.FileName = FileName
		Me.SourcePath = SourcePath
		Me.SavePath = SavePath
	End Sub

	Public Sub New(ContinueData As Download)
		ID = ContinueData.ID
		FileName = ContinueData.FileName
		SourcePath = ContinueData.SourcePath
		SavePath = ContinueData.SavePath
		Status = ContinueData.Status
		ConnectionString = ContinueData.ConnectionString

		Data.SavePath = SavePath
		Data.SourcePath = SourcePath
		Data.FileName = FileName
	End Sub

	Public Sub New(Data As DownloadData)
		Me.Data = Data
	End Sub
#End Region

#Region "Properties"
	Public ReadOnly Property ID As Integer Implements IDownload.ID
	Public ReadOnly Property FileName As String Implements IDownload.FileName
	Public ReadOnly Property SourcePath As String Implements IDownload.SourcePath
	Public ReadOnly Property SavePath As String Implements IDownload.SavePath
	Public ReadOnly Property Status As IDownload.DownloadStatus Implements IDownload.Status
	'DEPRECATED
	Public ReadOnly Property ConnectionString As String Implements IDownload.ConnectionString
#End Region

#Region "Structures"
	Structure DownloadData
		''' <summary>
		'''	Nama File yang akan disimpan.
		''' </summary>
		''' <returns>Nama File</returns>
		Public Property FileName As String

		''' <summary>
		''' Alamat web dimana file diterima
		''' </summary>
		''' <returns>Alamat Web file diterima</returns>
		Public Property SourcePath As String

		''' <summary>
		''' Letak penyimpanan data dalam local.
		''' </summary>
		''' <returns>Lokasi penyimpanan</returns>
		Public Property SavePath As String

	End Structure

	Structure DownloadProperties
		''' <summary>
		'''	Nama File yang akan disimpan.
		''' </summary>
		''' <returns>Nama File</returns>
		Public Property FileName As String

		''' <summary>
		''' Alamat web dimana file diterima
		''' </summary>
		''' <returns>Alamat Web file diterima</returns>
		Public Property SourcePath As String

		''' <summary>
		''' Letak penyimpanan data dalam local.
		''' </summary>
		''' <returns>Lokasi penyimpanan</returns>
		Public Property SavePath As String

		''' <summary>
		''' Menghasilkan Besar Data yang didownload dalam Byte
		''' </summary>
		''' <returns>Besar File</returns>
		Public Property FileSize As Long
	End Structure

	Structure DownloadProgress
		Property DownloadID As Integer
		Property Recieved As Long
		Property TotalBytes As Long
		Property Status As IDownload.DownloadStatus
	End Structure
#End Region

#Region "Private Functions"
	Private Function Add() As Task(Of Boolean) Implements IDownload.Add
		Throw New NotImplementedException()
	End Function

	Private Function SetStatus(ID As Integer, Status As Integer) As Task(Of Boolean) Implements IDownload.SetStatus
		Throw New NotImplementedException()
	End Function
#End Region

#Region "Shared Function"
	''' <summary>
	''' Fungsi untuk ngasilin dataset yang berguna kalo mau tampilin data.
	''' </summary>
	''' <returns>Dataset tabel 'Download'</returns>
	Public Shared Function GetDownloadedDataSet() As Task(Of DataSet)
		Throw New NotImplementedException()
	End Function
#End Region

#Region "Events"
	Public Event IsDownloaded(e As DownloadData)
	Public Event BeginDownloaded(e As DownloadData)
	Public Event IsCanceled(e As DownloadData)
	Public Event Downloading(e As DownloadData)
#End Region

	Public Function StartDownload(Optional OpenDownloadDialog As Boolean = True) As Task(Of IDownload.DownloadStatus)
		Dim hasil As IDownload.DownloadStatus = IDownload.DownloadStatus.BeginDownload
		If OpenDownloadDialog Then

		Else

		End If
	End Function

	Public Function DeleteAll() As Task(Of Boolean) Implements IDownload.DeleteAll
		Throw New NotImplementedException()
	End Function

	Public Function DeleteByURL(URL As String) As Task(Of Boolean) Implements IDownload.DeleteByURL
		Throw New NotImplementedException()
	End Function

	Public Function DeleteByFileName(FileName As String) As Task(Of Boolean) Implements IDownload.DeleteByFileName
		Throw New NotImplementedException()
	End Function

	Public Function DeleteByID(ID As Integer) As Task(Of Boolean) Implements IDownload.DeleteByID
		Throw New NotImplementedException()
	End Function

	Public Function FindColumn(SearchWithColumn As String, ValueToSearch As String, Column As String) As Task(Of DataSet) Implements IDownload.FindColumn
		Throw New NotImplementedException()
	End Function

	Public Function FindColums(SearchWithColumn As String, ValueToSearch As String, ParamArray Columns() As String) As Task(Of DataSet) Implements IDownload.FindColums
		Throw New NotImplementedException()
	End Function
End Class