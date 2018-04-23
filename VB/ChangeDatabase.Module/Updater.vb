Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Updating

Namespace ChangeDatabase.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			If Session.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Admin")) Is Nothing Then
				Dim user As New SimpleUser(Session)
				user.UserName = "Admin"
				user.Save()
			End If

			If Session.ConnectionString.Contains("DB1") Then
				If Session.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Admin1")) Is Nothing Then
					Dim user1 As New SimpleUser(Session)
					user1.UserName = "Admin1"
					user1.Save()
				End If
			End If
			If Session.ConnectionString.Contains("DB2") Then
				If Session.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Admin2")) Is Nothing Then
					Dim user2 As New SimpleUser(Session)
					user2.UserName = "Admin2"
					user2.Save()
				End If
			End If
		End Sub
	End Class
End Namespace
