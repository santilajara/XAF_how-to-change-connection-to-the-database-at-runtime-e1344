Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win.SystemModule

Namespace ChangeDatabase.Module.Win
	Public Interface IApplicationFactory
		Function CreateApplication() As WinApplication
	End Interface

	Public Class WinChangeDatabaseController
		Inherits WindowController
		Public Shared NewApplication As WinApplication = Nothing
		Public changeDatabaseAction As SingleChoiceAction
		Public Sub New()
			Me.TargetWindowType = WindowType.Main

			changeDatabaseAction = New SingleChoiceAction(Me, "ChangeDatabase", PredefinedCategory.View)
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
			NewApplication = (CType(Application, IApplicationFactory)).CreateApplication()

			WinChangeDatabaseHelper.DatabaseName = CStr(e.SelectedChoiceActionItem.Data)
			WinChangeDatabaseHelper.SkipLogonDialog = True
			WinChangeDatabaseStandardAuthentication.AuthenticatedUserName = SecuritySystem.CurrentUserName

			Frame.GetController(Of ExitController)().ExitAction.DoExecute()

			CType(NewApplication.Security.LogonParameters, IDatabaseNameParameter).DatabaseName = WinChangeDatabaseHelper.DatabaseName
			Dim authenticationStandardLogonParameters As AuthenticationStandardLogonParameters = TryCast(NewApplication.Security.LogonParameters, AuthenticationStandardLogonParameters)
			If authenticationStandardLogonParameters IsNot Nothing Then
				authenticationStandardLogonParameters.UserName = WinChangeDatabaseStandardAuthentication.AuthenticatedUserName
			End If
		End Sub
	End Class
End Namespace
