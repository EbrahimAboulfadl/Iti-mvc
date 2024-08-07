using Assignment.Models.Entities;
using System.Collections.Generic;

namespace Assignment.Repository
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetAll();
        public List<Trainee> TraineesWithDepartments();
        public Trainee GetById(int id);

        public void Edit(int id, Trainee item);
        public void Delete(int id);

        public void Add(Trainee item);
    }
}
