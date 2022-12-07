using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=ASP.NETCoreEFCore6;Integrated security=true"));
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<MyContext>()!.Database.EnsureCreated();
}

app.MapGet("/", () => "Hello World!");

app.Run();
