using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Components;

namespace DAL
{
    public class MyContext : DbContext
    {

        private readonly string _connectionString;
#if DEBUG
        public MyContext()
        {

        }
#endif
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public MyContext(string connectionString)
        {
            _connectionString  = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                if (_connectionString != null)
                    optionsBuilder.UseSqlServer(_connectionString /*?? "Server=(local)\\SQLEXPRESS;Database=EFCore6;Integrated security=true"*/);
                else
                {
                    optionsBuilder.UseSqlServer();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ręczne dodawanie konfiguracji
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            //automatyczne zaczytywanie wszystkich konfiguracji ze wskazanego assembly
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            //modelBuilder.Ignore<Address>();

            //modelBuilder.Entity<Company>();
        }

        //public DbSet<Person> People { get; }
        //public DbSet<Company> Companies { get; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Component> Components { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<SubComponent> SubComponents { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.Entries<Entity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList()
                .ForEach(x => x.UpdatedAt = DateTime.Now);

            return base.SaveChanges();
        }

    }
}