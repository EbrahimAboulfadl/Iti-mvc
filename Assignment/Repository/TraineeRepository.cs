using Assignment.Models;
using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Repository
{

    public class TraineeRepository : ITraineeRepository
    {
        AppDbContext context;

        public TraineeRepository(AppDbContext _context) { 
        context = _context;
        }
        public void Add(Trainee item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
           Trainee trainee =  GetById(id);
            context.Remove(trainee);
            context.SaveChanges();
        }

        public void Edit(int id, Trainee item)
        {
            Trainee trainee =  GetById (id);
            trainee.Address = item.Address;
            trainee.Name = item.Name;
            trainee.DepartmentId = item.DepartmentId;
            trainee.Image = item.Image;
            context.SaveChanges();
            
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees.ToList();

        }

        public Trainee GetById(int id)
        {
            return context.Trainees.FirstOrDefault(t => t.Id == id);
        }

        public List<Trainee> TraineesWithDepartments()
        {
           return  context.Trainees.Include(t => t.Department).ToList();
        }
    }
}
