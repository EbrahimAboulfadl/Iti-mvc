using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Models.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            //builder.HasOne(x=>x.Department).WithMany(x=>x.Instructors).HasForeignKey(x=>x.DepartmentId);
            //builder.HasOne(x=>x.Course).WithMany(x=>x.Instructors).HasForeignKey(x=>x.CourseId);
            //builder.HasOne(x => x.Account).WithOne(x => x.Instructor).HasForeignKey<Instructor>(x=>x.AccountId);
        }
    }
}

