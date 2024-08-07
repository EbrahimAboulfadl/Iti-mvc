using Assignment.Models.Entities;
using System.Collections.Generic;

namespace Assignment.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public List<Course> CoursesWithDepartments();
        public Course GetById(int id);

        public void Edit (int id ,Course course);
        public void Delete(int id);

        public void Add (Course course);    
    }
}
