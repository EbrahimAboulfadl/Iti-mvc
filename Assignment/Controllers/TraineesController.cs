using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    public class TraineesController : Controller
    {
        AppDbContext context = new AppDbContext();
        public IActionResult Index()
        {
       
                List<Trainee> trainees = context.Trainees.Include(x=>x.Department).ToList();

                return View(trainees);
           
        }

        public IActionResult GetTrainee(int id)
        {
            Trainee trainee;
            trainee = context.Trainees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            

            if (trainee != null)
            {
                return View("GetTrainee", trainee);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
        }
        public IActionResult NewTrainee() {

            ViewData["departments"] = context.Departments.Select(x=>new DepartmentSelectionViewModel() {DepartmentId=x.Id,DepartmentName=x.Name}).ToList();
            return View();
        }
        public IActionResult SaveNewTrainee(Trainee trainee) {
        context.Trainees.Add(trainee);
        context.SaveChanges();
        return RedirectToAction("Index");     
        }
        public IActionResult EditTrainee(int id)
        {
            Trainee trainee = context.Trainees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            ViewData["departments"] = context.Departments.Select(x => new DepartmentSelectionViewModel() { DepartmentId = x.Id, DepartmentName = x.Name }).ToList();


            if (trainee != null)
            {

                return View(trainee);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
        }

        [HttpPost]
        public IActionResult SaveTrainee(int id, Trainee trainee)
        {

            Trainee oldTrainee = context.Trainees.Find(id);
            if (oldTrainee != null)
            {
                oldTrainee.Name = trainee.Name;
                oldTrainee.DepartmentId = trainee.DepartmentId;
                oldTrainee.Address = trainee.Address;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View("Error", new ErrorViewModel());
            }

        }
        public IActionResult DeleteTrainee(int id)
        {
            Trainee traineeToDelete = context.Trainees.Find(id);
            if (traineeToDelete != null)
            {
                context.Trainees.Remove(traineeToDelete);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult AspGrade(int id)
        {
            
            CourseResult result;
            using (var context = new AppDbContext())
            {

                result = context.CourseResults.Include(x => x.Trainee).Include(x=>x.Course).FirstOrDefault(x=>x.TraineeId == id && x.CourseId==1);
            }
            if (result != null)
            {
            bool isSucceeded = result.Grade >= result.Course.MinGrade;
            TraineeGradeViewModel traineeGradeViewModel = new() {
                TraineeName = result.Trainee.Name,
                TraineeGrade = result.Grade,
                CourseName = result.Course.Name,
                Status = isSucceeded ? "succeeded" : "Failed",
                Color = isSucceeded ? "green" : "red"
            };
                return View("AspGrade", traineeGradeViewModel);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
        }
    }
}
