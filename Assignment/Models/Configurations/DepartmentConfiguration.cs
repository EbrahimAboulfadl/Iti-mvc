using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Models.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //builder.HasMany(x => x.Trainees).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
        }
    }
}
