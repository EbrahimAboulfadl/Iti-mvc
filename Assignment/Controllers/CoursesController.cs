using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class CoursesController : Controller
    {
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;

        public CoursesController(ICourseRepository _courseRepository, IDepartmentRepository _departmentRepository) { 
        courseRepository = _courseRepository;
        departmentRepository = _departmentRepository;
        
        }

        public IActionResult Index()
        {
            return View(courseRepository.CoursesWithDepartments());
        }   
        public IActionResult CheckGrade(decimal MinGrade, decimal Grade)
        {
            if (MinGrade > Grade) return Json(false);
            return Json (true);
        }

        [HttpGet]
        public IActionResult New() {
        ViewBag.departments = departmentRepository.GetDepartmentSelectionViewModels();
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
                    courseRepository.Add(course);
                    return RedirectToAction("Index");
                }
                else {
                    ModelState.AddModelError("DepartmentId","A course must be related to a department");
                }
     
            }
            ViewBag.departments = departmentRepository.GetDepartmentSelectionViewModels();
            return View();

        }

        public IActionResult Delete(int id ) {
            courseRepository.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id) {
            Course course = courseRepository.GetById(id);       
            if (course != null)
            {
                ViewBag.departments = departmentRepository.GetDepartmentSelectionViewModels();
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

            try
            {
                courseRepository.Edit(id, course);
                return RedirectToAction("Index");

            }
            catch { 
                return View("Error", new ErrorViewModel());

            }
          
            
        }
        public IActionResult GetCourse(int id)
        {
            Course course = courseRepository.GetById(id);

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
