using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class CoursesController : Controller
    {

        static AppDbContext  context = new AppDbContext();
        List<DepartmentSelectionViewModel> departmentSelections = context.Departments
            .Select(x => 
                    new DepartmentSelectionViewModel() { DepartmentName = x.Name, DepartmentId = x.Id }
                    ).ToList();

        public IActionResult Index()
        {
                List<Course> courses = context.Courses.Include(x=>x.Department).ToList();

                return View(courses);
        }

  
        public IActionResult NewCourse() {
        
        return View(departmentSelections);
        }
        
        public IActionResult DeleteCourse(int id ) {
            Course courseToDelete = context.Courses.Find(id);
            context.Courses.Remove(courseToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult SaveNewCourse(Course course) {

        context.Courses.Add(course);
        context.SaveChanges();
        return RedirectToAction("Index");   
        }
        public IActionResult EditCourse(int id) {
            Course course = context.Courses.Include(x=>x.Department).FirstOrDefault(x=>x.Id == id);       
            EditCourseViewModel viewModel = new() { Course = course ,Departments = departmentSelections};
            if (viewModel.Course != null)
            {

                return View(viewModel);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
        }

        [HttpPost]
        public IActionResult SaveCourse(int id , Course course) {

            Course oldCourse = context.Courses.Find(id);
            if (oldCourse != null)
            {
                oldCourse.Name = course.Name;
                oldCourse.DepartmentId = course.DepartmentId;
                oldCourse.Grade = course.Grade;
                oldCourse.MinGrade = course.MinGrade;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else { 
            return View("Error", new ErrorViewModel());
            }
            
        }
        public IActionResult GetCourse(int id)
        {
            Course course;
            course = context.Courses.Include(x=>x.Department).FirstOrDefault(x => x.Id == id);

            if (course != null)
            {
                return View("GetCourse", course);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
        }
    }
}
