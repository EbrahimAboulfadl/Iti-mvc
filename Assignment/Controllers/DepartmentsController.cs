using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class DepartmentsController : Controller
    {

        IDepartmentRepository departmentRepository;
        IInstructorRepository instructorRepository;

        public DepartmentsController(IDepartmentRepository _departmentRepository , IInstructorRepository _instructorRepository) {
        
            departmentRepository = _departmentRepository;
            instructorRepository = _instructorRepository;
        }

        #region Validations
        public IActionResult CheckName(string Manager) {
            if (departmentRepository.GetAll().FirstOrDefault(d => d.Manager == Manager) != null) return Json(false);
            return Json(true);
        
        }
        #endregion

        public IActionResult DepartmentDetails(int id) {
            var dept =departmentRepository.GetById(id);
            return PartialView("DepartmentDetailsPartial",dept);
        }

        public IActionResult ShowDepartmentsEmployees() {

            var depts = departmentRepository.GetAll();
            return View(depts);
        }
        public IActionResult GetdepartmentEmployees(int id) { 
        
        var emps = instructorRepository.GetAll().Where(x=>x.DepartmentId==id).ToList();
            return Json(emps);
        }
        public IActionResult Index()
        {
            List <Department> departments =departmentRepository.GetAll();
            return View(departments);
        }


        [HttpGet]       
        public IActionResult New()
        {
         return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Department department)
        {
            if (ModelState.IsValid)
            {
               departmentRepository.Add(department);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }

        }
        [HttpGet]
        public IActionResult Edit(int id )
        {
            var department = departmentRepository.GetById(id);
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id ,Department department)
        {
            
            if ( ModelState.IsValid)
            {
                departmentRepository.Edit(id, department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public IActionResult Delete(int id)
        {
            try  {

                departmentRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("New");
            }
           
        }    

    }
}
