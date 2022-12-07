

using DAL;

//var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EF6;AttachDBFilename=c:\\test\\abc.mdf";
var connectionString = "Server=(local)\\SQLEXPRESS;Database=EF6;Integrated security=true";
//var connectionString = "Server=(local)\\SQLEXPRESS;Database=EF6;User Id=sa;Passwrod=pass";

using (var context = new MyContext(connectionString))
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}