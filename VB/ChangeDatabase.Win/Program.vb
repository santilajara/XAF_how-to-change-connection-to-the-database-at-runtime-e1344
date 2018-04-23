Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports ChangeDatabase.Module
Imports ChangeDatabase.Module.Win

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
			DevExpress.ExpressApp.EasyTest.WinAdapter.RemotingRegistration.Register(4100)
#End If

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
			Do
				Dim winApplication As ChangeDatabaseWindowsFormsApplication
				If WinChangeDatabaseController.NewApplication Is Nothing Then
					winApplication = ChangeDatabaseWindowsFormsApplication.CreateApplication()
				Else
					winApplication = CType(WinChangeDatabaseController.NewApplication, ChangeDatabaseWindowsFormsApplication)
					WinChangeDatabaseController.NewApplication = Nothing
				End If
				Try
					winApplication.Setup()
					winApplication.Start()
					If WinChangeDatabaseHelper.AuthenticatedUserLogonFailed Then
						WinChangeDatabaseHelper.SkipLogonDialog = False
						winApplication.Start()
					End If
				Catch e As Exception
					winApplication.HandleException(e)
				End Try
				winApplication.Dispose()
			Loop While WinChangeDatabaseController.NewApplication IsNot Nothing
		End Sub
	End Class
End Namespace
