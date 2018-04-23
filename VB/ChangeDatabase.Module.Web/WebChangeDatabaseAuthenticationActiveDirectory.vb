Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports System.Web
Imports DevExpress.ExpressApp.Web
Imports System.Web.Security

Namespace ChangeDatabase.Module.Web
	Public Class WebChangeDatabaseAuthenticationActiveDirectory
		Inherits AuthenticationActiveDirectory(Of DevExpress.Persistent.BaseImpl.SimpleUser, ChangeDatabaseActiveDirectoryLogonParameters)
		Public Sub New()
			Me.CreateUserAutomatically = True
		End Sub
		Public Overrides ReadOnly Property AskLogonParametersViaUI() As Boolean
			Get
				Dim databaseName As String = HttpContext.Current.Request.Params(WebChangeDatabaseController.DatabaseParameterName)
				If String.IsNullOrEmpty(databaseName) Then
					Return True
				End If
				Return MyBase.AskLogonParametersViaUI
			End Get
		End Property
	End Class
End Namespace
