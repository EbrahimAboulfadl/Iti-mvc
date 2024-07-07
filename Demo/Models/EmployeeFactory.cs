using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Models
{
	public class EmployeeFactory
	{
		public static List<Employee> _employees = new List<Employee>() {
        new (){Id=1 , Name = "Ebrahim Aboulfadl" , Type = "FullTime", HiringDate =  DateTime.Now , Salary = 15000 , ImagePath = "abou.jpg"},
        new (){Id=2 , Name = "Omar Derbala" , Type = "FullTime", HiringDate =  new(year: 2022 , month: 11 , day : 17) , Salary = 18000},
        new (){Id=3 , Name = "Abdelrahman Essam" , Type = "PartTime", HiringDate =  new(year: 2023 , month: 11 , day : 17) , Salary = 11000},
        new (){Id=4 , Name = "Mohamed Osama" , Type = "FreeLancer", HiringDate =  new(year: 2024 , month: 7 , day : 17) , Salary = 25000},


        };
        public static List<Employee> GetAllEmployees() => _employees;
        public static Employee GetEmployee(int id) => _employees.FirstOrDefault(e=>e.Id ==id );



    }
}
