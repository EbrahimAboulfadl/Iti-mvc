using Assignment.Models;
using Assignment.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new AppDbContext())
            {

                List<Course> courses = context.Courses.Include(x=>x.Department).ToList();

                return View(courses);
            }
        }

        public IActionResult GetCourse(int id)
        {
            Course course;
            using (var context = new AppDbContext())
            {

                 course = context.Courses.Include(x=>x.Department).FirstOrDefault(x => x.Id == id);
            }

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
