using Assignment.Models.Entities;
using Assignment.ViewModels;
using System.Collections.Generic;

namespace Assignment.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetById(int id);

        public List<DepartmentSelectionViewModel> GetDepartmentSelectionViewModels();

        public void Edit(int id, Department course);
        public void Delete(int id);

        public void Add(Department course);

    }
}
