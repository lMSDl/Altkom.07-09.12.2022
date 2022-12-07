using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            //tworzymy klucz złożony
            //builder.HasKey(x => new { x.Street, x.City });

            //Informujemy EFCore, że encja nie posiada klucza
            //builder.HasNoKey();

            builder.HasIndex(x => x.ZipCode).HasDatabaseName("Index_ZipCode");

            builder.HasIndex(x => new { x.Street, x.City }).IsUnique();
        }
    }
}
