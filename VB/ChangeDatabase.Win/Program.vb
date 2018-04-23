Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports ChangeDatabase.Module.Win
Imports DevExpress.ExpressApp.Security

Namespace ChangeDatabase.Win
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
#If EASYTEST Then
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim winApplication As ChangeDatabaseWindowsFormsApplication = ChangeDatabaseWindowsFormsApplication.CreateApplication()
            Try
                DevExpress.ExpressApp.InMemoryDataStoreProvider.Register()
                                winApplication.ConnectionString = DevExpress.ExpressApp.InMemoryDataStoreProvider.ConnectionString
                winApplication.Setup()
                winApplication.Start()
            Catch e As Exception
                winApplication.HandleException(e)
            End Try
            winApplication.Dispose()
        End Sub
	End Class
End Namespace
