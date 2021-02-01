Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Security

Namespace RuntimeDbChooser.Module.BusinessObjects
	Public Interface IDatabaseNameParameter
		Property DatabaseName() As String
	End Interface
	<DomainComponent>
	Public Class CustomLogonParametersForStandardAuthentication
		Inherits AuthenticationStandardLogonParameters
		Implements IDatabaseNameParameter

'INSTANT VB NOTE: The field databaseName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private databaseName_Conflict As String = MSSqlServerChangeDatabaseHelper.Databases.Split(";"c)(0)
		<ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.Databases)>
		Public Property DatabaseName() As String Implements IDatabaseNameParameter.DatabaseName
			Get
				Return databaseName_Conflict
			End Get
			Set(ByVal value As String)
				databaseName_Conflict = value
			End Set
		End Property
	End Class
	<DomainComponent>
	Public Class CustomLogonParametersForActiveDirectoryAuthentication
		Implements IDatabaseNameParameter

'INSTANT VB NOTE: The field databaseName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private databaseName_Conflict As String = MSSqlServerChangeDatabaseHelper.Databases.Split(";"c)(0)

		<ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.Databases)>
		Public Property DatabaseName() As String Implements IDatabaseNameParameter.DatabaseName
			Get
				Return databaseName_Conflict
			End Get
			Set(ByVal value As String)
				databaseName_Conflict = value
			End Set
		End Property
	End Class
	Public Class MSSqlServerChangeDatabaseHelper
		Public Const Databases As String = "E1344_DB1;E1344_DB2"
		Public Shared Sub UpdateDatabaseName(ByVal application As XafApplication, ByVal databaseName As String)
			Dim helper As New ConnectionStringParser(application.ConnectionString)
			helper.RemovePartByName("Initial Catalog")
			application.ConnectionString = String.Format("Initial Catalog={0};{1}", databaseName, helper.GetConnectionString())
		End Sub
	End Class
End Namespace
