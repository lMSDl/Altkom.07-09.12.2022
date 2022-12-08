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
    internal class DriverConfiguration : EntityConfiguration<Driver>
    {
        public override void Configure(EntityTypeBuilder<Driver> builder)
        {
            base.Configure(builder);
        }
    }
}
