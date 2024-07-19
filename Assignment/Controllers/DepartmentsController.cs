using Assignment.Models;
using Assignment.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class DepartmentsController : Controller
    {

        AppDbContext context = new AppDbContext();

        #region Validations
        public IActionResult CheckName(string Manager) {
            if (context.Departments.FirstOrDefault(d => d.Manager == Manager) != null) return Json(false);
            return Json(true);
        
        }
        #endregion
        public IActionResult Index()
        {
            List <Department> departments = context.Departments.ToList();
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
                context.Departments.Add(department);
                context.SaveChanges();
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
            var department = context.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id ,Department department)
        {
            var departmentToEdit = context.Departments.Find(id);
            if (departmentToEdit != null && ModelState.IsValid)
            {
                departmentToEdit.Name = department.Name;
                departmentToEdit.Manager = department.Manager;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public IActionResult Delete(int id)
        {
            Department deptToDelete = context.Departments.Find(id);
            if (deptToDelete != null) {
            
                context.Remove(deptToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View("New");
            }
           
        }    

    }
}
