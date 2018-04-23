using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;
using ChangeDatabase.Module.Web;
using System.Web;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.ExpressApp;
using ChangeDatabase.Module;
using System.Web.Security;

namespace ChangeDatabase.Web {
    public partial class ChangeDatabaseAspNetApplication : WebApplication {
        protected override void ReadSecuredLogonParameters() {
            base.ReadSecuredLogonParameters(); // the "UserName" is restored in the base method.

            string databaseName = HttpContext.Current.Request.Params[WebChangeDatabaseController.DatabaseParameterName];
            if(!string.IsNullOrEmpty(databaseName)) {
                ((IDatabaseNameParameter)SecuritySystem.LogonParameters).DatabaseName = databaseName;
            }
        }
        private bool canReadSecuredLogonParameters = true;
        protected override bool CanReadSecuredLogonParameters() {
            if(!canReadSecuredLogonParameters)
                return false;
            return base.CanReadSecuredLogonParameters();
        }
        protected override bool OnLogonFailed(object logonParameters, Exception e) {
            if(CanReadSecuredLogonParameters()) {
                FormsAuthentication.SignOut();
                canReadSecuredLogonParameters = false;
                try {
                    Start();
                }
                finally {
                    canReadSecuredLogonParameters = true;
                }
                return true;
            }
            else {
                return base.OnLogonFailed(logonParameters, e);
            }
        }
        protected override void ReadLastLogonParametersCore(DevExpress.ExpressApp.Utils.SettingsStorage storage, object logonObject) {
            //string databaseName = HttpContext.Current.Request.Params[WebChangeDatabaseController.DatabaseParameterName];
            if(string.IsNullOrEmpty(((IDatabaseNameParameter)logonObject).DatabaseName)) {
                base.ReadLastLogonParametersCore(storage, logonObject);
            }
        }
        protected override void OnLoggingOn(LogonEventArgs args) {
            base.OnLoggingOn(args);
            ChangeDatabaseHelper.UpdateDatabaseName(this, ((IDatabaseNameParameter)args.LogonParameters).DatabaseName);
        }
    }
}