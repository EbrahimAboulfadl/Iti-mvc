using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Models.Configurations
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            //builder.HasMany(x => x.CourseResults).WithOne(x => x.Trainee).HasForeignKey(x => x.TraineeId);
           



        }
    }        }

