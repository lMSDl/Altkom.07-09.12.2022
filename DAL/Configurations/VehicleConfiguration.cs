using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class VehicleConfiguration : EntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Registration).WithOne(x => x.Vehicle).HasForeignKey<Vehicle>("RegistrationId")
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);


            //builder.Property<bool>("ShadowProperty");
        }
    }
}
