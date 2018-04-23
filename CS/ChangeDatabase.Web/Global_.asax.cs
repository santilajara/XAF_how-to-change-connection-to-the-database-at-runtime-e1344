using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp;
using System.Configuration;
using ChangeDatabase.Module;
using DevExpress.Persistent.BaseImpl;
using ChangeDatabase.Module.Web;

namespace ChangeDatabase.Web {
    public partial class Global : System.Web.HttpApplication {
        protected void Session_Start(Object sender, EventArgs e) {
            WebApplication.SetInstance(Session, new ChangeDatabaseAspNetApplication());

            ((SecurityBase)WebApplication.Instance.Security).Authentication = new AuthenticationStandard<SimpleUser, ChangeDatabaseStandardAuthenticationLogonParameters>();

            //((SecurityBase)WebApplication.Instance.Security).Authentication = new WebChangeDatabaseAuthenticationActiveDirectory();

            WebApplication.Instance.CanAutomaticallyLogonWithStoredLogonParameters = true;

            if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            WebApplication.Instance.Setup();
            WebApplication.Instance.Start();
        }
    }
}