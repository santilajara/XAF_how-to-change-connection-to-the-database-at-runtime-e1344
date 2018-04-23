using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Web.SystemModule;
using System.Web;
using DevExpress.ExpressApp.Web;
using System.Web.Security;

namespace ChangeDatabase.Module.Web {
    public class WebChangeDatabaseController : WindowController {
        public const string DatabaseParameterName = "DatabaseName";
        public SingleChoiceAction changeDatabaseAction;
        public WebChangeDatabaseController() {
            this.TargetWindowType = WindowType.Main;

            changeDatabaseAction = new SingleChoiceAction(this, "ChangeDatabase", WebApplication.OldStyleLayout ? "Tools" : "Security");
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
            SecuritySystem.Instance.Logoff();
            HttpContext.Current.Session.Abandon();
            WebApplication.Redirect(FormsAuthentication.DefaultUrl + "?" + DatabaseParameterName + "=" + (string)e.SelectedChoiceActionItem.Data);
        }
    }
}
