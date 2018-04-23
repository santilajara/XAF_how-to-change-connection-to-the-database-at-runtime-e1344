Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports ChangeDatabase.Module.Web
Imports System.Web
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.ExpressApp
Imports ChangeDatabase.Module
Imports System.Web.Security

Namespace ChangeDatabase.Web
	Partial Public Class ChangeDatabaseAspNetApplication
		Inherits WebApplication
		Protected Overrides Sub ReadSecuredLogonParameters()
			MyBase.ReadSecuredLogonParameters() ' the "UserName" is restored in the base method.

			Dim databaseName As String = HttpContext.Current.Request.Params(WebChangeDatabaseController.DatabaseParameterName)
			If (Not String.IsNullOrEmpty(databaseName)) Then
				CType(SecuritySystem.LogonParameters, IDatabaseNameParameter).DatabaseName = databaseName
			End If
		End Sub
		Private canReadSecuredLogonParameters_Renamed As Boolean = True
		Protected Overrides Function CanReadSecuredLogonParameters() As Boolean
			If (Not canReadSecuredLogonParameters_Renamed) Then
				Return False
			End If
			Return MyBase.CanReadSecuredLogonParameters()
		End Function
		Protected Overrides Function OnLogonFailed(ByVal logonParameters As Object, ByVal e As Exception) As Boolean
			If CanReadSecuredLogonParameters() Then
				FormsAuthentication.SignOut()
				canReadSecuredLogonParameters_Renamed = False
				Try
					Start()
				Finally
					canReadSecuredLogonParameters_Renamed = True
				End Try
				Return True
			Else
				Return MyBase.OnLogonFailed(logonParameters, e)
			End If
		End Function
		Protected Overrides Sub ReadLastLogonParametersCore(ByVal storage As DevExpress.ExpressApp.Utils.SettingsStorage, ByVal logonObject As Object)
			'string databaseName = HttpContext.Current.Request.Params[WebChangeDatabaseController.DatabaseParameterName];
			If String.IsNullOrEmpty((CType(logonObject, IDatabaseNameParameter)).DatabaseName) Then
				MyBase.ReadLastLogonParametersCore(storage, logonObject)
			End If
		End Sub
		Protected Overrides Sub OnLoggingOn(ByVal args As LogonEventArgs)
			MyBase.OnLoggingOn(args)
			ChangeDatabaseHelper.UpdateDatabaseName(Me, (CType(args.LogonParameters, IDatabaseNameParameter)).DatabaseName)
		End Sub
	End Class
End Namespace