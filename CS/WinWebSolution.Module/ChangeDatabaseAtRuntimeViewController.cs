using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace WinWebSolution.Module {
    public partial class ChangeDatabaseAtRuntimeWindowController : WindowController {
        public ChangeDatabaseAtRuntimeWindowController() {
            InitializeComponent();
            RegisterActions(components);
            TargetWindowType = WindowType.Main;
        }
        private void scaChangeTo_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            ((ISupportChangeDatabaseAtRuntime)Application).ChangeTo(e.SelectedChoiceActionItem.Data.ToString());
        }
    }
}