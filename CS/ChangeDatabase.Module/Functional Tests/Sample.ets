;#DropDB ChangeDatabaseEasyTest

#Application ChangeDatabaseWin
#Application ChangeDatabaseWeb

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef ChangeDatabaseWeb
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef ChangeDatabaseWin
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
