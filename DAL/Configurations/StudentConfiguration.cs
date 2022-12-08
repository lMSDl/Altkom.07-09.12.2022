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
    public class StudentConfiguration : EntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
            builder.ToTable("Students");
        }
    }
}
