using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Username);

            //TAK NIE ROBIĆ NA PRODUKCJI!
            builder.Property(x => x.Password).HasConversion(
                x => Convert.ToBase64String(Encoding.UTF8.GetBytes(x)),
                x => Encoding.UTF8.GetString(Convert.FromBase64String(x)));

            /*builder.Property(x => x.UserType).HasConversion(
                x => x.ToString(),
                x => Enum.Parse<UserType>(x));*/

            //builder.Property(x => x.UserType).HasConversion(new EnumToStringConverter<UserType>());
            builder.Property(x => x.UserType).HasConversion<string>();

            builder.HasData(User.DEFAULT_USERS);
        }
    }
}
