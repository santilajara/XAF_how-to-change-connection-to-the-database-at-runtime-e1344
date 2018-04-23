using DevExpress.ExpressApp;
using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;

namespace ChangeDatabase.Module.Web {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
        }
    }
}
