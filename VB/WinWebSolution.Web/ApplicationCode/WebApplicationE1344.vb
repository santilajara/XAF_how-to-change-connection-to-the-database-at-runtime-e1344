Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports WinWebSolution.Module

Namespace WinWebSolution.Web
    Partial Public Class WinWebSolutionAspNetApplication
        Implements ISupportChangeDatabaseAtRuntime
        Public Sub ChangeTo(ByVal newConnectionString As String) Implements ISupportChangeDatabaseAtRuntime.ChangeTo
            Dim dataStoreProvider As IXpoDataStoreProvider = New ConnectionStringDataStoreProvider(newConnectionString)
            Setup(New ExpressApplicationSetupParameters(ApplicationName, CreateDefaultObjectSpaceProvider(dataStoreProvider), ControllersManager, DetailViewItemsFactory, Model, Modules))
            System.Web.HttpContext.Current.Response.Redirect("Default.aspx")
        End Sub
    End Class
End Namespace
