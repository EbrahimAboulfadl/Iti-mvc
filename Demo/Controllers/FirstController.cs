using System;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class FirstController : Controller
    {
        string notAvailable = "notAvailable";
        string message = "hello world";

        public IActionResult Index()
        {
            return View();
        } 
        
        public ContentResult Welcome()
        {
            return new() { Content = "Hello From The Application"};
        }  public ViewResult GetView()
        {
            return new() { ViewName = "My First Page"};
        }
        public JsonResult GetJson() {
            var obj = new { Name = "Ebrahim Aboulfadl", PhoneNumber = "01014621673" };
            return new JsonResult(obj);
        }
        public IActionResult GetMix() {
            if (DateTime.Now.Day == 26) {

                return Content("Page Closed");
            }
            else
            
            {
                return View("My First Page");
            }
        }
    }
}
