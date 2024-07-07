using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }	

		public string Address { get; set; }
		
		public string Image {  get; set; }

		public int Age { get; set; }

		[ForeignKey("Department")]
		public int DeptId { get; set; }
		public Department Department { get; set; }



	}
}
