using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=ASP.NETCoreEFCore6;Integrated security=true"));
builder.Services.AddDbContext<DbContext, MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<ICrudService<Vehicle>, CrudService<Vehicle>>();
builder.Services.AddScoped<ICrudService<Engine>, CrudService<Engine>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<MyContext>()!.Database.EnsureCreated();



    await scope.ServiceProvider.GetService<IPeopleService>().CreateAsync(new Person { FirstName = "Adam", LastName = "Adamski" });
}

app.MapGet("/", () => "Hello World!");

app.MapControllers();



app.Run();
