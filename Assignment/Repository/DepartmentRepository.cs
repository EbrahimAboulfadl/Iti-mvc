using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        readonly AppDbContext context;
        public DepartmentRepository(AppDbContext _context) {
            context = _context;
        }
        public void Add(Department department)
        {
            context.Add(department);
        }

        public void Delete(int id)
        {
            Department department = GetById(id);

            context.Departments.Remove(department); 
        }

        public void Edit(int id, Department newDepartment)
        {
            Department department = GetById(id);
            
            department.Name = newDepartment.Name;
            department.Manager = newDepartment.Manager;
            context.SaveChanges();

        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public List<DepartmentSelectionViewModel> GetDepartmentSelectionViewModels()
        {
           return context.Departments
            .Select(x =>
                    new DepartmentSelectionViewModel() { DepartmentName = x.Name, DepartmentId = x.Id }
                    ).ToList();
        }
    }
}
