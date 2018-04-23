using DevExpress.ExpressApp;
using WinWebSolution.Module;

namespace WinWebSolution.Web {
    partial class WinWebSolutionAspNetApplication : ISupportChangeDatabaseAtRuntime {
        public void ChangeTo(string newConnectionString) {
            IXpoDataStoreProvider dataStoreProvider = new ConnectionStringDataStoreProvider(newConnectionString);
            Setup(new ExpressApplicationSetupParameters(ApplicationName, CreateDefaultObjectSpaceProvider(dataStoreProvider), ControllersManager, DetailViewItemsFactory, Model, Modules));
            System.Web.HttpContext.Current.Response.Redirect("Default.aspx");
        }
    }
}
