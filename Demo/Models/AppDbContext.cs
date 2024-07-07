using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer("Data Source=. ;Initial Catalog = ITIMVCDb; Integrated Security = True");	
		}
	}
}
