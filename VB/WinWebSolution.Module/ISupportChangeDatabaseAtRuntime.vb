Imports Microsoft.VisualBasic
Imports System
Namespace WinWebSolution.Module
	Public Interface ISupportChangeDatabaseAtRuntime
		Sub ChangeTo(ByVal newConnectionString As String)
	End Interface
End Namespace
