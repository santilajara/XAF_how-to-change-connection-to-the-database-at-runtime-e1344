Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace ChangeDatabase.Web
	Partial Public Class ChangeDatabaseAspNetApplication
		Inherits WebApplication
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProviderThreadSafe(args.ConnectionString, args.Connection)
        End Sub
		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
		Private module3 As ChangeDatabase.Module.ChangeDatabaseModule
		Private module4 As ChangeDatabase.Module.Web.ChangeDatabaseAspNetModule
		Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
		Private securitySimple1 As DevExpress.ExpressApp.Security.SecuritySimple
		Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
		Private sqlConnection1 As System.Data.SqlClient.SqlConnection
		Private authenticationStandard2 As DevExpress.ExpressApp.Security.AuthenticationStandard
		Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ChangeDatabaseAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
			e.Updater.Update()
			e.Handled = True
#Else
			If System.Diagnostics.Debugger.IsAttached Then
				e.Updater.Update()
				e.Handled = True
			Else
				Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & Constants.vbCrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & Constants.vbCrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & Constants.vbCrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
			End If
#End If
		End Sub

		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
			Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
			Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
			Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
			Me.securitySimple1 = New DevExpress.ExpressApp.Security.SecuritySimple()
			Me.authenticationStandard2 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
			Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
			Me.module3 = New ChangeDatabase.Module.ChangeDatabaseModule()
			Me.module4 = New ChangeDatabase.Module.Web.ChangeDatabaseAspNetModule()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' module5
			' 
			Me.module5.AllowValidationDetailsAccess = True
			' 
			' securitySimple1
			' 
			Me.securitySimple1.Authentication = Me.authenticationStandard2
			Me.securitySimple1.IsGrantedForNonExistentPermission = False
			Me.securitySimple1.UserType = GetType(DevExpress.Persistent.BaseImpl.SimpleUser)
			' 
			' authenticationStandard2
			' 
			Me.authenticationStandard2.LogonParametersType = GetType(ChangeDatabase.Module.ChangeDatabaseStandardAuthenticationLogonParameters)
			' 
			' sqlConnection1
			' 
			Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=ChangeDatabase;Integrated Security=SSPI;Pooli" & "ng=false"
			Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
			' 
			' ChangeDatabaseAspNetApplication
			' 
			Me.ApplicationName = "ChangeDatabase"
			Me.Connection = Me.sqlConnection1
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module6)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module4)
			Me.Modules.Add(Me.module5)
			Me.Modules.Add(Me.securityModule1)
			Me.Security = Me.securitySimple1
'			Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.ChangeDatabaseAspNetApplication_DatabaseVersionMismatch);
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
	End Class
End Namespace
