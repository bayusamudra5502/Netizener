Imports CefSharp

Public Class BrowserLoad
	Implements ILoadHandler

	Public Event OnLoadErrorEvent(args As LoadErrorEventArgs)
	Public Event OnLoadingStateChangeEvent(args As LoadingStateChangedEventArgs)
	Public Event OnFrameLoadStartEvent(args As FrameLoadStartEventArgs)
	Public Event OnFrameLoadEndEvent(args As FrameLoadEndEventArgs)

	Public Sub OnLoadingStateChange(browserControl As IWebBrowser, loadingStateChangedArgs As LoadingStateChangedEventArgs) Implements ILoadHandler.OnLoadingStateChange
		RaiseEvent OnLoadingStateChangeEvent(loadingStateChangedArgs)
	End Sub

	Public Sub OnFrameLoadStart(browserControl As IWebBrowser, frameLoadStartArgs As FrameLoadStartEventArgs) Implements ILoadHandler.OnFrameLoadStart
		RaiseEvent OnFrameLoadStartEvent(frameLoadStartArgs)
	End Sub

	Public Sub OnFrameLoadEnd(browserControl As IWebBrowser, frameLoadEndArgs As FrameLoadEndEventArgs) Implements ILoadHandler.OnFrameLoadEnd
		RaiseEvent OnFrameLoadEndEvent(frameLoadEndArgs)
	End Sub

	Public Sub OnLoadError(browserControl As IWebBrowser, loadErrorArgs As LoadErrorEventArgs) Implements ILoadHandler.OnLoadError
		RaiseEvent OnLoadErrorEvent(loadErrorArgs)

		Select Case loadErrorArgs.ErrorCode
			Case CefErrorCode.ConnectionAborted
				'...
		End Select
	End Sub
End Class
