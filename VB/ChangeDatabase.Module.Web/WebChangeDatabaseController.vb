Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Web.SystemModule
Imports System.Web
Imports DevExpress.ExpressApp.Web
Imports System.Web.Security

Namespace ChangeDatabase.Module.Web
	Public Class WebChangeDatabaseController
		Inherits WindowController
		Public Const DatabaseParameterName As String = "DatabaseName"
		Public changeDatabaseAction As SingleChoiceAction
		Public Sub New()
			Me.TargetWindowType = WindowType.Main

			Dim category As String
			If WebApplication.OldStyleLayout Then
				category = "Tools"
			Else
				category = "Security"
			End If

			changeDatabaseAction = New SingleChoiceAction(Me, "ChangeDatabase", category)
			For Each databaseName As String In ChangeDatabaseHelper.Databases.Split(";"c)
				changeDatabaseAction.Items.Add(New ChoiceActionItem(databaseName, databaseName))
			Next databaseName
			AddHandler changeDatabaseAction.Execute, AddressOf changeDatabaseAction_Execute
		End Sub

		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			For Each item As ChoiceActionItem In changeDatabaseAction.Items
				If Application.ConnectionString.Contains(CStr(item.Data)) Then
					changeDatabaseAction.SelectedItem = item
					Exit For
				End If
			Next item
		End Sub
		Private Sub changeDatabaseAction_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs)
			SecuritySystem.Instance.Logoff()
			HttpContext.Current.Session.Abandon()
			WebApplication.Redirect(FormsAuthentication.DefaultUrl & "?" & DatabaseParameterName & "=" & CStr(e.SelectedChoiceActionItem.Data))
		End Sub
	End Class

End Namespace
