using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;
using System.Configuration;
using DevExpress.ExpressApp.Security;
using ChangeDatabase.Module;
using DevExpress.Persistent.BaseImpl;
using ChangeDatabase.Module.Win;

namespace ChangeDatabase.Win {
    public partial class ChangeDatabaseWindowsFormsApplication : WinApplication, IApplicationFactory {
        protected override void ReadLastLogonParametersCore(DevExpress.ExpressApp.Utils.SettingsStorage storage, object logonObject) {
            AuthenticationStandardLogonParameters standardLogonParameters = logonObject as AuthenticationStandardLogonParameters;
            if((standardLogonParameters != null) && string.IsNullOrEmpty(standardLogonParameters.UserName)) {
                base.ReadLastLogonParametersCore(storage, logonObject);
            }
        }
        protected override void OnLoggingOn(LogonEventArgs args) {
            base.OnLoggingOn(args);
            ChangeDatabaseHelper.UpdateDatabaseName(this, ((IDatabaseNameParameter)args.LogonParameters).DatabaseName);
        }
        protected override bool OnLogonFailed(object logonParameters, Exception e) {
            if(WinChangeDatabaseHelper.SkipLogonDialog) {
                return true;
            }
            return base.OnLogonFailed(logonParameters, e);
        }
        WinApplication IApplicationFactory.CreateApplication() {
            return CreateApplication();
        }
        public static ChangeDatabaseWindowsFormsApplication CreateApplication() {
            ChangeDatabaseWindowsFormsApplication winApplication = new ChangeDatabaseWindowsFormsApplication();
            
            ((SecurityBase)winApplication.Security).Authentication = new WinChangeDatabaseStandardAuthentication();

            //((SecurityBase)winApplication.Security).Authentication = new WinChangeDatabaseActiveDirectoryAuthentication();

            if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            return winApplication;
        }

    }
}
