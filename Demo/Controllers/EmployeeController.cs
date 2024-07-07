using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class EmployeeController : Controller
	{
		public IActionResult GetAll()
		{

			return View("EmployeesTable" , EmployeeFactory.GetAllEmployees());
		}	
		
		public IActionResult GetEmployee(int id)
		{

			return View("EmployeeDetails" , EmployeeFactory.GetEmployee(id));
		}
	}
}
