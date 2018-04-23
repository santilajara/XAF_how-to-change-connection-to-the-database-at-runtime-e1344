Imports DevExpress.ExpressApp
Imports WinWebSolution.Module

Namespace WinWebSolution.Win
    Partial Public Class WinWebSolutionWindowsFormsApplication
        Implements ISupportChangeDatabaseAtRuntime
        Public Sub ChangeTo(ByVal newConnectionString As String) Implements ISupportChangeDatabaseAtRuntime.ChangeTo
            ShowViewStrategy.CloseAllWindows()
            Dim dataStoreProvider As IXpoDataStoreProvider = New ConnectionStringDataStoreProvider(newConnectionString)
            Setup(Me.ApplicationName, CreateDefaultObjectSpaceProvider(dataStoreProvider))
            ShowViewStrategy.ShowStartupWindow()
        End Sub
    End Class
End Namespace