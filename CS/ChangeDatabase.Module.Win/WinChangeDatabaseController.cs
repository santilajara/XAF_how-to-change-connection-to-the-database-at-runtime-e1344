using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win.SystemModule;

namespace ChangeDatabase.Module.Win {
    public interface IApplicationFactory {
        WinApplication CreateApplication();
    }

    public class WinChangeDatabaseController : WindowController {
        public static WinApplication NewApplication = null;
        public SingleChoiceAction changeDatabaseAction;
        public WinChangeDatabaseController() {
            this.TargetWindowType = WindowType.Main;

            changeDatabaseAction = new SingleChoiceAction(this, "ChangeDatabase", PredefinedCategory.View);
            foreach(string databaseName in ChangeDatabaseHelper.Databases.Split(';')) {
                changeDatabaseAction.Items.Add(new ChoiceActionItem(databaseName, databaseName));
            }
            changeDatabaseAction.Execute += new SingleChoiceActionExecuteEventHandler(changeDatabaseAction_Execute);
        }

        protected override void OnActivated() {
            base.OnActivated();
            foreach(ChoiceActionItem item in changeDatabaseAction.Items) {
                if(Application.ConnectionString.Contains((string)item.Data)) {
                    changeDatabaseAction.SelectedItem = item;
                    break;
                }
            }
        }
        void changeDatabaseAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            NewApplication = ((IApplicationFactory)Application).CreateApplication();

            WinChangeDatabaseHelper.DatabaseName = (string)e.SelectedChoiceActionItem.Data;
            WinChangeDatabaseHelper.SkipLogonDialog = true;
            WinChangeDatabaseStandardAuthentication.AuthenticatedUserName = SecuritySystem.CurrentUserName;

            Frame.GetController<ExitController>().ExitAction.DoExecute();

            ((IDatabaseNameParameter)NewApplication.Security.LogonParameters).DatabaseName = WinChangeDatabaseHelper.DatabaseName;
            AuthenticationStandardLogonParameters authenticationStandardLogonParameters = NewApplication.Security.LogonParameters as AuthenticationStandardLogonParameters;
            if(authenticationStandardLogonParameters != null) {
                authenticationStandardLogonParameters.UserName = WinChangeDatabaseStandardAuthentication.AuthenticatedUserName;
            }
        }
    }
}
