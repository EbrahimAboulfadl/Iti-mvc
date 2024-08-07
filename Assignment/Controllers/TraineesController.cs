using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.Repository;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Controllers
{
    [Authorize]
    public class TraineesController : Controller
    {
       ITraineeRepository traineeRepository;
       IDepartmentRepository departmentRepository;
        public TraineesController(ITraineeRepository _traineeRepository ,IDepartmentRepository _departmentRepository) { 
                traineeRepository = _traineeRepository;
            departmentRepository = _departmentRepository;
        }
        public IActionResult Index()
        {

                return View(traineeRepository.TraineesWithDepartments());
           
        }

        public IActionResult GetTrainee(int id)
        {
            Trainee trainee;
            trainee = traineeRepository.TraineesWithDepartments().FirstOrDefault(x => x.Id == id);
            

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

            ViewData["departments"] = departmentRepository.GetDepartmentSelectionViewModels();
            return View();
        }
        public IActionResult SaveNewTrainee(Trainee trainee) {
      

        traineeRepository.Add(trainee);
        return RedirectToAction("Index");     
        }
        public IActionResult EditTrainee(int id)
        {
            Trainee trainee = traineeRepository.TraineesWithDepartments().FirstOrDefault(x => x.Id == id);
            ViewData["departments"] = departmentRepository.GetDepartmentSelectionViewModels();


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

            
            try 
            {
                traineeRepository.Edit(id, trainee);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }

        }
        public IActionResult DeleteTrainee(int id)
        {

            try
            {
                traineeRepository.Delete(id);   
                return RedirectToAction("Index");

            }
            catch { 
                 return RedirectToAction("Index");

            }
        }


        //public IActionResult AspGrade(int id)
        //{
            
        //    CourseResult result;
        //    using (var context = new AppDbContext())
        //    {

        //        result = context.CourseResults.Include(x => x.Trainee).Include(x=>x.Course).FirstOrDefault(x=>x.TraineeId == id && x.CourseId==1);
        //    }
        //    if (result != null)
        //    {
        //    bool isSucceeded = result.Grade >= result.Course.MinGrade;
        //    TraineeGradeViewModel traineeGradeViewModel = new() {
        //        TraineeName = result.Trainee.Name,
        //        TraineeGrade = result.Grade,
        //        CourseName = result.Course.Name,
        //        Status = isSucceeded ? "succeeded" : "Failed",
        //        Color = isSucceeded ? "green" : "red"
        //    };
        //        return View("AspGrade", traineeGradeViewModel);
        //    }
        //    else
        //    {
        //        return View("Error", new ErrorViewModel());

        //    }
        //}
    }
}
