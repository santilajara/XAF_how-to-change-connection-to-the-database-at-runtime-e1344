Imports Microsoft.VisualBasic
Imports DevExpress.ExpressApp.Model
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.ExpressApp.Security

Namespace ChangeDatabase.Module
	Public Interface IDatabaseNameParameter
		Property DatabaseName() As String
	End Interface
	Public Class ChangeDatabaseHelper
		Public Const Databases As String = "ChangeDatabase_DB1;ChangeDatabase_DB2"
		Public Shared Sub UpdateDatabaseName(ByVal application As XafApplication, ByVal databaseName As String)
			Dim helper As New ConnectionStringParser(application.ConnectionString)
			helper.RemovePartByName("Initial Catalog")
			application.ConnectionString = "Initial Catalog=" & databaseName & ";" & helper.GetConnectionString()
		End Sub
	End Class

	<NonPersistent> _
	Public Class ChangeDatabaseStandardAuthenticationLogonParameters
		Inherits AuthenticationStandardLogonParameters
		Implements IDatabaseNameParameter
		Private databaseName_Renamed As String = ChangeDatabaseHelper.Databases.Split(";"c)(0)

		<ModelDefault("PredefinedValues", ChangeDatabaseHelper.Databases)> _
		Public Property DatabaseName() As String Implements IDatabaseNameParameter.DatabaseName
			Get
				Return databaseName_Renamed
			End Get
			Set(ByVal value As String)
				databaseName_Renamed = value
			End Set
		End Property
	End Class

	<NonPersistent> _
	Public Class ChangeDatabaseActiveDirectoryLogonParameters
		Implements IDatabaseNameParameter
		Private databaseName_Renamed As String = ChangeDatabaseHelper.Databases.Split(";"c)(0)

		<ModelDefault("PredefinedValues", ChangeDatabaseHelper.Databases)> _
		Public Property DatabaseName() As String Implements IDatabaseNameParameter.DatabaseName
			Get
				Return databaseName_Renamed
			End Get
			Set(ByVal value As String)
				databaseName_Renamed = value
			End Set
		End Property

	End Class
End Namespace
