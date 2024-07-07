using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo.Controllers
{
	public class DepartmentController : Controller
	{
		public IActionResult Index()
		{
			using (AppDbContext context = new AppDbContext())
			{
                var deps = context.Departments.ToList();
                return View("DepartmentsView", deps);
            }
				
	
		}		
		public IActionResult GetStudents(int id)
		{

            using (AppDbContext context = new AppDbContext())
            {
                var students = context.Students.Include(x=>x.Department).Where(x=>x.DeptId == id).ToList();
                return View("StudentsView", students);
            }
        }
	}
}
