using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Assignment.Models.Entities
{
    public class Trainee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }
        public decimal? Degree { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<CourseResult> CourseResults { get; set; } = new();


    }
}
