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
    public class PersonConfiguration : EntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.ToTable("People");

            builder.Property(x => x.FirstName).HasColumnName("Name");

            builder.Property(x => x.LastName).HasMaxLength(15).HasDefaultValue("Kowalski");

            builder.Property(x => x.PESEL)/*.HasColumnType("decimal(11,0)")*/.HasPrecision(11, 0);

            builder.Ignore(x => x.Address);

            builder.Property(x => x.FullName).HasComputedColumnSql("[Name] + ' ' + [LastName]", stored: true);
        }
    }
}
