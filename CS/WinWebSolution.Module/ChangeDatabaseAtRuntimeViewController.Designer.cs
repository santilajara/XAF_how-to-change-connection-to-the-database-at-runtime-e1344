namespace WinWebSolution.Module {
    partial class ChangeDatabaseAtRuntimeWindowController {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.scaChangeTo = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // scaChangeTo
            // 
            this.scaChangeTo.Caption = "Change Database To";
            this.scaChangeTo.Id = "b4b17f3a-386d-4b60-bfe2-ca0add553f14";
            this.scaChangeTo.ItemHierarchyType = DevExpress.ExpressApp.Actions.ChoiceActionItemHierarchyType.Tree;
            choiceActionItem1.Caption = "DB 1";
            choiceActionItem1.Data = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=DB1";
            choiceActionItem2.Caption = "DB 2";
            choiceActionItem2.Data = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=DB2";
            this.scaChangeTo.Items.Add(choiceActionItem1);
            this.scaChangeTo.Items.Add(choiceActionItem2);
            this.scaChangeTo.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.scaChangeTo.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.scaChangeTo_Execute);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaChangeTo;

    }
}
