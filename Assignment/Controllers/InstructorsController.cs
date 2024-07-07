using Assignment.Models;
using Assignment.Models.Entities;
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
    }
}
