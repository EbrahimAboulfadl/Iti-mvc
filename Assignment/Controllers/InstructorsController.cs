using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.Repository;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class InstructorsController : Controller
    {
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentRepository;


        public InstructorsController(IInstructorRepository _instructorRepository , IDepartmentRepository _departmentRepository) { 
           instructorRepository = _instructorRepository;
            departmentRepository = _departmentRepository;


        }
        public IActionResult Index()
        {	
				List<Instructor> instructors = instructorRepository.InstructorsWithDepartments();
				return View(instructors);
        }
        public IActionResult GetInstructor(int id)
        {
            Instructor instructor;
          

               instructor= instructorRepository.InstructorsWithDepartments().FirstOrDefault(x => x.Id == id);
            

            if (instructor != null)
            {
                return View("GetInstructor", instructor);
            }
            else { return View("Error",new ErrorViewModel());
            
            }
        }

        public IActionResult NewInstructor() {         
            
        return View(departmentRepository.GetDepartmentSelectionViewModels());
        }
        [HttpPost]
        public IActionResult SaveInstuctor(Instructor instructor) {

            if (ModelState.IsValid)
            instructorRepository.Add(instructor);        
            
            return RedirectToAction("Index");
        
        }
    }
}
