using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public List<Instructor> Instructors { get; set; } = new();
        public List<Trainee> Trainees { get; set; } = new();
    }
}