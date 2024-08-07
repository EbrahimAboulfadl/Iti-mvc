using Assignment.Models;
using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Repository
{
    public class CourseRepository : ICourseRepository
    {
        readonly AppDbContext context;
        public CourseRepository(AppDbContext _context) {
        context = _context; 
        
        }
        public void Add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();

        }

        public List<Course> CoursesWithDepartments()
        {
            return context.Courses.Include(x => x.Department).ToList();
        }

        public void Delete(int id)
        {
            Course course = GetById(id);
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public void Edit(int id, Course course)
        {
            Course oldCourse = GetById(id);
            oldCourse.Grade  = course.Grade;
            oldCourse.DepartmentId = course.DepartmentId;
            oldCourse.Name = course.Name;
            oldCourse.MinGrade = course.MinGrade;
            context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(x => x.Id == id);
        }
    }
}
