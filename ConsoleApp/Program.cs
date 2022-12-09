

using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Components;
using Newtonsoft.Json;

//var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCore6;";// AttachDBFilename=c:\\test\\abc.mdf";
var connectionString = "Server=(local)\\SQLEXPRESS;Database=EFCore6;Integrated security=true";
//var connectionString = "Server=(local)\\SQLEXPRESS;Database=EFCore6;User Id=sa;Passwrod=pass";

var options = new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;

AddUpdateDelete(options);
Components(options);

using (var context = new MyContext(options))
{
    var vehicles = context.Set<Vehicle>().ToList();
    vehicles[0].Registration = context.Set<Registration>().AsNoTracking().Where(x => x.Vehicle.Id == vehicles[0].Id).SingleOrDefault();
    //Load - pobiera wskazane referencje lub kolekcje z bazy danych
    context.Entry(vehicles[1]).Reference(x => x.Engine).Load();
    context.Entry(vehicles[1]).Collection(x => x.Drivers).Load();

    //AsNoTracking - powoduje nie dodawanie encji do contextu
    //Include - pobiera wskazane referencje z bazy danych
    vehicles = context.Set<Vehicle>().AsNoTracking().Include(x => x.Registration).Include(x => x.Engine).Include(x => x.Drivers).ToList();

    //context.ChangeTracker.Clear();

    IQueryable<Vehicle> query = context.Set<Vehicle>();

    Console.WriteLine($"\nInclude registration?");
    if (Console.ReadKey().KeyChar == 'y')
    {
        query = query.Include(x => x.Registration);
    }
    Console.WriteLine($"\nInclude engine?");
    if (Console.ReadKey().KeyChar == 'y')
    {
        query = query.Include(x => x.Engine);
    }
    Console.WriteLine($"\nInclude drivers?");
    if (Console.ReadKey().KeyChar == 'y')
    {
        query = query.Include(x => x.Drivers);
    }

    Console.WriteLine($"\nSort by name descending?");
    if (Console.ReadKey().KeyChar == 'y')
    {
        query = query.OrderByDescending(x => x.Name);
    }

    vehicles = query.ToList();

    Console.WriteLine(JsonConvert.SerializeObject(vehicles, new JsonSerializerSettings() { Formatting = Formatting.Indented, ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
}

using (var context = new MyContext(options))
{
    var components = context.Set<Component>().AsNoTracking().Include(x => x.SubComponents).ThenInclude(x => x.Status).ToList();


    Console.WriteLine(JsonConvert.SerializeObject(components, new JsonSerializerSettings() { Formatting = Formatting.Indented, ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

}







static void Components(DbContextOptions options)
{
    var statuses = new[] { "A", "B", "C", "D" };
    using (var context = new MyContext(options))
    {

        foreach (var status in statuses)
        {
            context.Statuses.Add(new Status { Id = status });
        }
        context.SaveChanges();
    }

    using (var context = new MyContext(options))
    {
        var component = new Component();
        context.Components.Add(component);
        context.SaveChanges();
    }
    using (var context = new MyContext(options))
    {
        for (int i = 0; i < 10; i++)
        {

            var subComponent = new SubComponent();
            subComponent.Status = new Status() { Id = statuses[i % 4] }; ;
            subComponent.Component = new Component { Id = 1 };
            context.Attach(subComponent.Status);
            context.Attach(subComponent.Component);

            context.Add(subComponent);
            context.SaveChanges();
            //alternatywą do usuwania DbContext jest czyszczenie ChangeTrackera
            context.ChangeTracker.Clear();
        }
    }
}

static void AddUpdateDelete(DbContextOptions options)
{
    var vehicle = new Vehicle();
    vehicle.Name = "Car";

    using (var context = new MyContext(options))
    {
        context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        context.Database.Migrate();



        //korzystamy z utworzonego przez nas property DbSet
        //context.Vehicle.Add(vehicle);

        //korzystamy z generycznego DbSet
        context.Set<Vehicle>().Add(vehicle);
        context.Set<Vehicle>().Add(new Vehicle() { Name = "Bus" });

        //automatycznie wybierany jest DbSet
        //context.Add(vehicle);

        Console.WriteLine(context.ChangeTracker.ToDebugString());
        context.SaveChanges();
        Console.WriteLine(JsonConvert.SerializeObject(vehicle, Formatting.Indented));


        vehicle.Name = "Bike";
        context.SaveChanges();
    }

    using (var context = new MyContext(options))
    {

        vehicle.Name = "Motorbike";
        context.Set<Vehicle>().Update(vehicle);

        //context.Attach(vehicle);
        //vehicle.Name = "Motorbike";

        Console.WriteLine(context.ChangeTracker.ToDebugString(Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTrackerDebugStringOptions.ShortDefault));

        context.SaveChanges();
    }

    using (var context = new MyContext(options))
    {
        //jeżeli przy Update Id będzie 0, to zadziała jak Add
        //Update == AddOrUpdate (dla Id = 0)
        vehicle = new Vehicle() { Id = 1, Name = "Ship" };
        context.Set<Vehicle>().Update(vehicle);

        //możemy wysterować co ma być aktualizowane w bazie danych
        context.Entry(vehicle).Property(x => x.CreatedAt).IsModified = false;

        //możemy też zmienić stan całej encji
        //context.Entry(vehicle).State = EntityState.Unchanged;

        Console.WriteLine(context.ChangeTracker.ToDebugString());

        context.SaveChanges();
    }


    using (var context = new MyContext(options))
    {
        var registration = new Registration() { Number = "abc123" };
        registration.Vehicle = new Vehicle { Id = 2 };

        context.Attach(registration.Vehicle);

        context.Set<Registration>().Add(registration);

        context.SaveChanges();

    }


    using (var context = new MyContext(options))
    {
        vehicle = new Vehicle() { Name = "Plane" };
        var registration = new Registration() { Number = "123abc" };

        var engine = new Engine() { Power = 123 };

        var driver1 = new Driver() { Name = "1" };
        var driver2 = new Driver() { Name = "2" };

        vehicle.Drivers = new List<Driver> { driver1, driver2 };
        vehicle.Engine = engine;
        vehicle.Registration = registration;

        context.Set<Vehicle>().Add(vehicle);

        Console.WriteLine(context.ChangeTracker.ToDebugString());

        context.SaveChanges();
    }

    using (var context = new MyContext(options))
    {
        context.Set<Vehicle>().Remove(new Vehicle() { Id = 1 });
        Console.WriteLine(context.ChangeTracker.ToDebugString());

        context.SaveChanges();
    }
}