using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
			using (var context = new AppDbContext())
			{

				List<Instructor> instructors = context.Instructors.Include(x=>x.Department).ToList();

				return View(instructors);
			}
		
        }
        public IActionResult GetInstructor(int id)
        {
            Instructor instructor;
            using (var context = new AppDbContext()) {

               instructor= context.Instructors.Include(x=>x.Department).FirstOrDefault(x => x.Id == id);
            }

            if (instructor != null)
            {
                return View("GetInstructor", instructor);
            }
            else { return View("Error",new ErrorViewModel());
            
            }
        }

        public IActionResult NewInstructor() {
            List<DepartmentSelectionViewModel> departments = new List<DepartmentSelectionViewModel>();
            using (var context = new AppDbContext()) { 
            departments = context.Departments.Select(x => new DepartmentSelectionViewModel() {DepartmentId = x.Id ,DepartmentName = x.Name }).ToList();
            
            }
        return View(departments);
        }
        public IActionResult SaveInstuctor(string name, decimal salary, string address, int departmentId) { 
        
        Instructor instructor = new Instructor() { Name = name , Address = address ,Salary = salary, DepartmentId = departmentId};

            using (var context = new AppDbContext()) {
            context.Instructors.Add(instructor);
            context.SaveChanges();            
            }
            return RedirectToAction("Index");
        
        }
    }
}
