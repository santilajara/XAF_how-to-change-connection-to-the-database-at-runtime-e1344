Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports WinWebSolution.Module

Namespace WinWebSolution.Win
    Partial Public Class WinWebSolutionWindowsFormsApplication
        Implements ISupportChangeDatabaseAtRuntime
        Public Sub ChangeTo(ByVal newConnectionString As String) Implements ISupportChangeDatabaseAtRuntime.ChangeTo
            Dim dataStoreProvider As IXpoDataStoreProvider = New ConnectionStringDataStoreProvider(newConnectionString)
            Setup(New ExpressApplicationSetupParameters(ApplicationName, CreateDefaultObjectSpaceProvider(dataStoreProvider), ControllersManager, DetailViewItemsFactory, Model, Modules))
            ShowViewStrategy.CloseAllWindows()
            ShowViewStrategy.ShowStartupWindow()
        End Sub
    End Class
End Namespace
