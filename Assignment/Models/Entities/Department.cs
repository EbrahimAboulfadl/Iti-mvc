using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Assignment.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "The Name Field Must Contain More Than 2 Characters")]
        [MaxLength(50, ErrorMessage = "The Name Field Must be Less Than 50 Characters")]
        [UniqueName(EntityName ="Department")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Manager Name Field Must Contain More Than 2 Characters")]
        [MaxLength(50, ErrorMessage = "The Manager Name Field Must be Less Than 50 Characters")]
        [Display(Name ="Manager Name")]
        [Remote("CheckName","Departments",ErrorMessage ="This manager already another department")]
        public string Manager { get; set; }
        public List<Instructor> Instructors { get; set; } = new();
        public List<Trainee> Trainees { get; set; } = new();
    }
}