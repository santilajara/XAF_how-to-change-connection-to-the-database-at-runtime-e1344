using System;
using System.Windows.Forms;
using ChangeDatabase.Module.Win;
using DevExpress.ExpressApp.Security;

namespace ChangeDatabase.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if EASYTEST
			DevExpress.ExpressApp.EasyTest.WinAdapter.RemotingRegistration.Register(4100);
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            ChangeDatabaseWindowsFormsApplication winApplication = ChangeDatabaseWindowsFormsApplication.CreateApplication();
            try {
                winApplication.Setup();
                winApplication.Start();
            }
            catch (Exception e) {
                winApplication.HandleException(e);
            }
            winApplication.Dispose();
        }
    }
}
