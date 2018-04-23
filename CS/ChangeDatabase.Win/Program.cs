using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using ChangeDatabase.Module;
using ChangeDatabase.Module.Win;

namespace ChangeDatabase.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if EASYTEST
			DevExpress.ExpressApp.EasyTest.WinAdapter.RemotingRegistration.Register(4100);
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            do {
                ChangeDatabaseWindowsFormsApplication winApplication;
                if(WinChangeDatabaseController.NewApplication == null) {
                    winApplication = ChangeDatabaseWindowsFormsApplication.CreateApplication();
                }
                else {
                    winApplication = (ChangeDatabaseWindowsFormsApplication)WinChangeDatabaseController.NewApplication;
                    WinChangeDatabaseController.NewApplication = null;
                }
                try {
                    winApplication.Setup();
                    winApplication.Start();
                    if(WinChangeDatabaseHelper.AuthenticatedUserLogonFailed) {
                        WinChangeDatabaseHelper.SkipLogonDialog = false;
                        winApplication.Start();
                    }
                }
                catch(Exception e) {
                    winApplication.HandleException(e);
                }
                winApplication.Dispose();
            }
            while(WinChangeDatabaseController.NewApplication != null);
        }
    }
}
