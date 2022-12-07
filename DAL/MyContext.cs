using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyContext : DbContext
    {

        private readonly string _connectionString;

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

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}