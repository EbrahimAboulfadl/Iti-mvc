using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Field is Required")]
        public string Name { get; set; }

        [Range(40, 100)]

        public decimal Grade { get; set; }
        [Range(20,50)]
        [Remote("CheckGrade" ,"Courses",AdditionalFields ="Grade" ,ErrorMessage ="The Min Grade Can't be bigger than Grade")]
        [Display(Name = "Minimum Grade")]
        public decimal MinGrade { get; set; }

        [ForeignKey("Department")]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List <Instructor> Instructors { get; set; }
        public List<CourseResult> CourseResults { get; set; } = new();




    }
}