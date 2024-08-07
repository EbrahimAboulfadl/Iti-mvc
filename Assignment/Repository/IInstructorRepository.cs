using Assignment.Models.Entities;
using System.Collections.Generic;

namespace Assignment.Repository
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAll();
        public List<Instructor> InstructorsWithDepartments();
        public Instructor GetById(int id);

        public void Edit(int id, Instructor item);
        public void Delete(int id);

        public void Add(Instructor item);
    }
}
