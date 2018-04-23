using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.ExpressApp.Security;

namespace ChangeDatabase.Module {
    public interface IDatabaseNameParameter {
        string DatabaseName { get; set; }
    }
    public class ChangeDatabaseHelper {
        public const string Databases = "ChangeDatabase_DB1;ChangeDatabase_DB2";
        public static void UpdateDatabaseName(XafApplication application, string databaseName) {
            ConnectionStringParser helper = new ConnectionStringParser(application.ConnectionString);
            helper.RemovePartByName("Initial Catalog");
            application.ConnectionString = "Initial Catalog=" + databaseName + ";" + helper.GetConnectionString();
        }
    }

    [NonPersistent]
    public class ChangeDatabaseStandardAuthenticationLogonParameters : AuthenticationStandardLogonParameters, IDatabaseNameParameter {
        private string databaseName = ChangeDatabaseHelper.Databases.Split(';')[0];

        [Custom("PredefinedValues", ChangeDatabaseHelper.Databases)]
        public string DatabaseName {
            get { return databaseName; }
            set { databaseName = value; }
        }
    }

    [NonPersistent]
    public class ChangeDatabaseActiveDirectoryLogonParameters : IDatabaseNameParameter {
        private string databaseName = ChangeDatabaseHelper.Databases.Split(';')[0];

        [Custom("PredefinedValues", ChangeDatabaseHelper.Databases)]
        public string DatabaseName {
            get { return databaseName; }
            set { databaseName = value; }
        }

    }
}
