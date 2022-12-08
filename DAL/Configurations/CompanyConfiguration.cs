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
    public class CompanyConfiguration : EntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.ToTable("Companies");

            builder.Ignore(x => x.Address);

            //przypisanie wartości stringowych dla typów
            builder.HasDiscriminator<string>("CompanyType")
                .HasValue<Company>(nameof(Company))
                .HasValue<SmallCompany>(nameof(SmallCompany))
                .HasValue<LargeCompany>(nameof(LargeCompany));

            //zmiana typu danych w kolumnie discriminator i przypisanie wartości liczbowych
            /*builder.HasDiscriminator<int>("CompanyType")
                .HasValue<Company>(0)
                .HasValue<SmallCompany>(1)
                .HasValue<LargeCompany>(2);*/

            //zmianę nazwy kolumny z domyślnej  (Discriminator)
            //builder.HasDiscriminator<int>("CompanyType");

            //Discriminator - domyślna nazwa kolumny rozróżniająca typy
        }
    }
}
