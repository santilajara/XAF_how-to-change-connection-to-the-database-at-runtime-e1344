using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using System.Web;

namespace ChangeDatabase.Module.Web {
    public class WebChangeDatabaseAuthenticationActiveDirectory : AuthenticationActiveDirectory<SimpleUser, ChangeDatabaseActiveDirectoryLogonParameters> {
        public WebChangeDatabaseAuthenticationActiveDirectory() {
            this.CreateUserAutomatically = true;
        }
        public override bool AskLogonParametersViaUI {
            get {
                string databaseName = HttpContext.Current.Request.Params[WebChangeDatabaseController.DatabaseParameterName];
                if(string.IsNullOrEmpty(databaseName)) {
                    return true;
                }
                return base.AskLogonParametersViaUI;
            }
        }
    }
}
