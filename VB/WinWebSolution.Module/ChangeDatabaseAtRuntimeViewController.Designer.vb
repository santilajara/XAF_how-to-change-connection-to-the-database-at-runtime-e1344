Imports Microsoft.VisualBasic
Imports System
Namespace WinWebSolution.Module
	Partial Public Class ChangeDatabaseAtRuntimeWindowController
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim choiceActionItem1 As New DevExpress.ExpressApp.Actions.ChoiceActionItem()
			Dim choiceActionItem2 As New DevExpress.ExpressApp.Actions.ChoiceActionItem()
			Me.scaChangeTo = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
			' 
			' scaChangeTo
			' 
			Me.scaChangeTo.Caption = "Change Database To"
			Me.scaChangeTo.Id = "b4b17f3a-386d-4b60-bfe2-ca0add553f14"
			Me.scaChangeTo.ItemHierarchyType = DevExpress.ExpressApp.Actions.ChoiceActionItemHierarchyType.Tree
			choiceActionItem1.Caption = "DB 1"
			choiceActionItem1.Data = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=DB1"
			choiceActionItem2.Caption = "DB 2"
			choiceActionItem2.Data = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=DB2"
			Me.scaChangeTo.Items.Add(choiceActionItem1)
			Me.scaChangeTo.Items.Add(choiceActionItem2)
			Me.scaChangeTo.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
'			Me.scaChangeTo.Execute += New DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(Me.scaChangeTo_Execute);

		End Sub

		#End Region

		Private WithEvents scaChangeTo As DevExpress.ExpressApp.Actions.SingleChoiceAction

	End Class
End Namespace
