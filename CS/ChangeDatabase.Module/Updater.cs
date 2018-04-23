using DevExpress.ExpressApp;
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Updating;

namespace ChangeDatabase.Module
{
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            if (ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "Admin")) == null) {
                SimpleUser user = ObjectSpace.CreateObject<SimpleUser>();
                user.UserName = "Admin";
                user.Save();
            }

            if (((ObjectSpace)ObjectSpace).Session.ConnectionString.Contains("DB1")) {
                if (ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "Admin1")) == null) {
                    SimpleUser user1 = ObjectSpace.CreateObject<SimpleUser>();
                    user1.UserName = "Admin1";
                    user1.Save();
                }
            }
            if (((ObjectSpace)ObjectSpace).Session.ConnectionString.Contains("DB2")) {
                if (ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "Admin2")) == null) {
                    SimpleUser user2 = ObjectSpace.CreateObject<SimpleUser>();
                    user2.UserName = "Admin2";
                    user2.Save();
                }
            }
        }
    }
}
