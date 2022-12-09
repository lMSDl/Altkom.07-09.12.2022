* Pakiety
```
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools (dla VS)
```

* dotnet-ef (CLI)
```
dotnet tool install --global dotnet-ef [--version 6.0.11]
dotnet tool uninstall --global dotnet-ef
```

* Migracje
  * CLI
  ```
  dotnet ef migrations add <name>
  dotnet ef migrations remove [-f]
  
  dotnet ef database update [--connection "<connection string>"]
  
  dotnet ef migrations script [<nazwa_migracji_od>]  [<nazwa_migracji_do>]
  dotnet ef migrations bundle
  ```
  * Package Manager Console
  ```
  Add-Migration <name>
  Remove-Migration [-f]
  
  Update-Database [-Connection "<connection string>"]
  
  Script-Migration
  Bundle-Migration
  ```
  
* ConnectionString dla MSSql
```
Server=(localdb)\mssqllocaldb;Database=<name>;[AttachDBFilename=<file path>]
Sercer=(local);Database=<name>;Integrated security=true
Sercer=<ip>;Database=<name>;User Id=<user>;Password=<password>
Sercer=(local)\SQLExpress;Database=<name>;Integrated security=true
```
* Db First
  * CLI
  ```
  dotnet ef dbcontext scaffold <connection string> <provider package>
  dotnet ef dbcontext scaffold "Server=(local)\SQLExpress;Database=EFCore6;Integrated security=true" Microsoft.EntityFrameworkCore.SqlServer
  ```
  * Package Manager Console
  ```
  Scaffold-DbContext <connection string> <provider package>
  Scaffold-DbContext "Server=(local)\SQLExpress;Database=EFCore6;Integrated security=true" Microsoft.EntityFrameworkCore.SqlServer
  ```
