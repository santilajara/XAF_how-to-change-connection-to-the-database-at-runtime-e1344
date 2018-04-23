Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions

Namespace WinWebSolution.Module
	Partial Public Class ChangeDatabaseAtRuntimeWindowController
		Inherits WindowController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
			TargetWindowType = WindowType.Main
		End Sub
		Private Sub scaChangeTo_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs) Handles scaChangeTo.Execute
			CType(Application, ISupportChangeDatabaseAtRuntime).ChangeTo(e.SelectedChoiceActionItem.Data.ToString())
		End Sub
	End Class
End Namespace