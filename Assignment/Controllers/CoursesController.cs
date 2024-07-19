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

        static AppDbContext context = new AppDbContext();
        List<DepartmentSelectionViewModel> departmentSelections = context.Departments
            .Select(x => 
                    new DepartmentSelectionViewModel() { DepartmentName = x.Name, DepartmentId = x.Id }
                    ).ToList();

        public IActionResult Index()
        {
            List<Course> courses = context.Courses.Include(x=>x.Department).ToList();

            return View(courses);
        }   
        public IActionResult CheckGrade(decimal MinGrade, decimal Grade)
        {
            if (MinGrade > Grade) return Json(false);
            return Json (true);
        }

        [HttpGet]
        public IActionResult New() {
        ViewBag.departments = departmentSelections;
        return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.DepartmentId != -1)
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ModelState.AddModelError("DepartmentId","A course must be related to a department");
                }
     
            }
            ViewBag.departments = departmentSelections;
            return View();

        }

        public IActionResult Delete(int id ) {
            Course courseToDelete = context.Courses.Find(id);
            context.Courses.Remove(courseToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id) {
            Course course = context.Courses.Include(x=>x.Department).FirstOrDefault(x=>x.Id == id);       
            if (course != null)
            {
                ViewBag.departments = departmentSelections;
                return View(course);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , Course course) {

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
