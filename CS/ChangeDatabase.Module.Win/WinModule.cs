using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace ChangeDatabase.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class ChangeDatabaseWindowsFormsModule : ModuleBase
    {
        public ChangeDatabaseWindowsFormsModule()
        {
            InitializeComponent();
        }
    }
}
