Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports DevExpress.ExpressApp.Security
Imports DevExpress.Persistent.BaseImpl

Namespace ChangeDatabase.Module.Web
	Public Class WebChangeDatabaseAuthenticationActiveDirectory
		Inherits AuthenticationActiveDirectory(Of SimpleUser, ChangeDatabaseActiveDirectoryLogonParameters)
		Public Sub New()
			Me.CreateUserAutomatically = True
		End Sub
		Public Overrides ReadOnly Overloads Property AskLogonParametersViaUI() As Boolean
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
