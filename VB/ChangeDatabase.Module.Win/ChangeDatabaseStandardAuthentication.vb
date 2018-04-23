Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security

Namespace ChangeDatabase.Module.Win
	Public Class WinChangeDatabaseHelper
		Public Shared DatabaseName As String
		Public Shared AuthenticatedUserLogonFailed As Boolean = False
		Public Shared SkipLogonDialog As Boolean = False
	End Class

	Public Class WinChangeDatabaseStandardAuthentication
		Inherits AuthenticationStandard(Of SimpleUser, ChangeDatabaseStandardAuthenticationLogonParameters)
		Public Shared AuthenticatedUserName As String

		Public Overrides ReadOnly Overloads Property AskLogonParametersViaUI() As Boolean
			Get
				If WinChangeDatabaseHelper.SkipLogonDialog Then
					Return False
				End If
				Return MyBase.AskLogonParametersViaUI
			End Get
		End Property
		Public Overrides Overloads Function Authenticate(ByVal objectSpace As DevExpress.ExpressApp.IObjectSpace) As Object
			WinChangeDatabaseHelper.AuthenticatedUserLogonFailed = False
			If String.IsNullOrEmpty(AuthenticatedUserName) Then
				Return MyBase.Authenticate(objectSpace)
			Else
				Dim logonParameters As ChangeDatabaseStandardAuthenticationLogonParameters = CType(Me.LogonParameters, ChangeDatabaseStandardAuthenticationLogonParameters)
				Dim result As Object = objectSpace.FindObject(UserType, New BinaryOperator("UserName", logonParameters.UserName))
				If result Is Nothing Then
					WinChangeDatabaseHelper.AuthenticatedUserLogonFailed = True
					WinChangeDatabaseHelper.SkipLogonDialog = False
					Throw New AuthenticationException(logonParameters.UserName, SecurityExceptionLocalizer.GetExceptionMessage(SecurityExceptionId.RetypeTheInformation))
				End If
				AuthenticatedUserName = ""
				Return result
			End If
		End Function
	End Class

	Public Class WinChangeDatabaseActiveDirectoryAuthentication
		Inherits AuthenticationActiveDirectory(Of SimpleUser, ChangeDatabaseActiveDirectoryLogonParameters)
		Public Overrides ReadOnly Overloads Property AskLogonParametersViaUI() As Boolean
			Get
				If WinChangeDatabaseHelper.SkipLogonDialog Then
					Return False
				End If
				Return True
			End Get
		End Property

		Public Overrides Overloads Function Authenticate(ByVal objectSpace As DevExpress.ExpressApp.IObjectSpace) As Object
			WinChangeDatabaseHelper.AuthenticatedUserLogonFailed = False
			Try
				Return MyBase.Authenticate(objectSpace)
			Catch
				WinChangeDatabaseHelper.AuthenticatedUserLogonFailed = True
				WinChangeDatabaseHelper.SkipLogonDialog = False
				Throw
			End Try
		End Function
	End Class
End Namespace
