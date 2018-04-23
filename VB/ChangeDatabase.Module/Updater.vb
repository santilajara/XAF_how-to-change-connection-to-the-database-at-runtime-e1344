Imports Microsoft.VisualBasic
Imports DevExpress.ExpressApp
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Updating

Namespace ChangeDatabase.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As ObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			If ObjectSpace.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Admin")) Is Nothing Then
				Dim user As SimpleUser = ObjectSpace.CreateObject(Of SimpleUser)()
				user.UserName = "Admin"
				user.Save()
			End If

            If ObjectSpace.Session.ConnectionString.Contains("DB1") Then
                If ObjectSpace.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Admin1")) Is Nothing Then
                    Dim user1 As SimpleUser = ObjectSpace.CreateObject(Of SimpleUser)()
                    user1.UserName = "Admin1"
                    user1.Save()
                End If
            End If
            If ObjectSpace.Session.ConnectionString.Contains("DB2") Then
                If ObjectSpace.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Admin2")) Is Nothing Then
                    Dim user2 As SimpleUser = ObjectSpace.CreateObject(Of SimpleUser)()
                    user2.UserName = "Admin2"
                    user2.Save()
                End If
            End If
		End Sub
	End Class
End Namespace
