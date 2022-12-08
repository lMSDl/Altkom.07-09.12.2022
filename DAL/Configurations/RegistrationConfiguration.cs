using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class RegistrationConfiguration : EntityConfiguration<Registration>
    {
        public override void Configure(EntityTypeBuilder<Registration> builder)
        {
            base.Configure(builder);
        }
    }
}
