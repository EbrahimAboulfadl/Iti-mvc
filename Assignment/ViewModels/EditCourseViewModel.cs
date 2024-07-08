using Assignment.Models.Entities;
using System.Collections.Generic;

namespace Assignment.ViewModels
{
    public class EditCourseViewModel
    {
        public Course  Course { get; set; }

        public List<DepartmentSelectionViewModel> Departments { get; set; }
    }
}
