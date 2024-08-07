using Assignment.Models;
using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        readonly AppDbContext context;

        public InstructorRepository(AppDbContext _context) {
        context = _context;
        }
        public void Add(Instructor item)
        {
            context.Instructors.Add(item);
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            Instructor instructor = GetById(id);
            context.Instructors.Remove(instructor);
            context.SaveChanges();
        }

        public void Edit(int id, Instructor item)
        {
            Instructor instructor = GetById(id);
            instructor.Address = item.Address;
            instructor.Name = item.Name;
            instructor.Salary = item.Salary;
            instructor.DepartmentId = item.DepartmentId;
            context.SaveChanges();

        }

        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return context.Instructors.FirstOrDefault(x => x.Id == id);

        }

        public List<Instructor> InstructorsWithDepartments()
        {
            return context.Instructors.Include(x=>x.Department).ToList();

        }
    }
}
