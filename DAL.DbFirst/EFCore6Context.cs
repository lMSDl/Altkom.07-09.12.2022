using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DbFirst
{
    public partial class EFCore6Context : DbContext
    {
        public EFCore6Context()
        {
        }

        public EFCore6Context(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Component> Components { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Educator> Educators { get; set; } = null!;
        public virtual DbSet<Engine> Engines { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<SubComponent> SubComponents { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local)\\SQLExpress;Database=EFCore6;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => new { e.Street, e.City }, "IX_Addresses_Street_City")
                    .IsUnique();

                entity.HasIndex(e => e.ZipCode, "Index_ZipCode");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyType).HasDefaultValueSql("(N'')");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.HasMany(d => d.Vehicles)
                    .WithMany(p => p.Drivers)
                    .UsingEntity<Dictionary<string, object>>(
                        "DriverVehicle",
                        l => l.HasOne<Vehicle>().WithMany().HasForeignKey("VehiclesId"),
                        r => r.HasOne<Driver>().WithMany().HasForeignKey("DriversId"),
                        j =>
                        {
                            j.HasKey("DriversId", "VehiclesId");

                            j.ToTable("DriverVehicle");

                            j.HasIndex(new[] { "VehiclesId" }, "IX_DriverVehicle_VehiclesId");
                        });
            });

            modelBuilder.Entity<Educator>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Educator)
                    .HasForeignKey<Educator>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.ToTable("Engine");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FullName).HasComputedColumnSql("(([Name]+' ')+[LastName])", true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'Kowalski')");

                entity.Property(e => e.Pesel)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("PESEL");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SubComponent>(entity =>
            {
                entity.HasIndex(e => e.ComponentId, "IX_SubComponents_ComponentId");

                entity.HasIndex(e => e.StatusId, "IX_SubComponents_StatusId");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.SubComponents)
                    .HasForeignKey(d => d.ComponentId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SubComponents)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.UserType).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.EngineId, "IX_Vehicle_EngineId");

                entity.HasIndex(e => e.RegistrationId, "IX_Vehicle_RegistrationId")
                    .IsUnique()
                    .HasFilter("([RegistrationId] IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.EngineId);

                entity.HasOne(d => d.Registration)
                    .WithOne(p => p.Vehicle)
                    .HasForeignKey<Vehicle>(d => d.RegistrationId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
