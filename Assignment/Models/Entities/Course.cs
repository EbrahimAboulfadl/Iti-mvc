using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Grade { get; set; }

        public decimal MinGrade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List <Instructor> Instructors { get; set; }
        public List<CourseResult> CourseResults { get; set; } = new();




    }
}