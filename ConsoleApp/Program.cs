

using DAL;
using Microsoft.EntityFrameworkCore;

//var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCore6;AttachDBFilename=c:\\test\\abc.mdf";
var connectionString = "Server=(local)\\SQLEXPRESS;Database=EFCore6;Integrated security=true";
//var connectionString = "Server=(local)\\SQLEXPRESS;Database=EFCore6;User Id=sa;Passwrod=pass";

using (var context = new MyContext(connectionString))
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
    context.Database.Migrate();
}