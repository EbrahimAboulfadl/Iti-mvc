using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Models.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //builder.HasMany(x => x.CourseResults).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
           



        }
    }
    }

