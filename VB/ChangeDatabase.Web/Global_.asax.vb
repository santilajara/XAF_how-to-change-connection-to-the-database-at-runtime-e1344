Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp
Imports System.Configuration
Imports ChangeDatabase.Module
Imports ChangeDatabase.Module.Web
Imports DevExpress.Persistent.BaseImpl

Namespace ChangeDatabase.Web
	Partial Public Class [Global]
		Inherits System.Web.HttpApplication
		Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
			WebApplication.SetInstance(Session, New ChangeDatabaseAspNetApplication())

			CType(WebApplication.Instance.Security, SecurityBase).Authentication = New AuthenticationStandard(Of SimpleUser, ChangeDatabaseStandardAuthenticationLogonParameters)()

			'CType(WebApplication.Instance.Security, SecurityBase).Authentication = New WebChangeDatabaseAuthenticationActiveDirectory()

			WebApplication.Instance.CanAutomaticallyLogonWithStoredLogonParameters = True

			If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
				WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			End If
			WebApplication.Instance.Setup()
			WebApplication.Instance.Start()
		End Sub
	End Class
End Namespace