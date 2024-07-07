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
        public IActionResult Index()
        {
            using (var context = new AppDbContext())
            {

                List<Trainee> trainees = context.Trainees.Include(x=>x.Department).ToList();

                return View(trainees);
            }
        }

        public IActionResult GetTrainee(int id)
        {
            Trainee trainee;
            using (var context = new AppDbContext())
            {

                trainee = context.Trainees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            }

            if (trainee != null)
            {
                return View("GetTrainee", trainee);
            }
            else
            {
                return View("Error", new ErrorViewModel());

            }
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
