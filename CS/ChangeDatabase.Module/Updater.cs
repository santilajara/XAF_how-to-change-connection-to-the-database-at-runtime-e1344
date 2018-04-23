using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Updating;

namespace ChangeDatabase.Module
{
    public class Updater : ModuleUpdater
    {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            if (Session.FindObject<SimpleUser>(new BinaryOperator("UserName", "Admin")) == null) {
                SimpleUser user = new SimpleUser(Session);
                user.UserName = "Admin";
                user.Save();
            }

            if (Session.ConnectionString.Contains("DB1")) {
                if (Session.FindObject<SimpleUser>(new BinaryOperator("UserName", "Admin1")) == null) {
                    SimpleUser user1 = new SimpleUser(Session);
                    user1.UserName = "Admin1";
                    user1.Save();
                }
            }
            if (Session.ConnectionString.Contains("DB2")) {
                if (Session.FindObject<SimpleUser>(new BinaryOperator("UserName", "Admin2")) == null) {
                    SimpleUser user2 = new SimpleUser(Session);
                    user2.UserName = "Admin2";
                    user2.Save();
                }
            }
        }
    }
}
